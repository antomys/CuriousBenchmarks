using MemoryPack.AspNetCoreMvcFormatter;
using MessagePack;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.MemoryPack;

public static class MvcOptionsExtension
{
    private readonly static MessagePackSerializerOptions MsgPackOptions 
        = MessagePackSerializerOptions.Standard;
    
    public static IMvcBuilder AddMemoryPackFormatter(this IMvcBuilder mvcBuilder)
    {
        Configure(mvcBuilder.Services);
       
        return mvcBuilder;
    }
    
    private static void Configure(IServiceCollection serviceCollection) => serviceCollection.Configure((Action<MvcOptions>) (config =>
    {
        config.OutputFormatters.Clear();
        config.InputFormatters.Clear();
        config.OutputFormatters.Add(new MemoryPackOutputFormatter());
        config.InputFormatters.Add(new MemoryPackInputFormatter());
    }));
}