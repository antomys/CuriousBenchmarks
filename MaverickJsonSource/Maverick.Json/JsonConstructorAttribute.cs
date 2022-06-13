using System;

namespace Maverick.Json
{
    [AttributeUsage( AttributeTargets.Constructor, AllowMultiple = false )]
    public sealed class JsonConstructorAttribute : Attribute
    {
    }
}
