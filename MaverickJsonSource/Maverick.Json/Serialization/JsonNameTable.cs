using System;
using System.Collections.Generic;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonNameTable
    {
        public String Find( ReadOnlyMemory<Byte> bytes )
        {
            m_properties.TryGetValue( new JsonNameKey( bytes ), out var value );

            return value;
        }


        public unsafe String Find( Byte* bytes, Int32 length )
        {
            m_properties.TryGetValue( new JsonNameKey( bytes, length ), out var value );

            return value;
        }


        public void Add( ReadOnlyMemory<Byte> bytes, String value )
        {
            m_properties.Add( new JsonNameKey( bytes ), value );
        }


        private readonly Dictionary<JsonNameKey, String> m_properties = new Dictionary<JsonNameKey, String>();
    }
}
