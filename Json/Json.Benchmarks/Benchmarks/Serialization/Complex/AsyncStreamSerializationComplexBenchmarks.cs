using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Complex;

/// <summary>
///     Async Stream serialization benchmarks.
/// </summary>
public class AsyncStreamSerializationComplexBenchmarks : JsonComplexBenchmark
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
         return SystemTextJsonService.SerializeStreamAsync(ComplexModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> SystemTextJsonSourceGen()
    {
        if (ComplexModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.ComplexSerializeAsync(ComplexModels[0]);
        }
        
        return SystemTextJsonGeneratedService.ComplexSerializeArrayAsync(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> Utf8Json()
    {
        return Utf8JsonService.SerializeStreamAsync(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> SpanJson()
    {
        return SpanJsonService.SerializeStreamAsync(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> MsgPackClassic()
    {
        return MsgPackService.ClassicSerializeAsync(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public Task<MemoryStream> MsgPackLz4Block()
    {
        return MsgPackService.Lz4BlockSerializeAsync(ComplexModels);
    }
}