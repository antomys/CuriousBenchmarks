using System;

namespace Maverick.Json
{
    /// <summary>
    /// Instructs the JSON serializer to use the specified <see cref="JsonConverter"/> when serializing the member or class.
    /// </summary>
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = false )]
    public class JsonConverterAttribute : Attribute
    {
        public JsonConverterAttribute( Type converterType )
        {
            ConverterType = converterType ?? throw new ArgumentNullException( nameof( converterType ) );
        }


        public Type ConverterType { get; }


        protected internal virtual JsonConverter CreateInstance( Type objectType )
        {
            var converterType = ConverterType;

            if ( converterType.IsGenericTypeDefinition )
            {
                // This is a generic converter. The converted type must also be
                // generic with the same number of generic arguments.
                if ( !objectType.IsGenericType )
                {
                    throw new JsonSerializationException( $"{objectType} has explicitly specified converter {converterType} which is a generic type, but the converted type is not." );
                }

                try
                {
                    converterType = converterType.MakeGenericType( objectType.GetGenericArguments() );
                }
                catch
                {
                    throw new JsonSerializationException( $"The converter {converterType} for {objectType} doesn't match the converted type generic arguments or constraints." );
                }
            }

            return (JsonConverter)Activator.CreateInstance( converterType );
        }
    }
}
