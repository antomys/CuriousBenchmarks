namespace Benchmark.Serializers.Binary;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="MessagePack.MessagePackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> MessagePackDeserializeBytes<T>(byte[] bytes)
    {
        return MessagePack.MessagePackSerializer.Deserialize<ICollection<T>>(bytes);
    }
    /// <summary>
    ///     Serializes with <see cref="MessagePack.MessagePackSerializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] MessagePackSerializeBytes<T>(T[] simpleModels)
    {
        return MessagePack.MessagePackSerializer.Serialize(simpleModels);
    }
}