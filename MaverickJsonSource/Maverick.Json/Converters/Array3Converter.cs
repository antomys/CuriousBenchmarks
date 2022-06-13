using System;

namespace Maverick.Json.Converters
{
    internal sealed class Array3Converter<T> : JsonConverter<T[,,]>
    {
        public override T[,,] Read( JsonReader reader, Type objectType )
        {
            reader.ReadStartArray();

            var buffer = new ArrayBuilder<ArrayBuilder<ArrayBuilder<T>>>( 4 );
            var innerLength = 0;
            var innerInnerLength = 0;

            while ( reader.Peek() != JsonToken.EndArray )
            {
                reader.ReadStartArray();

                var innerArray = new ArrayBuilder<ArrayBuilder<T>>( innerLength == 0 ? 4 : innerLength );

                while ( reader.Peek() != JsonToken.EndArray )
                {
                    reader.ReadStartArray();

                    var innerInnerArray = new ArrayBuilder<T>( innerInnerLength == 0 ? 4 : innerInnerLength );

                    while ( reader.Peek() != JsonToken.EndArray )
                    {
                        innerInnerArray.Add( reader.ReadValue<T>() );
                    }

                    reader.ReadEndArray();

                    if ( innerInnerLength != 0 && innerInnerLength != innerInnerArray.Count )
                    {
                        throw new JsonSerializationException( $"Unexpected 3rd dimension array size of {innerInnerArray.Count}. Expected size is {innerInnerLength}." );
                    }

                    innerInnerLength = innerInnerArray.Count;
                    innerArray.Add( innerInnerArray );
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

            var result = new T[ buffer.Count, innerLength, innerInnerLength ];

            for ( var i0 = 0; i0 < buffer.Count; i0++ )
            {
                for ( var i1 = 0; i1 < innerLength; i1++ )
                {
                    for ( var i2 = 0; i2 < innerLength; i2++ )
                    {
                        result[ i0, i1, i2 ] = buffer.Buffer[ i0 ].Buffer[ i1 ].Buffer[ i2 ];
                    }
                }
            }

            return result;
        }


        public override void Write( JsonWriter writer, T[,,] array )
        {
            var dim0end = array.GetUpperBound( 0 );

            var dim1start = array.GetLowerBound( 1 );
            var dim1end = array.GetUpperBound( 1 );

            var dim2start = array.GetLowerBound( 2 );
            var dim2end = array.GetUpperBound( 2 );

            writer.WriteStartArray();

            for ( var i0 = 0; i0 <= dim0end; ++i0 )
            {
                writer.WriteStartArray();

                for ( var i1 = dim1start; i1 <= dim1end; ++i1 )
                {
                    writer.WriteStartArray();

                    for ( var i2 = dim2start; i2 <= dim2end; ++i2 )
                    {
                        writer.WriteValue( array[ i0, i1, i2 ] );
                    }

                    writer.WriteEndArray();
                }

                writer.WriteEndArray();
            }

            writer.WriteEndArray();
        }
    }
}
