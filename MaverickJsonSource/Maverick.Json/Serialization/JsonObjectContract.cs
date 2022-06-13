using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonObjectContract : JsonContract
    {
        public static JsonObjectContract Instance { get; } = new JsonObjectContract();


        private JsonObjectContract() : base( typeof( Object ) )
        {
            Freeze();
        }


        public override void WriteValue( JsonWriter writer, Object value )
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }


        public override Object ReadValue( JsonReader reader, Type objectType )
        {
            switch ( reader.Peek() )
            {
                case JsonToken.StartObject:
                    return reader.ReadValue<Dictionary<String, Object>>();

                case JsonToken.StartArray:
                    return reader.ReadValue<List<Object>>();

                case JsonToken.Number:
                    return reader.ReadDouble();

                case JsonToken.String:
                    return reader.ReadString();

                case JsonToken.Boolean:
                    return reader.ReadBoolean();

                case JsonToken.Null:
                    return reader.ReadNull();
            }

            throw new JsonSerializationException( $"Unexpected token {reader.Peek()} detected while trying to read a value." );
        }
    }
}
