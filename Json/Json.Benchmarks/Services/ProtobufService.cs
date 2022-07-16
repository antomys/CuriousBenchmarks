using System.Buffers;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="ProtoBuf"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class ProtobufService<T>
{
    /// <summary>
    ///     Serializes collection of T values using 'Protobuf'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized value.</returns>
    public static byte[] ProtobufSerializeBytes(ICollection<T> tValue)
    {
        var writer = new ArrayBufferWriter<byte>();

        ProtoBuf.Serializer.Serialize(writer, tValue);

        return writer.WrittenSpan.ToArray();
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="ProtoBuf"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ProtobufDeserializeBytes(byte[] testByteArray)
    {
        return ProtoBuf.Serializer.Deserialize<ICollection<T>>(testByteArray.AsSpan())!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="ProtoBuf"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> ProtobufDeserializeStream(Stream testStream)
    {
        testStream.Position = 0;

        return ProtoBuf.Serializer.Deserialize<ICollection<T>>(testStream)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="ProtoBuf"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> ProtobufDeserializeAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return ValueTask.FromResult(ProtoBuf.Serializer.Deserialize<ICollection<T>>(testStream));
    }
}