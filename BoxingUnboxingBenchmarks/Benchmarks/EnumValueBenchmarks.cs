using BenchmarkDotNet.Attributes;
using BoxingUnboxingBenchmarks.Extensions;

namespace BoxingUnboxingBenchmarks.Benchmarks;

/// <summary>
///     Benchmarks of getting int value from enum.
/// </summary>
public class EnumValueBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Getting int value from enum by .ToString().
    /// </summary>
    [BenchmarkCategory(GroupConstants.Value), Benchmark]
    public string IntToString()
    {
        return TestEnums[0].ToString("D");
    }
    
    /// <summary>
    ///     Getting int value from enum by implicit cast of enum
    /// </summary>
    [BenchmarkCategory(GroupConstants.Value), Benchmark]
    public string IntCast()
    {
        return ((int) TestEnums[0]).ToString();
    }
    
    /// <summary>
    ///     Getting int value from enum by custom method
    /// </summary>
    [BenchmarkCategory(GroupConstants.Value), Benchmark]
    public string IntCustom()
    {
        return EnumExtensions.GetValue(TestEnums[0]).ToString();
    }

}