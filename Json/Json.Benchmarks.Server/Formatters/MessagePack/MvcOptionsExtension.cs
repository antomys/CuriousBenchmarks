using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using Microsoft.AspNetCore.Mvc;

namespace Json.Benchmarks.Server.Formatters.MessagePack;

public static class MvcOptionsExtension
{
    private static readonly MessagePackSerializerOptions MsgPackOptions 
        = MessagePackSerializerOptions.Standard;
    
    public static IMvcBuilder AddMsgPackFormatter(this IMvcBuilder mvcBuilder)
    {
        Configure(mvcBuilder.Services);
       
        return mvcBuilder;
    }
    
    private static void Configure(IServiceCollection serviceCollection) => serviceCollection.Configure((Action<MvcOptions>) (config =>
    {
        config.OutputFormatters.Clear();
        config.InputFormatters.Clear();
        config.OutputFormatters.Add(new MessagePackOutputFormatter(MsgPackOptions));
        config.InputFormatters.Add(new MessagePackInputFormatter(MsgPackOptions));
    }));
}