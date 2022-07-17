using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal ref struct CollectionAppender<TCollection, TItem>
    {
        public static readonly Boolean Supported;


        static CollectionAppender()
        {
            Supported = Initialize( out s_add, out s_clear );
        }


        public CollectionAppender( TCollection collection )
        {
            m_collection = collection;
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public void Add( TItem item ) => s_add( m_collection, item );


        public void Clear()
        {
            // Clear method is not required, so if it doesn't exist we must not throw exception
            s_clear?.Invoke( m_collection );
        }


        private static Boolean Initialize( out Action<TCollection, TItem> add, out Action<TCollection> clear )
        {
            var collectionType = typeof( TCollection );
            var itemType = typeof( TItem );

            add = null;
            clear = null;

            if ( typeof( ICollection<TItem> ).IsAssignableFrom( collectionType ) )
            {
                add = ( collection, item ) => ( (ICollection<TItem>)collection ).Add( item );
            }
            else if ( typeof( IList ).IsAssignableFrom( collectionType ) )
            {
                add = ( collection, item ) => ( (IList)collection ).Add( item );
            }
            else if ( ReflectionHelpers.IsSubclassOfRawGeneric( collectionType, typeof( IDictionary<,> ), out var types ) &&
                      ReflectionHelpers.IsSubclassOfRawGeneric( itemType, typeof( KeyValuePair<,> ), out var itemTypes ) &&
                      types.SequenceEqual( itemTypes ) )
            {
                add = (Action<TCollection, TItem>)typeof( ReflectionHelpers ).GetMethod( nameof( ReflectionHelpers.GetDictionarySetMethod ), BindingFlags.Public | BindingFlags.Static )
                    .MakeGenericMethod( collectionType, itemTypes[ 0 ], itemTypes[ 1 ] )
                    .Invoke( null, null );
            }

            if ( add != null )
            {
                var clearMethod = collectionType.GetMethod( "Clear", BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null );

                if ( clearMethod != null && clearMethod.ReturnType == typeof( void ) )
                {
                    clear = (Action<TCollection>)clearMethod.CreateDelegate( typeof( Action<TCollection> ) );
                }
            }


            return add != null;
        }


        private readonly TCollection m_collection;

        private static readonly Action<TCollection, TItem> s_add;
        private static readonly Action<TCollection> s_clear;
    }
}
