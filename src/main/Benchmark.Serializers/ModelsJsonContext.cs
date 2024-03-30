using System.Text.Json.Serialization;
using Benchmark.Serializers.Models;

namespace Benchmark.Serializers;

/// <inheritdoc cref="System.Text.Json.Serialization.JsonSerializerContext" />
[JsonSerializable(typeof(ICollection<ComplexModel>)), JsonSerializable(typeof(ICollection<SimpleModel>)), JsonSourceGenerationOptions(
     GenerationMode = JsonSourceGenerationMode.Default,
     PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public sealed partial class ModelsJsonContext : JsonSerializerContext;