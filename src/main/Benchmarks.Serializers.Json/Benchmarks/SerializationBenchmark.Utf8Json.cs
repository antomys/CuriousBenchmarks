using BenchmarkDotNet.Attributes;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref=" Utf8Json.JsonSerializer"/>.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string Utf8JsonString()
    {
        return System.Text.Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize(_simpleModels));
    }
    
    /// <summary>
    ///     Serializes with Utf8Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] Utf8JsonByte()
    {
        return Utf8Json.JsonSerializer.Serialize(_simpleModels)!;
    }
}