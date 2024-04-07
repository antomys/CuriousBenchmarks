using System.Text;
using Jil;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.Jil;

public sealed class JilInputFormatter : InputFormatter
{
    private readonly Options _jilOptions;

    public JilInputFormatter(Options jilOptions)
    {
        _jilOptions = jilOptions;
        SupportedMediaTypes.Add("application/json");
        SupportedMediaTypes.Add("text/json");
        SupportedMediaTypes.Add("application/*+json");
    }
    
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        var result = await JSON.DeserializeDynamicAsync(request.BodyReader, Encoding.UTF8, _jilOptions);
        
        return await InputFormatterResult.SuccessAsync(result);
    }
}