using BenchmarkDotNet.Attributes;
using Json.Benchmarks.Models;
using Json.Benchmarks.Models.SrcGen;
using Json.Benchmarks.Services;

namespace Json.Benchmarks.Benchmarks.Deserialization.Simple;

/// <summary>
///     Deserialization from string benchmarks.
/// </summary>
public class StringDeserializationSimpleBenchmarks: JsonSimpleBenchmark
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
        
        _testString = SystemTextJsonService.Serialize(SimpleModels);
        _testJilString = JilService.Serialize(SimpleModels);
        _testServiceStackString = ServiceStackService.Serialize(SimpleModels);
    }
    
    /// <summary>
    ///     Deserialize with System.Text.Json.
    /// </summary>
    [Benchmark(Baseline = true)]
    public ICollection<SimpleModel> SystemTextJson()
     {
         return SystemTextJsonService.Deserialize<ICollection<SimpleModel>>(_testString);
     }

    /// <summary>
    ///     Deserialize with System.Text.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> SystemTextJsonSourceGen()
    {
        return SystemTextJsonGeneratedService.SimpleDeserializeArray(_testString)!;
    }
    
    /// <summary>
    ///     Deserialize with Maverick.Json source gen.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Maverick()
    {
        return MaverickJsonService.Deserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Newtonsoft.Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Newtonsoft()
    {
        return NewtonsoftService.Deserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with Jil.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Jil()
    {
        return JilService.Deserialize<ICollection<SimpleModel>>(_testJilString);
    }
    
    /// <summary>
    ///     Deserialize with Utf8Json.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> Utf8Json()
    {
        return Utf8JsonService.Deserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with SpanJson.
    /// </summary>

    [Benchmark]
    public ICollection<SimpleModel> SpanJson()
    {
        return SpanJsonService.Deserialize<ICollection<SimpleModel>>(_testString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> ServiceStack()
    {
        return ServiceStackService.Deserialize<ICollection<SimpleModel>>(_testServiceStackString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public ICollection<SimpleModel> NetJson()
    {
        return NetJsonService.Deserialize<ICollection<SimpleModel>>(_testServiceStackString);
    }
    
    /// <summary>
    ///     Deserialize with ServiceStack.
    /// </summary>
    [Benchmark]
    public SimpleSrcGenModel?[]? JsonSrcGen()
    {
        return JsonSrcGenService.SimpleDeserializeArray(_testString);
    }
}