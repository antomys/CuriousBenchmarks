# EnumName and EnumValue Performance Benchmarks

## Table of contents

* [Reasons and introduction](#reasons-and-introduction)
* [Machine information](#machine-information)
* [Benchmarks](#benchmarks)

  * [Get Enum Name](#get-enum-name)
  * [Get Enum Value](#get-enum-value)
* [Conclusions](#conclusions)

<a name="reasons-and-introduction"></a>

## Reasons and introduction

We needed to evaluate the fastest and least-allocating strategies for both retrieving an enum’s name and formatting its numeric value as a string. Specifically:

* **Get Enum Name**:

  1. `CustomGetName` via a prebuilt lookup dictionary
  2. `Enum.GetName()` reflection-based API
  3. Default `ToString()` on the enum

* **Get Enum Value**:

  1. Cast to `int` then call `ToString()`
  2. `ExternalMethodToString` via a precomputed mapping
  3. `value.ToString("D")` format specifier

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

### Get Enum Name

```csharp
// 1. Custom lookup
public static string CustomGetName(MyEnum value) => _nameMap[value];

// 2. Enum.GetName
public static string EnumGetName(MyEnum value) => Enum.GetName(typeof(MyEnum), value);

// 3. Default ToString()
public static string DefaultToString(MyEnum value) => value.ToString();
```

| Method          | Mean (ns) | Error (ns) | StdDev (ns) | Ops/sec (M) |  Gen0 | Allocated (B) |
| --------------- | --------: | ---------: | ----------: | ----------: | ----: | ------------: |
| CustomGetName   |     0.495 |      0.037 |       0.034 |     2019.79 |     - |             - |
| EnumGetName     |     3.717 |      0.085 |       0.075 |      269.05 |     - |             - |
| DefaultToString |     5.510 |      0.131 |       0.123 |      181.48 | 0.002 |            24 |

### Get Enum Value

```csharp
// 1. Cast to int then ToString()
public static string IntCastToString(MyEnum value) => ((int)value).ToString();

// 2. External mapping method
public static string ExternalMethodToString(MyEnum value) => _valueMap[value];

// 3. ToString with "D" format
public static string ToStringFormatD(MyEnum value) => value.ToString("D");
```

| Method                 | Mean (ns) | Error (ns) | StdDev (ns) | Ops/sec (M) |  Gen0 | Allocated (B) |
| ---------------------- | --------: | ---------: | ----------: | ----------: | ----: | ------------: |
| IntCastToString        |     1.424 |      0.071 |       0.067 |      702.20 |     - |             - |
| ExternalMethodToString |     2.468 |      0.105 |       0.113 |      405.14 |     - |             - |
| ToStringFormatD        |     6.449 |      0.125 |       0.111 |      155.06 | 0.002 |            24 |

<a name="conclusions"></a>

## Conclusions

* **Enum Name**: The `CustomGetName` lookup is the fastest (<1 ns) with zero allocations. `Enum.GetName` and `ToString()` are significantly slower, and `ToString()` incurs allocations.
* **Enum Value**: Casting to `int` then `ToString()` offers the best balance of speed and zero allocations, outperforming an external map and `ToString("D")`, which allocates.
* **Recommendation**: In performance-critical paths, use a prebuilt lookup for enum names and cast-to-int for value formatting.
