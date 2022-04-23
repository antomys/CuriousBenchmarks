using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using JsonBenchmarks.Models;
using MessagePack;

namespace JsonBenchmarks.Benchmarks;

/// <summary>
///     Serialization benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class SerializationBenchmarks
{
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1000, 10000, 100000, 1000000)]
    public int CollectionSize { get; set; }
    
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private List<TestModel> _persons = new();

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        Faker<TestModel> faker = new();
        Randomizer.Seed = new Random(420);
        _persons = faker
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.Date, y => y.Date.Past())
            .RuleFor(x => x.TemperatureCelsius, y => y.Random.Int())
            .RuleFor(x => x.Summary, y => y.Random.String2(5))
            .Generate(CollectionSize);
    }

    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("Stream"), Benchmark(Baseline = true)]
    public MemoryStream ClassicSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _persons, _options);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream GeneratedSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _persons, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream Utf8StreamSerializer()
    {
        var memoryStream = new MemoryStream();
        Utf8Json.JsonSerializer.Serialize(memoryStream, _persons);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream MsgPackStreamSerializer()
    {
        var memoryStream = new MemoryStream();
        MessagePackSerializer.Serialize(memoryStream, _persons);

        return memoryStream;
    }

    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string ClassicStringSerializer()
    {
        return JsonSerializer.Serialize(_persons, _options);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string GeneratedStringSerializer()
    {
        return JsonSerializer.Serialize(_persons, TestModelJsonContext.Default.ICollectionTestModel);
    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string NewtonsoftStringSerializer()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(_persons);
    }
    
    /// <summary>
    ///     Serializes with Jil.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string JilStringSerializer()
    {
        return Jil.JSON.Serialize(_persons);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string Utf8JsonStringSerializer()
    {
        var serialized = Utf8Json.JsonSerializer.Serialize(_persons)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to bytes.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string SpanJsonStringFromByteSerializer()
    {
        var serialized = SpanJson.JsonSerializer.Generic.Utf8.Serialize(_persons)!;

        return Encoding.UTF8.GetString(serialized, 0, serialized.Length);
    }
    
    /// <summary>
    ///     Serializes with SpanJson to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string SpanJsonStringSerializer()
    {
        var serialized = SpanJson.JsonSerializer.Generic.Utf16.Serialize(_persons)!;

        return serialized;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [BenchmarkCategory("String"), Benchmark]
    public string MsgPackStringSerializer()
    {
        var serialized = MessagePackSerializer.Serialize(_persons)!;

        return MessagePackSerializer.ConvertToJson(serialized);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Async Stream"), Benchmark(Baseline = true)]
    public MemoryStream ClassicSerializerAsync()
    {
        var memoryStream = new MemoryStream();
        JsonSerializer.SerializeAsync(memoryStream, _persons, _options);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Async Stream"), Benchmark]
    public async Task<MemoryStream> GeneratedSerializerAsync()
    {
        var memoryStream = new MemoryStream();
        
        await JsonSerializer.SerializeAsync(memoryStream, _persons, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Async Stream"), Benchmark]
    public async Task<MemoryStream> Utf8StreamSerializerAsync()
    {
        var memoryStream = new MemoryStream();
        await Utf8Json.JsonSerializer.SerializeAsync(memoryStream, _persons);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Async Stream"), Benchmark]
    public async Task<MemoryStream> SpanJsonStreamSerializerAsync()
    {
        var memoryStream = new MemoryStream();
        await SpanJson.JsonSerializer.Generic.Utf8.SerializeAsync(_persons, memoryStream);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory("Async Stream"), Benchmark]
    public async Task<MemoryStream> MsgPackStreamSerializerAsync()
    {
        var memoryStream = new MemoryStream();
        await MessagePackSerializer.SerializeAsync(memoryStream, _persons);

        return memoryStream;
    }
}