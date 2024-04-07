using System.Text.Json.Serialization;
using Benchmarks.Serializers.Models;

namespace Benchmarks.Serializers;

/// <inheritdoc cref="System.Text.Json.Serialization.JsonSerializerContext" />
[JsonSerializable(typeof(ICollection<ComplexModel>)), JsonSerializable(typeof(ICollection<SimpleModel>)), JsonSourceGenerationOptions(
     GenerationMode = JsonSourceGenerationMode.Default,
     PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public sealed partial class ModelsJsonContext : JsonSerializerContext;