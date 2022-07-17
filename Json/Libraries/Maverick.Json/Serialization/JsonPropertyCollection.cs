using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Maverick.Json.Serialization
{
    public sealed class JsonPropertyCollection<TOwner>
    {
        internal JsonPropertyCollection( JsonNamingStrategy namingStrategy )
        {
            NameTable = new JsonNameTable<TOwner>( namingStrategy );
        }


        public Int32 Count => m_list.Count;
        internal Int32 ValueMemorySize { get; private set; }
        internal Int32 ReferenceCount { get; private set; }
        internal JsonProperty<TOwner>[] Sorted { get; private set; }
        internal JsonProperty<TOwner>[] SortedWritable { get; private set; }
        internal JsonProperty<TOwner>[] Required { get; private set; }
        internal JsonNameTable<TOwner> NameTable { get; }
        public JsonProperty<TOwner> this[ Int32 index ] => m_list[ index ];


        public Boolean Contains( JsonPropertyName propertyName ) => m_dictionary.ContainsKey( propertyName );


        internal void Freeze()
        {
            m_frozen = true;
            Sorted = m_list.OrderBy( x => x.Order ).ToArray();
            SortedWritable = Sorted.Where( x => x.CanGetValue ).ToArray();
            Required = Sorted.Where( x => x.Required ).ToArray();

            var memoryOffset = 0;

            for ( var i = 0; i < Sorted.Length; i++ )
            {
                var property = Sorted[ i ];

                property.Index = i;

                if ( property.PropertyType.IsValueType )
                {
                    property.MemoryOffset = memoryOffset;

                    memoryOffset += property.MemorySize;
                    ValueMemorySize += property.MemorySize;
                }
                else
                {
                    property.MemoryOffset = -1;
                    property.ReferenceIndex = ReferenceCount++;
                }

                // Add naming lookup record
                NameTable.Add( property );
            }
        }


        public Boolean Remove( JsonPropertyName propertyName )
        {
            CheckNotFrozen();

            if ( m_dictionary.TryGetValue( propertyName, out var properties ) )
            {
                var item = properties.First;

                while ( item != null )
                {
                    if ( item.Value.Name == propertyName )
                    {
                        properties.Remove( item );
                        m_list.Remove( item.Value );

                        if ( properties.Count == 0 )
                        {
                            m_dictionary.Remove( propertyName );
                        }

                        return true;
                    }

                    item = item.Next;
                }
            }

            return false;
        }


        public void Add( JsonProperty<TOwner> property )
        {
            CheckNotFrozen();

            if ( Contains( property.Name ) )
            {
                var existingProperty = FindProperty( property.Name, false );
                var duplicateProperty = true;

                if ( property.DeclaringType != null && existingProperty.DeclaringType != null )
                {
                    if ( property.DeclaringType.IsSubclassOf( existingProperty.DeclaringType )
                        || ( existingProperty.DeclaringType.IsInterface && existingProperty.DeclaringType.IsAssignableFrom( property.DeclaringType ) ) )
                    {
                        // Current property is on a derived class and hides the existing
                        Remove( existingProperty.Name );

                        duplicateProperty = false;
                    }

                    if ( existingProperty.DeclaringType.IsSubclassOf( property.DeclaringType )
                        || ( property.DeclaringType.IsInterface && property.DeclaringType.IsAssignableFrom( existingProperty.DeclaringType ) ) )
                    {
                        // Current property is hidden by the existing so don't add it
                        return;
                    }
                }

                if ( duplicateProperty )
                {
                    throw new JsonSerializationException( $"A member with the name '{property.Name}' already exists on '{typeof( TOwner )}'. Use the JsonPropertyAttribute to specify another name." );
                }
            }

            if ( !m_dictionary.TryGetValue( property.Name, out var properties ) )
            {
                m_dictionary.Add( property.Name, ( properties = new LinkedList<JsonProperty<TOwner>>() ) );
            }

            properties.AddFirst( property );
            m_list.Add( property );
        }


        public void AddRange( JsonPropertyCollection<TOwner> properties )
        {
            for ( var i = 0; i < properties.Count; ++i )
            {
                Add( properties[ i ] );
            }
        }


        public JsonProperty<TOwner> FindProperty( JsonPropertyName propertyName, Boolean ignoreCase )
        {
            if ( m_dictionary.TryGetValue( propertyName, out var properties ) )
            {
                var item = properties.First;

                if ( ignoreCase )
                {
                    return item.Value;
                }

                while ( item != null )
                {
                    if ( item.Value.Name.Value == propertyName.Value )
                    {
                        return item.Value;
                    }

                    item = item.Next;
                }
            }

            return null;
        }


        internal JsonProperty<TOwner> FindProperty( ParameterInfo parameter )
        {
            foreach ( var property in m_list )
            {
                if ( property.UnderlyingName.Equals( parameter.Name, StringComparison.OrdinalIgnoreCase ) &&
                     property.PropertyType == parameter.ParameterType )
                {
                    return property;
                }
            }

            return null;
        }


        private void CheckNotFrozen()
        {
            if ( m_frozen )
            {
                throw new InvalidOperationException( "The collection cannot be modified because it's frozen." );
            }
        }


        private readonly List<JsonProperty<TOwner>> m_list = new List<JsonProperty<TOwner>>();
        private readonly Dictionary<JsonPropertyName, LinkedList<JsonProperty<TOwner>>> m_dictionary = new Dictionary<JsonPropertyName, LinkedList<JsonProperty<TOwner>>>();

        private Boolean m_frozen;
    }
}
