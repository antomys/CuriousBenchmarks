using System.Text.Json.Serialization;

namespace JsonBenchmarks.TestModel;

[JsonSerializable(typeof(ICollection<TestModel>))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class TestModelJsonContext : JsonSerializerContext
{
}