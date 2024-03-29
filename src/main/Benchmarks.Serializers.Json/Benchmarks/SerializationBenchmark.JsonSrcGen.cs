using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    private readonly static JsonSrcGen.JsonConverter JsonConverter = new();

    /// <summary>
    ///     Serializes with <see cref="JsonSrcGenService"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string JsonSrcGenString()
    {
        return CollectionSize is 1 
            ? JsonConverter.ToJson(_simpleSrcGenModels[0]).ToString() 
            : JsonConverter.ToJson(_simpleSrcGenModels).ToString();
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] JsonSrcGenByte()
    {
        return CollectionSize is 1
            ? JsonConverter.ToJsonUtf8(_simpleSrcGenModels[0]).ToArray()
            : JsonConverter.ToJsonUtf8(_simpleSrcGenModels).ToArray();
    }
}