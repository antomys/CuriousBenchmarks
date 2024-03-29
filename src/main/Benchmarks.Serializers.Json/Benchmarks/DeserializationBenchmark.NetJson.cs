using System.Text;
using BenchmarkDotNet.Attributes;
using Benchmarks.Serializers.Json.Extensions;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> NetJsonString()
    {
        return NetJSON.NetJSON.Deserialize<ICollection<SimpleModel>>(_testString, JsonServiceExtensions.NetJsonOptions);
    }
    
    /// <summary>
    ///     Serializes with <see cref="NetJSON.NetJSON"/> to string.
    /// </summary>
    /// <returns><see cref="string"/></returns>
    [Benchmark]
    public ICollection<SimpleModel> NetJsonByte()
    {
        return NetJSON.NetJSON.Deserialize<ICollection<SimpleModel>>(Encoding.UTF8.GetString(_testBytes), JsonServiceExtensions.NetJsonOptions);
    }
}