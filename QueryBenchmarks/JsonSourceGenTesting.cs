using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Bogus;
using QueryBenchmarks.JsonSourceGen;

namespace QueryBenchmarks;

[MemoryDiagnoser]
public class JsonSourceGenTesting
{
    private static string _weatherString = default!;

    private static List<TestModel> _testModel = default!;
    
    [GlobalSetup]
    public static void SetupVariables()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        _testModel = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000);
        _weatherString =
        @"{
    ""Date"": ""2019-08-01T00:00:00"",
    ""TemperatureCelsius"": 25,
    ""Summary"": ""Hot""
    }
    ";
    }

    [Benchmark]
    public void SerializeDefault()
    {
        JsonSerializer.Serialize(_testModel);
    }
    
    [Benchmark]
    public void DeserializeDefault()
    {
        JsonSerializer.Deserialize<TestModel>(_weatherString);
    }
    
    [Benchmark]
    public void SerializeGenerated()
    {
        SetupVariables();
        var tst = JsonSerializer.Serialize(_testModel, typeof(IEnumerable<TestModel>), TestModelGenerationContext.Default);
    }
    
    [Benchmark]
    public void DeserializeGenerated()
    {
        SetupVariables();
        var tst = JsonSerializer.Serialize(_testModel, _testModel.GetType(), TestModelGenerationContext.Default); // WORKING
        //var tst = JsonSerializer.Serialize(_testModel, TestModelGenerationContext.Default.TestModel); //NOT WORKING
        var aa = JsonSerializer.Deserialize(tst, TestModelGenerationContext.Default.TestModel);
    }
}