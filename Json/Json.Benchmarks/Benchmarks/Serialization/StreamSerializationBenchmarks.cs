using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization tests using <see cref="Stream"/>.
/// </summary>
public class StreamSerializationBenchmarks : SerializationBenchmarksBase
{
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark(Baseline = true)]
    public MemoryStream SystemTextJson()
    {
        using var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, Persons, Options);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream SystemTextJsonSourceGen()
    {
        using  var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, Persons, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream Maverick()
    {
        using var memoryStream = new MemoryStream();
        global::Maverick.Json.JsonConvert.Serialize(memoryStream, Persons,  global::Maverick.Json.JsonFormat.None, MaverickSettings);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream Utf8Json()
    {
        using var memoryStream = new MemoryStream();
        global::Utf8Json.JsonSerializer.Serialize(memoryStream, Persons);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream ZeroFormatter()
    {
        using var memoryStream = new MemoryStream();
        global::ZeroFormatter.ZeroFormatterSerializer.Serialize(memoryStream, PersonsVirtual);
        
        return memoryStream;
    }
        
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream Protobuf()
    {
        using var memoryStream = new MemoryStream();
        ProtoBuf.Serializer.Serialize(memoryStream, Persons);

        return memoryStream;
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream MsgPackNoCompress()
    {
        using var memoryStream = new MemoryStream();
        MessagePack.MessagePackSerializer.Serialize(memoryStream, Persons);

        return memoryStream;
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public MemoryStream MsgPackLz4Block()
    {
        using var memoryStream = new MemoryStream();
        MessagePack.MessagePackSerializer.Serialize(
            memoryStream,
            Persons,
            MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray));

        return memoryStream;
    }

}