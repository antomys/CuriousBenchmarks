using Benchmarks.Enum.Services;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Enum.Benchmarks;

/// <summary>
///     Benchmarks of getting int value from enum.
/// </summary>
public class EnumValueBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Getting int value from enum by .ToString().
    /// </summary>
    [BenchmarkCategory(Group.Value), Benchmark]
    public string ToStringFormatD()
    {
        return TestEnums[0].ToStringFormatD();
    }

    /// <summary>
    ///     Getting int value from enum by implicit cast of enum
    /// </summary>
    [BenchmarkCategory(Group.Value), Benchmark]
    public string IntCastToString()
    {
        return TestEnums[0].IntCastToString();
    }

    /// <summary>
    ///     Getting int value from enum by custom method
    /// </summary>
    [BenchmarkCategory(Group.Value), Benchmark]
    public string ExternalMethodToString()
    {
        return TestEnums[0].CustomGetValue();
    }
}