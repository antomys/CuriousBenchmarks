using System;
using System.Collections;
using Maverick.Json.Serialization;

namespace Maverick.Json.Converters
{
    internal sealed class CollectionConverter<TCollection> : JsonConverter<TCollection>, IJsonPopulateFeature
    {
        public Boolean Copy( Object source, Object target )
        {
            if ( CollectionAppender<TCollection, Object>.Supported )
            {
                var facade = new CollectionAppender<TCollection, Object>( (TCollection)target );
                facade.Clear();

                foreach ( var item in (IEnumerable)source )
                {
                    facade.Add( item );
                }

                return true;
            }

            return false;
        }


        public Boolean Populate( JsonReader reader, Object target )
        {
            if ( CollectionAppender<TCollection, Object>.Supported )
            {
                var facade = new CollectionAppender<TCollection, Object>( (TCollection)target );
                reader.ReadStartArray();

                while ( reader.Peek() != JsonToken.EndArray )
                {
                    facade.Add( reader.ReadValue<Object>() );
                }

                reader.ReadEndArray();

                return true;
            }

            return false;
        }


        public override TCollection Read( JsonReader reader, Type objectType )
        {
            var builder = new CollectionBuilder<TCollection, Object>();

            reader.ReadStartArray();

            while ( reader.Peek() != JsonToken.EndArray )
            {
                builder.Add( reader.ReadValue<Object>() );
            }

            reader.ReadEndArray();

            return builder.ToCollection();
        }


        public override void Write( JsonWriter writer, TCollection value )
        {
            writer.WriteStartArray();

            foreach ( var item in (IEnumerable)value )
            {
                writer.WriteValue( item );
            }

            writer.WriteEndArray();
        }
    }
}
