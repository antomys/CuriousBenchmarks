namespace Json.Benchmarks.Models;

/// <summary>
///     Test model.
/// </summary>
[JsonSrcGen.Json]
public class SimpleSrcGenModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [JsonSrcGen.JsonName("testString")]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string array values.
    /// </summary>
    [JsonSrcGen.JsonName("testStringArray")]
    public virtual string[] TestStringArray { get; set; }  = Array.Empty<string>();
    
    /// <summary>
    ///     Gets or sets test int value.
    /// </summary>
    [JsonSrcGen.JsonName("testInt")]
    public virtual int TestInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test int array values.
    /// </summary>
    [JsonSrcGen.JsonName("testIntArray")]
    public virtual int[] TestIntArray { get; set; } = Array.Empty<int>();

    /// <summary>
    ///     Gets or sets test double value.
    /// </summary>
    [JsonSrcGen.JsonName("testDouble")]
    public virtual double TestDouble { get; set; }
    
    /// <summary>
    ///     Gets or sets test double array values.
    /// </summary>
    [JsonSrcGen.JsonName("testDoubleArray")]
    public virtual double[] TestDoubleArray { get; set; } = Array.Empty<double>();
    
    /// <summary>
    ///     Gets or sets test float value.
    /// </summary>
    [JsonSrcGen.JsonName("testFloat")]
    public virtual float TestFloat { get; set; }
    
    /// <summary>
    ///     Gets or sets test float array values.
    /// </summary>
    [JsonSrcGen.JsonName("testFloatArray")]
    public virtual float[] TestFloatArray { get; set; } = Array.Empty<float>();
    
    /// <summary>
    ///     Gets or sets test uint value.
    /// </summary>
    [JsonSrcGen.JsonName("testUInt")]
    public virtual uint TestUInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test uint array values.
    /// </summary>
    [JsonSrcGen.JsonName("testUIntArray")]
    public virtual uint[] TestUIntArray { get; set; } = Array.Empty<uint>();
    
    /// <summary>
    ///     Gets or sets test char value.
    /// </summary>
    [JsonSrcGen.JsonName("testChar")]
    public virtual char TestChar { get; set; }
    
    /// <summary>
    ///     Gets or sets test char array values.
    /// </summary>
    [JsonSrcGen.JsonName("testCharArray")]
    public virtual char[] TestCharArray { get; set; } = Array.Empty<char>();
    
    /// <summary>
    ///     Gets or sets test byte value.
    /// </summary>
    [JsonSrcGen.JsonName("testByte")]
    public virtual byte TestByte { get; set; }
    
    // [ZeroFormatter.Index(13)]
    // [ProtoBuf.ProtoMember(13)]
    // [JsonSrcGen.JsonName("testByteArray")]
    // public virtual byte[] TestByteArray { get; set; }
    
    /// <summary>
    ///     Gets or sets test short value.
    /// </summary>
    [JsonSrcGen.JsonName("testShort")]
    public virtual short TestShort { get; set; }
    
    /// <summary>
    ///     Gets or sets test short array values.
    /// </summary>
    [JsonSrcGen.JsonName("testShortArray")]
    public virtual short[] TestShortArray { get; set; } = Array.Empty<short>();
    
    /// <summary>
    ///     Gets or sets test ushort value.
    /// </summary>
    [JsonSrcGen.JsonName("testUShort")]
    public virtual ushort TestUShort { get; set; }
    
    /// <summary>
    ///     Gets or sets test ushort array values.
    /// </summary>
    [JsonSrcGen.JsonName("testUShortArray")]
    public virtual ushort[] TestUShortArray { get; set; } = Array.Empty<ushort>();
    
        
    /// <summary>
    ///     Gets or sets test long value.
    /// </summary>
    [JsonSrcGen.JsonName("testLong")]
    public virtual long TestLong { get; set; }

    /// <summary>
    ///     Gets or sets test long array values.
    /// </summary>
    [JsonSrcGen.JsonName("testLongArray")]
    public virtual long[] TestLongArray { get; set; } = Array.Empty<long>();
    
    /// <summary>
    ///     Gets or sets test ulong value.
    /// </summary>
    [JsonSrcGen.JsonName("testULong")]
    public virtual ulong TestULong { get; set; }
    
    /// <summary>
    ///     Gets or sets test ulong array values.
    /// </summary>
    [JsonSrcGen.JsonName("testULongArray")]
    public virtual ulong[] TestULongArray { get; set; } = Array.Empty<ulong>();
    
    /// <summary>
    ///     Gets or sets test DateTime value.
    /// </summary>
    [JsonSrcGen.JsonName("testDate")]
    public virtual DateTime TestDate { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    ///     Gets or sets test TimeSpan value.
    /// </summary>
    [JsonSrcGen.JsonIgnore]
    public virtual TimeSpan TestTimeSpan { get; set; } = TimeSpan.Zero;
}