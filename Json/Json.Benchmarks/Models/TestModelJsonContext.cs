using System.Text.Json.Serialization;

namespace Json.Benchmarks.Models;

/// <inheritdoc />
[JsonSerializable(typeof(ICollection<TestModel>))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public sealed partial class TestModelJsonContext : JsonSerializerContext
{
}