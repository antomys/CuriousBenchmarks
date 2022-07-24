using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization.Complex;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class AsyncStreamDeserializationComplexBenchmarks: JsonComplexBenchmark
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
    public ValueTask<ICollection<ComplexModel>?> SystemTextJson()
    {
        return SystemTextJsonService.DeserializeAsync<ICollection<ComplexModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<ComplexModel>?> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.ComplexDeserializeArrayAsync(_testStream);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public Task<ICollection<ComplexModel>> Utf8Json()
    {
        return Utf8JsonService.DeserializeStreamAsync<ICollection<ComplexModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<ComplexModel>> SpanJson()
    {
        return SpanJsonService.DeserializeStreamAsync<ICollection<ComplexModel>>(_testStream);
    }

    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<ComplexModel>> Protobuf()
    {
        return ProtobufService.DeserializeStreamAsync<ICollection<ComplexModel>>(_protobufStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackClassic.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<ComplexModel>> MsgPackClassic()
    {
        return MsgPackService.ClassicDeserializeAsync<ICollection<ComplexModel>>(_testMsgPackClassicStream);
    }
    
    /// <summary>
    ///     Deserialize with MsgPackLz4.
    /// </summary>
    [Benchmark]
    public ValueTask<ICollection<ComplexModel>> MsgPackLz4()
    {
        return MsgPackService.Lz4BlockDeserializeAsync<ICollection<ComplexModel>>(_testMsgPackLz4Stream);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public Task<ICollection<ComplexModel>> ServiceStack()
    {
        return ServiceStackService.DeserializeStreamAsync<ICollection<ComplexModel>>(_testServiceStackStream);
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