using System;

namespace Maverick.Json
{
    internal struct ArrayBuilder<T>
    {
        public ArrayBuilder( Int32 initialSize )
        {
            m_buffer = new T[ initialSize ];
            Count = 0;
        }


        public T[] Buffer => m_buffer;
        public Int32 Count { get; private set; }


        public void Add( T value )
        {
            if ( Count >= m_buffer.Length )
            {
                Array.Resize( ref m_buffer, Count * 2 );
            }

            m_buffer[ Count++ ] = value;
        }


        public T[] ToArray()
        {
            if ( Count == 0 )
            {
                return Array.Empty<T>();
            }
            else if ( m_buffer.Length == Count )
            {
                return m_buffer;
            }

            var result = new T[ Count ];
            Array.Copy( m_buffer, result, Count );

            return result;
        }


        private T[] m_buffer;
    }
}
