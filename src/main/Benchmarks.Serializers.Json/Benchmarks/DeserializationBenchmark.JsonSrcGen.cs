using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Models.SrcGen;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    private readonly static JsonSrcGen.JsonConverter JsonConverter = new();

    /// <summary>
    ///     Serializes with <see cref="JsonSrcGenService"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public SimpleSrcGenModel?[]? JsonSrcGenString()
    {
        return JsonConverter.FromJson( new List<SimpleSrcGenModel>().ToArray(), _testString);
    }
    
    /// <summary>
    ///     Serializes with MessagePack.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public SimpleSrcGenModel?[]? JsonSrcGenByte()
    {
        return JsonConverter.FromJson( new List<SimpleSrcGenModel>().ToArray(), _testBytes);
    }
}