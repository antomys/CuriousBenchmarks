using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BoxingUnboxingBenchmarks.Extensions;

namespace BoxingUnboxingBenchmarks.Benchmarks;

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
            EnumExtensions.GetName(TestEnums[i]).Consume(Consumer);
        }
    }
}