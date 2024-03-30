using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using SpanJson;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.SpanJson;

public sealed class SpanJsonOutputFormatter<TResolver> : TextOutputFormatter where TResolver : IJsonFormatterResolver<byte, TResolver>, new()
{
    public SpanJsonOutputFormatter()
    {
        SupportedMediaTypes.Add("application/json");
        SupportedMediaTypes.Add("text/json");
        SupportedMediaTypes.Add("application/*+json");
        SupportedEncodings.Add(Encoding.UTF8);
    }

    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context,
        Encoding encoding)
    {
        if (context.Object is null)
        {
            return;
        }
        
        var valueTask = JsonSerializer.NonGeneric.Utf8.SerializeAsync<TResolver>(context.Object, context.HttpContext.Response.Body);

        if (valueTask.IsCompletedSuccessfully)
        {
            return;
        }

        await valueTask;
    }
}