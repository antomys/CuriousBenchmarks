using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using Iterators.Benchmarks.Models;

namespace Iterators.Benchmarks.Benchmarks;

/// <summary>
///     Base class for iterators benchmarks.
/// </summary>
[RPlotExporter]
[MemoryDiagnoser]
[CategoriesColumn]
[AllStatisticsColumn]
[CsvMeasurementsExporter]
[MarkdownExporterAttribute.GitHub]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class BenchmarkBase
{
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    public int Size { get; set; }

    /// <summary>
    ///     <see cref="BenchmarkDotNet.Engines.Consumer"/>.
    /// </summary>
    protected readonly Consumer Consumer = new();
    
    /// <summary>
    ///     Collection of <see cref="SimpleModel"/>.
    /// </summary>
    protected static List<SimpleModel?> TestInputModels = default!;
    
    /// <summary>
    ///     Cleans array.
    /// </summary>
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        TestInputModels.Clear();
    }
    
    /// <summary>
    ///     Global setup of private and protected parameters.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<SimpleModel>();
        Randomizer.Seed = new Random(420);
        
        TestInputModels = faker
            .RuleFor(testModel => testModel.TestInd, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(testModel => testModel.TestString, fakerSetter=> fakerSetter.Random.String2(10))
            .RuleFor(testModel => testModel.TestDateTime, fakerSetter=> fakerSetter.Date.Past())
            .Generate(Size)!;
    }
}