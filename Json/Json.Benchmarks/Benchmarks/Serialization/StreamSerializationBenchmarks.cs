using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Serialization;

/// <summary>
///     Serialization tests using <see cref="Stream"/>.
/// </summary>
public class StreamSerializationBenchmarks : JsonBenchmark
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
        return SystemTextJsonService.SystemTextJsonSerializeStream(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public MemoryStream SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonSourceGenSerializeStream(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with Maverick.Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public MemoryStream Maverick()
    {
        return MaverickJsonService.MaverickSerializeStream(SimpleModels);
    }

    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream ZeroFormatter()
    {
        return ZeroFormatterService.ZeroFormatterSerializeStream(SimpleModels);
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream MsgPackNoCompress()
    {
        return MsgPackService.MsgPackClassicSerializeStream(SimpleModels);
    }

    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream MsgPackLz4Block()
    {
        return MsgPackService.MsgPackLz4BlockSerializeStream(SimpleModels);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="MemoryStream"/></returns>
    [Benchmark]
    public MemoryStream ServiceStack()
    {
        return ServiceStackService.ServiceStackSerializeStream(SimpleModels);
    }
}