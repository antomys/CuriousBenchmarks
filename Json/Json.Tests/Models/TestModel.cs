using System.Runtime.Serialization;
using MessagePack;
using ProtoBuf;
using ZeroFormatter;

namespace Json.Tests.Models;

/// <summary>
///     Test model.
/// </summary>
[ProtoContract]
[ZeroFormattable]
[MessagePackObject(true)]
public class TestModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [Index(1)]
    [ProtoMember(1)]
    [DataMember(Name = "TestString")]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string array values.
    /// </summary>
    [Index(24)]
    [ProtoMember(24)]
    [DataMember(Name = "TestStringArray")]
    public virtual string[] TestStringArray { get; set; }  = Array.Empty<string>();
    
    /// <summary>
    ///     Gets or sets test int value.
    /// </summary>
    [Index(2)]
    [ProtoMember(2)]
    [DataMember(Name = "TestInt")]
    public virtual int TestInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test int array values.
    /// </summary>
    [Index(3)]
    [ProtoMember(3)]
    [DataMember(Name = "TestIntArray")]
    public virtual int[] TestIntArray { get; set; } = Array.Empty<int>();

    /// <summary>
    ///     Gets or sets test double value.
    /// </summary>
    [Index(4)]
    [ProtoMember(4)]
    [DataMember(Name = "TestDouble")]
    public virtual double TestDouble { get; set; }
    
    /// <summary>
    ///     Gets or sets test double array values.
    /// </summary>
    [Index(5)]
    [ProtoMember(5)]
    [DataMember(Name = "TestDoubleArray")]
    public virtual double[] TestDoubleArray { get; set; } = Array.Empty<double>();
    
    /// <summary>
    ///     Gets or sets test float value.
    /// </summary>
    [Index(6)]
    [ProtoMember(6)]
    [DataMember(Name = "TestFloat")]
    public virtual float TestFloat { get; set; }
    
    /// <summary>
    ///     Gets or sets test float array values.
    /// </summary>
    [Index(7)]
    [ProtoMember(7)]
    [DataMember(Name = "TestFloatArray")]
    public virtual float[] TestFloatArray { get; set; } = Array.Empty<float>();
    
    /// <summary>
    ///     Gets or sets test uint value.
    /// </summary>
    [Index(8)]
    [ProtoMember(8)]
    [DataMember(Name = "TestUInt")]
    public virtual uint TestUInt { get; set; }
    
    /// <summary>
    ///     Gets or sets test uint array values.
    /// </summary>
    [Index(9)]
    [ProtoMember(9)]
    [DataMember(Name = "TestUIntArray")]
    public virtual uint[] TestUIntArray { get; set; } = Array.Empty<uint>();
    
    /// <summary>
    ///     Gets or sets test char value.
    /// </summary>
    [Index(10)]
    [ProtoMember(10)]
    [DataMember(Name = "TestChar")]
    public virtual char TestChar { get; set; }
    
    /// <summary>
    ///     Gets or sets test char array values.
    /// </summary>
    [Index(11)]
    [ProtoMember(11)]
    [DataMember(Name = "TestCharArray")]
    public virtual char[] TestCharArray { get; set; } = Array.Empty<char>();
    
    /// <summary>
    ///     Gets or sets test byte value.
    /// </summary>
    [Index(12)]
    [ProtoMember(12)]
    [DataMember(Name = "TestByte")]
    public virtual byte TestByte { get; set; }
    
    // [Index(13)]
    // [ProtoMember(13)]
    // [DataMember(Name = "TestByteArray")]
    // public virtual byte[] TestByteArray { get; set; }
    
    /// <summary>
    ///     Gets or sets test short value.
    /// </summary>
    [Index(14)]
    [ProtoMember(14)]
    [DataMember(Name = "TestShort")]
    public virtual short TestShort { get; set; }
    
    /// <summary>
    ///     Gets or sets test short array values.
    /// </summary>
    [Index(15)]
    [ProtoMember(15)]
    [DataMember(Name = "TestShortArray")]
    public virtual short[] TestShortArray { get; set; } = Array.Empty<short>();
    
    /// <summary>
    ///     Gets or sets test ushort value.
    /// </summary>
    [Index(16)]
    [ProtoMember(16)]
    [DataMember(Name = "TestUShort")]
    public virtual ushort TestUShort { get; set; }
    
    /// <summary>
    ///     Gets or sets test ushort array values.
    /// </summary>
    [Index(17)]
    [ProtoMember(17)]
    [DataMember(Name = "TestUShortArray")]
    public virtual ushort[] TestUShortArray { get; set; } = Array.Empty<ushort>();
    
        
    /// <summary>
    ///     Gets or sets test long value.
    /// </summary>
    [Index(18)]
    [ProtoMember(18)]
    [DataMember(Name = "TestLong")]
    public virtual long TestLong { get; set; }

    /// <summary>
    ///     Gets or sets test long array values.
    /// </summary>
    [Index(19)]
    [ProtoMember(19)]
    [DataMember(Name = "TestLongArray")]
    public virtual long[] TestLongArray { get; set; } = Array.Empty<long>();
    
    /// <summary>
    ///     Gets or sets test ulong value.
    /// </summary>
    [Index(20)]
    [ProtoMember(20)]
    [DataMember(Name = "TestULong")]
    public virtual ulong TestULong { get; set; }
    
    /// <summary>
    ///     Gets or sets test ulong array values.
    /// </summary>
    [Index(21)]
    [ProtoMember(21)]
    [DataMember(Name = "TestULongArray")]
    public virtual ulong[] TestULongArray { get; set; } = Array.Empty<ulong>();
    
    /// <summary>
    ///     Gets or sets test DateTime value.
    /// </summary>
    [Index(22)]
    [ProtoMember(22, DataFormat = DataFormat.Default)]
    [DataMember(Name = "TestDate")]
    public virtual DateTime TestDate { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    ///     Gets or sets test TimeSpan value.
    /// </summary>
    [Index(23)]
    [ProtoMember(23)]
    [DataMember(Name = "TestTimeSpan")]
    public virtual TimeSpan TestTimeSpan { get; set; } = TimeSpan.Zero;

}