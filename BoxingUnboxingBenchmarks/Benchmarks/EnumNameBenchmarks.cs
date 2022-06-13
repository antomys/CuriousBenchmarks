using BenchmarkDotNet.Attributes;
using BoxingUnboxingBenchmarks.Extensions;

namespace BoxingUnboxingBenchmarks.Benchmarks;

/// <summary>
///     Getting Name of Enum benchmarks
/// </summary>
public class EnumNameBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Getting string enum name by .ToString(). (Boxing allocation).
    /// </summary>
    [BenchmarkCategory(GroupConstants.Name), Benchmark]
    public string NameToString()
    {
        return TestEnums[0].ToString();
    }
    
    /// <summary>
    ///     Getting string enum name by Enum.GetName().
    /// </summary>
    [BenchmarkCategory(GroupConstants.Name), Benchmark]
    public string? NameGetName()
    {
        return Enum.GetName(TestEnums[0]);
    }
    
    /// <summary>
    ///     Getting string enum name by written custom method.
    /// </summary>
    [BenchmarkCategory(GroupConstants.Name), Benchmark]
    public string NameCustom()
    {
        return EnumExtensions.GetName(TestEnums[0]);
    }

}