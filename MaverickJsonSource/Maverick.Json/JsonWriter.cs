using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Maverick.Json.Serialization;

namespace Maverick.Json
{
    /// <summary>
    /// UTF-8 JSON writer that provides a fast, non-cached, forward-only way of generating JSON data.
    /// </summary>
    public class JsonWriter
    {
        public JsonWriter( IBufferWriter<Byte> output ) : this( output, JsonSettings.Default )
        {
        }


        public JsonWriter( IBufferWriter<Byte> output, JsonSettings settings )
        {
            Settings = settings ?? throw new ArgumentNullException( nameof( settings ) );
            Format = settings.Format;

            m_output = output ?? throw new ArgumentNullException( nameof( output ) );
        }


        /// <summary>
        /// User defined object state that can be used by application.
        /// </summary>
        public Object State { get; set; }


        public JsonFormat Format { get; set; }


        public JsonSettings Settings { get; }


        public Int32 Depth { get; private set; }


        public void WriteStartObject()
        {
            WriteStarted( InternalState.Start );
            WriteUTFByte( (Byte)'{' );

            Depth += 1;
        }


        public void WriteEndObject()
        {
            if ( Depth == 0 )
            {
                throw new JsonSerializationException( "Cannot write end object because the current depth is 0." );
            }

            Depth -= 1;

            WriteStarted( InternalState.End );
            WriteUTFByte( (Byte)'}' );
        }


        public void WriteStartArray()
        {
            WriteStarted( InternalState.Start );
            WriteUTFByte( (Byte)'[' );

            Depth += 1;
        }


        public void WriteEndArray()
        {
            if ( Depth == 0 )
            {
                throw new JsonSerializationException( "Cannot write end array because the current depth is 0." );
            }

            Depth -= 1;

            WriteStarted( InternalState.End );
            WriteUTFByte( (Byte)']' );
        }


        public void WritePropertyName( JsonPropertyName propertyName )
        {
            if ( propertyName is null )
                throw new ArgumentNullException( nameof( propertyName ) );

            WriteStarted( InternalState.PropertyName );
            WriteUTFBytes( propertyName.GetBytes( Settings.NamingStrategy ) );
        }


        public void WritePropertyName( String propertyName )
        {
            if ( propertyName is null )
                throw new ArgumentNullException( nameof( propertyName ) );

            WriteStarted( InternalState.PropertyName );
            WriteStringEscaped( propertyName.AsSpan(), withQuotes: true );
            WriteUTFByte( (Byte)':' );
        }


        public void WritePropertyName( ReadOnlySpan<Char> propertyName )
        {
            WriteStarted( InternalState.PropertyName );
            WriteStringEscaped( propertyName, withQuotes: true );
            WriteUTFByte( (Byte)':' );
        }


        public void WriteNull()
        {
            WriteStarted( InternalState.Value );
            WriteUTFBytes( Constants.Null );
        }


        public void WriteValue( Byte value ) => WriteValue( (UInt64)value );


