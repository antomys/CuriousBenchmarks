using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Service for <see cref="ServiceStack"/>.
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class ServiceStackService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    /// 
    public static ICollection<T> ServiceStackDeserialize(string testString)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromSpan<ICollection<T>>(testString);
        }
    }
    
    /// <summary>
    ///     Serialize collection of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Serialized string.</returns>
    public static string ServiceStackSerialize(ICollection<T> tValues)
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
    public static ICollection<T> ServiceStackDeserializeStream(Stream stream)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromStream<ICollection<T>>(stream);
        }
    }
    
    /// <summary>
    ///     Serialize collection of TValue using <see cref="ServiceStack"/>.
    /// </summary>
    /// <returns>Serialized string.</returns>
    public static MemoryStream ServiceStackSerializeStream(ICollection<T> tValues)
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
    public static Task<ICollection<T>> ServiceStackDeserializeStreamAsync(Stream stream)
    {
        using (ServiceStack.Text.JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return ServiceStack.Text.JsonSerializer.DeserializeFromStreamAsync<ICollection<T>>(stream);
        }
    }
}