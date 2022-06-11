using System;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    /// <summary>
    /// The exception thrown when an error occurs during JSON serialization or deserialization.
    /// </summary>
    public class JsonSerializationException : ApplicationException
    {
        public JsonSerializationException( String message )
            : base( message )
        {
        }


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowUnexpectedEnd() => throw new JsonSerializationException( "Unexpected end of json while trying to read the next token." );


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowUnexpectedSymbol( Byte symbol ) => throw new JsonSerializationException( $"Unexpected symbol {(Char)symbol} with code {symbol}." );


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowInvalidValue( Type valueType, String value ) => throw new JsonSerializationException( $"Detected invalid {valueType} \"{value}\"." );


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowInvalidState( JsonToken token, JsonToken previousToken ) => throw new JsonSerializationException( $"Detected invalid JSON state while trying to read {token}. The previous token is {previousToken}." );


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowMissingComma( JsonToken nextToken ) => throw new JsonSerializationException( $"Detected invalid JSON. {nextToken} is missing comma before it." );


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowStringTooBig() => throw new JsonSerializationException( "Cannot read value because the string is too big." );


        [MethodImpl( MethodImplOptions.NoInlining )]
        internal static void ThrowNumberTooBig() => throw new JsonSerializationException( "Cannot read number because the value is too big or not a number." );
    }
}
