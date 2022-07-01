using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BoxingUnboxing.Benchmarks.Extensions;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <inheritdoc />
public class LinqEnumNameBenchmarks : EnumBenchmarksBase
{
    /// <summary>
    ///     Linq method with getting name from Enum using .ToString
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinqName), Benchmark]
    public void LinqNameToString()
    {
        TestEnums.Select(testEnum => testEnum.ToString()).Consume(Consumer);
    }
    
    /// <summary>
    ///     Linq method with getting name from Enum using Enum.GetName. NOTE: Not group method, because func will not be cached!
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinqName), Benchmark]
    public void LinqNameGetName()
    {
        TestEnums.Select(testEnum => Enum.GetName(testEnum)).Consume(Consumer);
    }
    
    /// <summary>
    ///     Linq method with getting name from Enum using custom method. NOTE: Not group method, because func will not be cached!
    /// </summary>
    [BenchmarkCategory(GroupConstants.LinqName), Benchmark]
    public void LinqNameCustom()
    {
        TestEnums.Select(testEnum => EnumExtensions.CustomGetName(testEnum)).Consume(Consumer);
    }
}