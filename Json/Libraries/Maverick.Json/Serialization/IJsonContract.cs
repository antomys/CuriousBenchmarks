using System;

namespace Maverick.Json.Serialization
{
    internal interface IJsonContract<T>
    {
        void WriteValue( JsonWriter writer, T value );
        T ReadValue( JsonReader reader, Type objectType );
    }
}
