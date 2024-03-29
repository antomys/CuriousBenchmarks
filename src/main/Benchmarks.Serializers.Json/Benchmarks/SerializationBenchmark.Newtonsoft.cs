using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class SerializationBenchmark
{
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public string NewtonsoftString()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(_simpleModels, JsonServiceExtensions.NewtonsoftOptions);

    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public byte[] NewtonsoftBytes()
    {
        return Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(_simpleModels, JsonServiceExtensions.NewtonsoftOptions));
    }
}