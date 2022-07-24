using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Models.SrcGen;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization.Complex;

/// <summary>
///     Deserialization from string as byte array benchmarks.
/// </summary>
public class ByteDeserializationComplexBenchmarks: JsonComplexBenchmark
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

        _testMsgPackClassicByteArray = MsgPackService.ClassicSerializeBytes(ComplexModels);
        _zeroFormatterByteArray = ZeroFormatterService.SerializeBytes(ComplexModels);
        _testMsgPackLz4ByteArray = MsgPackService.Lz4BlockSerializeBytes(ComplexModels);
        _testByteArray = SystemTextJsonService.SerializeBytes(ComplexModels);
        _protobufBytes = ProtobufService.SerializeBytes(ComplexModels);
        _testJilByteArray = JilService.SerializeBytes(ComplexModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)]
    public ICollection<ComplexModel> SystemTextJson()
    {
        return SystemTextJsonService.DeserializeBytes<ICollection<ComplexModel>>(_testByteArray);
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.ComplexDeserializeBytesArray(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Maverick()
    {
        return MaverickJsonService.DeserializeBytes<ICollection<ComplexModel>>(_testByteArray);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Utf8Json()
    {
        return Utf8JsonService.DeserializeBytes<ICollection<ComplexModel>>(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> SpanJson()
    {
        return SpanJsonService.DeserializeBytes<ICollection<ComplexModel>>(_testByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Jil()
    {
        return JilService.DeserializeBytes<ICollection<ComplexModel>>(_testJilByteArray);
    }
    
    /// <summary>
    ///     Deserialize with ZeroFormatter.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> ZeroFormatter()
    {
        return ZeroFormatterService.DeserializeBytes<ICollection<ComplexModel>>(_zeroFormatterByteArray);
    }
    
    /// <summary>
    ///     Deserialize with Protobuf.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> Protobuf()
    {
        return ProtobufService.DeserializeBytes<ICollection<ComplexModel>>(_protobufBytes);
    }
    
    /// <summary>
    ///     Deserialize with MsgPack.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> MsgPackClassic()
    {
        return MsgPackService.ClassicDeserializeBytes<ICollection<ComplexModel>>(_testMsgPackClassicByteArray);
    }
    
    /// <summary>
    ///     Deserialize with MsgPack.
    /// </summary>
    [Benchmark]
    public ICollection<ComplexModel> MsgPackLz4()
    {
        return MsgPackService.Lz4BlockDeserializeBytes<ICollection<ComplexModel>>(_testMsgPackLz4ByteArray);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ComplexSrcGenModel[] JsonSrcGen()
    {
        return JsonSrcGenService.ComplexDeserializeBytesArray(_testByteArray);
    }
}