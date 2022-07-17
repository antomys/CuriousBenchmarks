using BenchmarkDotNet.Attributes;
using BoxingUnboxing.Benchmarks.Services;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <summary>
///     Getting Name of Enum benchmarks.
/// </summary>
public class EnumNameBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Getting string enum name by .ToString(). (Boxing allocation).
    /// </summary>
    /// <returns><see cref="string"/> value.</returns>
    [BenchmarkCategory(GroupConstants.Name)]
    [Benchmark]
    public string DefaultToString()
    {
        return TestEnums[0].DefaultToString();
    }

    /// <summary>
    ///     Getting string enum name by Enum.GetName().
    /// </summary>
    /// <returns><see cref="string"/> value.</returns>
    [BenchmarkCategory(GroupConstants.Name)]
    [Benchmark]
    public string? EnumGetName()
    {
        return TestEnums[0].EnumGetName();
    }

    /// <summary>
    ///     Getting string enum name by written custom method.
    /// </summary>
    /// <returns><see cref="string"/> value.</returns>
    [BenchmarkCategory(GroupConstants.Name)]
    [Benchmark]
    public string CustomGetName()
    {
        return TestEnums[0].CustomGetName();
    }
}