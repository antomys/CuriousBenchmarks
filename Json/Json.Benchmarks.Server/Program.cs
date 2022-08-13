using Json.Benchmarks.Server.Formatters.Protobuf;
using Json.Benchmarks.Server.Formatters.SpanJson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsProduction())
{
    builder.Logging.ClearProviders();
}

builder.Services
    .AddControllers()
    .AddSpanJsonFormatter();

builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();  
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();