using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization.Simple;

/// <summary>
///     Serialization tests using <see cref="Stream"/>.
/// </summary>
public class StreamSerializationSimpleBenchmarks : JsonSimpleBenchmark
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
        return SystemTextJsonService.SerializeStream(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public MemoryStream SystemTextJsonSourceGen()
    {
        if (SimpleModels.Count is 1)
        {
            return SystemTextJsonGeneratedService.SimpleSerializeStream(SimpleModels[0]);
        }
        
        return SystemTextJsonGeneratedService.SimpleSerializeStreamArray(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public MemoryStream Maverick()
    {
        return MaverickJsonService.SerializeStream(SimpleModels);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream ZeroFormatter()
    {
        return ZeroFormatterService.SerializeStream(SimpleModels);
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream MsgPackNoCompress()
    {
        return MsgPackService.ClassicSerializeStream(SimpleModels);
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream MsgPackLz4Block()
    {
        return MsgPackService.Lz4BlockSerializeStream(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream ServiceStack()
    {
        return ServiceStackService.SerializeStream(SimpleModels);
    }
}