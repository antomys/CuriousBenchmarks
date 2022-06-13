using System;
using System.Collections.Generic;
using Maverick.Json.Serialization;

namespace Maverick.Json.Converters
{
    internal class CollectionConverter<TCollection, TItem> : JsonConverter<TCollection>, IJsonPopulateFeature
    {
        public Boolean Copy( Object source, Object target )
        {
            if ( CollectionAppender<TCollection, TItem>.Supported )
            {
                var facade = new CollectionAppender<TCollection, TItem>( (TCollection)target );
                facade.Clear();

                foreach ( var item in (IEnumerable<TItem>)source )
                {
                    facade.Add( item );
                }

                return true;
            }

            return false;
        }


        public Boolean Populate( JsonReader reader, Object target )
        {
            if ( CollectionAppender<TCollection, TItem>.Supported )
            {
                var facade = new CollectionAppender<TCollection, TItem>( (TCollection)target );
                reader.ReadStartArray();

                while ( reader.Peek() != JsonToken.EndArray )
                {
                    facade.Add( reader.ReadValue<TItem>() );
                }

                reader.ReadEndArray();

                return true;
            }

            return false;
        }


        public override TCollection Read( JsonReader reader, Type objectType )
        {
            var builder = new CollectionBuilder<TCollection, TItem>();

            reader.ReadStartArray();

            if ( PrimitiveFormatter<TItem>.CanRead )
            {
                while ( reader.Peek() != JsonToken.EndArray )
                {
                    builder.Add( reader.ReadValue<TItem>() );
                }
            }
            else
            {
                var contract = reader.Settings.ResolveContract( typeof( TItem ) );

                while ( reader.Peek() != JsonToken.EndArray )
                {
                    builder.Add( reader.ReadValueInternal<TItem>( contract ) );
                }
            }

            reader.ReadEndArray();

            return builder.ToCollection();
        }


        public override void Write( JsonWriter writer, TCollection value )
        {
            writer.WriteStartArray();

            foreach ( var item in (IEnumerable<TItem>)value )
            {
                writer.WriteValue( item );
            }

            writer.WriteEndArray();
        }
    }
}
