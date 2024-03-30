using Microsoft.AspNetCore.Mvc;
using Utf8Json.AspNetCoreMvcFormatter;
using Utf8Json.Resolvers;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.Utf8Json;

public static class MvcOptionsExtension
{
    public static IMvcBuilder AddUtf8JsonFormatter(this IMvcBuilder mvcBuilder)
    {
        Configure(mvcBuilder.Services);
       
        return mvcBuilder;
    }
    
    private static void Configure(IServiceCollection serviceCollection) => serviceCollection.Configure((Action<MvcOptions>) (config =>
    {
        config.OutputFormatters.Clear();
        config.InputFormatters.Clear();
        config.OutputFormatters.Add(new JsonOutputFormatter(StandardResolver.CamelCase));
        config.InputFormatters.Add(new JsonInputFormatter());
    }));
}