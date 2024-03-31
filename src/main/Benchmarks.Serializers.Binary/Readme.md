﻿| Method        | CollectionSize |          Mean |      Error |     StdDev |     StdErr |        Median |           Min |            Q1 |            Q3 |           Max |         Op/s |    Gen0 |   Gen1 | Allocated |
|---------------|----------------|--------------:|-----------:|-----------:|-----------:|--------------:|--------------:|--------------:|--------------:|--------------:|-------------:|--------:|-------:|----------:|
| MemoryPack    | 1              |      44.58 ns |   0.224 ns |   0.210 ns |   0.054 ns |      44.62 ns |      44.17 ns |      44.46 ns |      44.75 ns |      44.87 ns | 22,431,215.9 |  0.0044 |      - |      56 B |
| ZeroFormatter | 1              |      58.11 ns |   0.598 ns |   0.560 ns |   0.144 ns |      58.31 ns |      56.79 ns |      58.07 ns |      58.42 ns |      58.76 ns | 17,208,883.3 |  0.0924 | 0.0004 |    1160 B |
| MessagePack   | 1              |      63.69 ns |   0.228 ns |   0.213 ns |   0.055 ns |      63.71 ns |      63.28 ns |      63.57 ns |      63.83 ns |      64.05 ns | 15,701,404.5 |  0.0063 |      - |      80 B |
| MsgPackLight  | 1              |     124.78 ns |   0.485 ns |   0.454 ns |   0.117 ns |     124.85 ns |     123.82 ns |     124.53 ns |     125.07 ns |     125.45 ns |  8,013,784.1 |  0.0508 |      - |     640 B |
| FlatBuffers   | 1              |     129.86 ns |   0.962 ns |   0.853 ns |   0.228 ns |     129.73 ns |     128.21 ns |     129.42 ns |     130.46 ns |     131.54 ns |  7,700,893.6 |  0.1173 | 0.0005 |    1472 B |
| Protobuf      | 1              |     328.87 ns |   3.812 ns |   3.566 ns |   0.921 ns |     329.82 ns |     320.74 ns |     328.62 ns |     330.83 ns |     333.26 ns |  3,040,721.5 |  0.0896 |      - |    1128 B |
| MemoryPack    | 100            |   1,572.33 ns |   4.803 ns |   4.492 ns |   1.160 ns |   1,572.38 ns |   1,564.70 ns |   1,570.30 ns |   1,575.31 ns |   1,579.76 ns |    635,999.2 |  0.2213 |      - |    2800 B |
| ZeroFormatter | 100            |   2,344.43 ns |  16.171 ns |  15.126 ns |   3.906 ns |   2,347.97 ns |   2,295.52 ns |   2,340.96 ns |   2,353.51 ns |   2,357.45 ns |    426,543.7 |  1.6060 |      - |   20160 B |
| MessagePack   | 100            |   2,700.91 ns |   7.130 ns |   6.321 ns |   1.689 ns |   2,701.28 ns |   2,689.82 ns |   2,697.22 ns |   2,704.02 ns |   2,713.53 ns |    370,245.9 |  0.3967 |      - |    4992 B |
| FlatBuffers   | 100            |   5,246.28 ns |  12.826 ns |  11.998 ns |   3.098 ns |   5,249.28 ns |   5,223.08 ns |   5,240.03 ns |   5,252.23 ns |   5,266.39 ns |    190,611.2 |  0.8774 | 0.0076 |   11024 B |
| Protobuf      | 100            |   9,052.27 ns | 199.378 ns | 575.252 ns |  58.711 ns |   8,699.98 ns |   8,593.52 ns |   8,654.87 ns |   9,385.34 ns |  10,333.83 ns |    110,469.5 |  0.7935 |      - |    9968 B |
| MsgPackLight  | 100            |  10,032.74 ns |  43.797 ns |  38.825 ns |  10.376 ns |  10,025.51 ns |   9,942.26 ns |  10,019.75 ns |  10,048.93 ns |  10,107.63 ns |     99,673.7 |  2.8534 | 0.0916 |   35904 B |
| MemoryPack    | 1000           |  19,538.48 ns | 389.409 ns | 519.849 ns | 103.970 ns |  19,471.45 ns |  18,801.87 ns |  19,053.11 ns |  20,007.16 ns |  20,259.29 ns |     51,181.1 |  2.1667 |      - |   27616 B |
| ZeroFormatter | 1000           |  23,622.12 ns | 301.538 ns | 267.305 ns |  71.440 ns |  23,688.51 ns |  23,062.27 ns |  23,617.64 ns |  23,816.04 ns |  23,904.07 ns |     42,333.2 | 14.0686 | 0.0305 |  176880 B |
| MessagePack   | 1000           |  33,444.42 ns | 211.910 ns | 198.221 ns |  51.180 ns |  33,464.34 ns |  33,103.47 ns |  33,312.68 ns |  33,584.00 ns |  33,802.72 ns |     29,900.4 |  3.9063 |      - |   49464 B |
| FlatBuffers   | 1000           |  59,325.37 ns | 336.210 ns | 314.491 ns |  81.201 ns |  59,400.20 ns |  58,758.19 ns |  59,233.49 ns |  59,539.80 ns |  59,741.61 ns |     16,856.2 | 13.0615 | 2.1362 |  164544 B |
| Protobuf      | 1000           |  90,520.24 ns | 440.767 ns | 412.294 ns | 106.454 ns |  90,579.55 ns |  89,643.73 ns |  90,301.12 ns |  90,854.19 ns |  91,016.56 ns |     11,047.3 |  7.2021 | 0.7324 |   91496 B |
| MsgPackLight  | 1000           | 103,635.11 ns | 598.144 ns | 559.504 ns | 144.463 ns | 103,534.95 ns | 102,697.17 ns | 103,365.34 ns | 103,971.48 ns | 104,603.63 ns |      9,649.2 | 25.7568 | 4.2725 |  325456 B |