using System;

namespace Maverick.Json.Serialization
{
    internal interface IJsonPopulateFeature
    {
        Boolean Populate( JsonReader reader, Object target );
        Boolean Copy( Object source, Object target );
    }
}
