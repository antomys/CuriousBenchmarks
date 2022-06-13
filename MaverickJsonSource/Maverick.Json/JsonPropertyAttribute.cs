using System;

namespace Maverick.Json
{
    /// <summary>
    /// Instructs the <see cref="JsonSettings"/> to always serialize the member with the specified name.
    /// </summary>
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false )]
    public sealed class JsonPropertyAttribute : Attribute
    {
        public JsonPropertyAttribute()
        {
        }


        public JsonPropertyAttribute( String name )
        {
            Name = name;
        }


        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        public String Name { get; }


        /// <summary>
        /// Gets or sets the order of serialization of a member.
        /// </summary>
        public Int32 Order { get; set; } = Int32.MaxValue;


        /// <summary>
        /// Indicates whether the property must be defined in the JSON. The default is false.
        /// </summary>
        public Boolean Required { get; set; }


        public Boolean SerializeNulls
        {
            get => m_serializeNulls ?? false;
            set => m_serializeNulls = value;
        }


        public Boolean? ShouldSerializeNulls() => m_serializeNulls;


        // Attributes doesn't support nullable properties
        private Boolean? m_serializeNulls;
    }
}
