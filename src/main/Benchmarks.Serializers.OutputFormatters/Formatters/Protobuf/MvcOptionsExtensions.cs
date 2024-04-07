using Microsoft.AspNetCore.Mvc;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.Protobuf;

public static class MvcOptionsExtension
{
    public static IMvcBuilder AddProtobufFormatter(this IMvcBuilder builder)
    {
        builder.Services.Configure((Action<MvcOptions>) (config =>
        {
            config.OutputFormatters.Clear();
            config.InputFormatters.Clear();
        }));
        
        return builder.AddProtoBufNet();
    }
}