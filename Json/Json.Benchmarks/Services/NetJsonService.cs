using Json.Benchmarks.Extensions;

namespace Json.Benchmarks.Services;

/// <summary>
///     Service for <see cref="NetJSON"/>.
/// </summary>
public static class NetJsonService
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="NetJSON"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T Deserialize<T>(string testString)
    {
        return NetJSON.NetJSON.Deserialize<T>(testString, JsonServiceExtensions.NetJsonOptions);
    }
    
    /// <summary>
    ///     Serializes collection of T using <see cref="NetJSON"/>.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized string.</returns>
    public static string Serialize<T>(T tValue)
    {
        return NetJSON.NetJSON.Serialize(tValue, JsonServiceExtensions.NetJsonOptions);
    }
}