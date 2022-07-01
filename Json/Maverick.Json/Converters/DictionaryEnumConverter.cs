using System;
using System.Collections.Generic;
using Maverick.Json.Serialization;

namespace Maverick.Json.Converters
{
    internal class DictionaryEnumConverter<TDictionary, TKey, TValue> : JsonConverter<TDictionary>, IJsonPopulateFeature
        where TDictionary : IDictionary<TKey, TValue>
        where TKey : unmanaged, Enum
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
                var key = EnumHelper<TKey>.FromPropertyName( propertyName );
                var value = reader.ReadValue<TValue>();

                target_[ key ] = value;
            }

            reader.ReadEndObject();

            return true;
        }


        public override TDictionary Read( JsonReader reader, Type objectType )
        {
            var builder = new CollectionBuilder<TDictionary, KeyValuePair<TKey, TValue>>();

            reader.ReadStartObject();

            while ( reader.Peek() == JsonToken.PropertyName )
            {
                var propertyName = reader.ReadPropertyName();
                var key = EnumHelper<TKey>.FromPropertyName( propertyName );
                var value = reader.ReadValue<TValue>();

                builder.Add( new KeyValuePair<TKey, TValue>( key, value ) );
            }

            reader.ReadEndObject();

            return builder.ToCollection();
        }


        public override void Write( JsonWriter writer, TDictionary value )
        {
            writer.WriteStartObject();

            foreach ( var item in value )
            {
                writer.WritePropertyName( EnumHelper<TKey>.ToPropertyName( item.Key ) );
                writer.WriteValue( item.Value );
            }

            writer.WriteEndObject();
        }
    }
}
