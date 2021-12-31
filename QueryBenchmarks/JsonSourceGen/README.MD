##  Summary 

- OS=Windows 10.0.19044.1415 (21H2)
- Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
- .NET SDK=6.0.101

## Serialization
### 1k objects
|                           Method | Categories |       Mean |    Error |   StdDev | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|--------------------------------- |----------- |-----------:|---------:|---------:|------:|--------:|---------:|---------:|---------:|----------:|
|                ClassicSerializer |     Stream | 1,300.9 us | 12.85 us | 12.02 us |  1.00 |    0.00 | 166.0156 | 166.0156 | 166.0156 |    644 KB |
|              GeneratedSerializer |     Stream | 1,068.1 us |  8.43 us |  7.88 us |  0.82 |    0.01 | 166.0156 | 166.0156 | 166.0156 |    642 KB |
|             Utf8StreamSerializer |     Stream |   998.8 us |  9.56 us |  7.98 us |  0.77 |    0.01 | 166.0156 | 166.0156 | 166.0156 |    517 KB |
|          MsgPackStreamSerializer |     Stream |   555.0 us | 10.70 us | 13.14 us |  0.43 |    0.01 |  89.8438 |  88.8672 |  44.9219 |    256 KB |
|                                  |            |            |          |          |       |         |          |          |          |           |
|          ClassicStringSerializer |     String |   880.2 us |  6.41 us |  5.36 us |  1.00 |    0.00 |  83.0078 |  83.0078 |  83.0078 |    267 KB |
|        GeneratedStringSerializer |     String |   681.9 us | 13.60 us | 12.72 us |  0.78 |    0.01 |  83.0078 |  83.0078 |  83.0078 |    267 KB |
|       NewtonsoftStringSerializer |     String | 1,572.8 us | 20.43 us | 19.11 us |  1.79 |    0.02 |  83.9844 |  82.0313 |  82.0313 |    597 KB |
|              JilStringSerializer |     String |   747.1 us |  8.95 us |  8.37 us |  0.85 |    0.01 |  76.1719 |  76.1719 |  76.1719 |    499 KB |
|         Utf8JsonStringSerializer |     String | 1,155.7 us | 15.77 us | 13.98 us |  1.31 |    0.02 | 248.0469 | 248.0469 | 248.0469 |    784 KB |
| SpanJsonStringFromByteSerializer |     String |   747.2 us |  8.84 us |  7.83 us |  0.85 |    0.01 | 124.0234 | 124.0234 | 124.0234 |    400 KB |
|         SpanJsonStringSerializer |     String |   500.9 us |  9.97 us | 16.10 us |  0.57 |    0.02 |  62.5000 |  62.5000 |  62.5000 |    267 KB |
|          MsgPackStringSerializer |     String | 1,981.0 us | 39.07 us | 34.63 us |  2.25 |    0.04 | 275.3906 | 109.3750 | 109.3750 |  1,048 KB |

