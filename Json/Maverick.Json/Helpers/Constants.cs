using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Maverick.Json
{
    [ExcludeFromCodeCoverage]
    internal static partial class Constants
    {
        public static UTF8Encoding Encoding { get; } = new UTF8Encoding( false );

        public const Byte Quote = (Byte)'"';
        public const Byte Dot = (Byte)'.';
        public const Byte LineFeed = (Byte)'\n';

        public static ReadOnlySpan<Byte> True => new Byte[] { 0x74, 0x72, 0x75, 0x65 };
        public static ReadOnlySpan<Byte> False => new Byte[] { 0x66, 0x61, 0x6C, 0x73, 0x65 };
        public static ReadOnlySpan<Byte> Null => new Byte[] { 0x6E, 0x75, 0x6C, 0x6C };
        public static ReadOnlySpan<Byte> PositiveInfinity => new Byte[] { 0x49, 0x6E, 0x66, 0x69, 0x6E, 0x69, 0x74, 0x79 };
        public static ReadOnlySpan<Byte> QuotedPositiveInfinity => new Byte[] { 0x22, 0x49, 0x6E, 0x66, 0x69, 0x6E, 0x69, 0x74, 0x79, 0x22 };
        public static ReadOnlySpan<Byte> NegativeInfinity => new Byte[] { 0x2D, 0x49, 0x6E, 0x66, 0x69, 0x6E, 0x69, 0x74, 0x79 };
        public static ReadOnlySpan<Byte> QuotedNegativeInfinity => new Byte[] { 0x22, 0x2D, 0x49, 0x6E, 0x66, 0x69, 0x6E, 0x69, 0x74, 0x79, 0x22 };
        public static ReadOnlySpan<Byte> NaN => new Byte[] { 0x4E, 0x61, 0x4E };
        public static ReadOnlySpan<Byte> QuotedNaN => new Byte[] { 0x22, 0x4E, 0x61, 0x4E, 0x22 };

        // 10 predefined indent levels should be enough for anybody
        public static readonly Byte[][] Indents = Enumerable.Range( 0, 10 ).Select( x => Indent( x, false ) ).ToArray();
        public static readonly Byte[][] IndentsWithNewLines = Enumerable.Range( 0, 10 ).Select( x => Indent( x, true ) ).ToArray();
        public static readonly DigitPair[] TwoDigits = Enumerable.Range( 0, 100 ).Select( x => new DigitPair( x ) ).ToArray();
        public static readonly DigitBytePair[] TwoDigitsBytes = Enumerable.Range( 0, 100 ).Select( x => new DigitBytePair( x ) ).ToArray();

        // A map between every possible ansi char and it's json token counterpart
        public static readonly JsonToken[] AnsiTokenMap = CreateAnsiTokenMap();

        // A map between every possible ansi char and whether it should be considered a value separator
        public static readonly Boolean[] AnsiValueSeparatorMap = CreateAnsiValueSeparatorMap();

        public const Int32 Max32BitNumberSize = 11;
        public const Int32 Max64BitNumberSize = 20;
        public const Int32 MaxDecimalSize = 31;
        public const Int32 MaxTimeSpanSize = 26;
        public const Int32 MaxDateTimeSize = 33;
        public const Int32 MaxGuidSize = 36;
        public const Int32 MaxFloatSize = 1079;
        public const Int32 MaxBooleanSize = 5;
        public const Int32 MaxCharSize = 6;
        public const Int32 MaxPropertyNameSize = 4096;


        private static Byte[] Indent( Int32 offset, Boolean newLine )
        {
            var result = new Byte[ ( newLine ? Environment.NewLine.Length : 0 ) + offset * 4 ];
            var i = 0;

            if ( newLine )
            {
                foreach ( var x in Environment.NewLine )
                {
                    result[ i++ ] = (Byte)x;
                }
            }

            for ( ; i < result.Length; ++i )
            {
                result[ i ] = (Byte)' ';
            }

            return result;
        }


        private static JsonToken[] CreateAnsiTokenMap()
        {
            var map = new JsonToken[ Byte.MaxValue + 1 ];

            map[ (Byte)'{' ] = JsonToken.StartObject;
            map[ (Byte)'}' ] = JsonToken.EndObject;
            map[ (Byte)'[' ] = JsonToken.StartArray;
            map[ (Byte)']' ] = JsonToken.EndArray;
            map[ (Byte)'"' ] = JsonToken.String;
            map[ (Byte)'n' ] = JsonToken.Null;
            map[ (Byte)'t' ] = JsonToken.Boolean;
            map[ (Byte)'f' ] = JsonToken.Boolean;
            map[ (Byte)'-' ] = JsonToken.Number;
            map[ (Byte)'0' ] = JsonToken.Number;
            map[ (Byte)'1' ] = JsonToken.Number;
            map[ (Byte)'2' ] = JsonToken.Number;
            map[ (Byte)'3' ] = JsonToken.Number;
            map[ (Byte)'4' ] = JsonToken.Number;
            map[ (Byte)'5' ] = JsonToken.Number;
            map[ (Byte)'6' ] = JsonToken.Number;
            map[ (Byte)'7' ] = JsonToken.Number;
            map[ (Byte)'8' ] = JsonToken.Number;
            map[ (Byte)'9' ] = JsonToken.Number;
            map[ (Byte)',' ] = JsonToken.Comma;
            map[ (Byte)' ' ] = JsonToken.WhiteSpace;
            map[ (Byte)'\r' ] = JsonToken.WhiteSpace;
            map[ (Byte)'\n' ] = JsonToken.WhiteSpace;
            map[ (Byte)'\t' ] = JsonToken.WhiteSpace;

            return map;
        }


        private static Boolean[] CreateAnsiValueSeparatorMap()
        {
            var map = new Boolean[ Byte.MaxValue + 1 ];

            map[ (Byte)',' ] = true;
            map[ (Byte)'}' ] = true;
            map[ (Byte)']' ] = true;
            map[ (Byte)' ' ] = true;
            map[ (Byte)'\r' ] = true;
            map[ (Byte)'\n' ] = true;
            map[ (Byte)'\t' ] = true;

            return map;
        }


        [DebuggerDisplay( "{First}{Second}" )]
        public struct DigitPair
        {
            public DigitPair( Int32 number )
            {
                First = (Char)( '0' + ( number / 10 ) );
                Second = (Char)( '0' + ( number % 10 ) );
            }


            public readonly Char First;
            public readonly Char Second;
        }


        [DebuggerDisplay( "{First}{Second}" )]
        public struct DigitBytePair
        {
            public DigitBytePair( Int32 number )
            {
                First = (Byte)( '0' + ( number / 10 ) );
                Second = (Byte)( '0' + ( number % 10 ) );
            }


            public readonly Byte First;
            public readonly Byte Second;
        }
    }
}
