using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Async Stream serialization benchmarks.
/// </summary>
public class AsyncStreamSerializationBenchmarks : SerializationBenchmarksBase
{
     /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.AsyncStream), Benchmark(Baseline = true)]
    public async Task<MemoryStream> SystemTextJson()
    {
        await using var memoryStream = new MemoryStream();
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, Persons, Options);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.AsyncStream), Benchmark]
    public async Task<MemoryStream> SystemTextJsonSourceGen()
    {
        await using var memoryStream = new MemoryStream();
        
        await System.Text.Json.JsonSerializer.SerializeAsync(memoryStream, Persons, TestModelJsonContext.Default.ICollectionTestModel);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.AsyncStream), Benchmark]
    public async Task<MemoryStream> Utf8Json()
    {
        await using var memoryStream = new MemoryStream();
        await global::Utf8Json.JsonSerializer.SerializeAsync(memoryStream, Persons);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.AsyncStream), Benchmark]
    public async Task<MemoryStream> SpanJson()
    {
        await using var memoryStream = new MemoryStream();
        await global::SpanJson.JsonSerializer.Generic.Utf8.SerializeAsync(Persons, memoryStream);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.AsyncStream), Benchmark]
    public async Task<MemoryStream> MsgPackClassic()
    {
        await using var memoryStream = new MemoryStream();
        await MessagePack.MessagePackSerializer.SerializeAsync(memoryStream, Persons);

        return memoryStream;
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [BenchmarkCategory(BenchmarkGroups.AsyncStream), Benchmark]
    public async Task<MemoryStream> MsgPackLz4Block()
    {
        await using var memoryStream = new MemoryStream();
        await MessagePack.MessagePackSerializer.SerializeAsync(
            memoryStream,
            Persons,
            MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray));

        return memoryStream;
    }
}