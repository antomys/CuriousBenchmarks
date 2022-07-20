using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Async Stream serialization benchmarks.
/// </summary>
public class AsyncStreamSerializationBenchmarks : JsonBenchmark
{
    /// <summary>
    ///     Global setup of test values.
    /// </summary>
    [GlobalSetup]
    public new void Setup() => base.Setup();
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark(Baseline = true)]
    public Task<MemoryStream> SystemTextJson()
     {
         return SystemTextJsonService.SystemTextJsonSerializeStreamAsync(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonSourceGenSerializeAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> Utf8Json()
    {
        return Utf8JsonService.Utf8JsonSerializeStreamAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> SpanJson()
    {
        return SpanJsonService.SpanJsonSerializeStreamAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> MsgPackClassic()
    {
        return MsgPackService.MsgPackClassicSerializeAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> MsgPackLz4Block()
    {
        return MsgPackService.MsgPackLz4BlockSerializeAsync(SimpleModels);
    }
}