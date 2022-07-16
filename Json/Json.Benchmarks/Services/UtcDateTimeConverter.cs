using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json.Benchmarks.Services;

/// <inheritdoc />
public sealed class UtcDateTimeConverter : JsonConverter<DateTime>
{
    /// <inheritdoc />
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var stringValue = jsonDoc.RootElement.GetRawText().Trim('"').Trim('\'');
        var value = DateTime.Parse(stringValue, null, System.Globalization.DateTimeStyles.RoundtripKind);
        
        return value;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var stringValue = value.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFZ");
        writer.WriteStringValue(stringValue);
    }
}