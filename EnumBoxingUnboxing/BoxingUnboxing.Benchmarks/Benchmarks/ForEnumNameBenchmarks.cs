using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BoxingUnboxing.Benchmarks.Extensions;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <inheritdoc />
public class ForEnumNameBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     For cycle with getting Enum name.
    /// </summary>
    [BenchmarkCategory(GroupConstants.ForName), Benchmark]
    public void ArrayNameToString()
    {
        for(var i = 0; i < TestEnums.Length; i++)
        {
            TestEnums[i].ToString().Consume(Consumer);
        }
    }

    /// <summary>
    ///     For cycle with getting Enum name using Enum.GetName
    /// </summary>
    [BenchmarkCategory(GroupConstants.ForName), Benchmark]
    public void ArrayNameGetName()
    {
        for(var i = 0; i < TestEnums.Length; i++)
        {
            Enum.GetName(TestEnums[i]).Consume(Consumer);
        }
    }

    /// <summary>
    ///     For cycle with getting Enum name using custom method
    /// </summary>
    [BenchmarkCategory(GroupConstants.ForName), Benchmark]
    public void ArrayNameCustom()
    {
        for(var i = 0; i < TestEnums.Length; i++)
        {
            EnumExtensions.CustomGetName(TestEnums[i]).Consume(Consumer);
        }
    }
}