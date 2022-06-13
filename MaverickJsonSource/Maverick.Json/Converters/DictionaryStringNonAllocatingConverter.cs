using System;
using System.Collections.Generic;

namespace Maverick.Json.Converters
{
    internal sealed class DictionaryStringNonAllocatingConverter<TDictionary, TValue, TEnumerator> : DictionaryStringConverter<TDictionary, TValue>
        where TDictionary : IDictionary<String, TValue>
        where TEnumerator : struct
    {
        public override void Write( JsonWriter writer, TDictionary value )
        {
            writer.WriteStartObject();

            var enumerator = new Enumerator<TDictionary, KeyValuePair<String, TValue>, TEnumerator>( value );

            while ( enumerator.MoveNext() )
            {
                var item = enumerator.GetCurrent();

                writer.WritePropertyName( item.Key );
                writer.WriteValue( item.Value );
            }

            writer.WriteEndObject();
        }
    }
}
