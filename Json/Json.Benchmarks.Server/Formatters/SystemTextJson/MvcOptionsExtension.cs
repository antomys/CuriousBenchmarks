using System.Text.Json;
using Json.Benchmarks.Models.SrcGen;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging.Abstractions;

namespace Json.Benchmarks.Server.Formatters.SystemTextJson;

public static class MvcOptionsExtension
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static IMvcBuilder AddSystemTextJsonFormatter(this IMvcBuilder builder)
    {
        builder.AddMvcOptions(options =>
        {
            options.OutputFormatters.Clear();
            options.InputFormatters.Clear();
            options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(Options));
            options.InputFormatters.Add(new SystemTextJsonInputFormatter(new JsonOptions(), NullLoggerFactory.Instance.CreateLogger<SystemTextJsonInputFormatter>()));
        });

        return builder;
    }
    
    public static IMvcBuilder AddSystemTextJsonSrcGenFormatter(this IMvcBuilder builder)
    {
        builder.AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.AddContext<ModelsJsonContext>();
        });

        return builder;
    }
}