        public void WriteValue( Byte? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( SByte value ) => WriteValue( (Int64)value );


        public void WriteValue( SByte? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Int16 value ) => WriteValue( (Int64)value );


        public void WriteValue( Int16? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( UInt16 value ) => WriteValue( (UInt64)value );


        public void WriteValue( UInt16? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Int32 value ) => WriteValue( (Int64)value );


        public void WriteValue( Int32? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( UInt32 value ) => WriteValue( (UInt64)value );


        public void WriteValue( UInt32? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Int64 value )
        {
            WriteStarted( InternalState.Value );

            if ( !Utf8Formatter.TryFormat( value, m_output.GetSpan(), out var bytesWritten ) &&
                 !Utf8Formatter.TryFormat( value, m_output.GetSpan( Constants.Max64BitNumberSize ), out bytesWritten ) )
            {
                ThrowFormatException( value );
            }

            m_output.Advance( bytesWritten );
        }


        public void WriteValue( Int64? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( UInt64 value )
        {
            WriteStarted( InternalState.Value );

            if ( !Utf8Formatter.TryFormat( value, m_output.GetSpan(), out var bytesWritten ) &&
                 !Utf8Formatter.TryFormat( value, m_output.GetSpan( Constants.Max64BitNumberSize ), out bytesWritten ) )
            {
                ThrowFormatException( value );
            }

            m_output.Advance( bytesWritten );
        }


        public void WriteValue( UInt64? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( String value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteStarted( InternalState.Value );
                WriteStringEscaped( value.AsSpan(), true );
            }
        }


        public void WriteValue( ReadOnlySpan<Char> value, Boolean escape )
        {
            WriteStarted( InternalState.Value );

            if ( escape )
            {
                WriteStringEscaped( value, true );
            }
            else
            {
                WriteString( value, true );
            }
        }


        public void WriteUTFString( ReadOnlySpan<Byte> value )
        {
            WriteStarted( InternalState.Value );
            WriteUTFByte( Constants.Quote );
            WriteUTFBytes( value );
            WriteUTFByte( Constants.Quote );
        }


        public void WriteValue( Single value )
        {
            WriteStarted( InternalState.Value );

            if ( Single.IsNaN( value ) )
            {
                WriteUTFBytes( Constants.QuotedNaN );
            }
            else if ( Single.IsInfinity( value ) )
            {
                WriteUTFBytes( Single.IsPositiveInfinity( value ) ?
                    Constants.QuotedPositiveInfinity : Constants.QuotedNegativeInfinity );
            }
            else
            {
                var sizeHint = 20;

            Retry:
                if ( !DoubleFormatter.TryFormat( value, m_output.GetSpan( sizeHint ), out var bytesWritten ) )
                {
                    sizeHint *= 2;

                    goto Retry;
                }

                m_output.Advance( bytesWritten );
            }
        }


        public void WriteValue( Single? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Double value )
        {
            WriteStarted( InternalState.Value );

            if ( Double.IsNaN( value ) )
            {
                WriteUTFBytes( Constants.QuotedNaN );
            }
            else if ( Double.IsInfinity( value ) )
            {
                WriteUTFBytes( Double.IsPositiveInfinity( value ) ?
                    Constants.QuotedPositiveInfinity : Constants.QuotedNegativeInfinity );
            }
            else
            {
                var sizeHint = 20;

            Retry:
                if ( !DoubleFormatter.TryFormat( value, m_output.GetSpan( sizeHint ), out var bytesWritten ) )
                {
                    sizeHint *= 2;

                    goto Retry;
                }

                m_output.Advance( bytesWritten );
            }
        }


        public void WriteValue( Double? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Decimal value )
        {
            WriteStarted( InternalState.Value );

            var span = m_output.GetSpan( Constants.MaxDecimalSize );

            if ( !Utf8Formatter.TryFormat( value, span, out var bytesWritten ) )
            {
                ThrowFormatException( value );
            }

            // Do not serialize trailing zeroes. The current version of the Utf8Formatter we use
            // do not allow us to specify that we don't want any.
            if ( span[ bytesWritten - 1 ] == (Byte)'0' )
            {
                // Find out if the decimal has a decimal point
                var pointIndex = span.Slice( 0, bytesWritten ).LastIndexOf( (Byte)'.' );

                if ( pointIndex != -1 )
                {
                    --bytesWritten;

                    while ( span[ bytesWritten - 1 ] == (Byte)'0' )
                    {
                        --bytesWritten;
                    }

                    if ( bytesWritten - 1 == pointIndex )
                    {
                        --bytesWritten;
                    }
                }
            }

            m_output.Advance( bytesWritten );
        }


        public void WriteValue( Decimal? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Boolean value )
        {
            WriteStarted( InternalState.Value );
            WriteUTFBytes( value ? Constants.True : Constants.False );
        }


        public void WriteValue( Boolean? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public unsafe void WriteValue( Char value )
        {
            WriteStarted( InternalState.Value );
            WriteStringEscaped( new ReadOnlySpan<Char>( &value, 1 ), true );
        }


        public void WriteValue( Char? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( TimeSpan value )
        {
            WriteStarted( InternalState.Value );
            WriteUTFByte( Constants.Quote );

            if ( !Utf8Formatter.TryFormat( value, m_output.GetSpan(), out var bytesWritten ) &&
                 !Utf8Formatter.TryFormat( value, m_output.GetSpan( Constants.MaxTimeSpanSize ), out bytesWritten ) )
            {
                ThrowFormatException( value );
            }

            m_output.Advance( bytesWritten );

            WriteUTFByte( Constants.Quote );
        }


        public void WriteValue( TimeSpan? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public virtual void WriteValue( DateTime value )
        {
            WriteStarted( InternalState.Value );
            WriteUTFByte( Constants.Quote );
            {
                // Unspecified: "yyyy-mm-ddThh:mm:ss.fffffff"
                // UTC:         "yyyy-mm-ddThh:mm:ss.fffffffZ"
                // Local:       "yyyy-mm-ddThh:mm:ss.fffffff+00:00"
                DateTimeHelpers.GetDateValues( value, out var year, out var month, out var day );

                var digits = Constants.TwoDigitsBytes[ year / 100 ];
                {
                    var buffer = m_output.GetSpan( 19 );
                    buffer[ 00 ] = digits.First;
                    buffer[ 01 ] = digits.Second;

                    digits = Constants.TwoDigitsBytes[ year % 100 ];
                    buffer[ 02 ] = digits.First;
                    buffer[ 03 ] = digits.Second;
                    buffer[ 04 ] = (Byte)'-';

                    digits = Constants.TwoDigitsBytes[ month ];
                    buffer[ 05 ] = digits.First;
                    buffer[ 06 ] = digits.Second;
                    buffer[ 07 ] = (Byte)'-';

                    digits = Constants.TwoDigitsBytes[ day ];
                    buffer[ 08 ] = digits.First;
                    buffer[ 09 ] = digits.Second;
                    buffer[ 10 ] = (Byte)'T';

                    digits = Constants.TwoDigitsBytes[ value.Hour ];
                    buffer[ 11 ] = digits.First;
                    buffer[ 12 ] = digits.Second;
                    buffer[ 13 ] = (Byte)':';

                    digits = Constants.TwoDigitsBytes[ value.Minute ];
                    buffer[ 14 ] = digits.First;
                    buffer[ 15 ] = digits.Second;
                    buffer[ 16 ] = (Byte)':';

                    digits = Constants.TwoDigitsBytes[ value.Second ];

                    buffer[ 17 ] = digits.First;
                    buffer[ 18 ] = digits.Second;

                    m_output.Advance( 19 );
                }

                var remainingTicks = (UInt32)( value.Ticks % 10000000L );

                if ( remainingTicks > 0 )
                {
                    // Remove trailing zeroes
                    Byte precision = 7;

                    while ( remainingTicks % 10 == 0 )
                    {
                        remainingTicks /= 10;
                        --precision;
                    }

                    WriteUTFByte( (Byte)'.' );
                    WriteUInt32( remainingTicks, new StandardFormat( 'D', precision ) );
                }

                if ( value.Kind == DateTimeKind.Utc )
                {
                    WriteUTFByte( (Byte)'Z' );
                }
                else if ( value.Kind == DateTimeKind.Local )
                {
                    // We need to write the time offset as +HH:mm
                    var offset = TimeZoneInfo.Local.GetUtcOffset( value );
                    var buffer = m_output.GetSpan( 6 );

                    digits = Constants.TwoDigitsBytes[ Math.Abs( offset.Hours ) ];
                    buffer[ 0 ] = offset >= TimeSpan.Zero ? (Byte)'+' : (Byte)'-';
                    buffer[ 1 ] = digits.First;
                    buffer[ 2 ] = digits.Second;
                    buffer[ 3 ] = (Byte)':';

                    digits = Constants.TwoDigitsBytes[ Math.Abs( offset.Minutes ) ];
                    buffer[ 4 ] = digits.First;
                    buffer[ 5 ] = digits.Second;

                    m_output.Advance( 6 );
                }
            }
            WriteUTFByte( Constants.Quote );
        }


        public void WriteValue( DateTime? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public virtual void WriteValue( DateTimeOffset value )
        {
            WriteStarted( InternalState.Value );
            WriteUTFByte( Constants.Quote );
            {
                // yyyy-mm-ddThh:mm:ss.fffffff+00:00
                var time = value.DateTime;
                DateTimeHelpers.GetDateValues( time, out var year, out var month, out var day );

                var digits = Constants.TwoDigitsBytes[ year / 100 ];
                var buffer = m_output.GetSpan( 19 );

                buffer[ 00 ] = digits.First;
                buffer[ 01 ] = digits.Second;

                digits = Constants.TwoDigitsBytes[ year % 100 ];

                buffer[ 02 ] = digits.First;
                buffer[ 03 ] = digits.Second;
                buffer[ 04 ] = (Byte)'-';

                digits = Constants.TwoDigitsBytes[ month ];

                buffer[ 05 ] = digits.First;
                buffer[ 06 ] = digits.Second;
                buffer[ 07 ] = (Byte)'-';

                digits = Constants.TwoDigitsBytes[ day ];

                buffer[ 08 ] = digits.First;
                buffer[ 09 ] = digits.Second;
                buffer[ 10 ] = (Byte)'T';

                digits = Constants.TwoDigitsBytes[ time.Hour ];

                buffer[ 11 ] = digits.First;
                buffer[ 12 ] = digits.Second;
                buffer[ 13 ] = (Byte)':';

                digits = Constants.TwoDigitsBytes[ time.Minute ];

                buffer[ 14 ] = digits.First;
                buffer[ 15 ] = digits.Second;
                buffer[ 16 ] = (Byte)':';

                digits = Constants.TwoDigitsBytes[ time.Second ];

                buffer[ 17 ] = digits.First;
                buffer[ 18 ] = digits.Second;

                m_output.Advance( 19 );
                var remainingTicks = (UInt32)( time.Ticks % 10000000L );

                if ( remainingTicks > 0 )
                {
                    // Remove trailing zeroes
                    Byte precision = 7;

                    while ( remainingTicks % 10 == 0 )
                    {
                        remainingTicks /= 10;
                        --precision;
                    }

                    WriteUTFByte( (Byte)'.' );
                    WriteUInt32( remainingTicks, new StandardFormat( 'D', precision ) );
                }

                var offset = value.Offset;
                digits = Constants.TwoDigitsBytes[ Math.Abs( offset.Hours ) ];
                buffer = m_output.GetSpan( 6 );

                buffer[ 0 ] = offset >= TimeSpan.Zero ? (Byte)'+' : (Byte)'-';
                buffer[ 1 ] = digits.First;
                buffer[ 2 ] = digits.Second;
                buffer[ 3 ] = (Byte)':';

                digits = Constants.TwoDigitsBytes[ Math.Abs( offset.Minutes ) ];

                buffer[ 4 ] = digits.First;
                buffer[ 5 ] = digits.Second;

                m_output.Advance( 6 );
            }
            WriteUTFByte( Constants.Quote );
        }


        public void WriteValue( DateTimeOffset? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Guid value )
        {
            WriteStarted( InternalState.Value );
            WriteUTFByte( Constants.Quote );

            if ( !Utf8Formatter.TryFormat( value, m_output.GetSpan( Constants.MaxGuidSize ), out var bytesWritten ) )
            {
                ThrowFormatException( value );
            }

            m_output.Advance( bytesWritten );

            WriteUTFByte( Constants.Quote );
        }


        public void WriteValue( Guid? value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteValue( value.Value );
            }
        }


        public void WriteValue( Byte[] value )
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteStarted( InternalState.Value );
                WriteUTFByte( Constants.Quote );

                var remaining = value.AsSpan();

                while ( remaining.Length > 0 )
                {
                    var sizeHint = Math.Min( 1024, Base64.GetMaxEncodedToUtf8Length( remaining.Length ) );
                    var status = Base64.EncodeToUtf8( remaining,
                                                      m_output.GetSpan( sizeHint ),
                                                      out var bytesConsumed,
                                                      out var bytesWritten );

                    Debug.Assert( remaining.Length == bytesConsumed || status == OperationStatus.DestinationTooSmall );
                    Debug.Assert( bytesWritten > 0 );

                    remaining = remaining.Slice( bytesConsumed );
                    m_output.Advance( bytesWritten );
                }

                WriteUTFByte( Constants.Quote );
            }
        }


        public void WriteValue<T>( T value ) => WriteValue( value, false );


        public void WriteValueIgnoreConverter<T>( T value ) => WriteValue( value, true );


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void WriteValue<T>( T value, Boolean ignoreConverter )
        {
            if ( !PrimitiveFormatter<T>.TryWrite( this, value ) )
            {
                if ( value == null )
                {
                    WriteNull();
                    return;
                }

                var contractType = value.GetType();

                if ( ignoreConverter )
                {
                    contractType = JsonIgnoreConverter.FromType( contractType );
                }

                var contract = Settings.ResolveContract( contractType );

                // If the object we try to write is value type then try to see if the contract
                // has implemented IJsonContract<T> so we can avoid memory allocation of boxing the value.
                if ( Traits<T>.IsValueType && contract is IJsonContract<T> objectContract )
                {
                    objectContract.WriteValue( this, value );
                }
                else
                {
                    var removeCircularReference = false;

                    // Guard against circular references after reasonable depth
                    // so we don't incur unnecessary performance penalty from premature
                    // guarding against such.
                    if ( Depth > 10 )
                    {
                        if ( m_circularReferences == null )
                        {
                            m_circularReferences = new List<Object>();
                        }

                        if ( m_circularReferences.Contains( value ) )
                        {
                            throw new JsonSerializationException( $"Self referencing loop detected with {value} detected." );
                        }

                        m_circularReferences.Add( value );
                        removeCircularReference = true;
                    }

                    contract.WriteValue( this, value );

                    if ( removeCircularReference )
                    {
                        m_circularReferences.Remove( value );
                    }
                }
            }
        }


        internal void WriteEnum<T>( T value ) where T : unmanaged, Enum
        {
            // By default, enums are serialized as numbers
            var number = EnumHelper<T>.Cast( value );

            WriteValue( number );
        }


        internal void WriteEnumNullable<T>( T? value ) where T : unmanaged, Enum
        {
            if ( value == null )
            {
                WriteNull();
            }
            else
            {
                WriteEnum( value.Value );
            }
        }


        private void WriteIndent()
        {
            var remainingDepth = Depth;
            var indents = Constants.IndentsWithNewLines;

            while ( remainingDepth >= 0 )
            {
                if ( remainingDepth >= indents.Length )
                {
                    remainingDepth -= ( indents.Length - 1 );
                    WriteUTFBytes( indents[ indents.Length - 1 ] );

                    // Use indents without new lines
                    indents = Constants.Indents;
                }
                else
                {
                    WriteUTFBytes( indents[ remainingDepth ] );

                    break;
                }
            }
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void WriteUInt32( UInt32 value, StandardFormat format )
        {
            if ( !Utf8Formatter.TryFormat( value, m_output.GetSpan(), out var bytesWritten, format ) &&
                 !Utf8Formatter.TryFormat( value, m_output.GetSpan( Constants.Max32BitNumberSize ), out bytesWritten, format ) )
            {
                ThrowFormatException( value );
            }

            m_output.Advance( bytesWritten );
        }


        [MethodImpl( MethodImplOptions.NoInlining )]
        private void ThrowFormatException<T>( T value ) => throw new FormatException( $"Failed to serialize {value} of type {typeof( T )}. The buffer was too small." );


        private void WriteStarted( InternalState newState )
        {
            var currentState = m_state;

            if ( currentState == InternalState.PropertyName )
            {
                if ( Format != JsonFormat.None )
                {
                    WriteUTFByte( (Byte)' ' );
                }
            }
            else if ( currentState != InternalState.None )
            {
                if ( newState != InternalState.End )
                {
                    if ( currentState >= InternalState.Value )
                    {
                        WriteUTFByte( (Byte)',' );

                        if ( Format == JsonFormat.WhiteSpace )
                        {
                            WriteUTFByte( (Byte)' ' );
                        }
                    }
                    else if ( currentState == InternalState.Start && Format == JsonFormat.WhiteSpace )
                    {
                        WriteUTFByte( (Byte)' ' );
                    }
                }
                else if ( currentState != InternalState.Start && Format == JsonFormat.WhiteSpace )
                {
                    WriteUTFByte( (Byte)' ' );
                }

                if ( Format == JsonFormat.Indented )
                {
                    // Do not indent if the previous state was start and the current is end
                    if ( !( currentState == InternalState.Start && newState == InternalState.End ) )
                    {
                        WriteIndent();
                    }
                }
            }

            m_state = newState;
        }


        private unsafe void WriteString( ReadOnlySpan<Char> value, Boolean withQuotes )
        {
            if ( withQuotes ) WriteUTFByte( Constants.Quote );
            if ( value.Length > 0 )
            {
                if ( m_encoder == null )
                {
                    m_encoder = Constants.Encoding.GetEncoder();
                }

                while ( true )
                {
                    var span = m_output.GetSpan( Constants.MaxCharSize );

                    fixed ( Char* fixedValue = value )
                    fixed ( Byte* fixedBytes = span )
                    {
                        m_encoder.Convert( chars: fixedValue,
                                           charCount: value.Length,
                                           bytes: fixedBytes,
                                           byteCount: span.Length,
                                           flush: true,
                                           out var charsUsed,
                                           out var bytesUsed,
                                           out var completed );
                        m_output.Advance( bytesUsed );

                        if ( completed )
                        {
                            Debug.Assert( value.Length == charsUsed );
                            break;
                        }

                        value = value.Slice( charsUsed );
                    }
                }
            }
            if ( withQuotes ) WriteUTFByte( Constants.Quote );
        }


        private unsafe void WriteStringEscaped( ReadOnlySpan<Char> value, Boolean withQuotes )
        {
            if ( withQuotes ) WriteUTFByte( Constants.Quote );

            if ( value.Length > 0 )
            {
                var start = 0;

                for ( var i = 0; i < value.Length; ++i )
                {
                    if ( NeedEscape( value, i ) )
                    {
                        var c = value[ i ];

                        WriteString( value.Slice( start, i - start ), false );

                        switch ( c )
                        {
                            case '\b': WriteUTFBytes( (Byte)'\\', (Byte)'b' ); break;
                            case '\f': WriteUTFBytes( (Byte)'\\', (Byte)'f' ); break;
                            case '\n': WriteUTFBytes( (Byte)'\\', (Byte)'n' ); break;
                            case '\r': WriteUTFBytes( (Byte)'\\', (Byte)'r' ); break;
                            case '\t': WriteUTFBytes( (Byte)'\\', (Byte)'t' ); break;
                            case '\"': WriteUTFBytes( (Byte)'\\', (Byte)'"' ); break;
                            case '\\': WriteUTFBytes( (Byte)'\\', (Byte)'\\' ); break;
                            case '/': WriteUTFBytes( (Byte)'\\', (Byte)'/' ); break;
                            default:
                                var buffer = m_output.GetSpan( 6 );

                                buffer[ 5 ] = IntToHex( c & '\x000f' );
                                buffer[ 4 ] = IntToHex( ( c >> 4 ) & '\x000f' );
                                buffer[ 3 ] = IntToHex( ( c >> 8 ) & '\x000f' );
                                buffer[ 2 ] = IntToHex( ( c >> 12 ) & '\x000f' );
                                buffer[ 1 ] = (Byte)'u';
                                buffer[ 0 ] = (Byte)'\\';

                                m_output.Advance( 6 );
                                break;
                        }

                        start = i + 1;
                    }
                }

                WriteString( value.Slice( start, value.Length - start ), false );
            }

            if ( withQuotes ) WriteUTFByte( Constants.Quote );

            Byte IntToHex( Int32 number )
            {
                if ( number <= 9 )
                {
                    return (Byte)( number + 48 );
                }

                return (Byte)( ( number - 10 ) + 97 );
            }
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void WriteUTFBytes( ReadOnlySpan<Byte> bytes ) => m_output.Write( bytes );


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void WriteUTFByte( Byte value )
        {
            m_output.GetSpan( 1 )[ 0 ] = value;
            m_output.Advance( 1 );
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private void WriteUTFBytes( Byte b0, Byte b1 )
        {
            var span = m_output.GetSpan( 2 );

            span[ 1 ] = b1;
            span[ 0 ] = b0;

            m_output.Advance( 2 );
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private static Boolean NeedEscape( ReadOnlySpan<Char> src, Int32 i )
        {
            // Characters which have to be escaped:
            // - Required by JSON Spec: Control characters, '"' and '\\'
            // - Broken surrogates to make sure the JSON string is valid Unicode
            //   (and can be encoded as UTF8)
            // - JSON does not require U+2028 and U+2029 to be escaped, but
            //   JavaScript does require this:
            //   http://stackoverflow.com/questions/2965293/javascript-parse-error-on-u2028-unicode-character/9168133#9168133
            // - '/' also does not have to be escaped, but escaping it when
            //   preceeded by a '<' avoids problems with JSON in HTML <script> tags
            var c = src[ i ];

            return c < 32 || c == '"' || c == '\\'
                // Broken lead surrogate
                || ( c >= '\uD800' && c <= '\uDBFF' && ( i == src.Length - 1 || src[ i + 1 ] < '\uDC00' || src[ i + 1 ] > '\uDFFF' ) )
                // Broken tail surrogate
                || ( c >= '\uDC00' && c <= '\uDFFF' && ( i == 0 || src[ i - 1 ] < '\uD800' || src[ i - 1 ] > '\uDBFF' ) )
                // To produce valid JavaScript
                || c == '\u2028' || c == '\u2029'
                // Escape "</" for <script> tags
                || ( c == '/' && i > 0 && src[ i - 1 ] == '<' );
        }


        private readonly IBufferWriter<Byte> m_output;
        private List<Object> m_circularReferences;
        private InternalState m_state;
        private Encoder m_encoder;


        private enum InternalState
        {
            None,
            Start,
            PropertyName,
            Value,
            End
        }
    }
}
