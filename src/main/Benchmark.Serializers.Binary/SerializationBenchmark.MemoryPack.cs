namespace Benchmark.Serializers.Binary;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="MemoryPack.MemoryPackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> MemoryPackDeserializeBytes<T>(byte[] bytes)
    {
        return MemoryPack.MemoryPackSerializer.Deserialize<ICollection<T>>(bytes)!;
    }
    /// <summary>
    ///     Serializes with <see cref="MemoryPack.MemoryPackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] MemoryPackSerializeBytes<T>(T[] simpleModels)
    {
        return MemoryPack.MemoryPackSerializer.Serialize(simpleModels);
    }
}