using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Maverick.Json.Serialization
{
    public class JsonProperty<TOwner, TProperty> : JsonProperty<TOwner>
    {
        private delegate TProperty Getter( TOwner target );
        private delegate void Setter( ref TOwner target, TProperty value );

        private static readonly Boolean IsValueType = typeof( TProperty ).IsValueType;


        public JsonProperty( JsonObjectContract<TOwner> parent, MemberInfo member ) : base( parent, member )
        {
            m_setter = CreateSetter( member );
            m_getter = ReflectionHelpers.CreateGetter<TOwner, TProperty, Getter>( member );

            if ( m_getter is not null )
            {
                ShouldSerialize = CreateShouldSerialize( member );
            }

            CanSetValue = m_setter is not null;
            CanGetValue = m_getter is not null;

            Debug.Assert( PropertyType == typeof( TProperty ) );
        }


        public override Boolean CanSetValue { get; }


        public override Boolean CanGetValue { get; }


        internal override Int32 MemorySize { get; } = Unsafe.SizeOf<TProperty>();


        internal override Object GetValue( TOwner owner ) => m_getter( owner );


        internal override Object GetValue( ref JsonPropertyValues<TOwner> propertyValues ) => propertyValues.GetValue( this );


        protected internal override void WriteValue( JsonWriter writer, TOwner owner )
        {
            if ( ShouldSerialize is not null && !ShouldSerialize( owner ) )
            {
                return;
            }

            var value = m_getter( owner );

            if ( value is null && !SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( Name );

            if ( Converter is not null )
            {
                // Try to avoid boxing if possible
                if ( IsValueType && Converter is JsonConverter<TProperty> valueConverter )
                {
                    valueConverter.Write( writer, value );
                }
                else
                {
                    Converter.WriteObject( writer, value );
                }
            }
            else
            {
                writer.WriteValue( value );
            }
        }


        internal override unsafe void ReadValue( JsonReader reader, ref TOwner target, bool targetCreated, ref JsonPropertyValues<TOwner> propertyValues )
        {
            TProperty value;

            if ( Converter is object )
            {
                // Try to avoid boxing if possible
                if ( IsValueType && Converter is JsonConverter<TProperty> valueConverter )
                {
                    value = valueConverter.Read( reader, NonNullablePropertyType );
                }
                else
                {
                    value = (TProperty)Converter.ReadObject( reader, NonNullablePropertyType );
                }
            }
            else
            {
                // If what we are trying to read is reference type with already created 
                if ( m_setter is null && targetCreated && Traits<TProperty>.IsPopulatable )
                {
                    var currentValue = m_getter( target );

                    if ( currentValue is not null )
                    {
                        reader.Populate( currentValue );
                        propertyValues.MarkAsPresent( this );

                        return;
                    }
                }

                value = reader.ReadValue<TProperty>();
            }

            if ( targetCreated && m_setter is not null )
            {
                m_setter( ref target, value );
                propertyValues.MarkAsPresent( this );
            }
            else
            {
                propertyValues.SetValue( this, value );
            }
        }


        internal override void SetValue( ref TOwner target, ref JsonPropertyValues<TOwner> propertyValues )
        {
            m_setter( ref target, propertyValues.GetValue( this ) );
        }


        internal override void SetValue( ref TOwner target, Object value ) => m_setter( ref target, (TProperty)value );


        internal override Boolean ValueEquals( Object left, Object right ) => EqualityComparer<TProperty>.Default.Equals( (TProperty)left, (TProperty)right );


        private static Setter CreateSetter( MemberInfo member )
        {
            switch ( member )
            {
                case FieldInfo f when f.IsInitOnly:
                case PropertyInfo p when p.GetSetMethod( nonPublic: true ) is null:
                    return null;
            }

            var dynamicMethod = new DynamicMethod( name: "Set" + member.Name,
                                                   returnType: null,
                                                   parameterTypes: new Type[] { typeof( TOwner ).MakeByRefType(), typeof( TProperty ) },
                                                   owner: typeof( ReflectionHelpers ),
                                                   skipVisibility: true );

            dynamicMethod.DefineParameter( 0, ParameterAttributes.None, "target" );
            dynamicMethod.DefineParameter( 1, ParameterAttributes.None, "value" );

            var il = dynamicMethod.GetILGenerator();
            il.Emit( OpCodes.Ldarg_0 );

            if ( typeof( TOwner ).IsClass )
                il.Emit( OpCodes.Ldind_Ref );

            il.Emit( OpCodes.Ldarg_1 );

            if ( member is FieldInfo field ) il.Emit( OpCodes.Stfld, field );
            else
            {
                var method = ( (PropertyInfo)member ).GetSetMethod( nonPublic: true );

                il.Emit( method.IsFinal || !method.IsVirtual ? OpCodes.Call : OpCodes.Callvirt, method );
            }

            il.Emit( OpCodes.Ret );

            return (Setter)dynamicMethod.CreateDelegate( typeof( Setter ) );
        }


        private static Predicate<TOwner> CreateShouldSerialize( MemberInfo member )
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = typeof( TOwner ).GetMethod( "ShouldSerialize" + member.Name, flags, null, Type.EmptyTypes, null );

            if ( method is not null && method.ReturnType == typeof( Boolean ) )
            {
                return (Predicate<TOwner>)method.CreateDelegate( typeof( Predicate<TOwner> ) );
            }

            return null;
        }


        private readonly Getter m_getter;
        private readonly Setter m_setter;
    }
}
