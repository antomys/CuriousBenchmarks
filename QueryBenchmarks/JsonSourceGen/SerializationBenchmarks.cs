using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;

namespace QueryBenchmarks.JsonSourceGen;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class SerializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private List<TestModel> _person = new();

    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        _person = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(1000);
    }

    [BenchmarkCategory("Stream"), Benchmark(Baseline = true)]
    public MemoryStream ClassicSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _person, _options);

        return memoryStream;
    }
    
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream GeneratedSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _person, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream Utf8StreamSerializer()
    {
        var memoryStream = new MemoryStream();
        Utf8Json.JsonSerializer.Serialize(memoryStream, _person);

        return memoryStream;
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string ClassicStringSerializer()
    {
        return JsonSerializer.Serialize(_person, _options);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string GeneratedStringSerializer()
    {
        return JsonSerializer.Serialize(_person, TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string NewtonsoftStringSerializer()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(_person);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string JilStringSerializer()
    {
        return Jil.JSON.Serialize(_person);
    }
    
    [BenchmarkCategory("String"), Benchmark]
    public string Utf8JsonStringSerializer()
    {
        var serialized = Utf8Json.JsonSerializer.Serialize(_person)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
}