using System;
using System.Buffers.Text;
using System.Diagnostics;

namespace Maverick.Json.Converters
{
    /// <summary>
    /// Serializes <seealso cref="Version"/> as string "0.0.0.0" instead of as an object.
    /// </summary>
    public sealed class VersionConverter : JsonConverter<Version>
    {
        public override Version Read( JsonReader reader, Type objectType ) => Version.Parse( reader.ReadString() );


        public override void Write( JsonWriter writer, Version value )
        {
            Span<Byte> buffer = stackalloc Byte[ 4 * 10/*Int32 max length*/ + 3/*Dots*/ ];
            var offset = 0;

            Write( value.Major, buffer, ref offset );
            buffer[ offset++ ] = Constants.Dot;
            Write( value.Minor, buffer, ref offset );

            if ( value.Build > 0 || value.Revision > 0 )
            {
                buffer[ offset++ ] = Constants.Dot;
                Write( value.Build, buffer, ref offset );

                if ( value.Revision > 0 )
                {
                    buffer[ offset++ ] = Constants.Dot;
                    Write( value.Revision, buffer, ref offset );
                }
            }

            writer.WriteUTFString( buffer.Slice( 0, offset ) );
        }


        private void Write( Int32 number, Span<Byte> target, ref Int32 offset )
        {
            var success = Utf8Formatter.TryFormat( number, target.Slice( offset ), out var bytesWritten );
            Debug.Assert( success );

            offset += bytesWritten;
        }
    }
}
