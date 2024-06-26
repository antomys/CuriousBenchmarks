﻿using Jil;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarks.Serializers.OutputFormatters.Formatters.Jil;

public static class MvcOptionsExtension
{
    private readonly static Options JilOptions = new(dateFormat: DateTimeFormat.ISO8601, serializationNameFormat: SerializationNameFormat.CamelCase);
    
    public static IMvcBuilder AddJilFormatter(this IMvcBuilder mvcBuilder) 
    {
        // //  Workaround of Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.
        // mvcBuilder.Services.Configure<KestrelServerOptions>(options =>
        // {
        //     options.AllowSynchronousIO = true;
        // });

        Configure(mvcBuilder.Services);
        
        return mvcBuilder;
    }
    
    private static void Configure(IServiceCollection serviceCollection) => serviceCollection.Configure((Action<MvcOptions>) (options =>
    {
        options.OutputFormatters.Clear();
        options.InputFormatters.Clear();

        options.InputFormatters.Add(new JilInputFormatter(JilOptions));
        options.OutputFormatters.Add(new JilOutputFormatter(JilOptions));
    }));
}