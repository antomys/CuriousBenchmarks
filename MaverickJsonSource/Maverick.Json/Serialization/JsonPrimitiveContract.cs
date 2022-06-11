using System;
using System.Collections.Generic;

namespace Maverick.Json.Serialization
{
    internal sealed class JsonPrimitiveContract : JsonContract
    {
        public static Boolean TryCreate( Type type, out JsonPrimitiveContract contract )
        {
            if ( s_primitiveTypes.ContainsKey( type ) || type.IsEnum )
            {
                contract = new JsonPrimitiveContract( type );
                return true;
            }

            contract = null;
            return false;
        }


        private JsonPrimitiveContract( Type primitiveType ) : base( primitiveType )
        {
            m_converter = primitiveType.IsEnum ?
                (JsonConverter)Activator.CreateInstance( typeof( EnumConverter<> ).MakeGenericType( primitiveType ) ) :
                (JsonConverter)Activator.CreateInstance( s_primitiveTypes[ primitiveType ] );
        }


        public override void WriteValue( JsonWriter writer, Object value ) => m_converter.WriteObject( writer, value );


        public override Object ReadValue( JsonReader reader, Type objectType ) => m_converter.ReadObject( reader, objectType );


        private readonly JsonConverter m_converter;
        private static readonly Dictionary<Type, Type> s_primitiveTypes = new Dictionary<Type, Type>()
        {
            [ typeof( Byte ) ] = typeof( ByteConverter ),
            [ typeof( SByte ) ] = typeof( SByteConverter ),
            [ typeof( Int16 ) ] = typeof( Int16Converter ),
            [ typeof( UInt16 ) ] = typeof( UInt16Converter ),
            [ typeof( Int32 ) ] = typeof( Int32Converter ),
            [ typeof( UInt32 ) ] = typeof( UInt32Converter ),
            [ typeof( Int64 ) ] = typeof( Int64Converter ),
            [ typeof( UInt64 ) ] = typeof( UInt64Converter ),
            [ typeof( String ) ] = typeof( StringConverter ),
            [ typeof( Single ) ] = typeof( SingleConverter ),
            [ typeof( Double ) ] = typeof( DoubleConverter ),
            [ typeof( Decimal ) ] = typeof( DecimalConverter ),
            [ typeof( Boolean ) ] = typeof( BooleanConverter ),
            [ typeof( Char ) ] = typeof( CharConverter ),
            [ typeof( TimeSpan ) ] = typeof( TimeSpanConverter ),
            [ typeof( DateTime ) ] = typeof( DateTimeConverter ),
            [ typeof( DateTimeOffset ) ] = typeof( DateTimeOffsetConverter ),
            [ typeof( Guid ) ] = typeof( GuidConverter ),
            [ typeof( Byte[] ) ] = typeof( ByteArrayConverter )
        };


        private sealed class ByteConverter : JsonConverter<Byte>
        {
            public override Byte Read( JsonReader reader, Type objectType ) => reader.ReadByte();
            public override void Write( JsonWriter writer, Byte value ) => writer.WriteValue( value );
        }


        private sealed class SByteConverter : JsonConverter<SByte>
        {
            public override SByte Read( JsonReader reader, Type objectType ) => reader.ReadSByte();
            public override void Write( JsonWriter writer, SByte value ) => writer.WriteValue( value );
        }


        private sealed class Int16Converter : JsonConverter<Int16>
        {
            public override Int16 Read( JsonReader reader, Type objectType ) => reader.ReadInt16();
            public override void Write( JsonWriter writer, Int16 value ) => writer.WriteValue( value );
        }


        private sealed class UInt16Converter : JsonConverter<UInt16>
        {
            public override UInt16 Read( JsonReader reader, Type objectType ) => reader.ReadUInt16();
            public override void Write( JsonWriter writer, UInt16 value ) => writer.WriteValue( value );
        }


        private sealed class Int32Converter : JsonConverter<Int32>
        {
            public override Int32 Read( JsonReader reader, Type objectType ) => reader.ReadInt32();
            public override void Write( JsonWriter writer, Int32 value ) => writer.WriteValue( value );
        }


