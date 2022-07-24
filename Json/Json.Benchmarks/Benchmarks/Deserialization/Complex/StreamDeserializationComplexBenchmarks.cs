using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization.Complex;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class StreamDeserializationComplexBenchmarks: JsonComplexBenchmark
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

        _testMsgPackClassicStream = new MemoryStream(MsgPackService.ClassicSerializeBytes(ComplexModels));
        _testZeroFormatterStream = new MemoryStream(ZeroFormatterService.SerializeBytes(ComplexModels));
        _testMsgPackLz4Stream = new MemoryStream(MsgPackService.Lz4BlockSerializeBytes(ComplexModels));
        _testStream = new MemoryStream(SystemTextJsonService.SerializeBytes(ComplexModels));
        _protobufStream = new MemoryStream(ProtobufService.SerializeBytes(ComplexModels));

        using var tempStream = ServiceStackService.SerializeStream(ComplexModels);
        _testServiceStackStream = new MemoryStream(tempStream.ToArray());
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)] 
    public ICollection<ComplexModel> SystemTextJson() 
    { 
        return SystemTextJsonService.DeserializeStream<ICollection<ComplexModel>>(_testStream); 
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.ComplexDeserializeStreamArray(_testStream);
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Maverick()
    {
        return MaverickJsonService.DeserializeStream<ICollection<ComplexModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Utf8Json()
    {
        return Utf8JsonService.DeserializeStream<ICollection<ComplexModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> SpanJson()
    {
        return SpanJsonService.DeserializeStream<ICollection<ComplexModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Protobuf()
    {
        return ProtobufService.DeserializeStream<ICollection<ComplexModel>>(_protobufStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackClassic.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> MsgPackClassic()
    {
        return MsgPackService.ClassicDeserializeStream<ICollection<ComplexModel>>(_testMsgPackClassicStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackLz4.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> MsgPackLz4()
    {
        return MsgPackService.Lz4BlockDeserializeStream<ICollection<ComplexModel>>(_testMsgPackLz4Stream);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> ServiceStack()
    {
        return ServiceStackService.DeserializeStream<ICollection<ComplexModel>>(_testServiceStackStream);
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