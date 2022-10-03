using BenchmarkDotNet.Attributes;
using BoxingUnboxing.Benchmarks.Services;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <summary>
///     Getting Name of Enum benchmarks.
/// </summary>
public class NameEnumBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Getting string enum name by Enum.GetName().
    /// </summary>
    /// <returns><see cref="string"/> value.</returns>
    [BenchmarkCategory(GroupConstants.Name)]
    [Benchmark]
    public TestEnum EnumTryParse()
    {
        return TestEnumNames[0].EnumTryParse();
    }

    /// <summary>
    ///     Getting string enum name by written custom method.
    /// </summary>
    /// <returns><see cref="string"/> value.</returns>
    [BenchmarkCategory(GroupConstants.Name)]
    [Benchmark]
    public TestEnum CustomGetEnumFromName()
    {
        return TestEnumNames[0].CustomGetEnumFromName();
    }
}