using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BoxingUnboxing.Benchmarks.Extensions;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <inheritdoc />
public class LinqEnumValueBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Linq method with getting int value from Enum using .ToString("D")
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinqValue), Benchmark]
    public void LinqIntToString()
    {
        TestEnums.Select(testEnum => testEnum.ToString("D")).Consume(Consumer);
    }

    /// <summary>
    ///     Linq method with getting int value from Enum using cast
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinqValue), Benchmark]
    public void LinqIntCast()
    {
        TestEnums.Select(testEnum =>  ((int) testEnum).ToString()).Consume(Consumer);
    }

    /// <summary>
    ///     Linq method with getting int value from Enum using custom method.
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinqValue), Benchmark]
    public void LinqIntCustom()
    {
        TestEnums.Select(testEnum => EnumExtensions.CustomGetValue(testEnum).ToString()).Consume(Consumer);
    }
}