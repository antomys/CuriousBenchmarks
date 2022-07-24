using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Complex;

/// <summary>
///     Serialization from byte array.
/// </summary>
public class ByteSerializationComplexBenchmarks : JsonComplexBenchmark
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
         return SystemTextJsonService.SerializeBytes(ComplexModels);
     }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] SystemTextJsonSourceGen()
    {
        if (ComplexModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.ComplexSerializeBytes(ComplexModels[0]);
        }
        
        return SystemTextJsonGeneratedService.ComplexSerializeBytesArray(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] Utf8Json()
    {
        return Utf8JsonService.SerializeBytes(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] ZeroFormatter()
    {
        return ZeroFormatterService.SerializeBytes(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with SpanJson.
    /// </summary>
    /// <returns><see cref="byte"/></returns>
    [Benchmark]
    public byte[] SpanJson()
    {
        return SpanJsonService.SerializeBytes(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackClassic()
    {
        return MsgPackService.ClassicSerializeBytes(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] MsgPackLz4Block()
    {
        return MsgPackService.Lz4BlockSerializeBytes(ComplexModels);
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
            return JsonSrcGenService.ComplexSerializeBytes(ComplexSrcGenModels[0]);
        }
        
        return JsonSrcGenService.ComplexSerializeBytesArray(ComplexSrcGenModels);
    }
}