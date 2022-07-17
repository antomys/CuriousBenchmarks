using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization from byte array.
/// </summary>
public class ByteSerializationBenchmarks : JsonBenchmark
{
    /// <summary>
    ///     Global setup of test values.
    /// </summary>
    [GlobalSetup]
    public new void Setup() => base.Setup();
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark(Baseline = true)]
    public byte[] SystemTextJson()
     {
         return SystemTextJsonService<SimpleModel>.SystemTextJsonSerializeBytes(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] Utf8Json()
    {
        return Utf8JsonService<SimpleModel>.Utf8JsonBytesSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] ZeroFormatter()
    {
        return ZeroFormatterService<SimpleModel>.ZeroFormatterSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="byte"/></returns>
    [Benchmark]
    public byte[] SpanJson()
    {
        return SpanJsonService<SimpleModel>.SpanJsonSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackClassic()
    {
        return MsgPackService<SimpleModel>.MsgPackClassicSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackLz4Block()
    {
        return MsgPackService<SimpleModel>.MsgPackLz4BlockSerializeBytes(SimpleModels);
    }
}