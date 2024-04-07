using Microsoft.AspNetCore.Mvc;
using SpanJson;
using SpanJson.AspNetCore.Formatter;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.SpanJson;

public static class MvcOptionsExtension
{
    public static IMvcBuilder AddSpanJsonFormatter(this IMvcBuilder mvcBuilder)
    {
        return mvcBuilder.AddSpanJsonCustom<SpanJsonFormatter<byte>>();
    }
    
    public static IMvcBuilder AddSpanJsonFormatterV2(this IMvcBuilder mvcBuilder)
    {
        Configure<SpanJsonFormatter<byte>>(mvcBuilder.Services);
       
        return mvcBuilder;
    }
    
    private static void Configure<TResolver>(IServiceCollection serviceCollection) where TResolver : IJsonFormatterResolver<byte, TResolver>, new()
        => serviceCollection.Configure((Action<MvcOptions>) (config => 
        {
            config.OutputFormatters.Clear();
            config.InputFormatters.Clear();
            config.InputFormatters.Add(new SpanJsonInputFormatter<TResolver>());
            config.OutputFormatters.Add(new SpanJsonOutputFormatter<TResolver>());
        }));
}