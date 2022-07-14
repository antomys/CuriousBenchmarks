using System;

namespace Maverick.Json
{
    /// <summary>
    /// Instructs the <see cref="JsonSettings"/> not to serialize the public field or public read/write property value.
    /// </summary>
    [AttributeUsage( AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false )]
    public class JsonIgnoreAttribute : Attribute
    {
    }
}
