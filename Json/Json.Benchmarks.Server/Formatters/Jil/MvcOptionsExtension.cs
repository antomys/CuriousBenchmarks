using Jil;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace Json.Benchmarks.Server.Formatters.Jil;

public static class MvcOptionsExtension
{
    private static readonly Options JilOptions = 
        new(dateFormat: DateTimeFormat.ISO8601,
            serializationNameFormat: SerializationNameFormat.CamelCase);
    
    public static IMvcBuilder AddJilFormatter(this IMvcBuilder mvcBuilder) 
    {
        //  Workaround of Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.
        mvcBuilder.Services.Configure<KestrelServerOptions>(options =>
        {
            options.AllowSynchronousIO = true;
        });
        
        Configure(mvcBuilder.Services);
        
        return mvcBuilder;
    }
    
    private static void Configure(IServiceCollection serviceCollection) => serviceCollection.Configure((Action<MvcOptions>) (options =>
    {
        options.OutputFormatters.Clear();
        options.InputFormatters.Clear();

        const string contentType = "application/jil+json";
        const string format = "jil";

        var mediaTypeHeaderValue = MediaTypeHeaderValue.Parse((StringSegment) contentType).CopyAsReadOnly();
        options.InputFormatters.Add(new JilInputFormatter(JilOptions, mediaTypeHeaderValue));
        options.OutputFormatters.Add(new JilOutputFormatter(JilOptions, mediaTypeHeaderValue));
        options.FormatterMappings.SetMediaTypeMappingForFormat(format, mediaTypeHeaderValue);
    }));
}