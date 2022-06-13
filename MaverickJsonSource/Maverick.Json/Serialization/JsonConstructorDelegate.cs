using System;
using System.Runtime.CompilerServices;

namespace Maverick.Json.Serialization
{
    public delegate T JsonConstructorDelegate<T>( ref JsonPropertyValues<T> propertyValues );


    public sealed class JsonConstructor<T>
    {
        public JsonConstructor( JsonConstructorDelegate<T> factory, JsonProperty<T>[] properties )
        {
            Factory = factory ?? throw new ArgumentNullException( nameof( factory ) );
            Properties = properties ?? Array.Empty<JsonProperty<T>>();
        }


        public JsonConstructorDelegate<T> Factory { get; }
        public JsonProperty<T>[] Properties { get; }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        internal Boolean CanExecute( ref JsonPropertyValues<T> propertyValues )
        {
            foreach ( var property in Properties )
            {
                if ( !propertyValues.HasValue( property ) )
                {
                    return false;
                }
            }

            return true;
        }
    }
}
