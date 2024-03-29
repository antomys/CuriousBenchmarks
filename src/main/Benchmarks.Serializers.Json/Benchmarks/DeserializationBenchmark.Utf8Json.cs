using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref=" Utf8Json.JsonSerializer"/>.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> Utf8JsonString()
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> Utf8JsonByte()
    {
        return Utf8Json.JsonSerializer.Deserialize<ICollection<SimpleModel>>(_testBytes);
    }
}