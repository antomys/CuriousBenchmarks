using System.Text;
using Jil;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Json.Benchmarks.Server.Formatters.Jil;

public sealed class JilInputFormatter : TextInputFormatter
{
    private readonly Options _jilOptions;

    public JilInputFormatter(Options jilOptions, MediaTypeHeaderValue mediaTypeHeaderValue)
    {
        _jilOptions = jilOptions;
        SupportedEncodings.Add(UTF8EncodingWithoutBOM);
        SupportedEncodings.Add(UTF16EncodingLittleEndian);
        SupportedMediaTypes.Add(mediaTypeHeaderValue);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context,
        Encoding encoding)
    {
        using var reader = context.ReaderFactory(context.HttpContext.Request.Body, encoding);
        
        return await InputFormatterResult.SuccessAsync(JSON.Deserialize(reader, context.ModelType, _jilOptions));
    }
}