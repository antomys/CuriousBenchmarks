using System;
using System.Runtime.CompilerServices;

namespace Maverick.Json.Converters
{
    /// <summary>
    /// Serializes Byte[] as JSON array instead of the default base64 string.
    /// </summary>
    public sealed class ByteArrayConverter : JsonConverter<Byte[]>
    {
        public override Byte[] Read( JsonReader reader, Type objectType )
        {
            reader.ReadStartArray();

            Span<Byte> buffer = stackalloc Byte[ 128 ];
            var builder = new ArrayBuilder( buffer );

            while ( reader.Peek() != JsonToken.EndArray )
            {
                builder.Add( reader.ReadByte() );
            }

            reader.ReadEndArray();

            return builder.ToArray();
        }


        public override void Write( JsonWriter writer, Byte[] value )
        {
            writer.WriteStartArray();

            foreach ( var @byte in value )
            {
                writer.WriteValue( @byte );
            }

            writer.WriteEndArray();
        }


        private ref struct ArrayBuilder
        {
            public ArrayBuilder( Span<Byte> bytes )
            {
                m_span = bytes;
                m_spanCount = 0;

                m_array = null;
                m_arrayCount = 0;
            }


            [MethodImpl( MethodImplOptions.AggressiveInlining )]
            public void Add( Byte value )
            {
                if ( m_spanCount < m_span.Length )
                {
                    m_span[ m_spanCount++ ] = value;
                }
                else
                {
                    if ( m_array == null )
                    {
                        m_array = new Byte[ m_spanCount ];
                    }
                    else if ( m_arrayCount == m_array.Length )
                    {
                        Array.Resize( ref m_array, m_arrayCount * 2 );
                    }

                    m_array[ m_arrayCount++ ] = value;
                }
            }


            [MethodImpl( MethodImplOptions.AggressiveInlining )]
            public Byte[] ToArray()
            {
                if ( m_spanCount == 0 )
                {
                    return Array.Empty<Byte>();
                }
                else if ( m_arrayCount == 0 )
                {
                    return m_span.Slice( 0, m_spanCount ).ToArray();
                }

                var result = new Byte[ m_spanCount + m_arrayCount ];

                m_span.CopyTo( result );
                m_array.AsSpan( 0, m_arrayCount ).CopyTo( result.AsSpan( m_spanCount, m_arrayCount ) );

                return result;
            }


            private Span<Byte> m_span;
            private Int32 m_spanCount;

            private Byte[] m_array;
            private Int32 m_arrayCount;
        }
    }
}
