using System;

namespace Maverick.Json.Converters
{
    /// <summary>
    /// Converts Unix Timestamp to DateTime and vice versa.
    /// </summary>
    public sealed class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime UnixEpoch = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );


        public override DateTime Read( JsonReader reader, Type objectType )
        {
            var seconds = reader.ReadInt64();

            return UnixEpoch.AddSeconds( seconds );
        }


        public override void Write( JsonWriter writer, DateTime value )
        {
            var seconds = (Int64)( value.ToUniversalTime() - UnixEpoch ).TotalSeconds;

            writer.WriteValue( seconds );
        }
    }
}
