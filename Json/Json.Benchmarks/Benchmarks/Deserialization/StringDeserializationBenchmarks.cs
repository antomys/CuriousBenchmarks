using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from string benchmarks.
/// </summary>
public class StringDeserializationBenchmarks: JsonBenchmark
{
    private string _testString = string.Empty;
    private string _testJilString = string.Empty;

    /// <summary>
    ///     Override of setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();
        
        _testString = SystemTextJsonService<SimpleModel>.SystemTextJsonSerialize(SimpleModels);
        _testJilString = JilService<SimpleModel>.JilSerialize(SimpleModels);
    }
    
     /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark(Baseline = true)]
    public ICollection<SimpleModel> SystemTextJson()
     {
         return SystemTextJsonService<SimpleModel>.SystemTextJsonDeserialize(_testString);
     }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public ICollection<SimpleModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedDeserialize(_testString)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public ICollection<SimpleModel> Maverick()
    {
        return MaverickJsonService<SimpleModel>.MaverickJsonDeserialize(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Newtonsoft.Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public ICollection<SimpleModel> Newtonsoft()
    {
        return NewtonsoftService<SimpleModel>.NewtonsoftDeserialize(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public ICollection<SimpleModel> Jil()
    {
        return JilService<SimpleModel>.JilDeserialize(_testJilString);
    }
    
    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService<SimpleModel>.Utf8JsonDeserialize(_testString);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService<SimpleModel>.SpanJsonDeserialize(_testString);
    }
}