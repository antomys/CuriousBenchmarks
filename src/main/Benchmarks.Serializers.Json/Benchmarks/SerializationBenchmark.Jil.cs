using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="Jil.JSON"/>.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string JilString()
    {
        return Jil.JSON.Serialize(_simpleModels, JsonServiceExtensions.JilOptions);
    }
    
    /// <summary>
    ///     Serializes with <see cref="Jil.JSON"/>.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] JilBytes()
    {
        using var writer = new StringWriter();

        Jil.JSON.Serialize(_simpleModels,  writer, JsonServiceExtensions.JilOptions);
        
        return Encoding.UTF8.GetBytes(writer.ToString());
    }
}