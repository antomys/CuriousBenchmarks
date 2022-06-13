using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text;

namespace Maverick.Json
{
    public sealed class JsonPropertyName : IEquatable<JsonPropertyName>
    {
        public static JsonPropertyName GetOrCreate( String propertyName )
        {
            if ( propertyName is null )
                throw new ArgumentNullException( nameof( propertyName ) );

            return s_registeredProperties.GetOrAdd( propertyName, s_factory );
        }


        private JsonPropertyName( String propertyName )
        {
            if ( propertyName is null )
                throw new ArgumentNullException( nameof( propertyName ) );

            Value = String.Intern( propertyName );
        }


        internal String Value { get; }


        public ReadOnlySpan<Byte> GetBytes( JsonNamingStrategy strategy )
        {
            ref var bytes = ref m_bytes[ (Byte)strategy ];

            if ( bytes is null )
                bytes = Convert( Value, strategy );

            return bytes;
        }


        public ReadOnlyMemory<Byte> GetBytesNoQuotes( JsonNamingStrategy strategy )
        {
            ref var bytes = ref m_bytes[ (Byte)strategy ];

            if ( bytes is null )
                bytes = Convert( Value, strategy );

            return new ReadOnlyMemory<Byte>( bytes, 1, bytes.Length - 3 );
        }


        public override String ToString() => Value;


        public override Int32 GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode( Value );


        public override Boolean Equals( Object obj )
        {
            if ( obj is JsonPropertyName name )
            {
                return Equals( name );
            }

            return false;
        }


        public Boolean Equals( JsonPropertyName other ) => StringComparer.OrdinalIgnoreCase.Equals( Value, other?.Value );


        public static Boolean operator ==( JsonPropertyName left, JsonPropertyName right )
            => StringComparer.OrdinalIgnoreCase.Equals( left?.Value, right?.Value );


        public static Boolean operator !=( JsonPropertyName left, JsonPropertyName right )
            => !StringComparer.OrdinalIgnoreCase.Equals( left?.Value, right?.Value );


        private static JsonPropertyName Create( String name ) => new JsonPropertyName( name );


        private static Byte[] Convert( String propertyName, JsonNamingStrategy strategy )
        {
            propertyName = strategy switch
            {
                JsonNamingStrategy.CamelCase => ToCamelCase( propertyName ),
                JsonNamingStrategy.SnakeCase => ToSnakeCase( propertyName ),
                _ => propertyName
            };

            using var buffer = new JsonBufferWriter( 256 );
            new JsonWriter( buffer ).WriteValue( propertyName );

            // Append the separator
            buffer.GetSpan()[ 0 ] = (Byte)':';
            buffer.Advance( 1 );

            return buffer.ToArray();
        }


        private static String ToCamelCase( String name )
        {
            if ( String.IsNullOrEmpty( name ) || !Char.IsUpper( name[ 0 ] ) )
            {
                return name;
            }

            var chars = name.ToCharArray();

            for ( var i = 0; i < chars.Length; i++ )
            {
                if ( i == 1 && !Char.IsUpper( chars[ i ] ) )
                {
                    break;
                }

                var hasNext = ( i + 1 < chars.Length );

                if ( i > 0 && hasNext && !Char.IsUpper( chars[ i + 1 ] ) )
                {
                    // if the next character is a space, which is not considered uppercase 
                    // (otherwise we wouldn't be here...)
                    // we want to ensure that the following:
                    // 'FOO bar' is rewritten as 'foo bar', and not as 'foO bar'
                    // The code was written in such a way that the first word in uppercase
                    // ends when if finds an uppercase letter followed by a lowercase letter.
                    // now a ' ' (space, (char)32) is considered not upper
                    // but in that case we still want our current character to become lowercase
                    if ( Char.IsSeparator( chars[ i + 1 ] ) )
                    {
                        chars[ i ] = ToLower( chars[ i ] );
                    }

                    break;
                }

                chars[ i ] = ToLower( chars[ i ] );
            }

            return new String( chars );

            static Char ToLower( Char c )
            {
                return Char.ToLower( c, CultureInfo.InvariantCulture );
            }
        }