        private sealed class UInt32Converter : JsonConverter<UInt32>
        {
            public override UInt32 Read( JsonReader reader, Type objectType ) => reader.ReadUInt32();
            public override void Write( JsonWriter writer, UInt32 value ) => writer.WriteValue( value );
        }


        private sealed class Int64Converter : JsonConverter<Int64>
        {
            public override Int64 Read( JsonReader reader, Type objectType ) => reader.ReadInt64();
            public override void Write( JsonWriter writer, Int64 value ) => writer.WriteValue( value );
        }


        private sealed class UInt64Converter : JsonConverter<UInt64>
        {
            public override UInt64 Read( JsonReader reader, Type objectType ) => reader.ReadUInt64();
            public override void Write( JsonWriter writer, UInt64 value ) => writer.WriteValue( value );
        }


        private sealed class StringConverter : JsonConverter<String>
        {
            public override String Read( JsonReader reader, Type objectType ) => reader.ReadString();
            public override void Write( JsonWriter writer, String value ) => writer.WriteValue( value );
        }


        private sealed class SingleConverter : JsonConverter<Single>
        {
            public override Single Read( JsonReader reader, Type objectType ) => reader.ReadSingle();
            public override void Write( JsonWriter writer, Single value ) => writer.WriteValue( value );
        }


        private sealed class DoubleConverter : JsonConverter<Double>
        {
            public override Double Read( JsonReader reader, Type objectType ) => reader.ReadDouble();
            public override void Write( JsonWriter writer, Double value ) => writer.WriteValue( value );
        }


        private sealed class DecimalConverter : JsonConverter<Decimal>
        {
            public override Decimal Read( JsonReader reader, Type objectType ) => reader.ReadDecimal();
            public override void Write( JsonWriter writer, Decimal value ) => writer.WriteValue( value );
        }


        private sealed class BooleanConverter : JsonConverter<Boolean>
        {
            public override Boolean Read( JsonReader reader, Type objectType ) => reader.ReadBoolean();
            public override void Write( JsonWriter writer, Boolean value ) => writer.WriteValue( value );
        }


        private sealed class CharConverter : JsonConverter<Char>
        {
            public override Char Read( JsonReader reader, Type objectType ) => reader.ReadChar();
            public override void Write( JsonWriter writer, Char value ) => writer.WriteValue( value );
        }


        private sealed class TimeSpanConverter : JsonConverter<TimeSpan>
        {
            public override TimeSpan Read( JsonReader reader, Type objectType ) => reader.ReadTimeSpan();
            public override void Write( JsonWriter writer, TimeSpan value ) => writer.WriteValue( value );
        }


        private sealed class DateTimeConverter : JsonConverter<DateTime>
        {
            public override DateTime Read( JsonReader reader, Type objectType ) => reader.ReadDateTime();
            public override void Write( JsonWriter writer, DateTime value ) => writer.WriteValue( value );
        }


        private sealed class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
        {
            public override DateTimeOffset Read( JsonReader reader, Type objectType ) => reader.ReadDateTimeOffset();
            public override void Write( JsonWriter writer, DateTimeOffset value ) => writer.WriteValue( value );
        }


        private sealed class GuidConverter : JsonConverter<Guid>
        {
            public override Guid Read( JsonReader reader, Type objectType ) => reader.ReadGuid();
            public override void Write( JsonWriter writer, Guid value ) => writer.WriteValue( value );
        }


        private sealed class ByteArrayConverter : JsonConverter<Byte[]>
        {
            public override Byte[] Read( JsonReader reader, Type objectType ) => reader.ReadByteArray();
            public override void Write( JsonWriter writer, Byte[] value ) => writer.WriteValue( value );
        }


        private sealed class EnumConverter<T> : JsonConverter<T> where T : unmanaged, Enum
        {
            public override T Read( JsonReader reader, Type objectType ) => EnumHelper<T>.Cast( reader.ReadInt64() );


            public override void Write( JsonWriter writer, T value ) => writer.WriteValue( EnumHelper<T>.Cast( value ) );
        }
    }
}
