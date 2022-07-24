using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Simple;

/// <summary>
///     Serialization from byte array.
/// </summary>
public class ByteSerializationSimpleBenchmarks : JsonSimpleBenchmark
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
         return SystemTextJsonService.SerializeBytes(SimpleModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] SystemTextJsonSourceGen()
    {
        if (SimpleModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.SimpleSerializeBytes(SimpleModels[0]);
        }
        
        return SystemTextJsonGeneratedService.SimpleSerializeBytesArray(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] Utf8Json()
    {
        return Utf8JsonService.SerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] ZeroFormatter()
    {
        return ZeroFormatterService.SerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="byte"/></returns>
    [Benchmark]
    public byte[] SpanJson()
    {
        return SpanJsonService.SerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackClassic()
    {
        return MsgPackService.ClassicSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackLz4Block()
    {
        return MsgPackService.Lz4BlockSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] JsonSrcGen()
    {
        if (CollectionSize is 1)
        {
            return JsonSrcGenService.SimpleSerializeBytes(SimpleSrcGenModels[0]);
        }
        
        return JsonSrcGenService.SimpleSerializeBytesArray(SimpleSrcGenModels);
    }
}