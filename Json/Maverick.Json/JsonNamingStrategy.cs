using System;

namespace Maverick.Json
{
    /// <summary>
    /// How property names and dictionary keys are serialized.
    /// </summary>
    public enum JsonNamingStrategy : Byte
    {
        /// <summary>
        /// The property names are serialized as is.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The property names are serialized using camel case: e.g. "UserName" becomes "userName".
        /// </summary>
        CamelCase,

        /// <summary>
        /// The property names are serialized using snake case: e.g. "UserName" becomes "user_name".
        /// </summary>
        SnakeCase
    }
}
