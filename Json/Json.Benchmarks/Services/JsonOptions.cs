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

    internal static readonly Newtonsoft.Json.JsonSerializerSettings NewtonsoftOptions = new()
    {
        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
    };

    internal static readonly MessagePack.MessagePackSerializerOptions MsgPackOptions 
        = MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);

    /// <summary>
    ///     Settings for Maverick Json.
    /// </summary>
    internal static readonly Maverick.Json.JsonSettings MaverickSettings = new()
    {
        NamingStrategy = Maverick.Json.JsonNamingStrategy.CamelCase,
        Format = Maverick.Json.JsonFormat.None
    };
}