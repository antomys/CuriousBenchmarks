using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BoxingUnboxing.Benchmarks.Extensions;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <inheritdoc />
public class ForEnumValueBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     For method with getting int value from Enum using .ToString("D")
    /// </summary>
    [BenchmarkCategory(GroupConstants.ForValue), Benchmark]
    public void ArrayIntToString()
    {
        for(var i = 0; i < TestEnums.Length; i++)
        {
            TestEnums[i].ToString("D").Consume(Consumer);
        }
    }
    
    /// <summary>
    ///     For method with getting int from casting
    /// </summary>
    [BenchmarkCategory(GroupConstants.ForValue), Benchmark]
    public void ArrayIntCast()
    {
        for(var i = 0; i < TestEnums.Length; i++)
        {
            ((int) TestEnums[i]).ToString().Consume(Consumer);
        }
    }
    
    /// <summary>
    ///     For method with getting int using custom extensions method.
    /// </summary>
    [BenchmarkCategory(GroupConstants.ForValue), Benchmark]
    public void ArrayIntCustom()
    {
        for(var i = 0; i < TestEnums.Length; i++)
        {
            EnumExtensions.CustomGetValue(TestEnums[i]).ToString().Consume(Consumer);
        }
    }
}