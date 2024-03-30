using JsonSrcGen;

namespace Benchmarks.Serializers.Json.Models;

/// <summary>
///     Test model.
/// </summary>
[Json]
public class ComplexSrcGenModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonName("testString")]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string array values.
    /// </summary>
    [JsonName("testStringArray")]
    public virtual string[] TestStringArray { get; set; } = Array.Empty<string>();

    /// <summary>
    ///     Gets or sets test int value.
    /// </summary>
    [JsonName("testInt")]
    public virtual int TestInt { get; set; }

    /// <summary>
    ///     Gets or sets test int array values.
    /// </summary>
    [JsonName("testIntArray")]
    public virtual int[] TestIntArray { get; set; } = Array.Empty<int>();

    /// <summary>
    ///     Gets or sets test double value.
    /// </summary>
    [JsonName("testDouble")]
    public virtual double TestDouble { get; set; }

    /// <summary>
    ///     Gets or sets test double array values.
    /// </summary>
    [JsonName("testDoubleArray")]
    public virtual double[] TestDoubleArray { get; set; } = Array.Empty<double>();

    /// <summary>
    ///     Gets or sets test float value.
    /// </summary>
    [JsonName("testFloat")]
    public virtual float TestFloat { get; set; }

    /// <summary>
    ///     Gets or sets test float array values.
    /// </summary>
    [JsonName("testFloatArray")]
    public virtual float[] TestFloatArray { get; set; } = Array.Empty<float>();

    /// <summary>
    ///     Gets or sets test uint value.
    /// </summary>
    [JsonName("testUInt")]
    public virtual uint TestUInt { get; set; }

    /// <summary>
    ///     Gets or sets test uint array values.
    /// </summary>
    [JsonName("testUIntArray")]
    public virtual uint[] TestUIntArray { get; set; } = Array.Empty<uint>();

    /// <summary>
    ///     Gets or sets test char value.
    /// </summary>
    [JsonName("testChar")]
    public virtual char TestChar { get; set; }

    /// <summary>
    ///     Gets or sets test char array values.
    /// </summary>
    [JsonName("testCharArray")]
    public virtual char[] TestCharArray { get; set; } = Array.Empty<char>();

    /// <summary>
    ///     Gets or sets test byte value.
    /// </summary>
    [JsonName("testByte")]
    public virtual byte TestByte { get; set; }

    // [ZeroFormatter.Index(13)]
    // [ProtoBuf.ProtoMember(13)]
    // [JsonSrcGen.JsonName("testByteArray")]
    // public virtual byte[] TestByteArray { get; set; }

    /// <summary>
    ///     Gets or sets test short value.
    /// </summary>
    [JsonName("testShort")]
    public virtual short TestShort { get; set; }

    /// <summary>
    ///     Gets or sets test short array values.
    /// </summary>
    [JsonName("testShortArray")]
    public virtual short[] TestShortArray { get; set; } = Array.Empty<short>();

    /// <summary>
    ///     Gets or sets test ushort value.
    /// </summary>
    [JsonName("testUShort")]
    public virtual ushort TestUShort { get; set; }

    /// <summary>
    ///     Gets or sets test ushort array values.
    /// </summary>
    [JsonName("testUShortArray")]
    public virtual ushort[] TestUShortArray { get; set; } = Array.Empty<ushort>();


    /// <summary>
    ///     Gets or sets test long value.
    /// </summary>
    [JsonName("testLong")]
    public virtual long TestLong { get; set; }

    /// <summary>
    ///     Gets or sets test long array values.
    /// </summary>
    [JsonName("testLongArray")]
    public virtual long[] TestLongArray { get; set; } = Array.Empty<long>();

    /// <summary>
    ///     Gets or sets test ulong value.
    /// </summary>
    [JsonName("testULong")]
    public virtual ulong TestULong { get; set; }

    /// <summary>
    ///     Gets or sets test ulong array values.
    /// </summary>
    [JsonName("testULongArray")]
    public virtual ulong[] TestULongArray { get; set; } = Array.Empty<ulong>();

    /// <summary>
    ///     Gets or sets test DateTime value.
    /// </summary>
    [JsonName("testDate")]
    public virtual DateTime TestDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Gets or sets test TimeSpan value.
    /// </summary>
    [JsonIgnore]
    public virtual TimeSpan TestTimeSpan { get; set; } = TimeSpan.Zero;
}