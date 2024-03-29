using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="SpanJson.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string SpanJsonString()
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Serialize(_simpleModels)!;
    }
    
    /// <summary>
    ///     Serializes with <see cref="SpanJson.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] SpanJsonByte()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Serialize(_simpleModels)!;
    }
}