﻿| Method        | CollectionSize |         Mean |      Error |     StdDev |    StdErr |          Min |           Q1 |       Median |           Q3 |          Max |         Op/s |    Gen0 |   Gen1 | Allocated |
|---------------|----------------|-------------:|-----------:|-----------:|----------:|-------------:|-------------:|-------------:|-------------:|-------------:|-------------:|--------:|-------:|----------:|
| MemoryPack    | 1              |     46.17 ns |   0.159 ns |   0.148 ns |  0.038 ns |     45.92 ns |     46.09 ns |     46.19 ns |     46.27 ns |     46.45 ns | 21,656,864.8 |  0.0044 |      - |      56 B |
| ZeroFormatter | 1              |     61.33 ns |   0.576 ns |   0.539 ns |  0.139 ns |     59.51 ns |     61.31 ns |     61.41 ns |     61.55 ns |     61.90 ns | 16,305,912.1 |  0.0924 | 0.0004 |    1160 B |
| MessagePack   | 1              |     65.89 ns |   0.177 ns |   0.166 ns |  0.043 ns |     65.42 ns |     65.85 ns |     65.92 ns |     65.96 ns |     66.11 ns | 15,176,959.1 |  0.0063 |      - |      80 B |
| FlatBuffers   | 1              |    141.03 ns |   0.972 ns |   0.862 ns |  0.230 ns |    138.71 ns |    140.85 ns |    141.10 ns |    141.46 ns |    142.25 ns |  7,090,687.6 |  0.1173 | 0.0005 |    1472 B |
| Protobuf      | 1              |    313.25 ns |   2.808 ns |   2.489 ns |  0.665 ns |    310.54 ns |    311.89 ns |    312.15 ns |    314.34 ns |    318.60 ns |  3,192,355.2 |  0.0896 |      - |    1128 B |
| MemoryPack    | 100            |  1,634.43 ns |   5.870 ns |   5.491 ns |  1.418 ns |  1,625.86 ns |  1,630.23 ns |  1,633.43 ns |  1,638.08 ns |  1,645.69 ns |    611,834.8 |  0.2193 |      - |    2768 B |
| ZeroFormatter | 100            |  2,365.41 ns |  12.317 ns |  11.521 ns |  2.975 ns |  2,332.44 ns |  2,361.61 ns |  2,365.35 ns |  2,371.55 ns |  2,384.10 ns |    422,759.2 |  1.6098 | 0.0458 |   20192 B |
| MessagePack   | 100            |  2,764.01 ns |   8.740 ns |   8.175 ns |  2.111 ns |  2,738.74 ns |  2,762.40 ns |  2,764.60 ns |  2,768.60 ns |  2,774.61 ns |    361,793.5 |  0.3967 |      - |    5008 B |
| FlatBuffers   | 100            |  5,342.12 ns |  12.822 ns |  11.994 ns |  3.097 ns |  5,306.97 ns |  5,339.58 ns |  5,343.59 ns |  5,349.34 ns |  5,355.50 ns |    187,191.5 |  0.8774 | 0.0076 |   11032 B |
| Protobuf      | 100            |  8,473.96 ns |  23.346 ns |  18.227 ns |  5.262 ns |  8,435.92 ns |  8,474.43 ns |  8,481.10 ns |  8,484.39 ns |  8,487.40 ns |    118,008.6 |  0.7935 |      - |    9992 B |
| MemoryPack    | 1000           | 19,322.17 ns | 238.276 ns | 211.225 ns | 56.452 ns | 18,983.59 ns | 19,193.57 ns | 19,270.75 ns | 19,458.59 ns | 19,772.37 ns |     51,754.0 |  2.1667 |      - |   27592 B |
| ZeroFormatter | 1000           | 23,943.32 ns | 158.631 ns | 132.464 ns | 36.739 ns | 23,593.61 ns | 23,912.66 ns | 23,975.74 ns | 24,015.72 ns | 24,124.38 ns |     41,765.3 | 14.0381 | 0.9155 |  176776 B |
| MessagePack   | 1000           | 31,957.00 ns | 113.008 ns |  94.367 ns | 26.173 ns | 31,709.59 ns | 31,944.95 ns | 31,986.60 ns | 32,001.84 ns | 32,068.00 ns |     31,292.0 |  3.9063 |      - |   49616 B |
| FlatBuffers   | 1000           | 58,498.13 ns | 153.813 ns | 143.877 ns | 37.149 ns | 58,138.76 ns | 58,438.14 ns | 58,506.15 ns | 58,584.69 ns | 58,704.52 ns |     17,094.6 | 13.0615 | 2.1362 |  164560 B |
| Protobuf      | 1000           | 92,695.38 ns | 155.267 ns | 137.640 ns | 36.786 ns | 92,493.96 ns | 92,621.88 ns | 92,673.91 ns | 92,784.24 ns | 92,950.40 ns |     10,788.0 |  7.2021 |      - |   91808 B |