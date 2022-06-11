using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal ref struct CollectionBuilder<TCollection, TItem>
    {
        static CollectionBuilder()
        {
            s_canBuild = Setup( ref s_add,
                                ref s_defaultCtor,
                                ref s_enumerableCtor,
                                ref s_bufferCtor );
        }


        public void Add( TItem item )
        {
            if ( !m_initialized )
            {
                Initialize();
            }

            // Check the buffer for null instead of the collection, because the collection
            // can be a value type.
            if ( m_buffer != null )
            {
                m_buffer.Add( item );
            }
            else
            {
                s_add( m_collection, item );
            }
        }


        public TCollection ToCollection()
        {
            if ( !m_initialized )
            {
                Initialize();
            }

            if ( m_buffer == null )
            {
                return m_collection;
            }
            else if ( s_enumerableCtor != null )
            {
                return s_enumerableCtor( m_buffer );
            }

            return (TCollection)m_buffer;
        }


        [MethodImpl( MethodImplOptions.NoInlining )]
        private void Initialize()
        {
            if ( !s_canBuild )
            {
                throw new JsonSerializationException( $"Collection of type {typeof( TCollection )} cannot be deserialized because there is no suitable constructor." );
            }

            if ( s_defaultCtor != null )
            {
                m_collection = s_defaultCtor();
            }
            else
            {
                m_buffer = s_bufferCtor();
            }

            m_initialized = true;
        }


        private static Boolean Setup( ref Action<TCollection, TItem> add,
                                      ref Func<TCollection> defaultCtor,
                                      ref Func<IEnumerable<TItem>, TCollection> enumerableCtor,
                                      ref Func<ICollection<TItem>> bufferCtor )
        {
            var collectionType = typeof( TCollection );
            var itemType = typeof( TItem );

            if ( collectionType.IsAbstract || collectionType.IsInterface )
            {
                return SetupAbstract( ref bufferCtor );
            }

            var ctorFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var ctor = collectionType.GetConstructor( ctorFlags, null, Type.EmptyTypes, null );

            if ( ctor != null )
            {
                var addMethod = collectionType.GetMethod( "Add", BindingFlags.Public | BindingFlags.Instance, null, new[] { itemType }, null );

                if ( addMethod != null && ( addMethod.ReturnType == typeof( void ) || addMethod.ReturnType == typeof( Int32 ) ) )
                {
                    defaultCtor = ObjectConstructor.CreateDelegate<Func<TCollection>>( ctor );

                    if ( addMethod.ReturnType == typeof( void ) )
                    {
                        add = (Action<TCollection, TItem>)addMethod.CreateDelegate( typeof( Action<TCollection, TItem> ) );
                    }
                    else
                    {
                        var method = (Func<TCollection, TItem, Int32>)addMethod.CreateDelegate( typeof( Func<TCollection, TItem, Int32> ) );
                        add = ( collection, item ) => method( collection, item );
                    }
                    return true;
                }

                if ( typeof( ICollection<TItem> ).IsAssignableFrom( collectionType ) )
                {
                    defaultCtor = ObjectConstructor.CreateDelegate<Func<TCollection>>( ctor );

                    // Make sure that the add method works. Some collections implement ICollection<TItem>
                    // but are actually read only.
                    if ( !( (ICollection<TItem>)defaultCtor() ).IsReadOnly )
                    {
                        add = ( collection, item ) => ( (ICollection<TItem>)collection ).Add( item );
                        return true;
                    }

                    defaultCtor = null;
                }
            }

            // IEnumerable<T> constructor
            ctor = collectionType.GetConstructor( ctorFlags, null, new[] { typeof( IEnumerable<TItem> ) }, null );

            if ( ctor != null )
            {
                enumerableCtor = ObjectConstructor.CreateDelegate<Func<IEnumerable<TItem>, TCollection>>( ctor );
                bufferCtor = () => new List<TItem>();
                return true;
            }

            // IEnumerable constructor
            ctor = collectionType.GetConstructor( ctorFlags, null, new[] { typeof( IEnumerable ) }, null );

            if ( ctor != null )
            {
                enumerableCtor = ObjectConstructor.CreateDelegate<Func<IEnumerable, TCollection>>( ctor );
                bufferCtor = () => new List<TItem>();
                return true;
            }

            // Immutable Collections
            // There is a non generic type with the same name that has
            // public static TCollection CreateRange<TItem>( IEnumerable<TItem> )
            if ( collectionType.IsGenericType )
            {
                var collectionName = collectionType.GetGenericTypeDefinition().Name;

                try
                {
                    collectionName = collectionName.Substring( 0, collectionName.IndexOf( '`' ) );

                    var builderType = collectionType.Assembly.GetType( collectionType.Namespace + "." + collectionName, false );

                    if ( builderType != null )
                    {
                        var method = builderType
                            .GetMethods( BindingFlags.Static | BindingFlags.Public )
                            .FirstOrDefault( x => x.Name == "CreateRange"
                                && x.IsGenericMethodDefinition
                                && x.GetParameters().Length == 1
                                && x.GetParameters()[ 0 ].ParameterType.Name.StartsWith( "IEnumerable`" ) );

                        if ( method != null )
                        {
                            method = method.MakeGenericMethod( typeof( TItem ) );

                            if ( method.ReturnType == collectionType )
                            {
                                bufferCtor = () => new List<TItem>();
                                enumerableCtor = (Func<IEnumerable<TItem>, TCollection>)method.CreateDelegate( typeof( Func<IEnumerable<TItem>, TCollection> ) );
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            return false;
        }


        private static Boolean SetupAbstract( ref Func<ICollection<TItem>> bufferCtor )
        {
            var collectionType = typeof( TCollection );

            if ( collectionType.IsAssignableFrom( typeof( List<TItem> ) ) )
            {
                bufferCtor = () => new List<TItem>();
                return true;
            }
            else if ( collectionType.IsAssignableFrom( typeof( HashSet<TItem> ) ) )
            {
                bufferCtor = () => new HashSet<TItem>();
                return true;
            }
            else if ( ReflectionHelpers.IsSubclassOfRawGeneric( collectionType, typeof( IDictionary<,> ), out var args ) ||
                     ReflectionHelpers.IsSubclassOfRawGeneric( collectionType, typeof( IReadOnlyDictionary<,> ), out args ) )
            {
                var dictionaryType = typeof( Dictionary<,> ).MakeGenericType( args );
                bufferCtor = ObjectConstructor.CreateDelegate<Func<ICollection<TItem>>>( dictionaryType.GetConstructor( Type.EmptyTypes ) );
                return true;
            }

            return false;
        }


        private Boolean m_initialized;
        private TCollection m_collection;
        private ICollection<TItem> m_buffer;

        private static readonly Boolean s_canBuild;

        private static readonly Func<IEnumerable<TItem>, TCollection> s_enumerableCtor;
        private static readonly Func<TCollection> s_defaultCtor;  // Only available if void Add( TItem ) method exists.
        private static readonly Action<TCollection, TItem> s_add; // Only available if default ctor exists

        private static readonly Func<ICollection<TItem>> s_bufferCtor;
    }
}
