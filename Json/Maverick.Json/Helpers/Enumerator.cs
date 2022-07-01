using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal ref struct Enumerator<TCollection, TItem, TEnumerator>
        where TEnumerator : struct
    {
        static Enumerator()
        {
            var getEnumeratorMethod = ReflectionHelpers.FindGetEnumeratorMethod( typeof( TCollection ), typeof( TItem ) );
            var parameter = Expression.Parameter( typeof( TCollection ) );

            s_getEnumerator = Expression.Lambda<GetEnumeratorFunc>( Expression.Call( parameter, getEnumeratorMethod ), parameter ).Compile();
            s_moveNext = (MoveNextFunc)typeof( TEnumerator ).GetMethod( "MoveNext" ).CreateDelegate( typeof( MoveNextFunc ) );
            s_getCurrent = ReflectionHelpers.CreateGetter<TEnumerator, TItem, GetCurrentFunc>( typeof( TEnumerator ).GetProperty( "Current" ) );
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public Enumerator( TCollection collection )
        {
            m_enumerator = s_getEnumerator( collection );
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public TItem GetCurrent() => s_getCurrent( m_enumerator );


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public Boolean MoveNext() => s_moveNext( ref m_enumerator );


        private TEnumerator m_enumerator;


        private static readonly GetEnumeratorFunc s_getEnumerator;
        private static readonly MoveNextFunc s_moveNext;
        private static readonly GetCurrentFunc s_getCurrent;

        private delegate TEnumerator GetEnumeratorFunc( TCollection collection );
        private delegate Boolean MoveNextFunc( ref TEnumerator enumerator );
        private delegate TItem GetCurrentFunc( TEnumerator enumerator );
    }
}
