using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Benchmarks.String.Models;
using Bogus;

namespace Benchmarks.String.Benchmarks.Abstractions;

/// <summary>
///     Base abstraction for benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class BenchmarkCollectionBase
{
    /// <summary>
    ///     Gets or sets flag whether stack should be triggered or other collections.
    /// </summary>
    [Params(true, false)]
    public bool IsStack { get; set; }
    
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000)]
    public int Values { get; set; }
    
    /// <summary>
    ///     Collection of <see cref="StringsTestModel"/> for benchmarks.
    /// </summary>
    protected List<StringsTestModel> TestStringArray = null!;
    
    /// <summary>
    ///     Benchmark <see cref="Consumer"/>.
    /// </summary>
    protected readonly Consumer Consumer = new();
    
    /// <summary> 
    ///   Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        //stackalloc is used when sum of chars is less than 64. So we do generate random bigger that 64 to eliminate this behaviour.
        TestStringArray = IsStack
            ? new Faker<StringsTestModel>()
                .RuleFor(x => x.Values, y => new[] {y.Random.String2(5, 20), y.Random.String2(5, 20)})
                .Generate(Values)
            : new Faker<StringsTestModel>()
                .RuleFor(x => x.Values, y => new[] {y.Random.String2(65, 100), y.Random.String2(40, 100)})
                .Generate(Values);
    }
}