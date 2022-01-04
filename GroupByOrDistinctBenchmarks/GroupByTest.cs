using BenchmarkDotNet.Attributes;
using Bogus;
using GroupByOrDistinctBenchmarks.TestModels;

namespace GroupByOrDistinctBenchmarks;

[MemoryDiagnoser(true)]
public class GroupByTest
{
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
        var _ = _testModelsList.GroupBy(x => x.InnerTestModelId)
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .ToArray();
    }
        
    [Benchmark]
    public void DistinctByTake()
    {
        var _ = _testModelsList.DistinctBy(x => x.InnerTestModelId)
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .ToArray();
    }
    
    [Benchmark]
    public void DistinctTake()
    {
        var _ = _testModelsList.Select(x => x.InnerTestModelId).Distinct()
            .Select(_ => _innerTestModels[InnerTestModelConstId])
            .ToArray();
    }
}