using System;

namespace Maverick.Json
{
    public enum JsonToken : Byte
    {
        None = 0,
        PropertyName = 1,
        StartObject = 3,
        StartArray = 4,

        EndObject = 5,
        EndArray = 6,
        Number = 7,
        String = 8,
        Boolean = 9,
        Null = 10,

        Comma = 11,
        WhiteSpace = 12
    }
}
