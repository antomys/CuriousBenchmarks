using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Simple;

/// <summary>
///     Async Stream serialization benchmarks.
/// </summary>
public class AsyncStreamSerializationSimpleBenchmarks : JsonSimpleBenchmark
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
         return SystemTextJsonService.SerializeStreamAsync(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> SystemTextJsonSourceGen()
    {
        if (SimpleModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.SimpleSerializeAsync(SimpleModels[0]);
        }
        
        return SystemTextJsonGeneratedService.SimpleSerializeArrayAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> Utf8Json()
    {
        return Utf8JsonService.SerializeStreamAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> SpanJson()
    {
        return SpanJsonService.SerializeStreamAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> MsgPackClassic()
    {
        return MsgPackService.ClassicSerializeAsync(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> MsgPackLz4Block()
    {
        return MsgPackService.Lz4BlockSerializeAsync(SimpleModels);
    }
}