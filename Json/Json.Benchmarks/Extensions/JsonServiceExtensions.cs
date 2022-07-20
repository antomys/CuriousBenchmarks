namespace Json.Benchmarks.Extensions;

/// <summary>
///     Extensions for Json services.
/// </summary>
public static class JsonServiceExtensions
{
    /// <summary>
    ///     Default Options for System.Text.Json.
    /// </summary>
    internal static readonly System.Text.Json.JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
    };

    internal static readonly NetJSON.NetJSONSettings NetJsonOptions = new()
    {
        DateFormat = NetJSON.NetJSONDateFormat.ISO,
        TimeZoneFormat = NetJSON.NetJSONTimeZoneFormat.Utc,
        UseStringOptimization = true,
        CamelCase = true
    };
    
    internal static readonly Newtonsoft.Json.JsonSerializerSettings NewtonsoftOptions = new()
    {
        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
        DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
    };

    internal static readonly ServiceStack.Text.Config ServiceStackOptions = new() 
    {
        DateHandler = ServiceStack.Text.DateHandler.ISO8601,
        AlwaysUseUtc = true,
        TextCase = ServiceStack.Text.TextCase.CamelCase,
    };

    internal static readonly Jil.Options JilOptions = 
        new(dateFormat: Jil.DateTimeFormat.ISO8601,
            serializationNameFormat: Jil.SerializationNameFormat.CamelCase);

    internal static readonly MessagePack.MessagePackSerializerOptions MsgPackOptions 
        = MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);

    /// <summary>
    ///     Settings for Maverick Json.
    /// </summary>
    internal static readonly Maverick.Json.JsonSettings MaverickSettings = new()
    {
        NamingStrategy = Maverick.Json.JsonNamingStrategy.CamelCase,
        Format = Maverick.Json.JsonFormat.None,
    };
}