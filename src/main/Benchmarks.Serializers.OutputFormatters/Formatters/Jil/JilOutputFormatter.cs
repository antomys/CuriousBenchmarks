using System.Text;
using Jil;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.Jil;

public sealed class JilOutputFormatter : OutputFormatter
{
    private readonly Options _jilOptions;

    public JilOutputFormatter(Options jilOptions)
    {
        _jilOptions = jilOptions;
        SupportedMediaTypes.Add("application/json");
        SupportedMediaTypes.Add("text/json");
        SupportedMediaTypes.Add("application/*+json");
    }
    
    public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
    {
        if (context.Object is null)
        {
            var writer = context.HttpContext.Response.BodyWriter;
            if (writer is null)
            {
                context.HttpContext.Response.Body.WriteByte((byte)'{');
                context.HttpContext.Response.Body.WriteByte((byte)'}');
               
                return Task.CompletedTask;
            }

            var span = writer.GetSpan(2);
            span[0] = (byte)'{';
            span[1] = (byte)'}';
            
            writer.Advance(2);
            
            return writer.FlushAsync().AsTask();
        }
        else
        {
            var writer = context.HttpContext.Response.BodyWriter;

            return JSON.SerializeAsync(context.Object, writer: writer, Encoding.UTF8, _jilOptions).AsTask();
        }
    }
}