using System;
using System.Buffers;
using System.Diagnostics;
using System.Text;

namespace Maverick.Json
{
    internal static class EncodingExtensions
    {
        public static unsafe String GetString( this Encoding encoding, ReadOnlySequence<Byte> sequence )
        {
            if ( sequence.IsSingleSegment )
            {
                return GetString( encoding, sequence.First.Span );
            }

            var decoder = encoding.GetDecoder();
            var charCount = 0;
            var remainingByteCount = sequence.Length;

            foreach ( var memory in sequence )
            {
                remainingByteCount -= memory.Length;

                fixed ( Byte* bytes = memory.Span )
                {
                    charCount += decoder.GetCharCount( bytes, memory.Length, flush: remainingByteCount == 0 );
                }
            }

            var result = new String( '\0', charCount );

            fixed ( Char* chars = result )
            {
                var processedChars = 0;
                var position = sequence.Start;

                while ( true )
                {
                    var span = sequence.First.Span;

                    fixed ( Byte* bytes = span )
                    {
                        decoder.Convert( bytes,
                                         byteCount: span.Length,
                                         chars: chars + processedChars,
                                         charCount: charCount - processedChars,
                                         flush: sequence.IsSingleSegment,
                                         out var bytesUsed,
                                         out var charsUsed,
                                         out var completed );

                        processedChars += charsUsed;

                        if ( processedChars == charCount )
                        {
                            Debug.Assert( completed );

                            break;
                        }

                        sequence = sequence.Slice( bytesUsed );
                    }
                }
            }

            return result;
        }


        public static unsafe String GetString( this Encoding encoding, ReadOnlySpan<Byte> bytes )
        {
            if ( bytes.Length == 0 )
            {
                return String.Empty;
            }

            fixed ( Byte* fixedBytes = bytes )
            {
                return encoding.GetString( fixedBytes, bytes.Length );
            }
        }
    }
}
