using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Service for <see cref="ServiceStack"/>.
/// </summary>
public sealed class ServiceStackService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    /// 
    public static T ServiceStackDeserialize<T>(string testString)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromSpan<T>(testString);
        }
    }
    
    /// <summary>
    ///     Serialize collection of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Serialized string.</returns>
    public static string ServiceStackSerialize<T>(T tValues)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.SerializeToString(tValues);
        }
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T ServiceStackDeserializeStream<T>(Stream stream)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromStream<T>(stream);
        }
    }
    
    /// <summary>
    ///     Serialize collection of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Serialized string.</returns>
    public static MemoryStream ServiceStackSerializeStream<T>(T tValues)
    {
        using var memoryStream = new MemoryStream();
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            ServiceStack.Text.JsonSerializer.SerializeToStream(tValues, memoryStream);

            return memoryStream;
        }
    }
    
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static Task<T> ServiceStackDeserializeStreamAsync<T>(Stream stream)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromStreamAsync<T>(stream);
        }
    }
}