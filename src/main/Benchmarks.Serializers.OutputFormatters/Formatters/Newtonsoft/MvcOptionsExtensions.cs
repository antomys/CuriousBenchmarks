using Microsoft.AspNetCore.Mvc;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.Newtonsoft;

public static class MvcOptionsExtension
{
    public static IMvcBuilder AddNewtonsoftFormatter(this IMvcBuilder builder)
    {
        builder.Services.Configure((Action<MvcOptions>) (config => 
        {
            config.OutputFormatters.Clear();
            config.InputFormatters.Clear();
        }));
        
        return builder.AddNewtonsoftJson();
    }
}