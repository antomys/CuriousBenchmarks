using System.Text;
using Benchmarks.Serializers.Json.Extensions;
using Newtonsoft.Json;

namespace Benchmarks.Serializers.Json;

public partial class Serializers
{
    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <param name="testString"></param>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T>? NewtonsoftString<T>(string testString)
    {
        return JsonConvert.DeserializeObject<ICollection<T>>(testString, JsonServiceExtensions.NewtonsoftOptions);
    }

    /// <summary>
    ///     Serializes with Newtonsoft.Json.
    /// </summary>
    /// <param name="testBytes"></param>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T>? NewtonsoftBytes<T>(byte[] testBytes)
    {
        return JsonConvert.DeserializeObject<ICollection<T>>(Encoding.UTF8.GetString(testBytes), JsonServiceExtensions.NewtonsoftOptions);
    }

    public static string NewtonsoftString<T>(T[] simpleModels)
    {
        return JsonConvert.SerializeObject(simpleModels, JsonServiceExtensions.NewtonsoftOptions);
    }

    public static byte[] NewtonsoftBytes<T>(T[] simpleModels)
    {
        return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(simpleModels, JsonServiceExtensions.NewtonsoftOptions));
    }
}