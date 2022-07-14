using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class AsyncStreamDeserializationBenchmarks : DeserializationBenchmarksBase
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
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [BenchmarkCategory(BenchmarkGroups.Stream), Benchmark]
    public async Task<ICollection<TestModel>?> SystemTextJsonSourceGen()
    {
        _testStream.Position = 0;
        return await System.Text.Json.JsonSerializer.DeserializeAsync(_testStream, TestModelJsonContext.Default.ICollectionTestModel);
    }
}