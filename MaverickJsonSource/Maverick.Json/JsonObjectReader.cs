using System;
using System.Buffers;
using System.Collections.Generic;

namespace Maverick.Json
{
    /// <summary>
    /// A class that allows reading JSON objects by property name. The JSON object
    /// is traversed once initially to index it's properties.
    /// </summary>
    public sealed class JsonObjectReader
    {
        public JsonObjectReader( ReadOnlySequence<Byte> sequence ) : this( sequence, JsonSettings.Default )
        {
        }


        public JsonObjectReader( ReadOnlySequence<Byte> sequence, JsonSettings settings )
        {
            m_reader = new JsonReader( sequence, settings );
            m_reader.ReadStartObject();

            while ( m_reader.Peek() != JsonToken.EndObject )
            {
                var propertyName = m_reader.ReadPropertyName();
                var state = m_reader.GetState();

                m_properties.Add( propertyName, state );
                m_reader.Skip();
            }
        }


        public IEnumerable<String> PropertyNames => m_properties.Keys;


        public T Read<T>( String propertyName )
        {
            if ( !m_properties.TryGetValue( propertyName, out var state ) )
                throw new JsonSerializationException( $"{propertyName} was not found on object." );

            m_reader.SetState( state );

            return m_reader.ReadValue<T>();
        }


        public Boolean TryRead<T>( String propertyName, out T value )
        {
            if ( m_properties.TryGetValue( propertyName, out var state ) )
            {
                m_reader.SetState( state );

                value = m_reader.ReadValue<T>();
                return true;
            }

            value = default;
            return false;
        }


        public Boolean Contains( String propertyName ) => m_properties.ContainsKey( propertyName );


        private readonly JsonReader m_reader;
        private readonly Dictionary<String, JsonReaderState> m_properties = new Dictionary<String, JsonReaderState>( StringComparer.OrdinalIgnoreCase );
    }
}
