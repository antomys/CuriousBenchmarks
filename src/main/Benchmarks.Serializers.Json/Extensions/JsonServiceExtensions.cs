using System.Text.Json;
using Jil;
using MessagePack;
using NetJSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ServiceStack.Text;

namespace Benchmarks.Serializers.Json.Extensions;

/// <summary>
///     Extensions for Json services.
/// </summary>
public static class JsonServiceExtensions
{
    /// <summary>
    ///     Default Options for System.Text.Json.
    /// </summary>
    public readonly static JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public readonly static NetJSONSettings NetJsonOptions = new()
    {
        DateFormat = NetJSONDateFormat.ISO,
        TimeZoneFormat = NetJSONTimeZoneFormat.Utc,
        UseStringOptimization = true,
        CamelCase = true
    };

    public readonly static JsonSerializerSettings NewtonsoftOptions = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateFormatHandling = DateFormatHandling.IsoDateFormat
    };

    public readonly static Config ServiceStackOptions = new()
    {
        DateHandler = DateHandler.ISO8601,
        AlwaysUseUtc = true,
        TextCase = TextCase.CamelCase
    };

    public readonly static Options JilOptions =
        new(dateFormat: DateTimeFormat.ISO8601,
            serializationNameFormat: SerializationNameFormat.CamelCase);

    public readonly static MessagePackSerializerOptions MsgPackOptions
        = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);
}