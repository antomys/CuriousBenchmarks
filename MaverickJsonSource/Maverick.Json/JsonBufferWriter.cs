using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Maverick.Json
{
    public sealed class JsonBufferWriter : IBufferWriter<Byte>, IDisposable
    {
        public JsonBufferWriter() : this( 8192, ArrayPool<Byte>.Shared )
        {
        }


        public JsonBufferWriter(Int32 bufferSize ) : this( bufferSize, ArrayPool<Byte>.Shared )
        {
        }


        public JsonBufferWriter(Int32 bufferSize, ArrayPool<Byte> arrayPool )
        {
            m_arrayPool = arrayPool ?? throw new ArgumentNullException( nameof( arrayPool ) );
            m_current = new Segment( arrayPool.Rent( bufferSize ) );
            m_available = m_current.Buffer.Length;
        }


        /// <summary>
        /// Returns a sequence for the entire content of the current buffer.
        /// </summary>
        public ReadOnlySequence<Byte> Sequence
        {
            get
            {
                if ( m_current == null || ( m_current.Count == 0 && m_segments.Count == 0 ) )
                {
                    return ReadOnlySequence<Byte>.Empty;
                }

                if ( m_current.Count > 0 )
                {
                    m_current.UpdateReadOnlyMemory();

                    if ( m_segments.Count > 0 )
                    {
                        m_current.UpdateRunningIndex( m_segments[ m_segments.Count - 1 ] );
                    }
                }

                var first = m_segments.Count > 0 ? m_segments[ 0 ] : m_current;
                var last = m_current.Count > 0 ? m_current : m_segments[ m_segments.Count - 1 ];

                return new ReadOnlySequence<Byte>( first, 0, last, last.Count );
            }
        }


        public void Dispose()
        {
            if ( m_current != null )
            {
                m_current.Dispose( m_arrayPool );
                m_current = null;

                foreach ( var segment in m_segments )
                {
                    segment.Dispose( m_arrayPool );
                }

                m_segments.Clear();
                m_available = 0;
            }
        }


        public Byte[] ToArray()
        {

            CheckNotDisposed();

            return Sequence.ToArray();
        }


        public void Advance( Int32 count )
        {
            CheckNotDisposed();

            if ( count > m_available )
            {
                throw new ArgumentOutOfRangeException( nameof( count ) );
            }

            m_current.Count += count;
            m_available -= count;
        }


        public Memory<Byte> GetMemory( Int32 sizeHint = 0 )
        {
            CheckNotDisposed();

            if ( sizeHint > m_available || m_available == 0 )
            {
                Resize( sizeHint );
            }

            return m_current.Buffer.AsMemory( m_current.Count );
        }


        public Span<Byte> GetSpan( Int32 sizeHint = 0 )
        {
            CheckNotDisposed();

            if ( sizeHint > m_available || m_available == 0 )
            {
                Resize( sizeHint );
            }

            return m_current.Buffer.AsSpan( m_current.Count );
        }


        public void CopyTo( Stream stream )
        {
            CheckNotDisposed();

            foreach ( var segment in m_segments )
            {
                stream.Write( segment.Buffer, 0, segment.Count );
            }

            if ( m_current.Count > 0 )
            {
                stream.Write( m_current.Buffer, 0, m_current.Count );
            }
        }


        public async Task CopyToAsync( Stream stream )
        {
            CheckNotDisposed();

            foreach ( var segment in m_segments )
            {
                await stream.WriteAsync( segment.Buffer, 0, segment.Count );
            }

            if ( m_current.Count > 0 )
            {
                await stream.WriteAsync( m_current.Buffer, 0, m_current.Count );
            }
        }


        public unsafe void Write( String json )
        {
            CheckNotDisposed();

            if ( json is null )
            {
                throw new ArgumentNullException( nameof( json ) );
            }
            if ( json.Length == 0 )
            {
                return;
            }

            var encoder = Constants.Encoding.GetEncoder();
            var chars = json.AsSpan();

            while ( true )
            {
                var span = GetSpan( 6 );

                fixed ( Char* fixedChars = chars )
                fixed ( Byte* fixedBytes = span )
                {
                    encoder.Convert( chars: fixedChars,
                                     charCount: chars.Length,
                                     bytes: fixedBytes,
                                     byteCount: span.Length,
                                     flush: true,
                                     out var charsUsed,
                                     out var bytesUsed,
                                     out var completed );
                    Advance( bytesUsed );

                    if ( completed )
                    {
                        break;
                    }

                    chars = chars.Slice( charsUsed );
                }
            }
        }


        private void Resize( Int32 minimumSize )
        {
            var newBuffer = m_arrayPool.Rent( Math.Max( m_current.Buffer.Length, minimumSize ) );

            if ( m_current.Count == 0 )
            {
                // Nothing has been written, we are just going to return the buffer
                m_arrayPool.Return( m_current.Buffer );
                m_current.Buffer = newBuffer;
            }
            else
            {
                // Store the current buffer
                if ( m_segments.Count > 0 )
                {
                    m_current.UpdateRunningIndex( m_segments[ m_segments.Count - 1 ] );
                }

                m_current.UpdateReadOnlyMemory();
                m_segments.Add( m_current );

                // Assign a new segment for the newly acquired buffer
                m_current = new Segment( newBuffer );
            }

            m_available = newBuffer.Length;
        }


        /// <summary>
        /// Returns the bytes written as a string.
        /// </summary>
        public override String ToString() => Constants.Encoding.GetString( Sequence );


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void CheckNotDisposed()
        {
            if ( m_current == null )
            {
                ThrowHelper.ThrowObjectDisposed( nameof( JsonBufferWriter ) );
            }
        }


        private Segment m_current;
        private Int32 m_available;

        private readonly ArrayPool<Byte> m_arrayPool;
        private readonly List<Segment> m_segments = new List<Segment>();


        private sealed class Segment : ReadOnlySequenceSegment<Byte>
        {
            public Segment( Byte[] buffer )
            {
                Buffer = buffer;
            }


            public Byte[] Buffer { get; set; }
            public Int32 Count { get; set; }


            public void UpdateReadOnlyMemory()
            {
                Debug.Assert( Next == null );

                Memory = new ReadOnlyMemory<Byte>( Buffer, 0, Count );
            }


            public void UpdateRunningIndex( Segment previous )
            {
                previous.Next = this;
                RunningIndex = previous.RunningIndex + previous.Count;
            }


            public void Dispose( ArrayPool<Byte> arrayPool )
            {
                arrayPool.Return( Buffer );

                Buffer = null;
                Next = null;
                Memory = default;
                RunningIndex = 0;
            }
        }
    }
}
