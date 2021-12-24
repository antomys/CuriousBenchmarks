using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;
using MessagePack;

namespace QueryBenchmarks.JsonSourceGen;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class DeserializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private string _person = string.Empty;
    private byte[] _personsMsgPack;

    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        _person = JsonSerializer.Serialize(faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000), _options);
        
        Faker<TestModelMessagePack> fakerMsgPack = new();
        _personsMsgPack = MessagePackSerializer.Serialize(fakerMsgPack
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000));
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public ICollection<TestModel> ClassicDeserializer()
    {
        return JsonSerializer.Deserialize<ICollection<TestModel>>(_person, _options)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> GeneratedDeserializer()
    {
        return JsonSerializer.Deserialize(_person, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> NewtonsoftDeserializer()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<TestModel>>(_person)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> JilDeserializer()
    {
        return Jil.JSON.Deserialize<ICollection<TestModel>>(_person)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> Utf8Deserializer()
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_person)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModelMessagePack> MsgPackDeserializer()
    {
        return MessagePackSerializer.Deserialize<ICollection<TestModelMessagePack>>(_personsMsgPack);
    }
}