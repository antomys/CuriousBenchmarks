namespace Json.Benchmarks.Services;

public static class JsonOptions
{
    /// <summary>
    ///     Default Options for System.Text.Json.
    /// </summary>
    internal static readonly System.Text.Json.JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
    };
    
    /// <summary>
    ///     Settings for Maverick Json.
    /// </summary>
    internal static readonly Maverick.Json.JsonSettings MaverickSettings = new()
    {
        NamingStrategy = Maverick.Json.JsonNamingStrategy.CamelCase,
        Format = Maverick.Json.JsonFormat.None
    };
}