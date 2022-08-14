using Microsoft.AspNetCore.Mvc;

namespace Json.Benchmarks.Server.Formatters.Protobuf;

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