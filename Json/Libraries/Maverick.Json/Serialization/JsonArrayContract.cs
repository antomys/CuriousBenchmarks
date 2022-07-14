using System;
using Maverick.Json.Converters;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonArrayContract : JsonContract, IJsonPopulateFeature
    {
        public static Boolean TryCreate( Type type, out JsonArrayContract contract )
        {
            if ( type.IsArray )
            {
                contract = new JsonArrayContract( type );
                return true;
            }

            contract = null;
            return false;
        }


        private JsonArrayContract( Type arrayType ) : base( arrayType )
        {
            var converterType = default( Type );

            switch ( arrayType.GetArrayRank() )
            {
                case 1:
                    converterType = typeof( Array1Converter<> );
                    break;
                case 2:
                    converterType = typeof( Array2Converter<> );
                    break;
                case 3:
                    converterType = typeof( Array3Converter<> );
                    break;
                default:
                    throw new NotSupportedException( "Array with rank greater than 3 is not supported." );
            }

            m_converter = (JsonConverter)Activator.CreateInstance(
                converterType.MakeGenericType( arrayType.GetElementType() ) );
        }


        public override void WriteValue( JsonWriter writer, Object value ) => m_converter.WriteObject( writer, value );


        public override Object ReadValue( JsonReader reader, Type objectType ) => m_converter.ReadObject( reader, objectType );


        public Boolean Populate( JsonReader reader, Object target )
        {
            if ( m_converter is IJsonPopulateFeature feature )
            {
                return feature.Populate( reader, target );
            }

            return false;
        }


        public Boolean Copy( Object source, Object target )
        {
            if ( m_converter is IJsonPopulateFeature feature )
            {
                return feature.Copy( source, target );
            }

            return false;
        }


        private readonly JsonConverter m_converter;
    }
}
