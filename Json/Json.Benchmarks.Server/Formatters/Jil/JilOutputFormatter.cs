using System.Text;
using Jil;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Json.Benchmarks.Server.Formatters.Jil;

public sealed class JilOutputFormatter : TextOutputFormatter
{
    private readonly Options _jilOptions;

    public JilOutputFormatter(Options jilOptions, MediaTypeHeaderValue mediaTypeHeaderValue)
    {
        _jilOptions = jilOptions;
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
        SupportedMediaTypes.Add(mediaTypeHeaderValue);
    }

    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        
        return response.WriteAsync(JSON.Serialize(context.Object, _jilOptions));
    }
    
    public Task WriteResponseBodyV2Async(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        
        return response.WriteAsync(JSON.Serialize(context.Object, _jilOptions));
    }
}