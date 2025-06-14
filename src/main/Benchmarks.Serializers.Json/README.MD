# JSON Serializer Performance Benchmarks

## Table of contents

* [Reasons and Introduction](#reasons-and-introduction)
* [Machine Information](#machine-information)
* [Deserialization Benchmarks](#deserialization-benchmarks)

    * [Byte Array Deserialization](#byte-array-deserialization)
    * [String Deserialization](#string-deserialization)
* [Serialization Benchmarks](#serialization-benchmarks)

    * [Byte Array Serialization](#byte-array-serialization)
    * [String Serialization](#string-serialization)
* [Analysis](#analysis)
* [Conclusions](#conclusions)

<a name="reasons-and-introduction"></a>

## Reasons and Introduction

We need to choose the fastest and most memory-efficient JSON library for both serialization and deserialization scenarios, covering binary (UTF‑8 byte arrays) and text (strings) payloads. Libraries compared include:

* **Source-generated** System.Text.Json and JsonSrcGen
* **SpanJson**, **Utf8Json**, **Jil**, **NetJSON**, **ServiceStack**
* **Newtonsoft.Json**
  add:

The main purpose is to compare different JSON serializers:
- [Jil](https://github.com/kevin-montrose/Jil)
- [JsonSrcGen](https://github.com/trampster/JsonSrcGen)
- [NET.Json](https://github.com/netjson/netjson)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [ServiceStack](https://github.com/ServiceStack/ServiceStack)
- [SpanJson](https://github.com/Tornhoof/SpanJson)
- [System.Text.Json](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/ref/System.Text.Json.cs)
    - [SourceGen System.Text.Json ](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/ref/System.Text.Json.cs)
- [UTF8Json](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/ref/System.Text.Json.cs)
```

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

Data set: collections of 1, 100, and 1 000 objects.

<a name="byte-array-deserialization"></a>

### Byte Array Deserialization

| Library                            | Size | Mean (ns) | Ops/sec (M) | Allocated | Gen0 |
| ---------------------------------- | ---: | --------: | ----------: | --------: | ---: |
| **JsonSrcGen (byte)**              |    1 |      59.1 |        16.9 |     144 B | 0.01 |
| **SpanJson (byte)**                |    1 |      98.3 |        10.2 |     120 B | 0.01 |
| **Utf8Json (byte)**                |    1 |     115.5 |         8.7 |     176 B | 0.01 |
| System.Text.Json Source-Gen (byte) |    1 |     268.1 |         3.7 |     648 B | 0.05 |
| Newtonsoft.Json (byte)             |    1 |     581.7 |         1.7 |   3 176 B | 0.25 |

*Larger sizes (100, 1 000) follow similar rankings: JsonSrcGen fastest, SpanJson and Utf8Json next, System.Text.Json source-gen moderate, Newtonsoft slowest with highest allocations.*

<a name="string-deserialization"></a>

### String Deserialization

| Library                              | Size | Mean (ns) | Ops/sec (M) | Allocated | Gen0 |
| ------------------------------------ | ---: | --------: | ----------: | --------: | ---: |
| **JsonSrcGen (string)**              |    1 |      72.1 |        13.9 |     152 B | 0.01 |
| **SpanJson (string)**                |    1 |     103.3 |         9.7 |     104 B | 0.01 |
| **Utf8Json (string)**                |    1 |     143.7 |         7.0 |     280 B | 0.02 |
| System.Text.Json Source-Gen (string) |    1 |     281.3 |         3.6 |     648 B | 0.05 |
| Newtonsoft.Json (string)             |    1 |     598.3 |         1.7 |   3 008 B | 0.24 |

<a name="serialization-benchmarks"></a>

## Serialization Benchmarks

Data set: single objects and batches of 100 and 1 000.

<a name="byte-array-serialization"></a>

### Byte Array Serialization

| Library                            | Size | Mean (ns) | Ops/sec (M) | Allocated | Gen0 |
| ---------------------------------- | ---: | --------: | ----------: | --------: | ---: |
| **JsonSrcGen (byte)**              |    1 |      35.7 |        28.0 |      96 B | 0.01 |
| **SpanJson (byte)**                |    1 |      51.6 |        19.4 |      96 B | 0.01 |
| **Utf8Json (byte)**                |    1 |      59.9 |        16.7 |     104 B | 0.01 |
| System.Text.Json Source-Gen (byte) |    1 |      95.1 |        10.5 |     128 B | 0.01 |
| Newtonsoft.Json (byte)             |    1 |     365.2 |         2.7 |   1 784 B | 0.14 |

<a name="string-serialization"></a>

### String Serialization

| Library                              | Size | Mean (ns) | Ops/sec (M) | Allocated | Gen0 |
| ------------------------------------ | ---: | --------: | ----------: | --------: | ---: |
| **JsonSrcGen (string)**              |    1 |      31.5 |        31.8 |     160 B | 0.01 |
| **SpanJson (string)**                |    1 |      60.1 |        16.6 |     168 B | 0.01 |
| **Utf8Json (string)**                |    1 |      80.6 |        12.4 |     256 B | 0.02 |
| System.Text.Json Source-Gen (string) |    1 |     104.2 |         9.6 |     192 B | 0.01 |
| Newtonsoft.Json (string)             |    1 |     334.5 |         3.0 |   1 688 B | 0.13 |

<a name="analysis"></a>

## Analysis

* **JsonSrcGen** consistently leads in both serialization and deserialization, offering the highest throughput and minimal allocations.
* **SpanJson** and **Utf8Json** trade slight speed for lower binary allocations.
* **Source-generated System.Text.Json** is competitive for serialization but lags in deserialization and allocates more.
* **Newtonsoft.Json** remains the slowest and most allocation-heavy, especially on byte-based scenarios.

<a name="conclusions"></a>

## Conclusions

For performance-critical JSON processing:

1. **Adopt JsonSrcGen** where possible for peak speed and low GC pressure.
2. **Use SpanJson** when binaries require minimal heap usage.
3. **Prefer System.Text.Json source-gen** for moderate-performance, easy integration.
4. **Avoid Newtonsoft.Json** in hot paths due to its high cost.
