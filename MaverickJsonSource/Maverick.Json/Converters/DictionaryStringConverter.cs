using System;
using System.Collections.Generic;
using Maverick.Json.Serialization;

namespace Maverick.Json.Converters
{
    internal class DictionaryStringConverter<TDictionary, TValue> : JsonConverter<TDictionary>, IJsonPopulateFeature
        where TDictionary : IDictionary<String, TValue>
    {
        public Boolean Copy( Object source, Object target )
        {
            var source_ = (TDictionary)source;
            var target_ = (TDictionary)target;

            target_.Clear();

            foreach ( var item in source_ )
            {
                target_.Add( item );
            }

            return true;
        }


        public Boolean Populate( JsonReader reader, Object target )
        {
            var target_ = (TDictionary)target;

            reader.ReadStartObject();

            while ( reader.Peek() == JsonToken.PropertyName )
            {
                var propertyName = reader.ReadPropertyName();
                var value = reader.ReadValue<TValue>();

                target_[ propertyName ] = value;
            }

            reader.ReadEndObject();

            return true;
        }


        public override TDictionary Read( JsonReader reader, Type objectType )
        {
            var builder = new CollectionBuilder<TDictionary, KeyValuePair<String, TValue>>();

            reader.ReadStartObject();

            while ( reader.Peek() == JsonToken.PropertyName )
            {
                var propertyName = reader.ReadPropertyName();
                var value = reader.ReadValue<TValue>();

                builder.Add( new KeyValuePair<String, TValue>( propertyName, value ) );
            }

            reader.ReadEndObject();

            return builder.ToCollection();
        }


        public override void Write( JsonWriter writer, TDictionary value )
        {
            writer.WriteStartObject();

            foreach ( var item in value )
            {
                writer.WritePropertyName( item.Key );
                writer.WriteValue( item.Value );
            }

            writer.WriteEndObject();
        }
    }
}