###100k objects
|                           Method | Categories |      Mean |    Error |    StdDev | Ratio | RatioSD |      Gen 0 |     Gen 1 |    Gen 2 | Allocated |
|--------------------------------- |----------- |----------:|---------:|----------:|------:|--------:|-----------:|----------:|---------:|----------:|
|                ClassicSerializer |     Stream |  89.40 ms | 1.557 ms |  1.456 ms |  1.00 |    0.00 |   666.6667 |  666.6667 | 666.6667 |     47 MB |
|              GeneratedSerializer |     Stream |  67.38 ms | 1.056 ms |  0.881 ms |  0.75 |    0.01 |   500.0000 |  500.0000 | 500.0000 |     47 MB |
|             Utf8StreamSerializer |     Stream |  78.12 ms | 1.542 ms |  2.741 ms |  0.88 |    0.03 |   571.4286 |  571.4286 | 571.4286 |     45 MB |
|          MsgPackStreamSerializer |     Stream |  43.57 ms | 0.825 ms |  0.772 ms |  0.49 |    0.01 |   454.5455 |  454.5455 | 454.5455 |     18 MB |
|                                  |            |           |          |           |       |         |            |           |          |           |
|          ClassicStringSerializer |     String |  86.81 ms | 1.291 ms |  1.144 ms |  1.00 |    0.00 |          - |         - |        - |     26 MB |
|        GeneratedStringSerializer |     String |  58.35 ms | 0.825 ms |  0.732 ms |  0.67 |    0.01 |          - |         - |        - |     26 MB |
|       NewtonsoftStringSerializer |     String | 151.66 ms | 4.079 ms | 10.959 ms |  1.66 |    0.12 |  5000.0000 | 2000.0000 |        - |     57 MB |
|              JilStringSerializer |     String |  74.06 ms | 1.312 ms |  1.289 ms |  0.85 |    0.02 |  4875.0000 | 2125.0000 | 750.0000 |     48 MB |
|         Utf8JsonStringSerializer |     String |  87.32 ms | 1.011 ms |  0.844 ms |  1.01 |    0.02 |   500.0000 |  500.0000 | 500.0000 |     71 MB |
| SpanJsonStringFromByteSerializer |     String |  64.15 ms | 1.271 ms |  1.413 ms |  0.74 |    0.01 |   222.2222 |  222.2222 | 222.2222 |     39 MB |
|         SpanJsonStringSerializer |     String |  52.74 ms | 1.051 ms |  1.508 ms |  0.62 |    0.02 |          - |         - |        - |     26 MB |
|          MsgPackStringSerializer |     String | 189.09 ms | 3.659 ms |  7.798 ms |  2.21 |    0.09 | 11000.0000 | 3000.0000 |        - |    101 MB |


## Deserialization

### 1k objects
|                 Method |       Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------- |-----------:|---------:|---------:|------:|--------:|--------:|--------:|--------:|----------:|
|    ClassicDeserializer | 1,286.2 us | 14.49 us | 13.55 us |  1.00 |    0.00 | 37.1094 | 15.6250 |       - |    176 KB |
|  GeneratedDeserializer | 1,305.5 us |  7.39 us |  6.91 us |  1.02 |    0.01 | 37.1094 | 17.5781 |       - |    176 KB |
| NewtonsoftDeserializer | 2,584.9 us | 33.56 us | 31.39 us |  2.01 |    0.04 | 93.7500 | 42.9688 |       - |    461 KB |
|       Utf8Deserializer | 1,053.6 us | 16.19 us | 12.64 us |  0.82 |    0.01 | 68.3594 | 64.4531 | 35.1563 |    309 KB |
|   SpanJsonDeserializer |   592.9 us | 11.71 us | 10.95 us |  0.46 |    0.01 | 37.1094 | 14.6484 |       - |    167 KB |
|    MsgPackDeserializer |   483.9 us |  2.92 us |  2.59 us |  0.38 |    0.00 | 35.6445 | 17.5781 |       - |    167 KB |

### 100k objects
|                 Method |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |      Gen 0 |      Gen 1 |     Gen 2 | Allocated |
|----------------------- |-----------:|---------:|----------:|-----------:|------:|--------:|-----------:|-----------:|----------:|----------:|
|    ClassicDeserializer | 1,681.4 ms | 15.28 ms |  11.93 ms | 1,677.6 ms |  1.00 |    0.00 | 26000.0000 |  9000.0000 |         - |    302 MB |
|  GeneratedDeserializer | 1,906.8 ms | 92.11 ms | 268.70 ms | 1,802.8 ms |  1.09 |    0.10 | 26000.0000 |  9000.0000 |         - |    302 MB |
| NewtonsoftDeserializer | 3,461.9 ms | 53.52 ms |  54.96 ms | 3,440.8 ms |  2.07 |    0.04 | 72000.0000 | 20000.0000 | 1000.0000 |    446 MB |
|       Utf8Deserializer | 1,344.7 ms | 26.24 ms |  24.55 ms | 1,341.1 ms |  0.80 |    0.01 | 26000.0000 |  9000.0000 |         - |    302 MB |
|   SpanJsonDeserializer |   891.3 ms | 14.67 ms |  13.01 ms |   891.8 ms |  0.53 |    0.01 | 26000.0000 |  9000.0000 |         - |    163 MB |
|    MsgPackDeserializer |   757.4 ms |  7.10 ms |   5.93 ms |   758.1 ms |  0.45 |    0.00 | 26000.0000 |  9000.0000 |         - |    163 MB |
