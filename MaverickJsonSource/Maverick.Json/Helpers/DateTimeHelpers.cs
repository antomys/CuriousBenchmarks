using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal static class DateTimeHelpers
    {
        /// Largely based on https://raw.githubusercontent.com/dotnet/corefx/f5d31619f821e7b4a0bcf7f648fe1dc2e4e2f09f/src/System.Memory/src/System/Buffers/Text/Utf8Parser/Utf8Parser.Date.O.cs
        /// Copyright (c) .NET Foundation and Contributors

        private const Int32 DaysPer100Years = 36524;
        private const Int32 DaysPer400Years = 146097;
        private const Int32 DaysPer4Years = 1461;
        private const Int32 DaysPerYear = 365;
        private const Int64 TicksPerDay = 864000000000L;
        private static readonly Int32[] DaysToMonth365 = new[] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        private static readonly Int32[] DaysToMonth366 = new[] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366 };


        internal static void GetDateValues( DateTime time, out Int32 year, out Int32 month, out Int32 day )
        {
            var ticks = time.Ticks;
            // n = number of days since 1/1/0001
            var n = (Int32)( ticks / TicksPerDay );
            // y400 = number of whole 400-year periods since 1/1/0001
            var y400 = n / DaysPer400Years;
            // n = day number within 400-year period
            n -= y400 * DaysPer400Years;
            // y100 = number of whole 100-year periods within 400-year period
            var y100 = n / DaysPer100Years;
            // Last 100-year period has an extra day, so decrement result if 4
            if ( y100 == 4 )
            {
                y100 = 3;
            }
            // n = day number within 100-year period
            n -= y100 * DaysPer100Years;
            // y4 = number of whole 4-year periods within 100-year period
            var y4 = n / DaysPer4Years;
            // n = day number within 4-year period
            n -= y4 * DaysPer4Years;
            // y1 = number of whole years within 4-year period
            var y1 = n / DaysPerYear;
            // Last year has an extra day, so decrement result if 4
            if ( y1 == 4 )
            {
                y1 = 3;
            }

            year = y400 * 400 + y100 * 100 + y4 * 4 + y1 + 1;

            // n = day number within year
            n -= y1 * DaysPerYear;

            // Leap year calculation looks different from IsLeapYear since y1, y4,
            // and y100 are relative to year 1, not year 0
            var leapYear = y1 == 3 && ( y4 != 24 || y100 == 3 );
            var days = leapYear ? DaysToMonth366 : DaysToMonth365;
            // All months have less than 32 days, so n >> 5 is a good conservative
            // estimate for the month
            var m = n >> 5 + 1;
            // m = 1-based month number
            while ( n >= days[ m ] )
            {
                m++;
            }

            month = m;

            // Return 1-based day-of-month
            day = n - days[ m - 1 ] + 1;
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean TryParse( in ReadOnlySpan<Byte> source, out DateTimeOffset value, out Int32 bytesConsumed )
        {
            if ( TryParseDate( source, out var date, out bytesConsumed ) )
            {
                value = new DateTimeOffset( date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Offset ).AddTicks( date.Fraction );

                return true;
            }

            value = default;
            bytesConsumed = 0;

            return false;
        }


        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public static Boolean TryParse( in ReadOnlySpan<Byte> source, out DateTime value, out Int32 bytesConsumed )
        {
            if ( TryParseDate( source, out var date, out bytesConsumed ) )
            {
                value = new DateTime( date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind ).AddTicks( date.Fraction );

                switch ( date.Kind )
                {
                    case DateTimeKind.Local:
                        var offset = TimeZoneInfo.Local.GetUtcOffset( value ) - date.Offset;
                        value = value.Add( offset );
                        return true;

                    case DateTimeKind.Unspecified:
                    case DateTimeKind.Utc:
                        return true;
                }
            }

            value = default;
            bytesConsumed = 0;

            return false;
        }


        private static Boolean TryParseDate( in ReadOnlySpan<Byte> source, out Date value, out Int32 bytesConsumed )
        {
            if ( source.Length < 10 )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 year;
            {
                var digit1 = source[ 0 ] - 48U; // '0' (this makes it uint)
                var digit2 = source[ 1 ] - 48U;
                var digit3 = source[ 2 ] - 48U;
                var digit4 = source[ 3 ] - 48U;

                if ( digit1 > 9 || digit2 > 9 || digit3 > 9 || digit4 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                year = (Int32)( digit1 * 1000 + digit2 * 100 + digit3 * 10 + digit4 );
            }

            if ( source[ 4 ] != (Byte)'-' )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 month;
            {
                var digit1 = source[ 5 ] - 48U;
                var digit2 = source[ 6 ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                month = (Int32)( digit1 * 10 + digit2 );
            }

            if ( source[ 7 ] != (Byte)'-' )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 day;
            {
                var digit1 = source[ 8 ] - 48U;
                var digit2 = source[ 9 ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                day = (Int32)( digit1 * 10 + digit2 );
            }

            if ( source.Length == 10 )
            {
                value = new Date( year, month, day, 0, 0, 0, 0, DateTimeKind.Unspecified, TimeSpan.Zero );
                bytesConsumed = 10;
                return true;
            }

            if ( source[ 10 ] != (Byte)'T' )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 hour;
            {
                var digit1 = source[ 11 ] - 48U;
                var digit2 = source[ 12 ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                hour = (Int32)( digit1 * 10 + digit2 );
            }

            if ( source[ 13 ] != (Byte)':' )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 minute;
            {
                var digit1 = source[ 14 ] - 48U;
                var digit2 = source[ 15 ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                minute = (Int32)( digit1 * 10 + digit2 );
            }

            if ( source[ 16 ] != (Byte)':' )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 second;
            {
                var digit1 = source[ 17 ] - 48U;
                var digit2 = source[ 18 ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                second = (Int32)( digit1 * 10 + digit2 );
            }

            var currentOffset = 19; // Up until here everything is fixed
            var fraction = 0;

            if ( source.Length > currentOffset + 1 && source[ currentOffset ] == (Byte)'.' )
            {
                currentOffset++;
                var temp = source[ currentOffset++ ] - 48U; // One needs to exist

                if ( temp > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                var maxDigits = source.Length - currentOffset;
                Int32 digitCount;

                for ( digitCount = 0; digitCount < maxDigits; digitCount++ )
                {
                    var digit = source[ currentOffset ] - 48U;
                    if ( digit > 9 )
                    {
                        break;
                    }

                    if ( digitCount < 6 )
                    {
                        temp = temp * 10 + digit;
                    }

                    currentOffset++;
                }

                digitCount++; // Add one for the first digit

                switch ( digitCount )
                {
                    case 7:
                        break;

                    case 6:
                        temp *= 10;
                        break;

                    case 5:
                        temp *= 100;
                        break;

                    case 4:
                        temp *= 1000;
                        break;

                    case 3:
                        temp *= 10000;
                        break;

                    case 2:
                        temp *= 100000;
                        break;
                    case 1:
                        temp *= 1000000;
                        break;
                }

                fraction = (Int32)temp;
            }

            var offsetChar = source.Length <= currentOffset ? default : source[ currentOffset++ ];

            if ( offsetChar != (Byte)'Z' && offsetChar != (Byte)'+' && offsetChar != (Byte)'-' )
            {
                value = new Date( year, month, day, hour, minute, second, fraction, DateTimeKind.Unspecified, TimeSpan.Zero );
                bytesConsumed = currentOffset;
                return true;
            }

            if ( offsetChar == (Byte)'Z' )
            {
                value = new Date( year, month, day, hour, minute, second, fraction, DateTimeKind.Utc, TimeSpan.Zero );
                bytesConsumed = currentOffset;
                return true;
            }

            Debug.Assert( offsetChar == (Byte)'+' || offsetChar == (Byte)'-' );

            Int32 offsetHours;
            {
                var digit1 = source[ currentOffset++ ] - 48U;
                var digit2 = source[ currentOffset++ ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                offsetHours = (Int32)( digit1 * 10 + digit2 );
            }

            if ( source[ currentOffset++ ] != (Byte)':' )
            {
                value = default;
                bytesConsumed = 0;
                return false;
            }

            Int32 offsetMinutes;
            {
                var digit1 = source[ currentOffset++ ] - 48U;
                var digit2 = source[ currentOffset++ ] - 48U;

                if ( digit1 > 9 || digit2 > 9 )
                {
                    value = default;
                    bytesConsumed = 0;
                    return false;
                }

                offsetMinutes = (Int32)( digit1 * 10 + digit2 );
            }

            if ( offsetChar == (Byte)'-' )
            {
                offsetHours = -offsetHours;
                offsetMinutes = -offsetMinutes;
            }
            var timeSpan = new TimeSpan( offsetHours, offsetMinutes, 0 );
            value = new Date( year, month, day, hour, minute, second, fraction, DateTimeKind.Local, timeSpan );

            bytesConsumed = currentOffset;
            return true;
        }


        private readonly ref struct Date
        {
            public Date( Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second, Int32 fraction, DateTimeKind kind, TimeSpan offset )
            {
                Year = year;
                Month = month;
                Day = day;
                Hour = hour;
                Minute = minute;
                Second = second;
                Fraction = fraction;
                Kind = kind;
                Offset = offset;
            }


            public readonly Int32 Year;
            public readonly Int32 Month;
            public readonly Int32 Day;
            public readonly Int32 Hour;
            public readonly Int32 Minute;
            public readonly Int32 Second;
            public readonly Int32 Fraction;
            public readonly DateTimeKind Kind;
            public readonly TimeSpan Offset;
        }
    }
}
