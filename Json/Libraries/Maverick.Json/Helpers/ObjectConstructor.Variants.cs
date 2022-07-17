using System.Reflection;
using Maverick.Json.Serialization;

namespace Maverick.Json
{
    internal static partial class ObjectConstructor
    {
        private delegate TOwner Constructor<TOwner, P0>( P0 p0 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );

                return ctor( v0 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1>( P0 p0, P1 p1 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );

                return ctor( v0, v1 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2>( P0 p0, P1 p1, P2 p2 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );

                return ctor( v0, v1, v2 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3>( P0 p0, P1 p1, P2 p2, P3 p3 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );

                return ctor( v0, v1, v2, v3 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );

                return ctor( v0, v1, v2, v3, v4 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );

                return ctor( v0, v1, v2, v3, v4, v5 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );

                return ctor( v0, v1, v2, v3, v4, v5, v6 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93, P94 p94 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93, JsonProperty<TOwner, P94> p94 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );
                var v94 = propertyValues.GetValue( p94 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93, P94 p94, P95 p95 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93, JsonProperty<TOwner, P94> p94, JsonProperty<TOwner, P95> p95 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );
                var v94 = propertyValues.GetValue( p94 );
                var v95 = propertyValues.GetValue( p95 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93, P94 p94, P95 p95, P96 p96 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93, JsonProperty<TOwner, P94> p94, JsonProperty<TOwner, P95> p95, JsonProperty<TOwner, P96> p96 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );
                var v94 = propertyValues.GetValue( p94 );
                var v95 = propertyValues.GetValue( p95 );
                var v96 = propertyValues.GetValue( p96 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93, P94 p94, P95 p95, P96 p96, P97 p97 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93, JsonProperty<TOwner, P94> p94, JsonProperty<TOwner, P95> p95, JsonProperty<TOwner, P96> p96, JsonProperty<TOwner, P97> p97 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );
                var v94 = propertyValues.GetValue( p94 );
                var v95 = propertyValues.GetValue( p95 );
                var v96 = propertyValues.GetValue( p96 );
                var v97 = propertyValues.GetValue( p97 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97, P98>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93, P94 p94, P95 p95, P96 p96, P97 p97, P98 p98 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97, P98>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93, JsonProperty<TOwner, P94> p94, JsonProperty<TOwner, P95> p95, JsonProperty<TOwner, P96> p96, JsonProperty<TOwner, P97> p97, JsonProperty<TOwner, P98> p98 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97, P98>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );
                var v94 = propertyValues.GetValue( p94 );
                var v95 = propertyValues.GetValue( p95 );
                var v96 = propertyValues.GetValue( p96 );
                var v97 = propertyValues.GetValue( p97 );
                var v98 = propertyValues.GetValue( p98 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98 );
            };
        }

        private delegate TOwner Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97, P98, P99>( P0 p0, P1 p1, P2 p2, P3 p3, P4 p4, P5 p5, P6 p6, P7 p7, P8 p8, P9 p9, P10 p10, P11 p11, P12 p12, P13 p13, P14 p14, P15 p15, P16 p16, P17 p17, P18 p18, P19 p19, P20 p20, P21 p21, P22 p22, P23 p23, P24 p24, P25 p25, P26 p26, P27 p27, P28 p28, P29 p29, P30 p30, P31 p31, P32 p32, P33 p33, P34 p34, P35 p35, P36 p36, P37 p37, P38 p38, P39 p39, P40 p40, P41 p41, P42 p42, P43 p43, P44 p44, P45 p45, P46 p46, P47 p47, P48 p48, P49 p49, P50 p50, P51 p51, P52 p52, P53 p53, P54 p54, P55 p55, P56 p56, P57 p57, P58 p58, P59 p59, P60 p60, P61 p61, P62 p62, P63 p63, P64 p64, P65 p65, P66 p66, P67 p67, P68 p68, P69 p69, P70 p70, P71 p71, P72 p72, P73 p73, P74 p74, P75 p75, P76 p76, P77 p77, P78 p78, P79 p79, P80 p80, P81 p81, P82 p82, P83 p83, P84 p84, P85 p85, P86 p86, P87 p87, P88 p88, P89 p89, P90 p90, P91 p91, P92 p92, P93 p93, P94 p94, P95 p95, P96 p96, P97 p97, P98 p98, P99 p99 );

        private static JsonConstructorDelegate<TOwner> Create<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97, P98, P99>( ConstructorInfo ctorInfo, JsonProperty<TOwner, P0> p0, JsonProperty<TOwner, P1> p1, JsonProperty<TOwner, P2> p2, JsonProperty<TOwner, P3> p3, JsonProperty<TOwner, P4> p4, JsonProperty<TOwner, P5> p5, JsonProperty<TOwner, P6> p6, JsonProperty<TOwner, P7> p7, JsonProperty<TOwner, P8> p8, JsonProperty<TOwner, P9> p9, JsonProperty<TOwner, P10> p10, JsonProperty<TOwner, P11> p11, JsonProperty<TOwner, P12> p12, JsonProperty<TOwner, P13> p13, JsonProperty<TOwner, P14> p14, JsonProperty<TOwner, P15> p15, JsonProperty<TOwner, P16> p16, JsonProperty<TOwner, P17> p17, JsonProperty<TOwner, P18> p18, JsonProperty<TOwner, P19> p19, JsonProperty<TOwner, P20> p20, JsonProperty<TOwner, P21> p21, JsonProperty<TOwner, P22> p22, JsonProperty<TOwner, P23> p23, JsonProperty<TOwner, P24> p24, JsonProperty<TOwner, P25> p25, JsonProperty<TOwner, P26> p26, JsonProperty<TOwner, P27> p27, JsonProperty<TOwner, P28> p28, JsonProperty<TOwner, P29> p29, JsonProperty<TOwner, P30> p30, JsonProperty<TOwner, P31> p31, JsonProperty<TOwner, P32> p32, JsonProperty<TOwner, P33> p33, JsonProperty<TOwner, P34> p34, JsonProperty<TOwner, P35> p35, JsonProperty<TOwner, P36> p36, JsonProperty<TOwner, P37> p37, JsonProperty<TOwner, P38> p38, JsonProperty<TOwner, P39> p39, JsonProperty<TOwner, P40> p40, JsonProperty<TOwner, P41> p41, JsonProperty<TOwner, P42> p42, JsonProperty<TOwner, P43> p43, JsonProperty<TOwner, P44> p44, JsonProperty<TOwner, P45> p45, JsonProperty<TOwner, P46> p46, JsonProperty<TOwner, P47> p47, JsonProperty<TOwner, P48> p48, JsonProperty<TOwner, P49> p49, JsonProperty<TOwner, P50> p50, JsonProperty<TOwner, P51> p51, JsonProperty<TOwner, P52> p52, JsonProperty<TOwner, P53> p53, JsonProperty<TOwner, P54> p54, JsonProperty<TOwner, P55> p55, JsonProperty<TOwner, P56> p56, JsonProperty<TOwner, P57> p57, JsonProperty<TOwner, P58> p58, JsonProperty<TOwner, P59> p59, JsonProperty<TOwner, P60> p60, JsonProperty<TOwner, P61> p61, JsonProperty<TOwner, P62> p62, JsonProperty<TOwner, P63> p63, JsonProperty<TOwner, P64> p64, JsonProperty<TOwner, P65> p65, JsonProperty<TOwner, P66> p66, JsonProperty<TOwner, P67> p67, JsonProperty<TOwner, P68> p68, JsonProperty<TOwner, P69> p69, JsonProperty<TOwner, P70> p70, JsonProperty<TOwner, P71> p71, JsonProperty<TOwner, P72> p72, JsonProperty<TOwner, P73> p73, JsonProperty<TOwner, P74> p74, JsonProperty<TOwner, P75> p75, JsonProperty<TOwner, P76> p76, JsonProperty<TOwner, P77> p77, JsonProperty<TOwner, P78> p78, JsonProperty<TOwner, P79> p79, JsonProperty<TOwner, P80> p80, JsonProperty<TOwner, P81> p81, JsonProperty<TOwner, P82> p82, JsonProperty<TOwner, P83> p83, JsonProperty<TOwner, P84> p84, JsonProperty<TOwner, P85> p85, JsonProperty<TOwner, P86> p86, JsonProperty<TOwner, P87> p87, JsonProperty<TOwner, P88> p88, JsonProperty<TOwner, P89> p89, JsonProperty<TOwner, P90> p90, JsonProperty<TOwner, P91> p91, JsonProperty<TOwner, P92> p92, JsonProperty<TOwner, P93> p93, JsonProperty<TOwner, P94> p94, JsonProperty<TOwner, P95> p95, JsonProperty<TOwner, P96> p96, JsonProperty<TOwner, P97> p97, JsonProperty<TOwner, P98> p98, JsonProperty<TOwner, P99> p99 )
        {
            var ctor = CreateDelegate<Constructor<TOwner, P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, P41, P42, P43, P44, P45, P46, P47, P48, P49, P50, P51, P52, P53, P54, P55, P56, P57, P58, P59, P60, P61, P62, P63, P64, P65, P66, P67, P68, P69, P70, P71, P72, P73, P74, P75, P76, P77, P78, P79, P80, P81, P82, P83, P84, P85, P86, P87, P88, P89, P90, P91, P92, P93, P94, P95, P96, P97, P98, P99>>( ctorInfo );
                
            return ( ref JsonPropertyValues<TOwner> propertyValues ) =>
            {
                var v0 = propertyValues.GetValue( p0 );
                var v1 = propertyValues.GetValue( p1 );
                var v2 = propertyValues.GetValue( p2 );
                var v3 = propertyValues.GetValue( p3 );
                var v4 = propertyValues.GetValue( p4 );
                var v5 = propertyValues.GetValue( p5 );
                var v6 = propertyValues.GetValue( p6 );
                var v7 = propertyValues.GetValue( p7 );
                var v8 = propertyValues.GetValue( p8 );
                var v9 = propertyValues.GetValue( p9 );
                var v10 = propertyValues.GetValue( p10 );
                var v11 = propertyValues.GetValue( p11 );
                var v12 = propertyValues.GetValue( p12 );
                var v13 = propertyValues.GetValue( p13 );
                var v14 = propertyValues.GetValue( p14 );
                var v15 = propertyValues.GetValue( p15 );
                var v16 = propertyValues.GetValue( p16 );
                var v17 = propertyValues.GetValue( p17 );
                var v18 = propertyValues.GetValue( p18 );
                var v19 = propertyValues.GetValue( p19 );
                var v20 = propertyValues.GetValue( p20 );
                var v21 = propertyValues.GetValue( p21 );
                var v22 = propertyValues.GetValue( p22 );
                var v23 = propertyValues.GetValue( p23 );
                var v24 = propertyValues.GetValue( p24 );
                var v25 = propertyValues.GetValue( p25 );
                var v26 = propertyValues.GetValue( p26 );
                var v27 = propertyValues.GetValue( p27 );
                var v28 = propertyValues.GetValue( p28 );
                var v29 = propertyValues.GetValue( p29 );
                var v30 = propertyValues.GetValue( p30 );
                var v31 = propertyValues.GetValue( p31 );
                var v32 = propertyValues.GetValue( p32 );
                var v33 = propertyValues.GetValue( p33 );
                var v34 = propertyValues.GetValue( p34 );
                var v35 = propertyValues.GetValue( p35 );
                var v36 = propertyValues.GetValue( p36 );
                var v37 = propertyValues.GetValue( p37 );
                var v38 = propertyValues.GetValue( p38 );
                var v39 = propertyValues.GetValue( p39 );
                var v40 = propertyValues.GetValue( p40 );
                var v41 = propertyValues.GetValue( p41 );
                var v42 = propertyValues.GetValue( p42 );
                var v43 = propertyValues.GetValue( p43 );
                var v44 = propertyValues.GetValue( p44 );
                var v45 = propertyValues.GetValue( p45 );
                var v46 = propertyValues.GetValue( p46 );
                var v47 = propertyValues.GetValue( p47 );
                var v48 = propertyValues.GetValue( p48 );
                var v49 = propertyValues.GetValue( p49 );
                var v50 = propertyValues.GetValue( p50 );
                var v51 = propertyValues.GetValue( p51 );
                var v52 = propertyValues.GetValue( p52 );
                var v53 = propertyValues.GetValue( p53 );
                var v54 = propertyValues.GetValue( p54 );
                var v55 = propertyValues.GetValue( p55 );
                var v56 = propertyValues.GetValue( p56 );
                var v57 = propertyValues.GetValue( p57 );
                var v58 = propertyValues.GetValue( p58 );
                var v59 = propertyValues.GetValue( p59 );
                var v60 = propertyValues.GetValue( p60 );
                var v61 = propertyValues.GetValue( p61 );
                var v62 = propertyValues.GetValue( p62 );
                var v63 = propertyValues.GetValue( p63 );
                var v64 = propertyValues.GetValue( p64 );
                var v65 = propertyValues.GetValue( p65 );
                var v66 = propertyValues.GetValue( p66 );
                var v67 = propertyValues.GetValue( p67 );
                var v68 = propertyValues.GetValue( p68 );
                var v69 = propertyValues.GetValue( p69 );
                var v70 = propertyValues.GetValue( p70 );
                var v71 = propertyValues.GetValue( p71 );
                var v72 = propertyValues.GetValue( p72 );
                var v73 = propertyValues.GetValue( p73 );
                var v74 = propertyValues.GetValue( p74 );
                var v75 = propertyValues.GetValue( p75 );
                var v76 = propertyValues.GetValue( p76 );
                var v77 = propertyValues.GetValue( p77 );
                var v78 = propertyValues.GetValue( p78 );
                var v79 = propertyValues.GetValue( p79 );
                var v80 = propertyValues.GetValue( p80 );
                var v81 = propertyValues.GetValue( p81 );
                var v82 = propertyValues.GetValue( p82 );
                var v83 = propertyValues.GetValue( p83 );
                var v84 = propertyValues.GetValue( p84 );
                var v85 = propertyValues.GetValue( p85 );
                var v86 = propertyValues.GetValue( p86 );
                var v87 = propertyValues.GetValue( p87 );
                var v88 = propertyValues.GetValue( p88 );
                var v89 = propertyValues.GetValue( p89 );
                var v90 = propertyValues.GetValue( p90 );
                var v91 = propertyValues.GetValue( p91 );
                var v92 = propertyValues.GetValue( p92 );
                var v93 = propertyValues.GetValue( p93 );
                var v94 = propertyValues.GetValue( p94 );
                var v95 = propertyValues.GetValue( p95 );
                var v96 = propertyValues.GetValue( p96 );
                var v97 = propertyValues.GetValue( p97 );
                var v98 = propertyValues.GetValue( p98 );
                var v99 = propertyValues.GetValue( p99 );

                return ctor( v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99 );
            };
        }

    }
}
