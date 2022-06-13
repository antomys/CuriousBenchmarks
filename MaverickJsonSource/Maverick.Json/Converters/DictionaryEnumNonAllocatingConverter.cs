using System;
using System.Collections.Generic;

namespace Maverick.Json.Converters
{
    internal sealed class DictionaryEnumNonAllocatingConverter<TDictionary, TKey, TValue, TEnumerator> : DictionaryEnumConverter<TDictionary, TKey, TValue>
        where TDictionary : IDictionary<TKey, TValue>
        where TKey : unmanaged, Enum
        where TEnumerator : struct
    {
        public override void Write( JsonWriter writer, TDictionary value )
        {
            writer.WriteStartObject();

            var enumerator = new Enumerator<TDictionary, KeyValuePair<TKey, TValue>, TEnumerator>( value );

            while ( enumerator.MoveNext() )
            {
                var item = enumerator.GetCurrent();

                writer.WritePropertyName( EnumHelper<TKey>.ToPropertyName( item.Key ) );
                writer.WriteValue( item.Value );
            }

            writer.WriteEndObject();
        }
    }
}
