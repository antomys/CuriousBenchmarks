using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Maverick.Json.Serialization;

namespace Maverick.Json
{
    [ExcludeFromCodeCoverage]
    internal static partial class ObjectConstructor
    {
        internal static JsonConstructor<T> Find<T>( JsonObjectContract<T> contract )
        {
            var ctors = typeof( T ).GetConstructors( BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
            var preferredCtor = ctors.FirstOrDefault( x => x.GetCustomAttribute<JsonConstructorAttribute>() != null );

            // When the preferred constructor is declared, do not try to lookup other constructors
            if ( preferredCtor != null )
            {
                if ( !TryCreate( contract, preferredCtor, out var factory ) )
                {
                    T ctor( ref JsonPropertyValues<T> propertyValues )
                    {
                        throw new JsonSerializationException( "The object cannot be created using the preferred constructor because some of the parameters do not exist as properties." );
                    }

                    return new JsonConstructor<T>( ctor, null );
                }

                return factory;
            }

            // Evaluate constructors by starting of with the constructor
            // with the most parameters that all can be matched
            foreach ( var ctor in ctors.OrderByDescending( x => x.GetParameters().Length ) )
            {
                if ( TryCreate( contract, ctor, out var factory ) )
                {
                    return factory;
                }
            }

            if ( typeof( T ).IsValueType )
            {
                // The default constructor of a struct will not be available through reflection
                return new JsonConstructor<T>( ( ref JsonPropertyValues<T> propertyValues ) => default, null );
            }

            return null;
        }


        private static Boolean TryCreate<T>( JsonObjectContract<T> contract, ConstructorInfo ctor, out JsonConstructor<T> factory )
        {
            var parameters = ctor.GetParameters();
            factory = null;

            if ( parameters.Length < 100 )
            {
                var properties = parameters.Select( x => contract.Properties.FindProperty( x ) ).ToArray();

                if ( properties.All( x => x != null ) )
                {
                    var types = new Type[ parameters.Length + 1 ];
                    var arguments = new Object[ parameters.Length + 1 ];

                    types[ 0 ] = typeof( T );
                    arguments[ 0 ] = ctor;

                    for ( var i = 0; i < parameters.Length; ++i )
                    {
                        types[ i + 1 ] = parameters[ i ].ParameterType;
                        arguments[ i + 1 ] = properties[ i ];
                    }

                    var @delegate = (JsonConstructorDelegate<T>)typeof( ObjectConstructor )
                       .GetMethods( BindingFlags.NonPublic | BindingFlags.Static )
                       .First( x => x.Name == "Create" && x.GetParameters().Length == properties.Length + 1 )
                       .MakeGenericMethod( types ).Invoke( null, arguments );

                    factory = new JsonConstructor<T>( @delegate, properties );
                }
            }

            return factory != null;
        }


        public static TDelegate CreateDelegate<TDelegate>( ConstructorInfo ctor ) where TDelegate : Delegate
        {
            var type = ctor.DeclaringType;
            var parameters = ctor.GetParameters();

            var method = new DynamicMethod( Guid.NewGuid().ToString( "N" ), type, parameters.Select( x => x.ParameterType ).ToArray(), ctor.Module, true );
            var il = method.GetILGenerator();

            for ( var i = 0; i < parameters.Length; ++i )
            {
                switch ( i )
                {
                    case 0: il.Emit( OpCodes.Ldarg_0 ); break;
                    case 1: il.Emit( OpCodes.Ldarg_1 ); break;
                    case 2: il.Emit( OpCodes.Ldarg_2 ); break;
                    case 3: il.Emit( OpCodes.Ldarg_3 ); break;
                    default: il.Emit( OpCodes.Ldarg, i ); break;
                }
            }

            il.Emit( OpCodes.Newobj, ctor );
            il.Emit( OpCodes.Ret );

            return (TDelegate)method.CreateDelegate( typeof( TDelegate ) );
        }


        [ExcludeFromCodeCoverage]
        private static JsonConstructorDelegate<TOwner> Create<TOwner>( ConstructorInfo ctorInfo )
        {
            var ctor = CreateDelegate<Func<TOwner>>( ctorInfo );

            return ( ref JsonPropertyValues<TOwner> propertyValues ) => ctor();
        }
    }
}
