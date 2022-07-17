using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class AsyncStreamDeserializationBenchmarks: JsonBenchmark
{
    private Stream _testMsgPackClassicStream = null!;
    private Stream _testZeroFormatterStream = null!;
    private Stream _testMsgPackLz4Stream = null!;
    private Stream _protobufStream = null!;
    private Stream _testStream = null!;

    /// <summary>
    ///     Override of setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();

        _testMsgPackClassicStream = new MemoryStream(MsgPackService<SimpleModel>.MsgPackClassicSerializeBytes(SimpleModels));
        _testZeroFormatterStream = new MemoryStream(ZeroFormatterService<SimpleModel>.ZeroFormatterSerializeBytes(SimpleModels));
        _testMsgPackLz4Stream = new MemoryStream(MsgPackService<SimpleModel>.MsgPackLz4BlockSerializeBytes(SimpleModels));
        _testStream = new MemoryStream(SystemTextJsonService<SimpleModel>.SystemTextJsonSerializeBytes(SimpleModels));
        _protobufStream = new MemoryStream(ProtobufService<SimpleModel>.ProtobufSerializeBytes(SimpleModels));
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)]
    public ValueTask<ICollection<SimpleModel>?> SystemTextJson()
    {
        return SystemTextJsonService<SimpleModel>.SystemTextJsonDeserializeAsync(_testStream);
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<SimpleModel>?> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedDeserializeAsync(_testStream);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public Task<ICollection<SimpleModel>> Utf8Json()
    {
        return Utf8JsonService<SimpleModel>.Utf8JsonDeserializeAsync(_testStream);
    }

    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<SimpleModel>> SpanJson()
    {
        return SpanJsonService<SimpleModel>.SpanJsonDeserializeAsync(_testStream);
    }

    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<SimpleModel>> Protobuf()
    {
        return ProtobufService<SimpleModel>.ProtobufDeserializeAsync(_protobufStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackClassic.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<SimpleModel>> MsgPackClassic()
    {
        return MsgPackService<SimpleModel>.MsgPackClassicDeserializeAsync(_testMsgPackClassicStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackLz4.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<SimpleModel>> MsgPackLz4()
    {
        return MsgPackService<SimpleModel>.MsgPackLz4BlockDeserializeAsync(_testMsgPackLz4Stream);
    }
    
    /// <summary>
    ///     Closing streams.
    /// </summary>
    [GlobalCleanup]
    public void Cleanup()
    {
        _testStream.Close();
        _testStream.Dispose();
        
        _testMsgPackClassicStream.Close();
        _testMsgPackClassicStream.Dispose();
       
        _testZeroFormatterStream.Close();
        _testZeroFormatterStream.Dispose();
        
        _testMsgPackLz4Stream.Close();
        _testMsgPackLz4Stream.Dispose();
        
        _protobufStream.Close();
        _protobufStream.Dispose();
    }
}