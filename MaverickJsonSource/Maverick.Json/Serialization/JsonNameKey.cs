using System;
using System.Runtime.InteropServices;

namespace Maverick.Json.Serialization
{
    internal unsafe readonly struct JsonNameKey : IEquatable<JsonNameKey>
    {
        internal JsonNameKey( Byte* bytes, Int32 length )
        {
            Bytes = null;

            UnsafeBytes = bytes;
            Length = length;
        }


        internal JsonNameKey( ReadOnlyMemory<Byte> bytes )
        {
            UnsafeBytes = null;

            Bytes = bytes;
            Length = bytes.Length;
        }


        public Boolean Equals( JsonNameKey other )
        {
            var left = UnsafeBytes == null ? Bytes.Span : new ReadOnlySpan<Byte>( UnsafeBytes, Length );
            var right = other.UnsafeBytes == null ? other.Bytes.Span : new ReadOnlySpan<Byte>( other.UnsafeBytes, other.Length );

            return left.SequenceEqual( right );
        }


        public override Int32 GetHashCode()
        {
            var bytes = UnsafeBytes == null ? Bytes.Span : new ReadOnlySpan<Byte>( UnsafeBytes, Length );
            var hashCode = Length;

            var ints = MemoryMarshal.Cast<Byte, Int32>( bytes );

            for ( var i = 0; i < ints.Length; ++i )
            {
                hashCode += ( hashCode << 7 ) ^ ints[ i ];
            }

            for ( var i = ints.Length * 4; i < bytes.Length; ++i )
            {
                hashCode += ( hashCode << 7 ) ^ bytes[ i ];
            }

            hashCode -= hashCode >> 17;
            hashCode -= hashCode >> 11;
            hashCode -= hashCode >> 5;

            return hashCode;
        }


        public override Boolean Equals( Object obj ) => throw new NotSupportedException();


        public readonly Byte* UnsafeBytes;
        public readonly Int32 Length;

        public readonly ReadOnlyMemory<Byte> Bytes;
    }
}
