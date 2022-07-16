using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from string as byte array benchmarks.
/// </summary>
public class StringByteDeserializationBenchmarks: JsonBenchmark
{
    private byte[] _testByteArray = default!;

    private byte[] _testMsgPackByteArray = default!;
    
    private byte[] _zeroFormatterByteArray = default!;
    
    private byte[] _protobufBytes = default!;

    // /// <summary>
    // ///     Override of global setup.
    // /// </summary>
    // [GlobalSetup]
    // public new void Setup()
    // {
    //     base.Setup();
    //     
    //     _testMsgPackByteArray = MessagePack.MessagePackSerializer.Serialize(TestModels);
    //     _testByteArray = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(TestModels, Options);
    //     _zeroFormatterByteArray = global::ZeroFormatter.ZeroFormatterSerializer.Serialize(TestModelVirtual.ToTestModelVirtual(TestModels));
    //     
    //     using var memoryStream = new MemoryStream();
    //     ProtoBuf.Serializer.Serialize(memoryStream, TestModels);
    //     _protobufBytes = memoryStream.ToArray();
    // }
}