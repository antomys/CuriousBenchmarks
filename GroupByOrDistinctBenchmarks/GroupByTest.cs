using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using Bogus;
using GroupByOrDistinctBenchmarks.TestModels;

namespace GroupByOrDistinctBenchmarks;

[MemoryDiagnoser]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class GroupByTest
{
    private readonly Consumer _consumer = new();
    
    private List<TestModel> _testModelsList = new();
    private Dictionary<string, InnerTestModelId> _innerTestModels = new();
    private const string InnerTestModelConstId = "InnerTestModelConstId";

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
            .Generate(50000);
        
        _testModelsList.AddRange(faker
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .RuleFor(x => x.InnerTestModelId, _ => InnerTestModelConstId)
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.TestModelId, y => y.Random.String2(20))
            .Generate(50000));

        var testModelFaker = new Faker<InnerTestModelId>();
        
        var generatedFakes2 = testModelFaker
            .RuleFor(x => x.InnerId, y => y.Random.String2(20))
            .RuleFor(x => x.DateOnly, y => y.Date.Past())
            .RuleFor(x => x.Integer, y => y.Random.Int())
            .Generate(99999).ToDictionary(x => x.InnerId);
        _innerTestModels = generatedFakes2;
        _innerTestModels.Add(InnerTestModelConstId, new InnerTestModelId{InnerId = InnerTestModelConstId, Integer = default, DateOnly = DateTime.Now});
    }

    [Benchmark(Baseline = true)]
    public void GroupByTake()
    {
        _testModelsList
            .GroupBy(x => x.InnerTestModelId)
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .Consume(_consumer);
    }
        
    [Benchmark]
    public void DistinctByTake()
    { 
        _testModelsList
            .DistinctBy(x => x.InnerTestModelId)
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .Consume(_consumer);
    }
    
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