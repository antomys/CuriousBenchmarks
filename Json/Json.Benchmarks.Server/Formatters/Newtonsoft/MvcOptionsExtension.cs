namespace Json.Benchmarks.Server.Formatters.Newtonsoft;

public static class MvcOptionsExtension
{
    public static IMvcBuilder AddNewtonsoftFormatter(this IMvcBuilder builder)
    {
        return builder.AddNewtonsoftJson();
    }
}