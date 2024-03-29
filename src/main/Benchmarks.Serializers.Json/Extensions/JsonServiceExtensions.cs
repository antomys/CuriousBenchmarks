namespace Benchmarks.Serializers.Json.Extensions;

/// <summary>
///     Extensions for Json services.
/// </summary>
public static class JsonServiceExtensions
{
    /// <summary>
    ///     Default Options for System.Text.Json.
    /// </summary>
    public readonly static System.Text.Json.JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
    };

    public readonly static NetJSON.NetJSONSettings NetJsonOptions = new()
    {
        DateFormat = NetJSON.NetJSONDateFormat.ISO,
        TimeZoneFormat = NetJSON.NetJSONTimeZoneFormat.Utc,
        UseStringOptimization = true,
        CamelCase = true
    };
    
    public readonly static Newtonsoft.Json.JsonSerializerSettings NewtonsoftOptions = new()
    {
        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
        DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
    };

    public readonly static ServiceStack.Text.Config ServiceStackOptions = new() 
    {
        DateHandler = ServiceStack.Text.DateHandler.ISO8601,
        AlwaysUseUtc = true,
        TextCase = ServiceStack.Text.TextCase.CamelCase,
    };

    public readonly static Jil.Options JilOptions = 
        new(dateFormat: Jil.DateTimeFormat.ISO8601,
            serializationNameFormat: Jil.SerializationNameFormat.CamelCase);

    public readonly static MessagePack.MessagePackSerializerOptions MsgPackOptions 
        = MessagePack.MessagePackSerializerOptions.Standard.WithCompression(MessagePack.MessagePackCompression.Lz4BlockArray);
}