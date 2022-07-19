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

        _testMsgPackClassicStream = new MemoryStream(MsgPackService.MsgPackClassicSerializeBytes(SimpleModels));
        _testZeroFormatterStream = new MemoryStream(ZeroFormatterService.ZeroFormatterSerializeBytes(SimpleModels));
        _testMsgPackLz4Stream = new MemoryStream(MsgPackService.MsgPackLz4BlockSerializeBytes(SimpleModels));
        _testStream = new MemoryStream(SystemTextJsonService.SystemTextJsonSerializeBytes(SimpleModels));
        _protobufStream = new MemoryStream(ProtobufService.ProtobufSerializeBytes(SimpleModels));

        using var tempStream = ServiceStackService.ServiceStackSerializeStream(SimpleModels);
        _testServiceStackStream = new MemoryStream(tempStream.ToArray());
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)] 
    public ICollection<SimpleModel> SystemTextJson() 
    { 
        return SystemTextJsonService.SystemTextJsonDeserializeStream<ICollection<SimpleModel>>(_testStream); 
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
        return MaverickJsonService.MaverickDeserializeStream<ICollection<SimpleModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService.Utf8JsonDeserializeStream<ICollection<SimpleModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService.SpanJsonDeserializeStream<ICollection<SimpleModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Protobuf()
    {
        return ProtobufService.ProtobufDeserializeStream<ICollection<SimpleModel>>(_protobufStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackClassic.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackClassic()
    {
        return MsgPackService.MsgPackClassicDeserializeStream<ICollection<SimpleModel>>(_testMsgPackClassicStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackLz4.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackLz4()
    {
        return MsgPackService.MsgPackLz4BlockDeserializeStream<ICollection<SimpleModel>>(_testMsgPackLz4Stream);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> ServiceStack()
    {
        return ServiceStackService.ServiceStackDeserializeStream<ICollection<SimpleModel>>(_testServiceStackStream);
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