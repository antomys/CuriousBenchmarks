using System.Text.Json.Serialization;

namespace QueryBenchmarks.JsonSourceGen;

[JsonSerializable(typeof(ICollection<TestModel>))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class TestModelJsonContext : JsonSerializerContext
{
    
}