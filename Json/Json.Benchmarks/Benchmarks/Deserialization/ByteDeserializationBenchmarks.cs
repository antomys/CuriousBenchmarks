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

        _testMsgPackClassicByteArray = MsgPackService.MsgPackClassicSerializeBytes(SimpleModels);
        _zeroFormatterByteArray = ZeroFormatterService.ZeroFormatterSerializeBytes(SimpleModels);
        _testMsgPackLz4ByteArray = MsgPackService.MsgPackLz4BlockSerializeBytes(SimpleModels);
        _testByteArray = SystemTextJsonService.SystemTextJsonSerializeBytes(SimpleModels);
        _protobufBytes = ProtobufService.ProtobufSerializeBytes(SimpleModels);
        _testJilByteArray = JilService.JilSerializeBytes(SimpleModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)]
    public ICollection<SimpleModel> SystemTextJson()
    {
        return SystemTextJsonService.SystemTextJsonDeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
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
        return MaverickJsonService.MaverickDeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService.Utf8JsonDeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService.SpanJsonDeserializeBytes<ICollection<SimpleModel>>(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Jil()
    {
        return JilService.JilDeserializeBytes<ICollection<SimpleModel>>(_testJilByteArray);
    }
    
    /// <summary>
    ///     Deserialize with ZeroFormatter.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> ZeroFormatter()
    {
        return ZeroFormatterService.ZeroFormatterDeserializeBytes<ICollection<SimpleModel>>(_zeroFormatterByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Protobuf()
    {
        return ProtobufService.ProtobufDeserializeBytes<ICollection<SimpleModel>>(_protobufBytes);
    }
    
    /// <summary>
    ///     Deserialize with MsgPack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackClassic()
    {
        return MsgPackService.MsgPackClassicDeserializeBytes<ICollection<SimpleModel>>(_testMsgPackClassicByteArray);
    }
    
    /// <summary>
    ///     Deserialize with MsgPack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> MsgPackLz4()
    {
        return MsgPackService.MsgPackLz4BlockDeserializeBytes<ICollection<SimpleModel>>(_testMsgPackLz4ByteArray);
    }
}