using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;
using MessagePack;

namespace JsonBenchmarks;

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
    private byte[] _personsMsgPack = default!;

    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel.TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        _person = JsonSerializer.Serialize(faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000), _options);
        
        Faker<TestModel.TestModel> fakerMsgPack = new();
        _personsMsgPack = MessagePackSerializer.Serialize(fakerMsgPack
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000));
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public ICollection<TestModel.TestModel> ClassicDeserializer()
    {
        return JsonSerializer.Deserialize<ICollection<TestModel.TestModel>>(_person, _options)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> GeneratedDeserializer()
    {
        return JsonSerializer.Deserialize(_person, TestModel.TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> NewtonsoftDeserializer()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<TestModel.TestModel>>(_person)!;
    }
    
    /*[BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel> JilDeserializer()
    {
        return Jil.JSON.Deserialize<ICollection<TestModel>>(_person)!;
    }*/
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> Utf8Deserializer()
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel.TestModel>>(_person)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> SpanJsonDeserializer()
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<TestModel.TestModel>>(_person)!;
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public ICollection<TestModel.TestModel> MsgPackDeserializer()
    {
        return MessagePackSerializer.Deserialize<ICollection<TestModel.TestModel>>(_personsMsgPack);
    }
}