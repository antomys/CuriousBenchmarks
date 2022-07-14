using System;

namespace Maverick.Json.Converters
{
    internal sealed class Array2Converter<T> : JsonConverter<T[,]>
    {
        public override T[,] Read( JsonReader reader, Type objectType )
        {
            reader.ReadStartArray();

            var buffer = new ArrayBuilder<ArrayBuilder<T>>( 4 );
            var innerLength = 0;

            while ( reader.Peek() != JsonToken.EndArray )
            {
                reader.ReadStartArray();

                var innerArray = new ArrayBuilder<T>( innerLength == 0 ? 4 : innerLength );

                while ( reader.Peek() != JsonToken.EndArray )
                {
                    innerArray.Add( reader.ReadValue<T>() );
                }

                reader.ReadEndArray();

                if ( innerLength != 0 && innerLength != innerArray.Count )
                {
                    throw new JsonSerializationException( $"Unexpected 2nd dimension array size of {innerArray.Count}. Expected size is {innerLength}." );
                }

                innerLength = innerArray.Count;
                buffer.Add( innerArray );
            }

            reader.ReadEndArray();

            var result = new T[ buffer.Count, innerLength ];

            for ( var i0 = 0; i0 < buffer.Count; i0++ )
            {
                for ( var i1 = 0; i1 < innerLength; i1++ )
                {
                    result[ i0, i1 ] = buffer.Buffer[ i0 ].Buffer[ i1 ];
                }
            }

            return result;
        }


        public override void Write( JsonWriter writer, T[,] array )
        {
            var dim0end = array.GetUpperBound( 0 );

            var dim1start = array.GetLowerBound( 1 );
            var dim1end = array.GetUpperBound( 1 );

            writer.WriteStartArray();

            for ( var i0 = array.GetLowerBound( 0 ); i0 <= dim0end; ++i0 )
            {
                writer.WriteStartArray();

                for ( var i1 = dim1start; i1 <= dim1end; ++i1 )
                {
                    writer.WriteValue( array[ i0, i1 ] );
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}
