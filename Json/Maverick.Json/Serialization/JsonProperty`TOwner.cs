using System;
using System.Reflection;

namespace Maverick.Json.Serialization
{
    /// <summary>
    /// Maps a JSON property to a .NET member or constructor parameter.
    /// </summary>
    public abstract class JsonProperty<TOwner>
    {
        protected private JsonProperty( JsonObjectContract<TOwner> parent, MemberInfo member )
        {
            if ( member == null ) throw new ArgumentNullException( nameof( member ) );

            Parent = parent ?? throw new ArgumentNullException( nameof( parent ) );
            DeclaringType = member.DeclaringType;
            UnderlyingName = member.Name;

            var propertyAttribute = ReflectionHelpers.GetAttribute<JsonPropertyAttribute>( member );
            var mappedName = member.Name;

            if ( propertyAttribute != null )
            {
                Order = propertyAttribute.Order;
                Required = propertyAttribute.Required;
                SerializeNulls = propertyAttribute.ShouldSerializeNulls() ?? parent.Settings.SerializeNulls;

                if ( propertyAttribute.Name != null )
                {
                    mappedName = propertyAttribute.Name;
                }
            }
            else
            {
                SerializeNulls = parent.Settings.SerializeNulls;
            }

            Name = JsonPropertyName.GetOrCreate( mappedName );
            PropertyType = ReflectionHelpers.GetFieldOrPropertyType( member );
            NonNullablePropertyType = Nullable.GetUnderlyingType( PropertyType ) ?? PropertyType;
            Converter = ReflectionHelpers.GetAttribute<JsonConverterAttribute>( member )?.CreateInstance( NonNullablePropertyType );
        }


        public JsonObjectContract<TOwner> Parent { get; }


        public JsonPropertyName Name { get; set; }


        public Type DeclaringType { get; }


        /// <summary>
        /// Returns the type of the property.
        /// </summary>
        public Type PropertyType { get; }


        public Type NonNullablePropertyType { get; }


        internal abstract Int32 MemorySize { get; }


        internal Int32 MemoryOffset { get; set; }


        /// <summary>
        /// The index of the property in <seealso cref="JsonPropertyCollection{TOwner}.Sorted"/> collection.
        /// </summary>
        internal Int32 Index { get; set; }


        /// <summary>
        /// If the property type is a reference then this will represent a sequential number starting from 0
        /// identifying all reference properties in the object.
        /// </summary>
        internal Int32 ReferenceIndex { get; set; } = -1;


        /// <summary>
        /// Returns whether the property can be set - i.e. is not read only.
        /// </summary>
        public abstract Boolean CanSetValue { get; }


        /// <summary>
        /// Returns whether the property can be read and serialized.
        /// </summary>
        /// <remarks>It is unusual that a property is write only - i.e. doesn't have a getter, but it is still possible to write one.</remarks>
        public abstract Boolean CanGetValue { get; }


        /// <summary>
        /// Gets or sets the order of serialization of a member.
        /// </summary>
        public Int32 Order { get; set; }


        /// <summary>
        /// Gets or sets the name of the underlying member.
        /// </summary>
        public String UnderlyingName { get; }


        /// <summary>
        /// Gets or sets the <see cref="JsonConverter" /> for the property.
        /// If set this converter takes precedence over the contract converter for the property type.
        /// </summary>
        /// <value>The converter.</value>
        public JsonConverter Converter { get; set; }


        /// <summary>
        /// Indicates whether the property must be defined in the JSON and must not be null. The default is false.
        /// </summary>
        public Boolean Required { get; set; }


        /// <summary>
        /// Instructs the <seealso cref="JsonWriter"/> to include null values in serialization.
        /// The default value is inherited from <seealso cref="JsonSettings" />.
        /// </summary>
        public Boolean SerializeNulls { get; set; }


        /// <summary>
        /// Gets or sets a predicate used to determine whether the property should be serialized.
        /// </summary>
        public Predicate<TOwner> ShouldSerialize { get; set; }


        /// <summary>
        /// Returns a <see cref="String"/> that represents this instance.
        /// </summary>
        public override String ToString() => Name.ToString();


        internal abstract Object GetValue( TOwner owner );


        internal abstract Object GetValue( ref JsonPropertyValues<TOwner> propertyValues );


        protected internal abstract void WriteValue( JsonWriter writer, TOwner owner );


        internal abstract unsafe void ReadValue( JsonReader reader, ref TOwner owner, bool ownerCreated, ref JsonPropertyValues<TOwner> propertyValues );


        internal abstract void SetValue( ref TOwner target, ref JsonPropertyValues<TOwner> propertyValues );


        internal abstract void SetValue( ref TOwner target, Object value );


        internal abstract Boolean ValueEquals( Object left, Object right );
    }
}
