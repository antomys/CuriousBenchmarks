using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Bogus;
using LinqGroupByDistinct.Benchmarks.Models;
using LinqGroupByDistinct.Benchmarks.Services;

namespace LinqGroupByDistinct.Benchmarks;

/// <summary>
///     Distinct/GroupBy benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class DistinctGroupByBenchmarks
{
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100, 1000, 10000, 100000, 1000000)]
    public int GenerationSize { get; set; }
    
    private readonly Consumer _consumer = new();
    
    private List<SimpleModel> _testModelsList = new();
    private Dictionary<string, InnerModel> _innerTestModels = new();
    
    private const string InnerTestModelConstId = "InnerTestModelConstId";

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<SimpleModel>();
        var genericFaker = new Faker();
        Randomizer.Seed = new Random(420);
        
        _testModelsList = faker
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .RuleFor(x => x.InnerTestModelId, y => y.Random.String2(20))
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.TestModelId, y => y.Random.String2(20))
            .Generate(GenerationSize);
        
        _testModelsList.AddRange(faker
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .RuleFor(x => x.InnerTestModelId, _ => InnerTestModelConstId)
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.TestModelId, y => y.Random.String2(20))
            .Generate(GenerationSize));

        var testModelFaker = new Faker<InnerModel>();
        
        _innerTestModels = testModelFaker
            .RuleFor(x => x.InnerId, y => y.Random.String2(20))
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .Generate(GenerationSize * 2 - 1)
            .ToDictionary(x => x.InnerId);
        
        _innerTestModels.Add(InnerTestModelConstId, new InnerModel
        {
            InnerId = InnerTestModelConstId,
            Integer = genericFaker.Random.Int(),
            DateOnly = genericFaker.Date.Past()
        });
    }

    /// <summary>
    ///     Testing GroupBy and Take.  
    /// </summary>
    [Benchmark(Baseline = true)]
    public void GroupByTake()
    {
        _testModelsList.GroupByTake(_innerTestModels, InnerTestModelConstId).Consume(_consumer);
    }
        
    /// <summary>
    ///     Testing DistinctBy.
    /// </summary>
    [Benchmark]
    public void DistinctByTake()
    {
        _testModelsList.DistinctByTake(_innerTestModels, InnerTestModelConstId).Consume(_consumer);
    }
    
    /// <summary>
    ///     Testing Select + Distinct + Select.
    /// </summary>
    [Benchmark]
    public void DistinctTake()
    {
        _testModelsList.DistinctTake(_innerTestModels, InnerTestModelConstId).Consume(_consumer);
    }
}