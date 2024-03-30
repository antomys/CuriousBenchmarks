using System.Text;
using Benchmarks.Serializers.Json.Extensions;
using ServiceStack.Text;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="ServiceStack.Text.JsonSerializer" /> to string.
    /// </summary>
    /// <param name="testString"></param>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static ICollection<T> ServiceStackString<T>(string testString)
    {
        using (JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return JsonSerializer.DeserializeFromString<ICollection<T>>(testString);
        }
    }

    /// <summary>
    ///     Serializes with <see cref="ServiceStack.Text.JsonSerializer" /> to string.
    /// </summary>
    /// <param name="testBytes"></param>
    /// <returns>
    ///     <see cref="string" />
    /// </returns>
    public static ICollection<T> ServiceStackByte<T>(byte[] testBytes)
    {
        using (JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return JsonSerializer.DeserializeFromSpan<ICollection<T>>(Encoding.UTF8.GetString(testBytes));
        }
    }

    public static string ServiceStackString<T>(T[] simpleModels)
    {
        using (JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            return JsonSerializer.SerializeToString(simpleModels);
        }
    }

    public static byte[] ServiceStackByte<T>(T[] simpleModels)
    {
        using var writer = new StringWriter();

        using (JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            JsonSerializer.SerializeToWriter(simpleModels, writer);
        }

        return Encoding.UTF8.GetBytes(writer.ToString());
    }
}