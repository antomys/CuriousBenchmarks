using System.Runtime.Serialization;

namespace Benchmarks.Serializers.Json.Models;

/// <summary>
///     Test model.
/// </summary>
[ProtoBuf.ProtoContract]
[ZeroFormatter.ZeroFormattable]
[MessagePack.MessagePackObject(true)]
public class ComplexModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [ZeroFormatter.Index(1)]
    [ProtoBuf.ProtoMember(1)]
    [DataMember(Name = "testString")]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string array values.
    /// </summary>
    [ZeroFormatter.Index(24)]
    [ProtoBuf.ProtoMember(24)]
    [DataMember(Name = "testStringArray")]
    public virtual string[] TestStringArray { get; set; }  = Array.Empty<string>();
    
    /// <summary>
    ///     Gets or sets test int value.
    /// </summary>
    [ZeroFormatter.Index(2)]
    [ProtoBuf.ProtoMember(2)]
    [DataMember(Name = "testInt")]
    public virtual int TestInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test int array values.
    /// </summary>
    [ZeroFormatter.Index(3)]
    [ProtoBuf.ProtoMember(3)]
    [DataMember(Name = "testIntArray")]
    public virtual int[] TestIntArray { get; set; } = Array.Empty<int>();

    /// <summary>
    ///     Gets or sets test double value.
    /// </summary>
    [ZeroFormatter.Index(4)]
    [ProtoBuf.ProtoMember(4)]
    [DataMember(Name = "testDouble")]
    public virtual double TestDouble { get; set; }
    
    /// <summary>
    ///     Gets or sets test double array values.
    /// </summary>
    [ZeroFormatter.Index(5)]
    [ProtoBuf.ProtoMember(5)]
    [DataMember(Name = "testDoubleArray")]
    public virtual double[] TestDoubleArray { get; set; } = Array.Empty<double>();
    
    /// <summary>
    ///     Gets or sets test float value.
    /// </summary>
    [ZeroFormatter.Index(6)]
    [ProtoBuf.ProtoMember(6)]
    [DataMember(Name = "testFloat")]
    public virtual float TestFloat { get; set; }
    
    /// <summary>
    ///     Gets or sets test float array values.
    /// </summary>
    [ZeroFormatter.Index(7)]
    [ProtoBuf.ProtoMember(7)]
    [DataMember(Name = "testFloatArray")]
    public virtual float[] TestFloatArray { get; set; } = Array.Empty<float>();
    
    /// <summary>
    ///     Gets or sets test uint value.
    /// </summary>
    [ZeroFormatter.Index(8)]
    [ProtoBuf.ProtoMember(8)]
    [DataMember(Name = "testUInt")]
    public virtual uint TestUInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test uint array values.
    /// </summary>
    [ZeroFormatter.Index(9)]
    [ProtoBuf.ProtoMember(9)]
    [DataMember(Name = "testUIntArray")]
    public virtual uint[] TestUIntArray { get; set; } = Array.Empty<uint>();
    
    /// <summary>
    ///     Gets or sets test char value.
    /// </summary>
    [ZeroFormatter.Index(10)]
    [ProtoBuf.ProtoMember(10)]
    [DataMember(Name = "testChar")]
    public virtual char TestChar { get; set; }
    
    /// <summary>
    ///     Gets or sets test char array values.
    /// </summary>
    [ZeroFormatter.Index(11)]
    [ProtoBuf.ProtoMember(11)]
    [DataMember(Name = "testCharArray")]
    public virtual char[] TestCharArray { get; set; } = Array.Empty<char>();
    
    /// <summary>
    ///     Gets or sets test byte value.
    /// </summary>
    [ZeroFormatter.Index(12)]
    [ProtoBuf.ProtoMember(12)]
    [DataMember(Name = "testByte")]
    public virtual byte TestByte { get; set; }
    
    // [ZeroFormatter.Index(13)]
    // [ProtoBuf.ProtoMember(13)]
    // [DataMember(Name = "testByteArray")]
    // public virtual byte[] TestByteArray { get; set; }
    
    /// <summary>
    ///     Gets or sets test short value.
    /// </summary>
    [ZeroFormatter.Index(14)]
    [ProtoBuf.ProtoMember(14)]
    [DataMember(Name = "testShort")]
    public virtual short TestShort { get; set; }
    
    /// <summary>
    ///     Gets or sets test short array values.
    /// </summary>
    [ZeroFormatter.Index(15)]
    [ProtoBuf.ProtoMember(15)]
    [DataMember(Name = "testShortArray")]
    public virtual short[] TestShortArray { get; set; } = Array.Empty<short>();
    
    /// <summary>
    ///     Gets or sets test ushort value.
    /// </summary>
    [ZeroFormatter.Index(16)]
    [ProtoBuf.ProtoMember(16)]
    [DataMember(Name = "testUShort")]
    public virtual ushort TestUShort { get; set; }
    
    /// <summary>
    ///     Gets or sets test ushort array values.
    /// </summary>
    [ZeroFormatter.Index(17)]
    [ProtoBuf.ProtoMember(17)]
    [DataMember(Name = "testUShortArray")]
    public virtual ushort[] TestUShortArray { get; set; } = Array.Empty<ushort>();
    
        
    /// <summary>
    ///     Gets or sets test long value.
    /// </summary>
    [ZeroFormatter.Index(18)]
    [ProtoBuf.ProtoMember(18)]
    [DataMember(Name = "testLong")]
    public virtual long TestLong { get; set; }

    /// <summary>
    ///     Gets or sets test long array values.
    /// </summary>
    [ZeroFormatter.Index(19)]
    [ProtoBuf.ProtoMember(19)]
    [DataMember(Name = "testLongArray")]
    public virtual long[] TestLongArray { get; set; } = Array.Empty<long>();
    
    /// <summary>
    ///     Gets or sets test ulong value.
    /// </summary>
    [ZeroFormatter.Index(20)]
    [ProtoBuf.ProtoMember(20)]
    [DataMember(Name = "testULong")]
    public virtual ulong TestULong { get; set; }
    
    /// <summary>
    ///     Gets or sets test ulong array values.
    /// </summary>
    [ZeroFormatter.Index(21)]
    [ProtoBuf.ProtoMember(21)]
    [DataMember(Name = "testULongArray")]
    public virtual ulong[] TestULongArray { get; set; } = Array.Empty<ulong>();
    
    /// <summary>
    ///     Gets or sets test DateTime value.
    /// </summary>
    [ZeroFormatter.Index(22)]
    [ProtoBuf.ProtoMember(22, DataFormat = ProtoBuf.DataFormat.Default)]
    [DataMember(Name = "testDate")]
    public virtual DateTime TestDate { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    ///     Gets or sets test TimeSpan value.
    /// </summary>
    [ZeroFormatter.Index(23)]
    [ProtoBuf.ProtoMember(23)]
    [DataMember(Name = "testTimeSpan")]
    [Utf8Json.JsonFormatter(typeof(Utf8Json.Formatters.TimeSpanFormatter))]
    public virtual TimeSpan TestTimeSpan { get; set; } = TimeSpan.Zero;
}