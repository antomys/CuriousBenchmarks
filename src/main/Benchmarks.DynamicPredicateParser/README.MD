# DynamicPredicateParser Performance Benchmarks

## Table of contents

* [Reasons and introduction](#reasons-and-introduction)
* [Machine information](#machine-information)
* [Benchmarks](#benchmarks)

    * [Generation Size: 100](#generation-size-100)
    * [Generation Size: 1 000](#generation-size-1000)
    * [Generation Size: 10 000](#generation-size-10000)
* [Conclusions](#conclusions)

<a name="reasons-and-introduction"></a>

## Reasons and introduction

We wanted to compare the performance and memory behavior of two dynamic predicate parsing approaches:

* **DynamicCore**: a lightweight, core-based expression parser.
* **PredicateParser**: a more feature‑rich parser implementation.

The goal is to understand how parsing scales with the complexity (generation size) and which implementation delivers the best throughput and lowest GC pressure.

<a name="machine-information"></a>

## Machine information

```ini
BenchmarkDotNet v0.15.1, Windows 11 (10.0.26100.4351/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
```

<a name="benchmarks"></a>

## Benchmarks

### Generation Size: 100

| Method          | Mean (μs) |  Ops/sec | Allocated (KB) | Ratio vs DynamicCore |
| --------------- | --------: | -------: | -------------: | -------------------: |
| DynamicCore     |     51.87 | 19 279.6 |          23.65 |                 1.00 |
| PredicateParser |     65.16 | 15 347.6 |          16.77 |                 1.26 |

### Generation Size: 1 000

| Method          | Mean (μs) |  Ops/sec | Allocated (KB) | Ratio vs DynamicCore |
| --------------- | --------: | -------: | -------------: | -------------------: |
| DynamicCore     |     63.71 | 15 697.0 |          23.64 |                 1.00 |
| PredicateParser |     83.01 | 12 046.8 |          16.77 |                 1.31 |

### Generation Size: 10 000

| Method          | Mean (μs) |  Ops/sec | Allocated (KB) | Ratio vs DynamicCore |
| --------------- | --------: | -------: | -------------: | -------------------: |
| DynamicCore     |     86.34 | 11 582.6 |          23.64 |                 1.00 |
| PredicateParser |    261.70 |  3 821.1 |          16.76 |                 3.04 |

<a name="conclusions"></a>

## Conclusions

* **Throughput**: `DynamicCore` outperforms `PredicateParser` at every generation size, with up to **3× higher** operation rate at larger inputs.
* **Latency**: Mean parse times for `PredicateParser` grow more steeply—by \~26% at size=100, \~31% at size=1 000, and over **200%** at size=10 000.
* **Memory**: `PredicateParser` allocates about **30% less** per operation, thanks to leaner data structures.

**Recommendation:** Use **DynamicCore** for high-throughput or large‑scale parsing scenarios. Consider **PredicateParser** only when its advanced features justify the increased latency.
