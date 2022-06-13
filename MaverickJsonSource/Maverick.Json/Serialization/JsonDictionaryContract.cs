using System;
using System.Collections.Generic;
using Maverick.Json.Converters;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonDictionaryContract : JsonContract, IJsonPopulateFeature
    {
        public static Boolean TryCreate( Type type, out JsonDictionaryContract contract )
        {
            // We only care about 2 types of dictionaries
            //    1. With string keys
            //    2. With enum keys
            // These types of dictionaries are serialized as objects instead of collections.
            if ( ReflectionHelpers.IsSubclassOfRawGeneric( type, typeof( IDictionary<,> ), out var arguments ) )
            {
                if ( arguments[ 0 ] == typeof( String ) || arguments[ 0 ].IsEnum )
                {
                    contract = new JsonDictionaryContract( type, arguments[ 0 ], arguments[ 1 ] );
                    return true;
                }
            }

            contract = null;
            return false;
        }


        private JsonDictionaryContract( Type dictionaryType, Type keyType, Type valueType ) : base( dictionaryType )
        {
            var keyValuePairType = typeof( KeyValuePair<,> ).MakeGenericType( keyType, valueType );
            var getEnumeratorMethod = ReflectionHelpers.FindGetEnumeratorMethod( dictionaryType, keyValuePairType );

            if ( getEnumeratorMethod != null )
            {
                var converterType = keyType.IsEnum ?
                    typeof( DictionaryEnumNonAllocatingConverter<,,,> ).MakeGenericType( dictionaryType, keyType, valueType, getEnumeratorMethod.ReturnType ) :
                    typeof( DictionaryStringNonAllocatingConverter<,,> ).MakeGenericType( dictionaryType, valueType, getEnumeratorMethod.ReturnType );

                m_converter = (JsonConverter)Activator.CreateInstance( converterType );
            }
            else
            {
                var converterType = keyType.IsEnum ?
                   typeof( DictionaryEnumConverter<,,> ).MakeGenericType( dictionaryType, keyType, valueType ) :
                   typeof( DictionaryStringConverter<,> ).MakeGenericType( dictionaryType, valueType );

                m_converter = (JsonConverter)Activator.CreateInstance( converterType );
            }
        }


        public override void WriteValue( JsonWriter writer, Object value ) => m_converter.WriteObject( writer, value );


        public override Object ReadValue( JsonReader reader, Type objectType ) => m_converter.ReadObject( reader, objectType );


        public Boolean Populate( JsonReader reader, Object target )
        {
            if ( m_converter is IJsonPopulateFeature feature )
            {
                return feature.Populate( reader, target );
            }

            return false;
        }


        public Boolean Copy( Object source, Object target )
        {
            if ( m_converter is IJsonPopulateFeature feature )
            {
                return feature.Copy( source, target );
            }

            return false;
        }


        private readonly JsonConverter m_converter;
    }
}
