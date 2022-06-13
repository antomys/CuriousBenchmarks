using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonDynamicContract : JsonContract, IJsonPopulateFeature
    {
        public static Boolean TryCreate( Type type, out JsonDynamicContract contract )
        {
            if ( typeof( ExpandoObject ).IsAssignableFrom( type ) )
            {
                contract = new JsonDynamicContract( type );
                return true;
            }

            contract = null;
            return false;
        }


        private JsonDynamicContract( Type underlyingType ) : base( underlyingType )
        {
        }


        public override void WriteValue( JsonWriter writer, Object value )
        {
            writer.WriteStartObject();

            foreach ( var item in (IEnumerable<KeyValuePair<String, Object>>)value )
            {
                writer.WritePropertyName( JsonPropertyName.GetOrCreate( item.Key ) );
                writer.WriteValue( item.Value );
            }

            writer.WriteEndObject();
        }


        public Boolean Copy( Object source, Object target )
        {
            var targetObject = (IDictionary<String, Object>)target;

            foreach ( var item in (IEnumerable<KeyValuePair<String, Object>>)source )
            {
                targetObject[ item.Key ] = item.Value;
            }

            return true;
        }


        public Boolean Populate( JsonReader reader, Object target )
        {
            if ( reader.Peek() == JsonToken.StartObject )
                reader.ReadStartObject();

            var targetObject = (IDictionary<String, Object>)target;

            while ( reader.Peek() != JsonToken.EndObject )
            {
                var propertyName = reader.ReadPropertyName();
                var value = reader.ReadValue( typeof( Object ) );

                targetObject[ propertyName ] = value;
            }

            reader.ReadEndObject();

            return true;
        }


        public override Object ReadValue( JsonReader reader, Type objectType )
        {
            var targetObject = (IDictionary<String, Object>)Activator.CreateInstance( objectType );
            Populate( reader, targetObject );

            return targetObject;
        }
    }
}
