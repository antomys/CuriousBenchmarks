using System.Text.Json.Serialization;

namespace QueryBenchmarks.JsonSourceGen;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(TestModel))]
internal partial class TestModelGenerationContext : JsonSerializerContext
{
    
}