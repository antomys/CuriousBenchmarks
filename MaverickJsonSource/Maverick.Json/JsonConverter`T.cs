using System;

namespace Maverick.Json
{
    public abstract class JsonConverter<T> : JsonConverter
    {
        public override Boolean CanConvert( Type type ) => typeof( T ).IsAssignableFrom( type );


        public override sealed void WriteObject( JsonWriter writer, Object value ) => Write( writer, (T)value );


        public override sealed Object ReadObject( JsonReader reader, Type objectType ) => Read( reader, objectType );


        public abstract void Write( JsonWriter writer, T value );


        public abstract T Read( JsonReader reader, Type objectType );
    }
}
