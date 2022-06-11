using System;
using System.Diagnostics;

namespace Maverick.Json.Serialization
{
    /// <summary>
    /// Contract details for a <see cref="System.Type"/> used by the <see cref="JsonSettings"/>.
    /// </summary>
    public abstract class JsonContract
    {
        protected private JsonContract( Type underlyingType )
        {
            Debug.Assert( Nullable.GetUnderlyingType( underlyingType ) == null );

            UnderlyingType = underlyingType;
        }


        /// <summary>
        /// Gets the underlying type for the contract.
        /// </summary>
        public Type UnderlyingType { get; }


        public abstract void WriteValue( JsonWriter writer, Object value );


        public abstract Object ReadValue( JsonReader reader, Type objectType );


        protected internal virtual void Freeze()
        {
            m_frozen = true;
        }


        protected void CheckNotFrozen()
        {
            if ( m_frozen )
            {
                throw new InvalidOperationException( "The contract cannot be changed because it's frozen." );
            }
        }


        private Boolean m_frozen;
    }
}
