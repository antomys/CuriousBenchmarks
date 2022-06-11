using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Maverick.Json.Serialization
{
    public unsafe ref struct JsonPropertyValues<TOwner>
    {
        public JsonPropertyValues( JsonObjectContract<TOwner> contract, Byte* memory, Byte* present )
        {
            m_referenceCount = contract.Properties.ReferenceCount;
            m_contract = contract;
            m_memory = memory;
            m_present = present;
            m_references = m_referenceCount > 0 ? ArrayPool<Object>.Shared.Rent( m_referenceCount ) : null;
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public readonly Boolean HasValue( JsonProperty<TOwner> property ) => m_present[ property.Index ] == 1;


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public readonly TProperty GetValue<TProperty>( JsonProperty<TOwner, TProperty> property )
        {
            if ( !HasValue( property ) )
            {
                return default;
            }
            if ( Traits<TProperty>.IsValueType )
            {
                return Unsafe.ReadUnaligned<TProperty>( m_memory + property.MemoryOffset );
            }

            return (TProperty)m_references[ property.ReferenceIndex ];
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        internal void SetValue<TProperty>( JsonProperty<TOwner, TProperty> property, TProperty value )
        {
            m_present[ property.Index ] = 1;

            if ( Traits<TProperty>.IsValueType )
            {
                Unsafe.WriteUnaligned( m_memory + property.MemoryOffset, value );
            }
            else
            {
                m_references[ property.ReferenceIndex ] = value;
            }
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        internal void MarkAsPresent<TProperty>( JsonProperty<TOwner, TProperty> property )
        {
            m_present[ property.Index ] = 2;
        }


        internal void Release()
        {
            if ( m_references != null )
            {
                Array.Clear( m_references, 0, m_referenceCount );
                ArrayPool<Object>.Shared.Return( m_references, false );

                m_references = null;
            }
        }


        internal readonly void CheckRequiredProperties()
        {
            if ( m_contract.Properties.Required.Length > 0 )
            {
                foreach ( var property in m_contract.Properties.Required )
                {
                    if ( m_present[ property.Index ] == 0 )
                    {
                        throw new JsonSerializationException( $"Missing value for required property {property.UnderlyingName} in {m_contract.UnderlyingType}." );
                    }
                }
            }
        }


        private readonly JsonObjectContract<TOwner> m_contract;
        private readonly Byte* m_memory;
        private readonly Byte* m_present;

        private Object[] m_references;
        private readonly Int32 m_referenceCount;
    }
}
