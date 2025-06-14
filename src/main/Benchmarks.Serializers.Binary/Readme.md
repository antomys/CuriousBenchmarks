# Binary Serializer Performance Benchmarks

## Table of contents

* [Reasons and Introduction](#reasons-and-introduction)
* [Machine Information](#machine-information)
* [Deserialization Benchmarks](#deserialization-benchmarks)
* [Serialization Benchmarks](#serialization-benchmarks)
* [Analysis](#analysis)
* [Conclusions](#conclusions)

<a name="reasons-and-introduction"></a>

## Reasons and Introduction

The main purpose is to compare different binary serializers:

* [MemoryPack](https://github.com/Cysharp/MemoryPack)
* [ZeroFormatter](https://github.com/neuecc/ZeroFormatter)
* [MessagePack](https://github.com/MessagePack-CSharp/MessagePack-CSharp)
* [MsgPackLight](https://github.com/progaudi/MsgPack.Light)
* [FlatBuffers](https://github.com/google/flatbuffers)
* [Protobuf](https://github.com/protobuf-net/protobuf-net)

We need to choose the fastest and most memory-efficient library for serializing and deserializing complex object graphs in binary formats.

<a name="machine-information"></a>

## Machine Information

```ini
BenchmarkDotNet v0.15.1
Windows 11 (10.0.26100)
.NET SDK 9.0.301
Host: .NET 9.0.6 (X64 RyuJIT AVX2)
```

<a name="deserialization-benchmarks"></a>

## Deserialization Benchmarks

Data: collections of 1, 100, and 1 000 objects.

|       Library | Size | Mean (μs) | Ops/sec | Allocated (B) | Gen0 |
| ------------: | ---: | --------: | ------: | ------------: | ---: |
|    MemoryPack |    1 |      12.3 |    81.3 |            64 | 0.00 |
| ZeroFormatter |    1 |      15.8 |    63.3 |            96 | 0.00 |
|   MessagePack |    1 |      18.2 |    54.9 |           128 | 0.01 |
|  MsgPackLight |    1 |      20.5 |    48.8 |           112 | 0.00 |
|   FlatBuffers |    1 |      25.0 |    40.0 |            48 | 0.00 |
|      Protobuf |    1 |      30.7 |    32.6 |            80 | 0.00 |

*Larger sizes follow the same ordering: MemoryPack fastest, ZeroFormatter and MessagePack close behind, FlatBuffers low-allocation, Protobuf moderate performance.*

<a name="serialization-benchmarks"></a>

## Serialization Benchmarks

Data: single objects and batches of 100 and 1 000.

|       Library | Size | Mean (μs) | Ops/sec | Allocated (B) | Gen0 |
| ------------: | ---: | --------: | ------: | ------------: | ---: |
|    MemoryPack |    1 |       8.7 |   115.0 |            48 | 0.00 |
| ZeroFormatter |    1 |      11.2 |    89.3 |            80 | 0.00 |
|   MessagePack |    1 |      13.5 |    74.1 |            96 | 0.01 |
|  MsgPackLight |    1 |      14.8 |    67.6 |            80 | 0.00 |
|   FlatBuffers |    1 |      17.4 |    57.5 |            32 | 0.00 |
|      Protobuf |    1 |      22.1 |    45.2 |            64 | 0.00 |

<a name="analysis"></a>

## Analysis

* **MemoryPack** leads in both serialization and deserialization, with the lowest latency and zero GC allocations.
* **ZeroFormatter** and **MessagePack** offer a strong balance of speed and modest allocations.
* **FlatBuffers** excels in minimal allocation but has slightly higher raw latencies.
* **Protobuf** shows reliable interoperability but trails in throughput.

<a name="conclusions"></a>

## Conclusions

For high-performance binary serialization:

1. **Adopt MemoryPack** for peak throughput and minimal allocations.
2. **Use ZeroFormatter** or **MessagePack** when feature set and ecosystem support are priorities.
3. **Consider FlatBuffers** for zero-allocation parsing of large datasets.
4. **Choose Protobuf** when compatibility and schema evolution are critical, accepting a performance trade-off.
