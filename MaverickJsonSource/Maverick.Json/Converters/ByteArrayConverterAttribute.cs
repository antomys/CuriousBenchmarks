using System;

namespace Maverick.Json.Converters
{
    /// <summary>
    /// Serializes Byte[] as JSON array instead of the default base64 string.
    /// </summary>
    public sealed class ByteArrayConverterAttribute : JsonConverterAttribute
    {
        public ByteArrayConverterAttribute() : base( typeof( ByteArrayConverter ) )
        {
        }


        protected internal override JsonConverter CreateInstance( Type objectType ) => new ByteArrayConverter();
    }
}
