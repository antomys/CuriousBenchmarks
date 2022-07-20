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
    private string _testServiceStackString = string.Empty;

    /// <summary>
    ///     Override of setup.
    /// </summary>
    [GlobalSetup]
    public new void Setup()
    {
        base.Setup();
        
        _testString = SystemTextJsonService.SystemTextJsonSerialize(SimpleModels);
        _testJilString = JilService.JilSerialize(SimpleModels);
        _testServiceStackString = ServiceStackService.ServiceStackSerialize(SimpleModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
     [Benchmark(Baseline = true)]
    public ICollection<SimpleModel> SystemTextJson()
     {
         return SystemTextJsonService.SystemTextJsonDeserialize<ICollection<SimpleModel>>(_testString);
     }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SystemTextJsonGeneratedDeserialize(_testString)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Maverick()
    {
        return MaverickJsonService.MaverickJsonDeserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Newtonsoft.Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Newtonsoft()
    {
        return NewtonsoftService.NewtonsoftDeserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Jil()
    {
        return JilService.JilDeserialize<ICollection<SimpleModel>>(_testJilString);
    }
    
    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService.Utf8JsonDeserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>

    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService.SpanJsonDeserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> ServiceStack()
    {
        return ServiceStackService.ServiceStackDeserialize<ICollection<SimpleModel>>(_testServiceStackString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> NetJson()
    {
        return NetJsonService.NetJsonDeserialize<ICollection<SimpleModel>>(_testServiceStackString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public SimpleSrcGenModel[] JsonSrcGen()
    {
        return JsonSrcGenService.JsonSrcGenDeserialize(_testString);
    }
}