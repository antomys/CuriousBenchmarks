using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonString()
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<SimpleModel>>(_testString, JsonServiceExtensions.Options);
    }
    
    /// <summary>
    ///     Serializes with <see cref="System.Text.Json"/>.
    /// </summary>
    /// <returns><see cref="string"/>.</returns>
    [Benchmark]
    public ICollection<SimpleModel>? SystemTextJsonByte()
    {
        return System.Text.Json.JsonSerializer.Deserialize<ICollection<SimpleModel>>(_testBytes, JsonServiceExtensions.Options);
    }
}