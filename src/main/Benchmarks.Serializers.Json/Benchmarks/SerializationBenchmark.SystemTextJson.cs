using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [Benchmark(Baseline = true)]
    public string SystemTextJsonString()
    {
        return System.Text.Json.JsonSerializer.Serialize(_simpleModels, JsonServiceExtensions.Options);
    }
    
    /// <summary>
    ///     Serializes with System.Text.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark(Baseline = true)]
    public byte[] SystemTextJsonByte()
    {
        return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_simpleModels, JsonServiceExtensions.Options);
    }
}