        private static String ToSnakeCase( String name )
        {
            if ( String.IsNullOrEmpty( name ) )
            {
                return name;
            }

            var builder = new StringBuilder();
            var state = SnakeCaseState.Start;

            for ( var i = 0; i < name.Length; i++ )
            {
                if ( name[ i ] == ' ' )
                {
                    if ( state != SnakeCaseState.Start )
                    {
                        state = SnakeCaseState.NewWord;
                    }
                }
                else if ( Char.IsUpper( name[ i ] ) )
                {
                    switch ( state )
                    {
                        case SnakeCaseState.Upper:
                            var hasNext = ( i + 1 < name.Length );

                            if ( i > 0 && hasNext )
                            {
                                var nextChar = name[ i + 1 ];

                                if ( !Char.IsUpper( nextChar ) && nextChar != '_' )
                                {
                                    builder.Append( '_' );
                                }
                            }
                            break;
                        case SnakeCaseState.Lower:
                        case SnakeCaseState.NewWord:
                            builder.Append( '_' );
                            break;
                    }

                    builder.Append( Char.ToLower( name[ i ], CultureInfo.InvariantCulture ) );

                    state = SnakeCaseState.Upper;
                }
                else if ( name[ i ] == '_' )
                {
                    builder.Append( '_' );
                    state = SnakeCaseState.Start;
                }
                else
                {
                    if ( state == SnakeCaseState.NewWord )
                    {
                        builder.Append( '_' );
                    }

                    builder.Append( name[ i ] );
                    state = SnakeCaseState.Lower;
                }
            }

            return builder.ToString();
        }


        internal static unsafe String RestoreCase( String name, JsonNamingStrategy sourceStrategy )
        {
            if ( sourceStrategy == JsonNamingStrategy.CamelCase )
            {
                fixed ( Char* pName = name )
                {
                    pName[ 0 ] = Char.ToUpper( name[ 0 ] );
                }
            }
            else if ( sourceStrategy == JsonNamingStrategy.SnakeCase )
            {
                return RestoreCaseFromSnakeCase( name );
            }

            return name;
        }


        private static unsafe String RestoreCaseFromSnakeCase( String name )
        {
            // Count instances of '_'
            var previousCharIsUnderscore = true;
            var underscoreCount = 0;

            for ( var i = 0; i < name.Length; ++i )
            {
                if ( name[ i ] == '_' && !previousCharIsUnderscore )
                {
                    underscoreCount += 1;
                    previousCharIsUnderscore = true;
                }
                else
                {
                    previousCharIsUnderscore = false;
                }
            }

            var result = new String( '\0', name.Length - underscoreCount );
            var resultIndex = 0;

            previousCharIsUnderscore = true;

            fixed ( Char* pResult = result )
            {
                for ( var i = 0; i < name.Length; ++i )
                {
                    var @char = name[ i ];

                    if ( @char == '_' && !previousCharIsUnderscore )
                    {
                        previousCharIsUnderscore = true;
                    }
                    else
                    {
                        pResult[ resultIndex++ ] = previousCharIsUnderscore ? Char.ToUpper( @char ) : @char;
                        previousCharIsUnderscore = false;
                    }
                }
            }

            return result;
        }


        private readonly Byte[][] m_bytes = new Byte[ 3 ][];


        private static readonly ConcurrentDictionary<String, JsonPropertyName> s_registeredProperties = new ConcurrentDictionary<String, JsonPropertyName>( StringComparer.Ordinal );
        private static readonly Func<String, JsonPropertyName> s_factory = Create;


        private enum SnakeCaseState
        {
            Start,
            Lower,
            Upper,
            NewWord
        }
    }
}
