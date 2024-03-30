using System.Text.Json;
using Benchmark.Serializers;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.SystemTextJson;

public static class MvcOptionsExtension
{
    private readonly static JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static IMvcBuilder AddSystemTextJsonSrcGenFormatter(this IMvcBuilder builder)
    {
        builder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.AddContext<ModelsJsonContext>();
        });

        return builder;
    }
}