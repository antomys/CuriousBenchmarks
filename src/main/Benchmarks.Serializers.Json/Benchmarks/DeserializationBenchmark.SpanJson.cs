using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="SpanJson.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> SpanJsonString()
    {
        return SpanJson.JsonSerializer.Generic.Utf16.Deserialize<ICollection<SimpleModel>>(_testString)!;
    }
    
    /// <summary>
    ///     Serializes with <see cref="SpanJson.JsonSerializer"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] SpanJsonByte()
    {
        return SpanJson.JsonSerializer.Generic.Utf8.Serialize(_testBytes)!;
    }
}