using System.Buffers;

namespace Json.Benchmarks.Services.Deserialization;

/// <summary>
///     Static methods wrapper of <see cref="Protobuf(string)"/>.
/// </summary>
/// <typeparam name="T">TValue.</typeparam>
public static class ProtobufService<T>
{
    /// <summary>
    ///     Deserialize string of TValue using <see cref="Protobuf(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Protobuf(string testString)
    {
        var testArray = System.Text.Encoding.UTF8.GetBytes(testString);
        
        return global::ProtoBuf.Serializer.Deserialize<ICollection<T>>(testArray.AsSpan());
    }
    
    public static string Protobuf(T tValue)
    {
        var writer = new ArrayBufferWriter<byte>();

        global::ProtoBuf.Serializer.Serialize(writer, tValue);

        return System.Text.Encoding.UTF8.GetString(writer.WrittenSpan);
    }
    
    public static byte[] ProtobufBytes(T tValue)
    {
        var writer = new ArrayBufferWriter<byte>();

        global::ProtoBuf.Serializer.Serialize(writer, tValue);

        return writer.WrittenSpan.ToArray();
    }
    
    /// <summary>
    ///     Deserialize byte array of TValue using <see cref="Protobuf(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Protobuf(byte[] testByteArray)
    {
        return global::ProtoBuf.Serializer.Deserialize<ICollection<T>>(testByteArray.AsSpan())!;
    }
    
    /// <summary>
    ///     Deserialize Stream of TValue using <see cref="Protobuf(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ICollection<T> Protobuf(Stream testStream)
    {
        testStream.Position = 0;

        return global::ProtoBuf.Serializer.Deserialize<ICollection<T>>(testStream)!;
    }
    
    /// <summary>
    ///     Asynchronously deserialize string ot TValue using <see cref="Protobuf(string)"/>.
    /// </summary>
    /// <returns>Collection of TValue.</returns>
    public static ValueTask<ICollection<T>> ProtobufAsync(Stream testStream)
    {
        testStream.Position = 0;
        
        return ValueTask.FromResult(global::ProtoBuf.Serializer.Deserialize<ICollection<T>>(testStream));
    }
}