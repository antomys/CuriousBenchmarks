using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from string as byte array benchmarks.
/// </summary>
public class ByteDeserializationBenchmarks: JsonBenchmark
{
    private byte[] _testByteArray = default!;
    private byte[] _testMsgPackClassicByteArray = default!;
    private byte[] _testMsgPackLz4ByteArray = default!;
    private byte[] _testJilByteArray = default!;
    private byte[] _zeroFormatterByteArray = default!;
    private byte[] _protobufBytes = default!;

    /// <summary>
    ///     Override of global setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();

        _testMsgPackClassicByteArray = MsgPackService<SimpleModel>.MsgPackClassicSerializeBytes(SimpleModels);
        _zeroFormatterByteArray = ZeroFormatterService<SimpleModel>.ZeroFormatterSerializeBytes(SimpleModels);
        _testMsgPackLz4ByteArray = MsgPackService<SimpleModel>.MsgPackLz4BlockSerializeBytes(SimpleModels);
        _testByteArray = SystemTextJsonService<SimpleModel>.SystemTextJsonSerializeBytes(SimpleModels);
        _protobufBytes = ProtobufService<SimpleModel>.ProtobufSerializeBytes(SimpleModels);
        _testJilByteArray = JilService<SimpleModel>.JilSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)]
    public ICollection<SimpleModel> SystemTextJson()
    {
        return SystemTextJsonService<SimpleModel>.SystemTextJsonDeserializeBytes(_testByteArray);
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedDeserializeBytes(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Maverick()
    {
        return MaverickJsonService<SimpleModel>.MaverickDeserializeBytes(_testByteArray);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService<SimpleModel>.Utf8JsonDeserializeBytes(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService<SimpleModel>.SpanJsonDeserializeBytes(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Jil()
    {
        return JilService<SimpleModel>.JilDeserializeBytes(_testJilByteArray);
    }
    
    /// <summary>
    ///     Deserialize with ZeroFormatter.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> ZeroFormatter()
    {
        return ZeroFormatterService<SimpleModel>.ZeroFormatterDeserializeBytes(_zeroFormatterByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Protobuf()
    {
        return ProtobufService<SimpleModel>.ProtobufDeserializeBytes(_protobufBytes);
    }
    
    /// <summary>
    ///     Deserialize with MsgPack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackClassic()
    {
        return MsgPackService<SimpleModel>.MsgPackClassicDeserializeByte(_testMsgPackClassicByteArray);
    }
    
    /// <summary>
    ///     Deserialize with MsgPack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackLz4()
    {
        return MsgPackService<SimpleModel>.MsgPackLz4BlockDeserializeByte(_testMsgPackLz4ByteArray);
    }
}