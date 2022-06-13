using BenchmarkDotNet.Attributes;
using JsonBenchmarks.Models;

namespace JsonBenchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from string as byte array benchmarks.
/// </summary>
public class StringByteDeserializationBenchmarks : DeserializationBenchmarksBase
{
    private byte[] _testByteArray = default!;

    private byte[] _testMsgPackByteArray = default!;
    
    private byte[] _zeroFormatterByteArray = default!;
    
    private byte[] _protobufBytes = default!;

    /// <summary>
    ///     Override of global setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();
        
        _testMsgPackByteArray = MessagePack.MessagePackSerializer.Serialize(TestModels);
        _testByteArray = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(TestModels, Options);
        _zeroFormatterByteArray = global::ZeroFormatter.ZeroFormatterSerializer.Serialize(TestModelVirtual.ToTestModelVirtual(TestModels));
        
        using var memoryStream = new MemoryStream();
        ProtoBuf.Serializer.Serialize(memoryStream, TestModels);
        _protobufBytes = memoryStream.ToArray();
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark(Baseline = true)]
    public ICollection<TestModel> SystemTextJson()
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_testByteArray, Options)!;
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModel> SystemTextJsonSourceGen()
    {
        return System.Text.Json.JsonSerializer.Deserialize(_testByteArray, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModel> Maverick()
    {
        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<TestModel>>(_testByteArray, MaverickSettings);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModel> Utf8Json()
    {
        return global::Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModel> SpanJson()
    {
        return global::SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ICollection<TestModel>>(_testByteArray)!;
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModelVirtual> ZeroFormatter()
    {
        return global::ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<TestModelVirtual>>(
            _zeroFormatterByteArray);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModel> Protobuf()
    {
        return ProtoBuf.Serializer.Deserialize<ICollection<TestModel>>(_protobufBytes.AsSpan());
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.StringBytes), Benchmark]
    public ICollection<TestModel> MsgPack()
    {
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<TestModel>>(_testMsgPackByteArray);
    }
}