using System;
using Maverick.Json.Serialization;

namespace Maverick.Json.Converters
{
    internal sealed class Array1Converter<T> : JsonConverter<T[]>, IJsonPopulateFeature
    {
        public Boolean Copy( Object source, Object target )
        {
            var source_ = (T[])source;
            var target_ = (T[])target;

            if ( source_.Length == target_.Length )
            {
                source_.CopyTo( target_, 0 );

                return true;
            }

            return false;
        }


        public Boolean Populate( JsonReader reader, Object target )
        {
            reader.ReadStartArray();

            var array = (T[])target;
            var index = 0;

            Array.Clear( array, 0, array.Length );

            while ( reader.Peek() != JsonToken.EndArray )
            {
                array[ index++ ] = reader.ReadValue<T>();
            }

            reader.ReadEndArray();

            return true;
        }


        public override T[] Read( JsonReader reader, Type objectType )
        {
            reader.ReadStartArray();

            // Check for empty array before continuing
            if ( reader.Peek() == JsonToken.EndArray )
            {
                reader.ReadEndArray();

                return Array.Empty<T>();
            }

            var buffer = new ArrayBuilder<T>( 4 );

            do
            {
                buffer.Add( reader.ReadValue<T>() );
            }
            while ( reader.Peek() != JsonToken.EndArray );

            reader.ReadEndArray();

            return buffer.ToArray();
        }


        public override void Write( JsonWriter writer, T[] array )
        {
            writer.WriteStartArray();

            for ( var i = 0; i < array.Length; ++i )
            {
                writer.WriteValue( array[ i ] );
            }

            writer.WriteEndArray();
        }
    }
}
