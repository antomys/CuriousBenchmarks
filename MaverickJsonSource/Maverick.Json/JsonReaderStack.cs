using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    /// <summary>
    /// Stack implementation for storing StartObject or StartArray tokens. Each token
    /// is encoded as a single bit allowing us to store 128 tokens without allocating. At the moment we don't support
    /// more and the implementation will throw after that.
    /// </summary>
    [DebuggerDisplay( "Depth = {Depth}" )]
    internal unsafe struct JsonReaderStack
    {
        public const Int32 MaxDepth = 128;


        public Int32 Depth => m_depth;


        public JsonToken Current
        {
            get
            {
                var depth = m_depth;

                if ( depth == 0 )
                    return JsonToken.None;

                var mask = 1 << GetIndex( depth );

                if ( ( GetByte( depth ) & mask ) == mask )
                    return JsonToken.StartObject;

                return JsonToken.StartArray;
            }
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public void PushStartObject()
        {
            if ( m_depth == MaxDepth )
                ThrowMaxDepthReached();

            var depth = ++m_depth;
            Set( ref GetByte( depth ), GetIndex( depth ) );
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public void PushStartArray()
        {
            if ( m_depth == MaxDepth )
                ThrowMaxDepthReached();

            var depth = ++m_depth;
            Clear( ref GetByte( depth ), GetIndex( depth ) );
        }


        public void Pop() => --m_depth;


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private ref Byte GetByte( Int32 depth ) => ref m_container[ ( depth - 1 ) / 8 ];


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private static Int32 GetIndex( Int32 depth ) => ( depth - 1 ) % 8;


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private static void Clear( ref Byte b, Int32 position ) => b &= (Byte)~( 1 << position );


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private static void Set( ref Byte b, Int32 position ) => b |= (Byte)( 1 << position );


        [MethodImpl( MethodImplOptions.NoInlining )]
        private static void ThrowMaxDepthReached() => throw new JsonSerializationException( $"Max object depth of {MaxDepth} has been reached." );


        private fixed Byte m_container[ MaxDepth / 8 ];
        private Int32 m_depth;
    }
}
