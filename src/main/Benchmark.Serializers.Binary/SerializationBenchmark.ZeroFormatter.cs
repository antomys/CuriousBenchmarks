namespace Benchmark.Serializers.Binary;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="ZeroFormatter" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> ZeroFormatterDeserializeBytes<T>(byte[] bytes)
    {
        return ZeroFormatter.ZeroFormatterSerializer.Deserialize<ICollection<T>>(bytes);
    }
    /// <summary>
    ///     Serializes with <see cref="ZeroFormatter" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] ZeroFormatterSerializeBytes<T>(T[] simpleModels)
    {
        return ZeroFormatter.ZeroFormatterSerializer.Serialize(simpleModels);
    }
}