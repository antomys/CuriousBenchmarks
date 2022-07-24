using System.Text.Json.Serialization;

namespace Json.Benchmarks.Models.SrcGen;

/// <inheritdoc />
[JsonSerializable(typeof(ICollection<ComplexModel>))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public sealed partial class ComplexModelJsonContext : JsonSerializerContext
{
}