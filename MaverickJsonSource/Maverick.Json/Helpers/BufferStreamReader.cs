using System;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Maverick.Json
{
    internal sealed class BufferStreamReader : IDisposable
    {
        public BufferStreamReader( Int32 blockSize ) : this( blockSize, ArrayPool<Byte>.Shared )
        {
        }


        public BufferStreamReader( Int32 blockSize, ArrayPool<Byte> arrayPool )
        {
            m_buffer = new JsonBufferWriter( blockSize, arrayPool );
        }


        public ReadOnlySequence<Byte> Sequence => m_buffer.Sequence;


        public async Task ReadAsync( Stream stream )
        {
            while ( true )
            {
                MemoryMarshal.TryGetArray<Byte>( m_buffer.GetMemory(), out var segment );

                var bytesRead = await stream.ReadAsync( segment.Array, segment.Offset, segment.Count );

                if ( bytesRead == 0 )
                {
                    break;
                }

                m_buffer.Advance( bytesRead );
            }
        }


        public void Dispose() => m_buffer.Dispose();


        private readonly JsonBufferWriter m_buffer;
    }
}
