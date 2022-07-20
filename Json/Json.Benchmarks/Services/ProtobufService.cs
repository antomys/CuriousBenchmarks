using System.Buffers;

namespace Json.Benchmarks.Services;

/// <summary>
///     Static methods wrapper of <see cref="ProtoBuf"/>.
/// </summary>
public static class ProtobufService
{
    /// <summary>
    ///     Serializes collection of T values using 'Protobuf'.
    /// </summary>
    /// <param name="tValue">Collection of T values.</param>
    /// <returns>Serialized value.</returns>
    public static byte[] ProtobufSerializeBytes<T>(T tValue)
    {
        var writer = new ArrayBufferWriter<byte>();

        ProtoBuf.Serializer.Serialize(writer, tValue);

        return writer.WrittenSpan.ToArray();
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="ProtoBuf"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T ProtobufDeserializeBytes<T>(byte[] testByteArray)
    {
        return ProtoBuf.Serializer.Deserialize<T>(testByteArray.AsSpan())!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="ProtoBuf"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static T ProtobufDeserializeStream<T>(Stream testStream)
    {
        testStream.Position = 0;

        return ProtoBuf.Serializer.Deserialize<T>(testStream)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="ProtoBuf"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<T> ProtobufDeserializeAsync<T>(Stream testStream)
    {
        testStream.Position = 0;
        
        return ValueTask.FromResult(ProtoBuf.Serializer.Deserialize<T>(testStream));
    }
}