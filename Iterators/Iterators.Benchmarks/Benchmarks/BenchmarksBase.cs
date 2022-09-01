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
public class BenchmarksBase
{
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100000)]
    public int Size { get; set; }

    /// <summary>
    ///     <see cref="BenchmarkDotNet.Engines.Consumer"/>.
    /// </summary>
    protected readonly Consumer Consumer = new();
    
    /// <summary>
    ///     List of <see cref="SimpleModel"/>.
    /// </summary>
    protected List<SimpleModel> TestInputModels = default!;

    /// <summary>
    ///     Array of int.
    /// </summary>
    protected int[] TestArray = default!;

    /// <summary>
    ///     List of int.
    /// </summary>
    protected List<int> TestList = default!;

    /// <summary>
    ///     Collection of int as array
    /// </summary>
    protected ICollection<int> TestCollectionArray = default!;
    
    /// <summary>
    ///     Collection of int as list
    /// </summary>
    protected ICollection<int> TestCollectionList = default!;

    /// <summary>
    ///     Global setup of private and protected parameters.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<SimpleModel>();
        Randomizer.Seed = new Random(420);
        
        TestInputModels = faker
            .RuleFor(testModel => testModel.TestInd, fakerSetter => fakerSetter.Random.Int(-100000, 100000))
            .RuleFor(testModel => testModel.TestString, fakerSetter=> fakerSetter.Random.String2(10))
            .RuleFor(testModel => testModel.TestDateTime, fakerSetter=> fakerSetter.Date.Past())
            .Generate(Size)!;

        TestArray = TestInputModels.Select(model => model.TestInd).ToArray();
        TestList = TestInputModels.Select(model => model.TestInd).ToList();
        TestCollectionArray = TestInputModels.Select(model => model.TestInd).ToArray();
        TestCollectionList = TestInputModels.Select(model => model.TestInd).ToList();
    }
}