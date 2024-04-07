using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using SpanJson;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.SpanJson;

public sealed class SpanJsonInputFormatter<TResolver> : TextInputFormatter where TResolver : IJsonFormatterResolver<byte, TResolver>, new()
{
    public SpanJsonInputFormatter()
    {
        SupportedMediaTypes.Add("application/json");
        SupportedMediaTypes.Add("text/json");
        SupportedMediaTypes.Add("application/*+json");
        SupportedEncodings.Add(UTF8EncodingWithoutBOM);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context,
        Encoding encoding)
    {
        try
        {
            var model = await JsonSerializer.NonGeneric.Utf8.DeserializeAsync<TResolver>(context.HttpContext.Request.Body, context.ModelType);
            
            return model is not null || context.TreatEmptyInputAsDefaultValue 
                ? await InputFormatterResult.SuccessAsync(model)
                : await InputFormatterResult.NoValueAsync();
        }
        catch (Exception ex)
        {
            context.ModelState.AddModelError("JSON", ex.Message);
            
            return await InputFormatterResult.FailureAsync();
        }
    }
}