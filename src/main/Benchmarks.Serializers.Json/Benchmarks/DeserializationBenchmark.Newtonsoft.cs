using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel>? NewtonsoftString()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<SimpleModel>>(_testString, JsonServiceExtensions.NewtonsoftOptions);

    }
    
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel>? NewtonsoftBytes()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<SimpleModel>>(Encoding.UTF8.GetString(_testBytes), JsonServiceExtensions.NewtonsoftOptions);
    }
}