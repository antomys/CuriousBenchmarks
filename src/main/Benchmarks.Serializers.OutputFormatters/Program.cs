using Benchmark.Serializers.Models;
using Benchmarks.Serializers.OutputFormatters.Extensions;
using Benchmarks.Serializers.OutputFormatters.Formatters.Jil;
using Benchmarks.Serializers.OutputFormatters.Formatters.MemoryPack;
using Benchmarks.Serializers.OutputFormatters.Formatters.MessagePack;
using Benchmarks.Serializers.OutputFormatters.Formatters.Protobuf;
using Benchmarks.Serializers.OutputFormatters.Formatters.SpanJson;
using Benchmarks.Serializers.OutputFormatters.Formatters.SystemTextJson;
using Benchmarks.Serializers.OutputFormatters.Formatters.Utf8Json;
using Microsoft.AspNetCore.Mvc;

namespace Benchmarks.Serializers.OutputFormatters;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        if (builder.Environment.IsProduction())
        {
            builder.Logging.ClearProviders();
        }

        builder.Services
            .AddControllers()
            // .AddJilFormatter();
            // .AddSystemTextJsonSrcGenFormatter();
            // .AddUtf8JsonFormatter();
            // .AddSpanJsonFormatter();
            // .AddSpanJsonFormatterV2();
            // .AddNewtonsoftJson();
            // .AddJilFormatter();
            .AddProtobufFormatter();
            // .AddMemoryPackFormatter();
            // .AddMsgPackFormatter();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}