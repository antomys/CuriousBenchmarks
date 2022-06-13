namespace Maverick.Json.Converters
{
    internal sealed class CollectionNonAllocatingConverter<TCollection, TItem, TEnumerator> : CollectionConverter<TCollection, TItem>
        where TEnumerator : struct
    {
        public override void Write( JsonWriter writer, TCollection value )
        {
            writer.WriteStartArray();

            var enumerator = new Enumerator<TCollection, TItem, TEnumerator>( value );

            while ( enumerator.MoveNext() )
            {
                writer.WriteValue( enumerator.GetCurrent() );
            }

            writer.WriteEndArray();
        }
    }
}
