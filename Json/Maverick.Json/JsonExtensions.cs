using System;

namespace Maverick.Json
{
    public static class JsonExtensions
    {
        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Byte value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Byte? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, SByte value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, SByte? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Int16 value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Int16? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, UInt16 value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, UInt16? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Int32 value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Int32? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, UInt32 value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, UInt32? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Int64 value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Int64? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, UInt64 value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, UInt64? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, String value )
        {
            if ( value == null && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Single value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Single? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Double value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Double? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Decimal value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Decimal? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Boolean value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Boolean? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Char value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Char? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, TimeSpan value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, TimeSpan? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, DateTime value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, DateTime? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, DateTimeOffset value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, DateTimeOffset? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Guid value )
        {
            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Guid? value )
        {
            if ( !value.HasValue && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write( this JsonWriter writer, JsonPropertyName propertyName, Byte[] value )
        {
            if ( value == null && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }


        public static void Write<T>( this JsonWriter writer, JsonPropertyName propertyName, T value )
        {
            if ( value == null && !writer.Settings.SerializeNulls )
            {
                return;
            }

            writer.WritePropertyName( propertyName );
            writer.WriteValue( value );
        }
    }
}
