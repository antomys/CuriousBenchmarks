using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Complex;

/// <summary>
///     Serialization tests using <see cref="Stream"/>.
/// </summary>
public class StreamSerializationComplexBenchmarks : JsonComplexBenchmark
{
    /// <summary>
    ///     Global setup of test values.
    /// </summary>
    [GlobalSetup]
    public new void Setup() => base.Setup();
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark(Baseline = true)]
    public MemoryStream SystemTextJson()
    {
        return SystemTextJsonService.SerializeStream(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public MemoryStream SystemTextJsonSourceGen()
    {
        if (ComplexModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.ComplexSerializeStream(ComplexModels[0]);
        }
        
        return SystemTextJsonGeneratedService.ComplexSerializeStreamArray(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public MemoryStream Maverick()
    {
        return MaverickJsonService.SerializeStream(ComplexModels);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream ZeroFormatter()
    {
        return ZeroFormatterService.SerializeStream(ComplexModels);
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream MsgPackNoCompress()
    {
        return MsgPackService.ClassicSerializeStream(ComplexModels);
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream MsgPackLz4Block()
    {
        return MsgPackService.Lz4BlockSerializeStream(ComplexModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream ServiceStack()
    {
        return ServiceStackService.SerializeStream(ComplexModels);
    }
}