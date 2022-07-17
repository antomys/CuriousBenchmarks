using System;

namespace Maverick.Json
{
    /// <summary>
    /// Instructs the serializer that only members marked with <see cref="JsonPropertyAttribute" />
    /// should be serialized.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public sealed class JsonExplicitMembersAttribute : Attribute
    {
    }
}
