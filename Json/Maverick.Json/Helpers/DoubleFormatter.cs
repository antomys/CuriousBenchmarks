// https://github.com/google/double-conversion
// Copyright 2006-2011, the V8 project authors.All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//   * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//   * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in documentation
//     and/or other materials provided with the distribution.
//   * Neither the name of Google Inc.nor the names of its contributors may be used to endorse or promote products derived from this software without
//     specific prior written permission.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT ( INCLUDING NEGLIGENCE OR OTHERWISE ) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
using System;
using System.Buffers.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Maverick.Json
{
    internal static class DoubleFormatter
    {
        public static Boolean TryFormat( Single value, Span<Byte> destination, out Int32 bytesWritten )
        {
            Debug.Assert( !Single.IsNaN( value ) );
            Debug.Assert( !Single.IsInfinity( value ) );

            // FastDtoa will produce at most 17 digits
            Span<Byte> buffer = stackalloc Byte[ 17 ];

            if ( !FastDtoa( value, true, buffer, out var digitCount, out var decimal_point ) )
            {
                // Fallback to UTF-8 Formatter
                return Utf8Formatter.TryFormat( value, destination, out bytesWritten );
            }

            return TryFormatCore( destination, buffer, digitCount, decimal_point, value < 0, out bytesWritten );
        }


        public static Boolean TryFormat( Double value, Span<Byte> destination, out Int32 bytesWritten )
        {
            Debug.Assert( !Double.IsNaN( value ) );
            Debug.Assert( !Double.IsInfinity( value ) );

            // FastDtoa will produce at most 17 digits
            Span<Byte> buffer = stackalloc Byte[ 17 ];

            if ( !FastDtoa( value, false, buffer, out var digitCount, out var decimal_point ) )
            {
                // Fallback to UTF-8 Formatter
                return Utf8Formatter.TryFormat( value, destination, out bytesWritten );
            }

            return TryFormatCore( destination, buffer, digitCount, decimal_point, value < 0, out bytesWritten );
        }


        private static Boolean TryFormatCore( Span<Byte> destination,
                                              Span<Byte> buffer,
                                              Int32 digitCount,
                                              Int32 decimal_point,
                                              Boolean negative,
                                              out Int32 bytesWritten )
        {
            // Slice the buffer with only the available amount so we don't need to
            // pass around the buffer actual size.
            buffer = buffer.Slice( 0, digitCount );

            // Find out which notation (decimal or with exponent) is shorter
            var decimalLength = CalculateDecimalLength( digitCount, decimal_point );
            var exponentLength = CalculateExponentLength( digitCount, decimal_point );

            bytesWritten = Math.Min( decimalLength, exponentLength );

            if ( negative )
            {
                ++bytesWritten;
            }

            if ( bytesWritten > destination.Length )
            {
                return false;
            }

            if ( negative )
            {
                destination[ 0 ] = (Byte)'-';
                destination = destination.Slice( 1 );
            }

            if ( decimalLength <= exponentLength )
            {
                CreateDecimalString( buffer, decimal_point, destination );
            }
            else
            {
                CreateExponentString( buffer, decimal_point - 1, destination );
            }

            return true;
        }


        private static Int32 CalculateDecimalLength( Int32 digits, Int32 decimal_point )
        {
            if ( decimal_point == digits )
            {
                return digits;
            }
            else if ( decimal_point < 1 )
            {
                return digits - decimal_point + 2;
            }
            else if ( decimal_point > digits )
            {
                return decimal_point;
            }

            return digits + 1;
        }


        private static Int32 CalculateExponentLength( Int32 digits, Int32 decimal_point )
        {
            var exponentLength = digits + 4; // .E+0
            var exponent = Math.Abs( decimal_point - 1 );

            if ( exponent > 9 )
            {
                ++exponentLength;

                if ( exponent > 99 )
                {
                    ++exponentLength;
                }
            }

            return exponentLength;
        }


        private static void CreateDecimalString( ReadOnlySpan<Byte> digits, Int32 decimal_point, Span<Byte> destination )
        {
            var offset = 0;

            if ( decimal_point <= 0 )
            {
                // "0.00000digits".
                destination[ offset++ ] = (Byte)'0';

                if ( digits.Length > 0 )
                {
                    destination[ offset++ ] = (Byte)'.';

                    while ( decimal_point < 0 )
                    {
                        destination[ offset++ ] = (Byte)'0';
                        ++decimal_point;
                    }

                    digits.CopyTo( destination.Slice( offset ) );
                }
            }
            else
            {
                // digi.ts or digits000.
                digits.Slice( 0, Math.Min( digits.Length, decimal_point ) ).CopyTo( destination );

                if ( decimal_point < digits.Length )
                {
                    destination[ decimal_point ] = (Byte)'.';
                    digits.Slice( decimal_point ).CopyTo( destination.Slice( decimal_point + 1 ) );
                }
                else
                {
                    var trailingZeroes = decimal_point - digits.Length;
                    offset = digits.Length;

                    while ( trailingZeroes-- > 0 )
                    {
                        destination[ offset++ ] = (Byte)'0';
                    }
                }
            }
        }


        private static void CreateExponentString( ReadOnlySpan<Byte> digits, Int32 exponent, Span<Byte> destination )
        {
            destination[ 0 ] = digits[ 0 ];
            var offset = 1;

            if ( digits.Length > 1 )
            {
                destination[ offset++ ] = (Byte)'.';
                digits.Slice( 1 ).CopyTo( destination.Slice( 2 ) );

                offset = digits.Length + 1;
            }

            if ( exponent == 0 )
            {
                return;
            }

            destination[ offset++ ] = (Byte)'E';

            if ( exponent < 0 )
            {
                destination[ offset++ ] = (Byte)'-';
                exponent = -exponent;
            }
            else
            {
                destination[ offset++ ] = (Byte)'+';
            }

            if ( exponent > 99 )
            {
                destination[ offset++ ] = (Byte)( '0' + exponent / 100 );
                exponent %= 100;

                destination[ offset++ ] = (Byte)( '0' + exponent / 10 );
                exponent %= 10;
            }
            else if ( exponent > 9 )
            {
                destination[ offset++ ] = (Byte)( '0' + exponent / 10 );
                exponent %= 10;
            }

            destination[ offset++ ] = (Byte)( '0' + exponent );
        }


        private static Boolean FastDtoa( Double value, Boolean single_precision, Span<Byte> buffer, out Int32 length, out Int32 decimal_point )
        {
            if ( value == 0 )
            {
                length = 0;
                decimal_point = 1;

                return true;
            }
            else if ( value < 0 )
            {
                value = -value;
            }

            var result = Grisu3( value, single_precision, buffer, out length, out var decimal_exponent );
            decimal_point = result ? length + decimal_exponent : 0;

            return result;
        }


        private static Boolean Grisu3( Double v, Boolean single_precision, Span<Byte> buffer, out Int32 length, out Int32 decimal_exponent )
        {
            var w = new DiyDouble( v ).AsNormalizedDiyFp();

            // boundary_minus and boundary_plus are the boundaries between v and its
            // closest floating-point neighbors. Any number strictly between
            // boundary_minus and boundary_plus will round to v when convert to a double.
            // Grisu3 will never output representations that lie exactly on a boundary.
            DiyFp boundary_minus, boundary_plus;

            if ( single_precision )
            {
                new DiySingle( (Single)v ).NormalizedBoundaries( out boundary_minus, out boundary_plus );
            }
            else
            {
                new DiyDouble( v ).NormalizedBoundaries( out boundary_minus, out boundary_plus );
            }

            Debug.Assert( boundary_plus.Exponent == w.Exponent );

            var ten_mk_minimal_binary_exponent = MINIMAL_TARGET_EXPONENT - ( w.Exponent + DiyFp.SignificantSize );
            var ten_mk_maximal_binary_exponent = MAXIMAL_TARGET_EXPONENT - ( w.Exponent + DiyFp.SignificantSize );

            // Note that ten_mk is only an approximation of 10^-k. A DiyFp only contains a
            // 64 bit significand and ten_mk is thus only precise up to 64 bits.
            GetCachedPowerForBinaryExponentRange( ten_mk_minimal_binary_exponent,
                                                  ten_mk_maximal_binary_exponent,
                                                  out var ten_mk,
                                                  out var mk );

            Debug.Assert( MINIMAL_TARGET_EXPONENT <= w.Exponent + ten_mk.Exponent + DiyFp.SignificantSize );
            Debug.Assert( MAXIMAL_TARGET_EXPONENT >= w.Exponent + ten_mk.Exponent + DiyFp.SignificantSize );

            // The DiyFp.Times procedure rounds its result, and ten_mk is approximated
            // too. The variable scaled_w (as well as scaled_boundary_minus/plus) are now
            // off by a small amount.
            // In fact: scaled_w - w*10^k < 1ulp (unit in the last place) of scaled_w.
            // In other words: let f = scaled_w.f() and e = scaled_w.e(), then (f-1) * 2^e < w*10^k < (f+1) * 2^e
            var scaled_w = DiyFp.Times( w, ten_mk );

            Debug.Assert( scaled_w.Exponent == boundary_plus.Exponent + ten_mk.Exponent + DiyFp.SignificantSize );

            // In theory it would be possible to avoid some recomputations by computing
            // the difference between w and boundary_minus/plus (a power of 2) and to
            // compute scaled_boundary_minus/plus by subtracting/adding from
            // scaled_w. However the code becomes much less readable and the speed enhancements are not terriffic.
            var scaled_boundary_minus = DiyFp.Times( boundary_minus, ten_mk );
            var scaled_boundary_plus = DiyFp.Times( boundary_plus, ten_mk );

            // DigitGen will generate the digits of scaled_w. Therefore we have
            // v == (double) (scaled_w * 10^-mk).
            // Set decimal_exponent == -mk and pass it to DigitGen. If scaled_w is not an
            // integer than it will be updated. For instance if scaled_w == 1.23 then
            // the buffer will be filled with "123" und the decimal_exponent will be decreased by 2.
            var result = DigitGen( scaled_boundary_minus,
                                   scaled_w,
                                   scaled_boundary_plus,
                                   buffer,
                                   out length,
                                   out var kappa );
            decimal_exponent = -mk + kappa;

            return result;
        }


        private static Boolean DigitGen( DiyFp low,
                                         DiyFp w,
                                         DiyFp high,
                                         Span<Byte> buffer,
                                         out Int32 length,
                                         out Int32 kappa )
        {
            Debug.Assert( low.Exponent == w.Exponent && w.Exponent == high.Exponent );
            Debug.Assert( low.Significand + 1 <= high.Significand - 1 );
            Debug.Assert( MINIMAL_TARGET_EXPONENT <= w.Exponent && w.Exponent <= MAXIMAL_TARGET_EXPONENT );

            // low, w and high are imprecise, but by less than one ulp (unit in the last place).
            // If we remove (resp. add) 1 ulp from low (resp. high) we are certain that
            // the new numbers are outside of the interval we want the final representation to lie in.
            // Inversely adding (resp. removing) 1 ulp from low (resp. high) would yield
            // numbers that are certain to lie in the interval. We will use this fact later on.
            // We will now start by generating the digits within the uncertain
            // interval. Later we will weed out representations that lie outside the safe
            // interval and thus _might_ lie outside the correct interval.
            UInt64 unit = 1;
            var too_low = new DiyFp( low.Significand - unit, low.Exponent );
            var too_high = new DiyFp( high.Significand + unit, high.Exponent );
            // too_low and too_high are guaranteed to lie outside the interval we want the generated number in.
            var unsafe_interval = DiyFp.Minus( too_high, too_low );
            // We now cut the input number into two parts: the integral digits and the
            // fractionals. We will not write any decimal separator though, but adapt
            // kappa instead.
            // Reminder: we are currently computing the digits (stored inside the buffer)
            // such that:   too_low < buffer * 10^kappa < too_high
            // We use too_high for the digit_generation and stop as soon as possible.
            // If we stop early we effectively round down.
            var one = new DiyFp( 1UL << -w.Exponent, w.Exponent );
            // Division by one is a shift.
            var integrals = (UInt32)( too_high.Significand >> -one.Exponent );
            // Modulo by one is an and.
            var fractionals = too_high.Significand & ( one.Significand - 1 );

            BiggestPowerTen( integrals, DiyFp.SignificantSize - ( -one.Exponent ), out var divisor, out var divisor_exponent_plus_one );
            kappa = divisor_exponent_plus_one;
            length = 0;

            // Loop invariant: buffer = too_high / 10^kappa  (integer division)
            // The invariant holds for the first iteration: kappa has been initialized
            // with the divisor exponent + 1. And the divisor is the biggest power of ten
            // that is smaller than integrals.
            while ( kappa > 0 )
            {
                var digit = integrals / divisor;
                Debug.Assert( digit <= 9 );
                buffer[ length ] = (Byte)( '0' + digit );
                ++length;
                integrals %= divisor;
                --kappa;
                // Note that kappa now equals the exponent of the divisor and that the
                // invariant thus holds again.
                var rest = ( (UInt64)( integrals ) << -one.Exponent ) + fractionals;
                // Invariant: too_high = buffer * 10^kappa + DiyFp(rest, one.e())
                // Reminder: unsafe_interval.e() == one.e()
                if ( rest < unsafe_interval.Significand )
                {
                    // Rounding down (by not emitting the remaining digits) yields a number
                    // that lies within the unsafe interval.
                    return RoundWeed( buffer,
                                      length,
                                      DiyFp.Minus( too_high, w ).Significand,
                                      unsafe_interval.Significand,
                                      rest,
                                      (UInt64)( divisor ) << -one.Exponent,
                                      unit );
                }

                divisor /= 10;
            }

            // The integrals have been generated. We are at the point of the decimal
            // separator. In the following loop we simply multiply the remaining digits by
            // 10 and divide by one. We just need to pay attention to multiply associated
            // data (like the interval or 'unit'), too.
            // Note that the multiplication by 10 does not overflow, because w.e >= -60
            // and thus one.e >= -60.
            Debug.Assert( one.Exponent >= -60 );
            Debug.Assert( fractionals < one.Significand );
            Debug.Assert( 0xFFFFFFFF_FFFFFFFF / 10 >= one.Significand );

            while ( true )
            {
                fractionals *= 10;
                unit *= 10;
                unsafe_interval.Significand = unsafe_interval.Significand * 10;
                // Integer division by one.
                var digit = (Int32)( fractionals >> -one.Exponent );
                Debug.Assert( digit <= 9 );

                buffer[ length ] = (Byte)( '0' + digit );
                ++length;
                fractionals &= one.Significand - 1;  // Modulo by one.
                --kappa;

                if ( fractionals < unsafe_interval.Significand )
                {
                    return RoundWeed( buffer,
                                      length,
                                      DiyFp.Minus( too_high, w ).Significand * unit,
                                      unsafe_interval.Significand,
                                      fractionals,
                                      one.Significand,
                                      unit );
                }
            }
        }


        // Adjusts the last digit of the generated number, and screens out generated
        // solutions that may be inaccurate. A solution may be inaccurate if it is
        // outside the safe interval, or if we cannot prove that it is closer to the
        // input than a neighboring representation of the same length.
        //
        // Input: * buffer containing the digits of too_high / 10^kappa
        //        * the buffer's length
        //        * distance_too_high_w == (too_high - w).f() * unit
        //        * unsafe_interval == (too_high - too_low).f() * unit
        //        * rest = (too_high - buffer * 10^kappa).f() * unit
        //        * ten_kappa = 10^kappa * unit
        //        * unit = the common multiplier
        // Output: returns true if the buffer is guaranteed to contain the closest
        //    representable number to the input.
        //  Modifies the generated digits in the buffer to approach (round towards) w.
        private static Boolean RoundWeed( Span<Byte> buffer,
                                          Int32 length,
                                          UInt64 distance_too_high_w,
                                          UInt64 unsafe_interval,
                                          UInt64 rest,
                                          UInt64 ten_kappa,
                                          UInt64 unit )
        {
            var small_distance = distance_too_high_w - unit;
            var big_distance = distance_too_high_w + unit;
            // Let w_low  = too_high - big_distance, and
            //     w_high = too_high - small_distance.
            // Note: w_low < w < w_high
            //
            // The real w (* unit) must lie somewhere inside the interval
            // ]w_low; w_high[ (often written as "(w_low; w_high)")

            // Basically the buffer currently contains a number in the unsafe interval
            // ]too_low; too_high[ with too_low < w < too_high
            //
            //  too_high - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //                     ^v 1 unit            ^      ^                 ^      ^
            //  boundary_high ---------------------     .      .                 .      .
            //                     ^v 1 unit            .      .                 .      .
            //   - - - - - - - - - - - - - - - - - - -  +  - - + - - - - - -     .      .
            //                                          .      .         ^       .      .
            //                                          .  big_distance  .       .      .
            //                                          .      .         .       .    rest
            //                              small_distance     .         .       .      .
            //                                          v      .         .       .      .
            //  w_high - - - - - - - - - - - - - - - - - -     .         .       .      .
            //                     ^v 1 unit                   .         .       .      .
            //  w ----------------------------------------     .         .       .      .
            //                     ^v 1 unit                   v         .       .      .
            //  w_low  - - - - - - - - - - - - - - - - - - - - -         .       .      .
            //                                                           .       .      v
            //  buffer --------------------------------------------------+-------+--------
            //                                                           .       .
            //                                                  safe_interval    .
            //                                                           v       .
            //   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     .
            //                     ^v 1 unit                                     .
            //  boundary_low -------------------------                     unsafe_interval
            //                     ^v 1 unit                                     v
            //  too_low  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
            //
            //
            // Note that the value of buffer could lie anywhere inside the range too_low
            // to too_high.
            //
            // boundary_low, boundary_high and w are approximations of the real boundaries
            // and v (the input number). They are guaranteed to be precise up to one unit.
            // In fact the error is guaranteed to be strictly less than one unit.
            //
            // Anything that lies outside the unsafe interval is guaranteed not to round
            // to v when read again.
            // Anything that lies inside the safe interval is guaranteed to round to v
            // when read again.
            // If the number inside the buffer lies inside the unsafe interval but not
            // inside the safe interval then we simply do not know and bail out (returning
            // false).
            //
            // Similarly we have to take into account the imprecision of 'w' when finding
            // the closest representation of 'w'. If we have two potential
            // representations, and one is closer to both w_low and w_high, then we know
            // it is closer to the actual value v.
            //
            // By generating the digits of too_high we got the largest (closest to
            // too_high) buffer that is still in the unsafe interval. In the case where
            // w_high < buffer < too_high we try to decrement the buffer.
            // This way the buffer approaches (rounds towards) w.
            // There are 3 conditions that stop the decrementation process:
            //   1) the buffer is already below w_high
            //   2) decrementing the buffer would make it leave the unsafe interval
            //   3) decrementing the buffer would yield a number below w_high and farther
            //      away than the current number. In other words:
            //              (buffer{-1} < w_high) && w_high - buffer{-1} > buffer - w_high
            // Instead of using the buffer directly we use its distance to too_high.
            // Conceptually rest ~= too_high - buffer
            // We need to do the following tests in this order to avoid over- and
            // underflows.
            Debug.Assert( rest <= unsafe_interval );
            while ( rest < small_distance &&  // Negated condition 1
                   unsafe_interval - rest >= ten_kappa &&  // Negated condition 2
                   ( rest + ten_kappa < small_distance ||  // buffer{-1} > w_high
                    small_distance - rest >= rest + ten_kappa - small_distance ) )
            {
                buffer[ length - 1 ]--;
                rest += ten_kappa;
            }

            // We have approached w+ as much as possible. We now test if approaching w-
            // would require changing the buffer. If yes, then we have two possible
            // representations close to w, but we cannot decide which one is closer.
            if ( rest < big_distance &&
                unsafe_interval - rest >= ten_kappa &&
                ( rest + ten_kappa < big_distance ||
                 big_distance - rest > rest + ten_kappa - big_distance ) )
            {
                return false;
            }

            // Weeding test.
            //   The safe interval is [too_low + 2 ulp; too_high - 2 ulp]
            //   Since too_low = too_high - unsafe_interval this is equivalent to
            //      [too_high - unsafe_interval + 4 ulp; too_high - 2 ulp]
            //   Conceptually we have: rest ~= too_high - buffer
            return ( 2 * unit <= rest ) && ( rest <= unsafe_interval - 4 * unit );
        }


        private static void BiggestPowerTen( UInt32 number, Int32 number_bits, out UInt32 power, out Int32 exponent_plus_one )
        {
            Debug.Assert( number < ( 1u << ( number_bits + 1 ) ) );
            // 1233/4096 is approximately 1/lg(10).
            var exponent_plus_one_guess = ( ( number_bits + 1 ) * 1233 >> 12 );
            // We increment to skip over the first entry in the kPowersOf10 table.
            // Note: kPowersOf10[i] == 10^(i-1).
            exponent_plus_one_guess++;
            // We don't have any guarantees that 2^number_bits <= number.
            if ( number < SMALL_POWERS_OF_TEN[ exponent_plus_one_guess ] )
            {
                exponent_plus_one_guess--;
            }

            power = SMALL_POWERS_OF_TEN[ exponent_plus_one_guess ];
            exponent_plus_one = exponent_plus_one_guess;
        }


        // Returns a cached power-of-ten with a binary exponent in the range
        // [min_exponent; max_exponent] (boundaries included).
        private static void GetCachedPowerForBinaryExponentRange( Int32 min_exponent, Int32 max_exponent, out DiyFp power, out Int32 decimal_exponent )
        {
            const Double D_1_LOG2_10 = 0.30102999566398114;  //  1 / lg(10)

            var kQ = DiyFp.SignificantSize;
            var k = Math.Ceiling( ( min_exponent + kQ - 1 ) * D_1_LOG2_10 );
            var index = ( CACHED_POWERS_OFFSET + (Int32)( k ) - 1 ) / DECIMAL_EXPONENT_DISTANCE + 1;
            var cached_power = CACHED_POWERS[ index ];

            Debug.Assert( min_exponent <= cached_power.binary_exponent );
            Debug.Assert( cached_power.binary_exponent <= max_exponent );

            decimal_exponent = cached_power.decimal_exponent;
            power = new DiyFp( cached_power.significand, cached_power.binary_exponent );
        }


        // The minimal and maximal target exponent define the range of w's binary
        // exponent, where 'w' is the result of multiplying the input by a cached power of ten.
        // A different range might be chosen on a different platform, to optimize digit
        // generation, but a smaller range requires more powers of ten to be cached.
        private const Int32 MINIMAL_TARGET_EXPONENT = -60;
        private const Int32 MAXIMAL_TARGET_EXPONENT = -32;

        private const Int32 DECIMAL_EXPONENT_DISTANCE = 8;
        private const Int32 MIN_DECIMAL_EXPONENT = -348;
        private const Int32 MAX_DECIMAL_EXPONENT = 340;
        private const Int32 CACHED_POWERS_OFFSET = 348;  // -1 * the first decimal_exponent
        private static readonly UInt32[] SMALL_POWERS_OF_TEN = { 0, 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        private static readonly (UInt64 significand, Int16 binary_exponent, Int16 decimal_exponent)[] CACHED_POWERS =
        {
            ( 0xfa8fd5a0_081c0288, -1220, -348 ),
            ( 0xbaaee17f_a23ebf76, -1193, -340 ),
            ( 0x8b16fb20_3055ac76, -1166, -332 ),
            ( 0xcf42894a_5dce35ea, -1140, -324 ),
            ( 0x9a6bb0aa_55653b2d, -1113, -316 ),
            ( 0xe61acf03_3d1a45df, -1087, -308 ),
            ( 0xab70fe17_c79ac6ca, -1060, -300 ),
            ( 0xff77b1fc_bebcdc4f, -1034, -292 ),
            ( 0xbe5691ef_416bd60c, -1007, -284 ),
            ( 0x8dd01fad_907ffc3c, -980, -276 ),
            ( 0xd3515c28_31559a83, -954, -268 ),
            ( 0x9d71ac8f_ada6c9b5, -927, -260 ),
            ( 0xea9c2277_23ee8bcb, -901, -252 ),
            ( 0xaecc4991_4078536d, -874, -244 ),
            ( 0x823c1279_5db6ce57, -847, -236 ),
            ( 0xc2109436_4dfb5637, -821, -228 ),
            ( 0x9096ea6f_3848984f, -794, -220 ),
            ( 0xd77485cb_25823ac7, -768, -212 ),
            ( 0xa086cfcd_97bf97f4, -741, -204 ),
            ( 0xef340a98_172aace5, -715, -196 ),
            ( 0xb23867fb_2a35b28e, -688, -188 ),
            ( 0x84c8d4df_d2c63f3b, -661, -180 ),
            ( 0xc5dd4427_1ad3cdba, -635, -172 ),
            ( 0x936b9fce_bb25c996, -608, -164 ),
            ( 0xdbac6c24_7d62a584, -582, -156 ),
            ( 0xa3ab6658_0d5fdaf6, -555, -148 ),
            ( 0xf3e2f893_dec3f126, -529, -140 ),
            ( 0xb5b5ada8_aaff80b8, -502, -132 ),
            ( 0x87625f05_6c7c4a8b, -475, -124 ),
            ( 0xc9bcff60_34c13053, -449, -116 ),
            ( 0x964e858c_91ba2655, -422, -108 ),
            ( 0xdff97724_70297ebd, -396, -100 ),
            ( 0xa6dfbd9f_b8e5b88f, -369, -92 ),
            ( 0xf8a95fcf_88747d94, -343, -84 ),
            ( 0xb9447093_8fa89bcf, -316, -76 ),
            ( 0x8a08f0f8_bf0f156b, -289, -68 ),
            ( 0xcdb02555_653131b6, -263, -60 ),
            ( 0x993fe2c6_d07b7fac, -236, -52 ),
            ( 0xe45c10c4_2a2b3b06, -210, -44 ),
            ( 0xaa242499_697392d3, -183, -36 ),
            ( 0xfd87b5f2_8300ca0e, -157, -28 ),
            ( 0xbce50864_92111aeb, -130, -20 ),
            ( 0x8cbccc09_6f5088cc, -103, -12 ),
            ( 0xd1b71758_e219652c, -77, -4 ),
            ( 0x9c400000_00000000, -50, 4 ),
            ( 0xe8d4a510_00000000, -24, 12 ),
            ( 0xad78ebc5_ac620000, 3, 20 ),
            ( 0x813f3978_f8940984, 30, 28 ),
            ( 0xc097ce7b_c90715b3, 56, 36 ),
            ( 0x8f7e32ce_7bea5c70, 83, 44 ),
            ( 0xd5d238a4_abe98068, 109, 52 ),
            ( 0x9f4f2726_179a2245, 136, 60 ),
            ( 0xed63a231_d4c4fb27, 162, 68 ),
            ( 0xb0de6538_8cc8ada8, 189, 76 ),
            ( 0x83c7088e_1aab65db, 216, 84 ),
            ( 0xc45d1df9_42711d9a, 242, 92 ),
            ( 0x924d692c_a61be758, 269, 100 ),
            ( 0xda01ee64_1a708dea, 295, 108 ),
            ( 0xa26da399_9aef774a, 322, 116 ),
            ( 0xf209787b_b47d6b85, 348, 124 ),
            ( 0xb454e4a1_79dd1877, 375, 132 ),
            ( 0x865b8692_5b9bc5c2, 402, 140 ),
            ( 0xc83553c5_c8965d3d, 428, 148 ),
            ( 0x952ab45c_fa97a0b3, 455, 156 ),
            ( 0xde469fbd_99a05fe3, 481, 164 ),
            ( 0xa59bc234_db398c25, 508, 172 ),
            ( 0xf6c69a72_a3989f5c, 534, 180 ),
            ( 0xb7dcbf53_54e9bece, 561, 188 ),
            ( 0x88fcf317_f22241e2, 588, 196 ),
            ( 0xcc20ce9b_d35c78a5, 614, 204 ),
            ( 0x98165af3_7b2153df, 641, 212 ),
            ( 0xe2a0b5dc_971f303a, 667, 220 ),
            ( 0xa8d9d153_5ce3b396, 694, 228 ),
            ( 0xfb9b7cd9_a4a7443c, 720, 236 ),
            ( 0xbb764c4c_a7a44410, 747, 244 ),
            ( 0x8bab8eef_b6409c1a, 774, 252 ),
            ( 0xd01fef10_a657842c, 800, 260 ),
            ( 0x9b10a4e5_e9913129, 827, 268 ),
            ( 0xe7109bfb_a19c0c9d, 853, 276 ),
            ( 0xac2820d9_623bf429, 880, 284 ),
            ( 0x80444b5e_7aa7cf85, 907, 292 ),
            ( 0xbf21e440_03acdd2d, 933, 300 ),
            ( 0x8e679c2f_5e44ff8f, 960, 308 ),
            ( 0xd433179d_9c8cb841, 986, 316 ),
            ( 0x9e19db92_b4e31ba9, 1013, 324 ),
            ( 0xeb96bf6e_badf77d9, 1039, 332 ),
            ( 0xaf87023b_9bf0ee6b, 1066, 340 ),
        };


        private struct DiyFp
        {
            public const Int32 SignificantSize = 64;


            public DiyFp( UInt64 significand, Int32 exponent )
            {
                Significand = significand;
                Exponent = exponent;
            }


            public UInt64 Significand { get; set; }
            public Int32 Exponent { get; set; }


            public void Normalize()
            {
                Debug.Assert( Significand != 0 );

                var significand = Significand;
                var exponent = Exponent;

                // This method is mainly called for normalizing boundaries. In general
                // boundaries need to be shifted by 10 bits. We thus optimize for this case.
                const UInt64 TEN_MSBits = 0xFFC00000UL << 32;

                while ( ( significand & TEN_MSBits ) == 0 )
                {
                    significand <<= 10;
                    exponent -= 10;
                }

                while ( ( significand & 0x80000000_00000000 ) == 0 )
                {
                    significand <<= 1;
                    exponent--;
                }

                Significand = significand;
                Exponent = exponent;
            }


            [MethodImpl( MethodImplOptions.AggressiveInlining )]
            public static DiyFp Times( DiyFp a, DiyFp b )
            {
                var result = a;
                result.Multiply( b );

                return result;
            }


            [MethodImpl( MethodImplOptions.AggressiveInlining )]
            public static DiyFp Normalize( DiyFp a )
            {
                var result = a;
                result.Normalize();

                return result;
            }


            public void Multiply( DiyFp other )
            {
                // Simply "emulates" a 128 bit multiplication.
                // However: the resulting number only contains 64 bits. The least
                // significant 64 bits are only used for rounding the most significant 64 bits.
                const UInt64 M32 = 0xFFFFFFFFU;

                var a = Significand >> 32;
                var b = Significand & M32;
                var c = other.Significand >> 32;
                var d = other.Significand & M32;
                var ac = a * c;
                var bc = b * c;
                var ad = a * d;
                var bd = b * d;
                var tmp = ( bd >> 32 ) + ( ad & M32 ) + ( bc & M32 );

                // By adding 1U << 31 to tmp we round the final result.
                // Halfway cases will be round up.
                tmp += 1U << 31;

                Exponent += other.Exponent + 64;
                Significand = ac + ( ad >> 32 ) + ( bc >> 32 ) + ( tmp >> 32 );
            }


            public void Subtract( DiyFp other )
            {
                Debug.Assert( Exponent == other.Exponent );
                Debug.Assert( Significand >= other.Significand );

                Significand -= other.Significand;
            }


            [MethodImpl( MethodImplOptions.AggressiveInlining )]
            public static DiyFp Minus( DiyFp a, DiyFp b )
            {
                var result = a;
                result.Subtract( b );

                return result;
            }
        }


        private struct DiyDouble
        {
            public unsafe DiyDouble( Double d )
            {
                m_value = *(UInt64*)( &d );
            }


            public DiyFp AsDiyFp() => new DiyFp( Significand(), Exponent() );


            public DiyFp AsNormalizedDiyFp()
            {
                var f = Significand();
                var e = Exponent();

                // The current double could be a denormal.
                while ( ( f & HiddenBit ) == 0 )
                {
                    f <<= 1;
                    e--;
                }

                // Do the final shifts in one go.
                f <<= DiyFp.SignificantSize - SignificandSize;
                e -= DiyFp.SignificantSize - SignificandSize;

                return new DiyFp( f, e );
            }


            public void NormalizedBoundaries( out DiyFp minus, out DiyFp plus )
            {
                Debug.Assert( Value() > 0.0 );

                var v = AsDiyFp();
                plus = DiyFp.Normalize( new DiyFp( ( v.Significand << 1 ) + 1, v.Exponent - 1 ) );
                minus = IsLowerBoundaryCloser() ?
                     new DiyFp( ( v.Significand << 2 ) - 1, v.Exponent - 2 ) :
                     new DiyFp( ( v.Significand << 1 ) - 1, v.Exponent - 1 );

                minus.Significand = minus.Significand << ( minus.Exponent - plus.Exponent );
                minus.Exponent = plus.Exponent;
            }


            public Int32 Exponent()
            {
                if ( IsDenormal() ) return DenormalExponent;

                var biased_e = (Int32)( ( m_value & ExponentMask ) >> PhysicalSignificandSize );

                return biased_e - ExponentBias;
            }


            public UInt64 Significand()
            {
                var significand = m_value & SignificandMask;

                if ( !IsDenormal() )
                {
                    return significand + HiddenBit;
                }

                return significand;
            }


            public Boolean IsDenormal() => ( m_value & ExponentMask ) == 0;


            public unsafe Double Value()
            {
                var value = m_value;

                return *(Double*)( &value );
            }


            private Boolean IsLowerBoundaryCloser()
            {
                // The boundary is closer if the significand is of the form f == 2^p-1 then
                // the lower boundary is closer.
                // Think of v = 1000e10 and v- = 9999e9.
                // Then the boundary (== (v - v-)/2) is not just at a distance of 1e9 but
                // at a distance of 1e8.
                // The only exception is for the smallest normal: the largest denormal is
                // at the same distance as its successor.
                // Note: denormals have the same exponent as the smallest normals.
                var physical_significand_is_zero = ( ( m_value & SignificandMask ) == 0 );

                return physical_significand_is_zero && ( Exponent() != DenormalExponent );
            }


            private readonly UInt64 m_value;

            private const UInt64 SignMask = 0x80000000_00000000;
            private const UInt64 ExponentMask = 0x7FF00000_00000000;
            private const UInt64 SignificandMask = 0x000FFFFF_FFFFFFFF;
            private const UInt64 HiddenBit = 0x00100000_00000000;
            private const Int32 PhysicalSignificandSize = 52;  // Excludes the hidden bit.
            private const Int32 SignificandSize = 53;

            private const Int32 ExponentBias = 0x3FF + PhysicalSignificandSize;
            private const Int32 DenormalExponent = -ExponentBias + 1;
            private const Int32 MaxExponent = 0x7FF - ExponentBias;
            private const UInt64 Infinity = 0x7FF00000_00000000;
            private const UInt64 NaN = 0x7FF80000_00000000;
        }


        private struct DiySingle
        {
            public unsafe DiySingle( Single value )
            {
                m_value = *(UInt32*)( &value );
            }


            public void NormalizedBoundaries( out DiyFp minus, out DiyFp plus )
            {
                Debug.Assert( Value() > 0.0 );

                var v = AsDiyFp();
                plus = DiyFp.Normalize( new DiyFp( ( v.Significand << 1 ) + 1, v.Exponent - 1 ) );
                minus = IsLowerBoundaryCloser() ?
                    new DiyFp( ( v.Significand << 2 ) - 1, v.Exponent - 2 ) :
                    new DiyFp( ( v.Significand << 1 ) - 1, v.Exponent - 1 );

                minus.Significand = minus.Significand << ( minus.Exponent - plus.Exponent );
                minus.Exponent = plus.Exponent;
            }


            public DiyFp AsDiyFp() => new DiyFp( Significand(), Exponent() );


            public Int32 Exponent()
            {
                if ( IsDenormal ) return DenormalExponent;

                var biased_e = (Int32)( ( m_value & ExponentMask ) >> PhysicalSignificandSize );

                return biased_e - ExponentBias;
            }


            public UInt32 Significand()
            {
                var significand = m_value & SignificandMask;

                if ( !IsDenormal )
                {
                    return significand + HiddenBit;
                }

                return significand;
            }


            public Boolean IsDenormal => ( m_value & ExponentMask ) == 0;


            public Boolean IsSpecial => ( m_value & ExponentMask ) == ExponentMask;


            public unsafe Single Value()
            {
                var value = m_value;

                return *(Single*)( &value );
            }


            private Boolean IsLowerBoundaryCloser()
            {
                // The boundary is closer if the significand is of the form f == 2^p-1 then
                // the lower boundary is closer.
                // Think of v = 1000e10 and v- = 9999e9.
                // Then the boundary (== (v - v-)/2) is not just at a distance of 1e9 but
                // at a distance of 1e8.
                // The only exception is for the smallest normal: the largest denormal is
                // at the same distance as its successor.
                // Note: denormals have the same exponent as the smallest normals.
                var physical_significand_is_zero = ( ( m_value & SignificandMask ) == 0 );

                return physical_significand_is_zero && ( Exponent() != DenormalExponent );
            }


            private readonly UInt32 m_value;

            private const UInt32 SignMask = 0x80000000;
            private const UInt32 ExponentMask = 0x7F800000;
            private const UInt32 SignificandMask = 0x007FFFFF;
            private const UInt32 HiddenBit = 0x00800000;
            private const Int32 PhysicalSignificandSize = 23;  // Excludes the hidden bit.
            private const Int32 SignificandSize = 24;

            private const Int32 ExponentBias = 0x7F + PhysicalSignificandSize;
            private const Int32 DenormalExponent = -ExponentBias + 1;
            private const Int32 MaxExponent = 0xFF - ExponentBias;
            private const UInt32 Infinity = 0x7F800000;
            private const UInt32 NaN = 0x7FC00000;
        }
    }
}
