using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Maverick.Json.Converters;
using Maverick.Json.Serialization;

namespace Maverick.Json
{
    /// <summary>
    /// The <see cref="JsonSettings"/> enables you to control how objects are encoded into JSON.
    /// </summary>
    public class JsonSettings
    {
        public static readonly JsonSettings Default = new JsonSettings();


        public JsonSettings()
        {
            m_contractResolver = new JsonContractResolver();
            m_contractFactory = new Func<Type, JsonContract>( CreateObjectContract );

            Converters.Add( new VersionConverter() );
        }


        /// <summary>
        /// Gets or sets the naming strategy used to resolve how property names are serialized.
        /// </summary>
        public JsonNamingStrategy NamingStrategy { get; set; }


        /// <summary>
        /// Instructs the <seealso cref="JsonWriter"/> whether null values should be included in the output JSON. The default is false.
        /// </summary>
        public Boolean SerializeNulls { get; set; }


        /// <summary>
        /// Gets or sets the contract resolver used by the serializer when serializing .NET objects to JSON and vice versa.
        /// </summary>
        public JsonContractResolver ContractResolver
        {
            get => m_contractResolver;
            set
            {
                m_contractResolver = value ?? throw new ArgumentNullException( nameof( value ) );
                m_contracts.Clear();
            }
        }


        /// <summary>
        /// Indicates whether JSON text output is formatted. The default is <see cref="JsonFormat.None"/>.
        /// </summary>
        public JsonFormat Format { get; set; }


        /// <summary>
        /// A collection of <see cref="JsonConverter"/> that will be used during serialization.
        /// </summary>
        public List<JsonConverter> Converters { get; } = new List<JsonConverter>();


        public JsonContract ResolveContract( Type objectType ) => m_contracts.GetOrAdd( objectType, m_contractFactory );


        private JsonContract CreateObjectContract( Type objectType )
        {
            // Nullable<T> is not allowed to have a contract
            if ( objectType.IsValueType && objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
            {
                return m_contracts.GetOrAdd( Nullable.GetUnderlyingType( objectType ), m_contractFactory );
            }

            return m_contractResolver.CreateContract( objectType, this );
        }


        private JsonContractResolver m_contractResolver;
        private readonly ConcurrentDictionary<Type, JsonContract> m_contracts = new ConcurrentDictionary<Type, JsonContract>();
        private readonly Func<Type, JsonContract> m_contractFactory;
    }
}
