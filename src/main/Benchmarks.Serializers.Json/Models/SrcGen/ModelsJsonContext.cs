using System.Text.Json.Serialization;

namespace Benchmarks.Serializers.Json.Models.SrcGen;

/// <inheritdoc />
[JsonSerializable(typeof(ICollection<ComplexModel>))]
[JsonSerializable(typeof(ICollection<SimpleModel>))]
[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public sealed partial class ModelsJsonContext : JsonSerializerContext
{
}