### Table of contents
- [Asp.Net Formatters Benchmarks](#aspnet-formatters-benchmarks)
    * [Deserialization](#aspnet-formatters-deserialization)
        * [System Text Json](#aspnet-formatters-deserialization-stj)
        * [System Text Json Source Generated](#aspnet-formatters-deserialization-stj-srcgen)
        * [Newtonsoft Json](#aspnet-formatters-deserialization-newtonsoft)
        * [SpanJson](#aspnet-formatters-deserialization-newtonsoft)
        * [MessagePack](#aspnet-formatters-deserialization-msgpack)
        * [Protobuf](#aspnet-formatters-deserialization-protobuf)
    * [Serialization](#aspnet-formatters-serialization)
        * [System Text Json](#aspnet-formatters-serialization-stj)
        * [System Text Json Source Generated](#aspnet-formatters-serialization-stj-srcgen)
        * [Newtonsoft Json](#aspnet-formatters-serialization-newtonsoft)
        * [SpanJson](#aspnet-formatters-serialization-newtonsoft)
        * [MessagePack](#aspnet-formatters-serialization-msgpack)
        * [Protobuf](#aspnet-formatters-serialization-protobuf)

<a name="aspnet-formatters-benchmarks"></a>
# Asp.Net Formatters Benchmarks

In this section i tried to test Requests per second and Time per request metrics with different serializer formatters.

For `Serialization` benchmarks, command `.\abs.exe -n 20000 -c 10 https://localhost:7102/serialize/simple/100` was used.

As for `Deserialization`, `.\abs.exe -p testjson.json -T application/json -n 20000 -c 10 https://localhost:7102/deserialize/simple/100` were used respectively.

<a name="aspnet-formatters-deserialization"></a>
## Deserialization

For deserialization I used previously generated json or binary response with 100 items in array of specific type to be parsed into request.

<a name="aspnet-formatters-deserialization-stj"></a>
### System Text Json

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   75.840 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        187220000
HTML transferred:       0 bytes
Requests per second:    263.71 [#/sec] (mean)
Time per request:       37.920 [ms] (mean)
Time per request:       3.792 [ms] (mean, across all concurrent requests)
Transfer rate:          28.59 [Kbytes/sec] received
2410.77 kb/s sent
2439.35 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   124.576 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        5085800000
HTML transferred:       0 bytes
Requests per second:    160.54 [#/sec] (mean)
Time per request:       62.288 [ms] (mean)
Time per request:       6.229 [ms] (mean, across all concurrent requests)
Transfer rate:          17.40 [Kbytes/sec] received
39867.93 kb/s sent
39885.33 kb/s total

<a name="aspnet-formatters-deserialization-stj-srcgen"></a>
### System Text Json Source Generated

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   81.554 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        187220000
HTML transferred:       0 bytes
Requests per second:    245.24 [#/sec] (mean)
Time per request:       40.777 [ms] (mean)
Time per request:       4.078 [ms] (mean, across all concurrent requests)
Transfer rate:          26.58 [Kbytes/sec] received
2241.85 kb/s sent
2268.43 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   122.774 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        5085800000
HTML transferred:       0 bytes
Requests per second:    162.90 [#/sec] (mean)
Time per request:       61.387 [ms] (mean)
Time per request:       6.139 [ms] (mean, across all concurrent requests)
Transfer rate:          17.66 [Kbytes/sec] received
40453.22 kb/s sent
40470.88 kb/s total

<a name="aspnet-formatters-deserialization-spanjson"></a>
### Span Json

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   78.046 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        186880000
HTML transferred:       0 bytes
Requests per second:    256.26 [#/sec] (mean)
Time per request:       39.023 [ms] (mean)
Time per request:       3.902 [ms] (mean, across all concurrent requests)
Transfer rate:          27.78 [Kbytes/sec] received
2338.36 kb/s sent
2366.14 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   105.603 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        3422140000
HTML transferred:       0 bytes
Requests per second:    189.39 [#/sec] (mean)
Time per request:       52.801 [ms] (mean)
Time per request:       5.280 [ms] (mean, across all concurrent requests)
Transfer rate:          20.53 [Kbytes/sec] received
31646.35 kb/s sent
31666.87 kb/s total


<a name="aspnet-formatters-deserialization-newtonsoft"></a>
### Newtonsoft Json

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   81.408 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        187760000
HTML transferred:       0 bytes
Requests per second:    245.68 [#/sec] (mean)
Time per request:       40.704 [ms] (mean)
Time per request:       4.070 [ms] (mean, across all concurrent requests)
Transfer rate:          26.63 [Kbytes/sec] received
2252.35 kb/s sent
2278.98 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   161.522 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        5085460000
HTML transferred:       0 bytes
Requests per second:    123.82 [#/sec] (mean)
Time per request:       80.761 [ms] (mean)
Time per request:       8.076 [ms] (mean, across all concurrent requests)
Transfer rate:          13.42 [Kbytes/sec] received
30746.79 kb/s sent
30760.22 kb/s total

<a name="aspnet-formatters-deserialization-msgpack"></a>
### MessagePack

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   77.279 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        54860000
HTML transferred:       0 bytes
Requests per second:    258.80 [#/sec] (mean)
Time per request:       38.640 [ms] (mean)
Time per request:       3.864 [ms] (mean, across all concurrent requests)
Transfer rate:          28.05 [Kbytes/sec] received
693.26 kb/s sent
721.31 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   100.502 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        1611620000
HTML transferred:       0 bytes
Requests per second:    199.00 [#/sec] (mean)
Time per request:       50.251 [ms] (mean)
Time per request:       5.025 [ms] (mean, across all concurrent requests)
Transfer rate:          21.57 [Kbytes/sec] received
15659.90 kb/s sent
15681.48 kb/s total

<a name="aspnet-formatters-deserialization-jil"></a>
### Jil

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   75.298 seconds
Complete requests:      20000
Failed requests:        0
Non-2xx responses:      20000
Total transferred:      2460000 bytes
Total body sent:        141000000
HTML transferred:       0 bytes
Requests per second:    265.61 [#/sec] (mean)
Time per request:       37.649 [ms] (mean)
Time per request:       3.765 [ms] (mean, across all concurrent requests)
Transfer rate:          31.90 [Kbytes/sec] received
1828.66 kb/s sent
1860.57 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   79.231 seconds
Complete requests:      20000
Failed requests:        0
Non-2xx responses:      20000
Total transferred:      2460000 bytes
Total body sent:        3428400000
HTML transferred:       0 bytes
Requests per second:    252.43 [#/sec] (mean)
Time per request:       39.616 [ms] (mean)
Time per request:       3.962 [ms] (mean, across all concurrent requests)
Transfer rate:          30.32 [Kbytes/sec] received
42256.77 kb/s sent
42287.09 kb/s total

<a name="aspnet-formatters-deserialization-protobuf"></a>
### Protobuf

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   76.935 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        57560000
HTML transferred:       0 bytes
Requests per second:    259.96 [#/sec] (mean)
Time per request:       38.467 [ms] (mean)
Time per request:       3.847 [ms] (mean, across all concurrent requests)
Transfer rate:          28.18 [Kbytes/sec] received
730.63 kb/s sent
758.81 kb/s total

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   98.842 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      2220000 bytes
Total body sent:        1734680000
HTML transferred:       0 bytes
Requests per second:    202.34 [#/sec] (mean)
Time per request:       49.421 [ms] (mean)
Time per request:       4.942 [ms] (mean, across all concurrent requests)
Transfer rate:          21.93 [Kbytes/sec] received
17138.74 kb/s sent
17160.67 kb/s total

<a name="aspnet-formatters-serialization"></a>
## Serialization

For serialization I just made several thousand `GET` requests.

<a name="aspnet-formatters-serialization-stj"></a>
### System Text Json

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   92.244 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      140940000 bytes
HTML transferred:       138160000 bytes
Requests per second:    216.82 [#/sec] (mean)
Time per request:       46.122 [ms] (mean)
Time per request:       4.612 [ms] (mean, across all concurrent requests)
Transfer rate:          1492.10 [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   112.093 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      3418400000 bytes
HTML transferred:       3415620000 bytes
Requests per second:    178.42 [#/sec] (mean)
Time per request:       56.047 [ms] (mean)
Time per request:       5.605 [ms] (mean, across all concurrent requests)
Transfer rate:          29781.27 [Kbytes/sec] received

<a name="aspnet-formatters-serialization-stj-srcgen"></a>
### System Text Json Source Generated

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   80.549 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      140740000 bytes
HTML transferred:       137960000 bytes
Requests per second:    248.30 [#/sec] (mean)
Time per request:       40.275 [ms] (mean)
Time per request:       4.027   [ms] (mean, across all concurrent requests)
Transfer rate:          1706.30 [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   97.504 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      3419220000 bytes
HTML transferred:       3416440000 bytes
Requests per second:    205.12   [#/sec] (mean)
Time per request:       48.752   [ms] (mean)
Time per request:       4.875         [ms] (mean, across all concurrent requests)
Transfer rate:          34245.72 [Kbytes/sec] received


<a name="aspnet-formatters-serialization-spanjson"></a>
### Span Json

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   75.449 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      140760000 bytes
HTML transferred:       137980000 bytes
Requests per second:    265.08  [#/sec] (mean)
Time per request:       37.725     [ms] (mean)
Time per request:       3.772         [ms] (mean, across all concurrent requests)
Transfer rate:          1821.90 [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   87.659 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      3421680000 bytes
HTML transferred:       3418900000 bytes
Requests per second:    228.16    [#/sec] (mean)
Time per request:       43.830    [ms] (mean)
Time per request:       4.383          [ms] (mean, across all concurrent requests)
Transfer rate:          38119.04 [Kbytes/sec] received

<a name="aspnet-formatters-serialization-newtonsoft"></a>
### Newtonsoft Json

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   77.085 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      141720000 bytes
HTML transferred:       138500000 bytes
Requests per second:    259.45   [#/sec] (mean)
Time per request:       38.542   [ms] (mean)
Time per request:       3.854     [ms] (mean, across all concurrent requests)
Transfer rate:          1795.41 [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   134.186 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      3417780000 bytes
HTML transferred:       3414520000 bytes
Requests per second:    149.05   [#/sec] (mean)
Time per request:       67.093   [ms] (mean)
Time per request:       6.709       [ms] (mean, across all concurrent requests)
Transfer rate:          24873.56 [Kbytes/sec] received

<a name="aspnet-formatters-serialization-msgpack"></a>
### MessagePack

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   76.259 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      101460000 bytes
HTML transferred:       98880000 bytes
Requests per second:    262.26  [#/sec] (mean)
Time per request:       38.130  [ms] (mean)
Time per request:       3.813     [ms] (mean, across all concurrent requests)
Transfer rate:          1299.28 [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   79.824 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      1610880000 bytes
HTML transferred:       1608300000 bytes
Requests per second:    250.55   [#/sec] (mean)
Time per request:       39.912  [ms] (mean)
Time per request:       3.991         [ms] (mean, across all concurrent requests)
Transfer rate:          19707.31 [Kbytes/sec] received

<a name="aspnet-formatters-serialization-jil"></a>
### Jil

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   76.210 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      140680000 bytes
HTML transferred:       137820000 bytes
Requests per second:    262.43   [#/sec] (mean)
Time per request:       38.105   [ms] (mean)
Time per request:       3.811         [ms] (mean, across all concurrent requests)
Transfer rate:          1802.68 [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   79.094 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      140680000 bytes
HTML transferred:       137820000 bytes
Requests per second:    252.86  [#/sec] (mean)
Time per request:       39.547  [ms] (mean)
Time per request:       3.955         [ms] (mean, across all concurrent requests)
Transfer rate:          1736.96 [Kbytes/sec] received

<a name="aspnet-formatters-serialization-protobuf"></a>
### Protobuf

For `SimpleModel`:

Concurrency Level:      10
Time taken for tests:   74.225 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      57300000 bytes
HTML transferred:       54300000 bytes
Requests per second:    269.45    [#/sec] (mean)
Time per request:       37.112    [ms] (mean)
Time per request:       3.711    [ms] (mean, across all concurrent requests)
Transfer rate:          753.89    [Kbytes/sec] received

For `ComplexModel`:

Concurrency Level:      10
Time taken for tests:   82.576 seconds
Complete requests:      20000
Failed requests:        0
Total transferred:      1734400000 bytes
HTML transferred:       1731380000 bytes
Requests per second:    242.20   [#/sec] (mean)
Time per request:       41.288   [ms] (mean)
Time per request:       4.129    [ms] (mean, across all concurrent requests)
Transfer rate:          20511.48 [Kbytes/sec] received
