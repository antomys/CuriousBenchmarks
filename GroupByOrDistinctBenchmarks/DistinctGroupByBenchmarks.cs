using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using GroupByOrDistinctBenchmarks.Models;

namespace GroupByOrDistinctBenchmarks;

/// <summary>
///     Distinct/GroupBy benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class DistinctGroupByBenchmarks
{
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10,100,1000,10000,100000,1000000)]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public int GenerationSize { get; set; }
    
    private readonly Consumer _consumer = new();
    
    private List<TestModel> _testModelsList = new();
    private Dictionary<string, InnerTestModelId> _innerTestModels = new();
    private const string InnerTestModelConstId = "InnerTestModelConstId";

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker<TestModel>();
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

        var testModelFaker = new Faker<InnerTestModelId>();
        
        var generatedFakes2 = testModelFaker
            .RuleFor(x => x.InnerId, y => y.Random.String2(20))
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .Generate(GenerationSize * 2 - 1).ToDictionary(x => x.InnerId);
        
        _innerTestModels = generatedFakes2;
        _innerTestModels.Add(InnerTestModelConstId, new InnerTestModelId{InnerId = InnerTestModelConstId, Integer = default, DateOnly = DateTime.Now});
    }

    /// <summary>
    ///     Testing GroupBy and Take.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void GroupByTake()
    {
        _testModelsList
            .GroupBy(x => x.InnerTestModelId)
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .Consume(_consumer);
    }
        
    /// <summary>
    ///     Testing DistinctBy.
    /// </summary>
    [Benchmark]
    public void DistinctByTake()
    { 
        _testModelsList
            .DistinctBy(x => x.InnerTestModelId)
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .Consume(_consumer);
    }
    
    /// <summary>
    /// Testing Select + Distinct + Select.
    /// </summary>
    [Benchmark]
    public void DistinctTake()
    {
        _testModelsList
            .Select(x => x.InnerTestModelId)
            .Distinct()
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .Consume(_consumer);
    }
}