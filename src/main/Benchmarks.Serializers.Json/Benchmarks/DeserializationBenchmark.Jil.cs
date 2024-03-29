using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="Jil.JSON"/>.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> JilString()
    {
        return Jil.JSON.Deserialize<ICollection<SimpleModel>>(_testString, JsonServiceExtensions.JilOptions);
    }
    
    /// <summary>
    ///     Serializes with <see cref="Jil.JSON"/>.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> JilBytes()
    {
        return Jil.JSON.Deserialize<ICollection<SimpleModel>>(Encoding.UTF8.GetString(_testBytes), JsonServiceExtensions.JilOptions);
    }
}