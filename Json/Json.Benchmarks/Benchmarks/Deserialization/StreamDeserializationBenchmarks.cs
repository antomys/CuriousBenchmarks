namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from stream.
/// </summary>
public class StreamDeserializationBenchmarks: JsonBenchmark
{
    private readonly Stream _testStream = new MemoryStream();

    private readonly Stream _testProtobufStream = new MemoryStream();
    
    private readonly Stream _testMsgPackStream = new MemoryStream();

    // /// <summary>
    // ///     Override of setup.
    // /// </summary>
    // [BenchmarkDotNet.Attributes.GlobalSetup]
    // public new void Setup()
    // {
    //     base.Setup();
    //
    //     System.Text.Json.JsonSerializer.Serialize(_testStream, TestModels, Options);
    //     MessagePack.MessagePackSerializer.Serialize(_testMsgPackStream, TestModels);
    //     ProtoBuf.Serializer.Serialize(_testProtobufStream, TestModels);
    // }

    /// <summary>
    ///     Closing streams.
    /// </summary>
    [BenchmarkDotNet.Attributes.GlobalCleanup]
    public void Cleanup()
    {
        _testStream.Close();
        _testMsgPackStream.Close();
        _testProtobufStream.Close();
        
        _testStream.Dispose();
        _testMsgPackStream.Dispose();
        _testProtobufStream.Dispose();
    }
}