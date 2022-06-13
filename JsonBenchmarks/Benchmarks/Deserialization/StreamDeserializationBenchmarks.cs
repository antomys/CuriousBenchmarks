using BenchmarkDotNet.Attributes;
using JsonBenchmarks.Models;

namespace JsonBenchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class StreamDeserializationBenchmarks : DeserializationBenchmarksBase
{
    private readonly Stream _testStream = new MemoryStream();

    private readonly Stream _testProtobufStream = new MemoryStream();
    
    private readonly Stream _testMsgPackStream = new MemoryStream();

    /// <summary>
    ///     Override of setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();

        System.Text.Json.JsonSerializer.Serialize(_testStream, TestModels, Options);
        MessagePack.MessagePackSerializer.Serialize(_testMsgPackStream, TestModels);
        ProtoBuf.Serializer.Serialize(_testProtobufStream, TestModels);
    }

    /// <summary>
    ///     Closing streams.
    /// </summary>
    [GlobalCleanup]
    public void Cleanup()
    {
        _testStream.Close();
        _testMsgPackStream.Close();
        _testProtobufStream.Close();
        
        _testStream.Dispose();
        _testMsgPackStream.Dispose();
        _testProtobufStream.Dispose();
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark(Baseline = true)]
    public ICollection<TestModel> SystemTextJson()
    {
        _testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_testStream, Options)!;
    }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public ICollection<TestModel> SystemTextJsonSourceGen()
    {
        _testStream.Position = 0;
        
        return System.Text.Json.JsonSerializer.Deserialize(_testStream, TestModelJsonContext.Default.ICollectionTestModel)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public ICollection<TestModel> Maverick()
    {
        _testStream.Position = 0;
        var buffer = new byte[_testStream.Length];
        _testStream.Read(buffer);
        
        return global::Maverick.Json.JsonConvert.Deserialize<ICollection<TestModel>>(buffer, MaverickSettings);
    }

    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public ICollection<TestModel> Utf8Json()
    {
        _testStream.Position = 0;
        
        return global::Utf8Json.JsonSerializer.Deserialize<ICollection<TestModel>>(_testStream)!;
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public ICollection<TestModel> SpanJson()
    {
        _testStream.Position = 0;
        var buffer = new byte[_testStream.Length];
        _testStream.Read(buffer);
        
        return global::SpanJson.JsonSerializer.Generic.Utf8.Deserialize<ICollection<TestModel>>(buffer)!;
    }

    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public ICollection<TestModel> Protobuf()
    {
        _testProtobufStream.Position = 0;
        
        return ProtoBuf.Serializer.Deserialize<ICollection<TestModel>>(_testProtobufStream);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public ICollection<TestModel> MsgPack()
    {
        _testMsgPackStream.Position = 0;
        
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<TestModel>>(_testMsgPackStream);
    }
}