using System;
using System.Buffers;
using System.IO;

namespace Maverick.Json
{
    public sealed class JsonStreamWriter : IBufferWriter<Byte>, IDisposable
    {
        public JsonStreamWriter( Stream stream ) : this( stream, 4096, ArrayPool<Byte>.Shared )
        {
        }


        public JsonStreamWriter( Stream stream, Int32 bufferSize ) : this( stream, bufferSize, ArrayPool<Byte>.Shared )
        {
        }


        public JsonStreamWriter( Stream stream, Int32 bufferSize, ArrayPool<Byte> arrayPool )
        {
            m_arrayPool = arrayPool ?? throw new ArgumentNullException( nameof( arrayPool ) );
            m_stream = stream ?? throw new ArgumentNullException( nameof( stream ) );
            m_buffer = arrayPool.Rent( bufferSize );
            m_available = m_buffer.Length;
        }


        public void Dispose()
        {
            if ( m_buffer != null )
            {
                if ( m_offset > 0 )
                {
                    m_stream.Write( m_buffer, 0, m_offset );
                }

                m_arrayPool.Return( m_buffer );

                m_buffer = null;
                m_stream = null;
            }
        }


        public void Advance( Int32 count )
        {
            if ( count > m_available )
            {
                throw new ArgumentOutOfRangeException( nameof( count ) );
            }

            m_offset += count;
            m_available -= count;
        }


        public Memory<Byte> GetMemory( Int32 sizeHint )
        {
        Retry:
            if ( sizeHint > m_available || m_available == 0 )
            {
                if ( m_offset > 0 )
                {
                    // Copy the current buffer to the stream
                    m_stream.Write( m_buffer, 0, m_offset );
                    m_available = m_buffer.Length;
                    m_offset = 0;

                    goto Retry;
                }

                // The current buffer is too small
                m_arrayPool.Return( m_buffer );

                m_buffer = m_arrayPool.Rent( sizeHint );
                m_available = m_buffer.Length;
            }

            return m_buffer.AsMemory( m_offset );
        }


        public Span<Byte> GetSpan( Int32 sizeHint )
        {
        Retry:
            if ( sizeHint > m_available || m_available == 0 )
            {
                if ( m_offset > 0 )
                {
                    // Copy the current buffer to the stream
                    m_stream.Write( m_buffer, 0, m_offset );
                    m_available = m_buffer.Length;
                    m_offset = 0;

                    goto Retry;
                }

                // The current buffer is too small
                m_arrayPool.Return( m_buffer );

                m_buffer = m_arrayPool.Rent( sizeHint );
                m_available = m_buffer.Length;
            }

            return m_buffer.AsSpan( m_offset );
        }


        private readonly ArrayPool<Byte> m_arrayPool;
        private Stream m_stream;

        private Byte[] m_buffer;
        private Int32 m_offset;
        private Int32 m_available;
    }
}
