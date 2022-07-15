using BenchmarkDotNet.Attributes;

namespace Json.Benchmarks.Benchmarks.Deserialization;

/// <summary>
///     Deserialization from string benchmarks.
/// </summary>
public class StringNativeDeserializationBenchmarks : DeserializationBenchmarksBase
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
        
        _testString = System.Text.Json.JsonSerializer.Serialize(TestModels, Options);
        _testJilString = global::Jil.JSON.Serialize(TestModels);
    }
}