using System;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonConverterContract<T> : JsonContract, IJsonContract<T>, IJsonPopulateFeature
    {
        public JsonConverterContract( JsonConverter converter, JsonContract nonConverterContract ) : base( typeof( T ) )
        {
            m_converter = converter;
            m_typedConverter = converter as JsonConverter<T>;
            m_nonConverterContract = nonConverterContract;
        }


        void IJsonContract<T>.WriteValue( JsonWriter writer, T value )
        {
            if ( m_typedConverter != null )
            {
                m_typedConverter.Write( writer, value );
            }
            else
            {
                m_converter.WriteObject( writer, value );
            }
        }


        T IJsonContract<T>.ReadValue( JsonReader reader, Type objectType )
        {
            if ( m_typedConverter != null )
            {
                return m_typedConverter.Read( reader, objectType );
            }

            return (T)m_converter.ReadObject( reader, objectType );
        }


        Boolean IJsonPopulateFeature.Populate( JsonReader reader, Object target )
        {
            if ( m_nonConverterContract is IJsonPopulateFeature feature )
            {
                return feature.Populate( reader, target );
            }

            return false;
        }


        Boolean IJsonPopulateFeature.Copy( Object source, Object target )
        {
            if ( m_nonConverterContract is IJsonPopulateFeature feature )
            {
                return feature.Copy( source, target );
            }

            return false;
        }


        public override void WriteValue( JsonWriter writer, Object value ) => m_converter.WriteObject( writer, value );


        public override Object ReadValue( JsonReader reader, Type objectType ) => m_converter.ReadObject( reader, objectType );


        protected internal override void Freeze()
        {
            m_nonConverterContract.Freeze();

            base.Freeze();
        }


        private readonly JsonConverter m_converter;
        private readonly JsonConverter<T> m_typedConverter;

        private readonly JsonContract m_nonConverterContract;
    }
}

