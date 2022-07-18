using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class StreamDeserializationBenchmarks: JsonBenchmark
{
    private Stream _testMsgPackClassicStream = null!;
    private Stream _testZeroFormatterStream = null!;
    private Stream _testServiceStackStream = null!;
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

        using var tempStream = ServiceStackService<SimpleModel>.ServiceStackSerializeStream(SimpleModels);
        _testServiceStackStream = new MemoryStream(tempStream.ToArray());
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)] 
    public ICollection<SimpleModel> SystemTextJson() 
    { 
        return SystemTextJsonService<SimpleModel>.SystemTextJsonDeserializeStream(_testStream); 
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedDeserializeStream(_testStream);
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Maverick()
    {
        return MaverickJsonService<SimpleModel>.MaverickDeserializeStream(_testStream);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService<SimpleModel>.Utf8JsonDeserializeStream(_testStream);
    }

    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService<SimpleModel>.SpanJsonDeserializeStream(_testStream);
    }

    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Protobuf()
    {
        return ProtobufService<SimpleModel>.ProtobufDeserializeStream(_protobufStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackClassic.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackClassic()
    {
        return MsgPackService<SimpleModel>.MsgPackClassicDeserializeStream(_testMsgPackClassicStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackLz4.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackLz4()
    {
        return MsgPackService<SimpleModel>.MsgPackLz4BlockDeserializeStream(_testMsgPackLz4Stream);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> ServiceStack()
    {
        return ServiceStackService<SimpleModel>.ServiceStackDeserializeStream(_testServiceStackStream);
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
        
        _testServiceStackStream.Close();
        _testServiceStackStream.Dispose();
        
        _testMsgPackLz4Stream.Close();
        _testMsgPackLz4Stream.Dispose();
        
        _protobufStream.Close();
        _protobufStream.Dispose();
    }
}