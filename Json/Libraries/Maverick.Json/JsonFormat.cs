using System;

namespace Maverick.Json
{
    public enum JsonFormat : Byte
    {
        /// <summary>
        /// No formatting is applied and the object is serialized on a single line with no white space.
        /// </summary>
        None = 0,

        /// <summary>
        /// The object is serialized on a single line but white space is inserted
        /// at various points such as after property name or value.
        /// </summary>
        WhiteSpace = 1,

        /// <summary>
        /// The resulting JSON is fully indented and white spaced where appropriate.
        /// </summary>
        Indented = 2
    }
}
