using System;
using System.Collections;
using System.Collections.Generic;
using Maverick.Json.Converters;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonCollectionContract<TCollection> : JsonContract, IJsonPopulateFeature
    {
        public static Boolean TryCreate( out JsonCollectionContract<TCollection> contract )
        {
            var type = typeof( TCollection );

            if ( ReflectionHelpers.IsSubclassOfRawGeneric( type, typeof( IEnumerable<> ), out var genericArguments ) )
            {
                contract = new JsonCollectionContract<TCollection>( genericArguments[ 0 ] );
                return true;
            }
            else if ( typeof( IEnumerable ).IsAssignableFrom( type ) )
            {
                contract = new JsonCollectionContract<TCollection>();
                return true;
            }

            contract = null;
            return false;
        }


        private JsonCollectionContract() : base( typeof( TCollection ) )
        {
            m_converter = new CollectionConverter<TCollection>();
        }


        private JsonCollectionContract( Type itemType ) : base( typeof( TCollection ) )
        {
            var collectionType = typeof( TCollection );
            var getEnumeratorMethod = ReflectionHelpers.FindGetEnumeratorMethod( collectionType, itemType );

            if ( getEnumeratorMethod != null && getEnumeratorMethod.ReturnType.IsValueType )
            {
                // The collection has non allocating enumerator
                m_converter = (JsonConverter)Activator.CreateInstance(
                    typeof( CollectionNonAllocatingConverter<,,> ).MakeGenericType( collectionType, itemType, getEnumeratorMethod.ReturnType ) );
            }
            else
            {
                m_converter = (JsonConverter)Activator.CreateInstance( typeof( CollectionConverter<,> ).MakeGenericType( collectionType, itemType ) );
            }
        }


        public override void WriteValue( JsonWriter writer, Object value ) => m_converter.WriteObject( writer, value );


        public override Object ReadValue( JsonReader reader, Type objectType ) => m_converter.ReadObject( reader, objectType );


        Boolean IJsonPopulateFeature.Populate( JsonReader reader, Object target )
        {
            if ( m_converter is IJsonPopulateFeature feature )
            {
                return feature.Populate( reader, target );
            }

            return false;
        }


        Boolean IJsonPopulateFeature.Copy( Object source, Object target )
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
