using System;
using System.Collections.Generic;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonNameTable<TOwner>
    {
        public JsonNameTable( JsonNamingStrategy namingStrategy )
        {
            m_namingStrategy = namingStrategy;
        }


        public JsonProperty<TOwner> Find( ReadOnlyMemory<Byte> bytes )
        {
            m_properties.TryGetValue( new JsonNameKey( bytes ), out var value );

            return value;
        }


        public unsafe JsonProperty<TOwner> Find( Byte* bytes, Int32 length )
        {
            m_properties.TryGetValue( new JsonNameKey( bytes, length ), out var value );

            return value;
        }


        public void Add( JsonProperty<TOwner> property )
        {
            var bytes = property.Name.GetBytesNoQuotes( m_namingStrategy );

            // It is possible for more than one property to have the same byte representation
            // in a given naming strategy. In this case we honor the first property.
            if ( Find( bytes ) != null )
            {
                return;
            }

            m_properties.Add( new JsonNameKey( bytes ), property );
        }


        private readonly JsonNamingStrategy m_namingStrategy;
        private readonly Dictionary<JsonNameKey, JsonProperty<TOwner>> m_properties = new Dictionary<JsonNameKey, JsonProperty<TOwner>>();
    }
}
