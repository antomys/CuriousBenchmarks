using System.Buffers;

namespace Benchmarks.Serializers.Binary;

public static partial class Serializers
{
    /// <summary>
    ///     Serializes with <see cref="ProtoBuf.Serializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="ICollection{T}" />
    /// </returns>
    public static ICollection<T> ProtobufDeserializeBytes<T>(ReadOnlySpan<byte> bytes)
    {
        return ProtoBuf.Serializer.Deserialize<ICollection<T>>(bytes);
    }
    /// <summary>
    ///     Serializes with <see cref="ProtoBuf.Serializer" />.
    /// </summary>
    /// <returns>
    ///     <see cref="byte" />
    /// </returns>
    public static byte[] ProtobufSerializeBytes<T>(T[] simpleModels)
    {
        var writer = new ArrayBufferWriter<byte>();

        ProtoBuf.Serializer.Serialize(writer, simpleModels);

        return writer.WrittenSpan.ToArray();
    }
}