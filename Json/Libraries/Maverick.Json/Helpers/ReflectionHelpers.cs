using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal static class ReflectionHelpers
    {
        public static Boolean IsSubclassOfRawGeneric( Type target, Type definition, out Type[] arguments )
        {
            if ( definition.IsInterface )
            {
                // Make sure that we check the provided target as well
                if ( target.IsInterface && target.IsGenericType && target.GetGenericTypeDefinition() == definition )
                {
                    arguments = target.GetGenericArguments();
                    return true;
                }

                foreach ( var interfaceType in target.GetInterfaces() )
                {
                    if ( interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == definition )
                    {
                        arguments = interfaceType.GetGenericArguments();
                        return true;
                    }
                }
            }
            else
            {
                while ( target != null && target != typeof( Object ) )
                {
                    var current = target.IsGenericType ? target.GetGenericTypeDefinition() : target;

                    if ( definition == current )
                    {
                        arguments = target.GetGenericArguments();
                        return true;
                    }

                    target = target.BaseType;
                }
            }

            arguments = null;
            return false;
        }


        public static Boolean IsVirtual( this PropertyInfo property ) =>
            property.GetGetMethod( true )?.IsVirtual ?? property.GetSetMethod( true )?.IsVirtual ?? false;


        public static Boolean IsPublic( PropertyInfo property ) =>
            property.GetGetMethod()?.IsPublic ?? property.GetSetMethod()?.IsPublic ?? false;


        public static MethodInfo FindGetEnumeratorMethod( Type collectionType, Type itemType )
        {
            return collectionType
                 .GetMethods( BindingFlags.Public | BindingFlags.Instance )
                 .Where( x => x.Name == "GetEnumerator"
                           && x.GetParameters().Length == 0
                           && x.ReturnType.IsValueType
                           && IsEnumerator( x.ReturnType ) )
                 .FirstOrDefault();

            Boolean IsEnumerator( Type type )
            {
                try
                {
                    var moveNext = type.GetMethod( "MoveNext" );
                    var current = type.GetProperty( "Current" );

                    return moveNext != null
                        && moveNext.GetParameters().Length == 0
                        && moveNext.ReturnType == typeof( Boolean )
                        && current != null
                        && current.PropertyType == itemType;
                }
                catch
                {
                }

                return false;
            }
        }


        public static Type GetFieldOrPropertyType( MemberInfo member )
        {
            switch ( member.MemberType )
            {
                case MemberTypes.Field:
                    return ( (FieldInfo)member ).FieldType;

                case MemberTypes.Property:
                    return ( (PropertyInfo)member ).PropertyType;
            }

            throw new ArgumentException( "The member must be of type FieldInfo or PropertyInfo.", nameof( member ) );
        }


        public static List<MemberInfo> GetFieldsAndProperties( Type type, Boolean includePrivate )
        {
            var members = new List<MemberInfo>();

            members.AddRange( GetFields( type, includePrivate ) );
            members.AddRange( GetProperties( type, includePrivate ) );

            return members;
        }


        private static List<FieldInfo> GetFields( Type targetType, Boolean includePrivate )
        {
            var flags = includePrivate ? BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance : BindingFlags.Public | BindingFlags.Instance;
            var fields = new List<FieldInfo>( targetType.GetFields( flags ) );

            // Inherited non public fields are not returned by default so we need to iterate base types
            if ( includePrivate )
            {
                var baseType = targetType.BaseType;

                while ( baseType != null )
                {
                    fields.AddRange( baseType.GetFields( BindingFlags.NonPublic | BindingFlags.Instance ).Where( x => x.IsPrivate/*filter out protected*/ ) );
                    baseType = baseType.BaseType;
                }
            }

            // Remove backing fields
            fields.RemoveAll( x => x.Name.Contains( "BackingField" ) && x.IsDefined( typeof( CompilerGeneratedAttribute ) ) );

            return fields;
        }


        private static List<PropertyInfo> GetProperties( Type targetType, Boolean includePrivate )
        {
            var flags = includePrivate ? BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance : BindingFlags.Public | BindingFlags.Instance;
            var properties = new List<PropertyInfo>( targetType.GetProperties( flags ) );

            // GetProperties on an interface doesn't return properties from its interfaces
            if ( targetType.IsInterface )
            {
                foreach ( var interfaceType in targetType.GetInterfaces() )
                {
                    properties.AddRange( interfaceType.GetProperties( flags ) );
                }
            }
            else
            {
                // Inherited non public properties are not returned by default so we need to iterate base types
                if ( includePrivate )
                {
                    var baseType = targetType.BaseType;

                    while ( baseType != null )
                    {
                        foreach ( var property in baseType.GetProperties( BindingFlags.NonPublic | BindingFlags.Instance ) )
                        {
                            if ( properties.FindIndex( x => x.Name == property.Name ) == -1 )
                            {
                                properties.Add( property );
                            }
                        }
                        baseType = baseType.BaseType;
                    }
                }

                // Inherited property can only be accessed if the PropertyInfo was acquired from the base class
                for ( var i = 0; i < properties.Count; i++ )
                {
                    var property = properties[ i ];

                    if ( property.DeclaringType != targetType && property.GetIndexParameters().Length == 0 )
                    {
                        properties[ i ] = property.DeclaringType.GetProperty( property.Name,
                                                                              BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                                                                              null,
                                                                              property.PropertyType,
                                                                              Type.EmptyTypes,
                                                                              null );
                    }
                }
            }

            // Remove any index property
            properties.RemoveAll( x => x.GetIndexParameters().Length > 0 );

            return properties;
        }


        public static TDelegate CreateGetter<TOwner, TProperty, TDelegate>( MemberInfo member ) where TDelegate : Delegate
        {
            var dynamicMethod = new DynamicMethod( "Get" + member.Name, typeof( TProperty ), new[] { typeof( TOwner ) }, typeof( ReflectionHelpers ), true );
            var generator = dynamicMethod.GetILGenerator();

            if ( typeof( TOwner ).IsValueType && member.MemberType == MemberTypes.Property )
            {
                // C# compiler emits this when the member owner type is struct and we are accessing a property
                generator.Emit( OpCodes.Ldarga_S, (Byte)0 );
            }
            else
            {
                generator.Emit( OpCodes.Ldarg_0 );
            }

            if ( member is PropertyInfo property )
            {
                var method = property.GetGetMethod( true );

                generator.Emit( method.IsFinal || !method.IsVirtual ? OpCodes.Call : OpCodes.Callvirt, method );
            }
            else
            {
                generator.Emit( OpCodes.Ldfld, (FieldInfo)member );
            }

            generator.Emit( OpCodes.Ret );

            return (TDelegate)dynamicMethod.CreateDelegate( typeof( TDelegate ) );
        }


        public static T GetAttribute<T>( Type type ) where T : Attribute
        {
            var attribute = type.GetCustomAttribute<T>( true );

            if ( attribute != null )
            {
                return attribute;
            }

            // Search interfaces
            foreach ( var interfaceType in type.GetInterfaces() )
            {
                attribute = interfaceType.GetCustomAttribute<T>( true );

                if ( attribute != null )
                {
                    return attribute;
                }
            }

            return null;
        }


        public static T GetAttribute<T>( MemberInfo member ) where T : Attribute
        {
            var attribute = member.GetCustomAttribute<T>( true );

            if ( attribute != null )
            {
                return attribute;
            }

            foreach ( var interfaceType in member.DeclaringType.GetInterfaces() )
            {
                var interfaceMember = SearchMemberInType( interfaceType, member );

                if ( interfaceMember != null )
                {
                    attribute = interfaceMember.GetCustomAttribute<T>( true );

                    if ( attribute != null )
                    {
                        return attribute;
                    }
                }
            }

            return null;
        }


        public static Action<TCollection, KeyValuePair<TKey, TValue>> GetDictionarySetMethod<TCollection, TKey, TValue>()
            where TCollection : IDictionary<TKey, TValue>
        {
            return ( collection, item ) => collection[ item.Key ] = item.Value;
        } 


        private static MemberInfo SearchMemberInType( Type targetType, MemberInfo member )
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            if ( member is PropertyInfo property )
            {
                return targetType.GetProperty( member.Name, flags, null, property.PropertyType, Type.EmptyTypes, null );
            }

            return targetType.GetMember( member.Name, member.MemberType, flags ).FirstOrDefault();
        }
    }
}
