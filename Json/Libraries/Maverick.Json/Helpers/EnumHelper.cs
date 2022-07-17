using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal static class EnumHelper<T> where T : unmanaged, Enum
    {
        static EnumHelper()
        {
            foreach ( T value in Enum.GetValues( typeof( T ) ) )
            {
                var propertyName = JsonPropertyName.GetOrCreate( value.ToString() );

                s_propertyNames.Add( value, propertyName );
                s_propertyNamesReversed.Add( propertyName.Value, value );
            }
        }


        public static JsonPropertyName ToPropertyName( T value )
        {
            if ( s_propertyNames.TryGetValue( value, out var propertyName ) )
            {
                return propertyName;
            }

            throw new ArgumentException( $"Enum value {value} is not specified in {typeof( T )}." );
        }


        public static T FromPropertyName( String name )
        {
            if ( s_propertyNamesReversed.TryGetValue( name, out var value ) )
            {
                return value;
            }

            throw new ArgumentException( $"Enum value {name} is not specified in {typeof( T )}." );
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static unsafe Int64 Cast( T value )
        {
            var p = &value;
            var result = default( Int64 );

            switch ( sizeof( T ) )
            {
                case 1: result = *( (Byte*)p ); break;
                case 2: result = *( (Int16*)p ); break;
                case 4: result = *( (Int32*)p ); break;
                case 8: result = *( (Int64*)p ); break;
            }

            return result;
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static unsafe T Cast( Int64 value )
        {
            var p = &value;
            var result = default( T );

            switch ( sizeof( T ) )
            {
                case 1: result = *( (T*)p ); break;
                case 2: result = *( (T*)p ); break;
                case 4: result = *( (T*)p ); break;
                case 8: result = *( (T*)p ); break;
            }

            return result;
        }


        private static readonly Dictionary<T, JsonPropertyName> s_propertyNames = new Dictionary<T, JsonPropertyName>();
        private static readonly Dictionary<String, T> s_propertyNamesReversed = new Dictionary<String, T>( StringComparer.OrdinalIgnoreCase );
    }
}
