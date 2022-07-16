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
    ///     Test first name.
    /// </summary>
    [Index(1)]
    [ProtoMember(1)]
    [DataMember(Name = "TestString")]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Test first name.
    /// </summary>
    [Index(24)]
    [ProtoMember(24)]
    [DataMember(Name = "TestStringArray")]
    public virtual string[] TestStringArray { get; set; }
    /// <summary>
    ///     Test last name.
    /// </summary>
    [Index(2)]
    [ProtoMember(2)]
    [DataMember(Name = "TestInt")]
    public virtual int TestInt { get; set; }
    
    [Index(3)]
    [ProtoMember(3)]
    [DataMember(Name = "TestIntArray")]
    public virtual int[] TestIntArray { get; set; }

    [Index(4)]
    [ProtoMember(4)]
    [DataMember(Name = "TestDouble")]
    public virtual double TestDouble { get; set; }
    
    [Index(5)]
    [ProtoMember(5)]
    [DataMember(Name = "TestDoubleArray")]
    public virtual double[] TestDoubleArray { get; set; }
    
    [Index(6)]
    [ProtoMember(6)]
    [DataMember(Name = "TestFloat")]
    public virtual float TestFloat { get; set; }
    
    [Index(7)]
    [ProtoMember(7)]
    [DataMember(Name = "TestFloatArray")]
    public virtual float[] TestFloatArray { get; set; }
    
    [Index(8)]
    [ProtoMember(8)]
    [DataMember(Name = "TestUInt")]
    public virtual uint TestUInt { get; set; }
    
    [Index(9)]
    [ProtoMember(9)]
    [DataMember(Name = "TestUIntArray")]
    public virtual uint[] TestUIntArray { get; set; }
    
    [Index(10)]
    [ProtoMember(10)]
    [DataMember(Name = "TestChar")]
    public virtual char TestChar { get; set; }
    
    [Index(11)]
    [ProtoMember(11)]
    [DataMember(Name = "TestCharArray")]
    public virtual char[] TestCharArray { get; set; }
    
    [Index(12)]
    [ProtoMember(12)]
    [DataMember(Name = "TestByte")]
    public virtual byte TestByte { get; set; }
    
    // [Index(13)]
    // [ProtoMember(13)]
    // [DataMember(Name = "TestByteArray")]
    // public virtual byte[] TestByteArray { get; set; }
    
    [Index(14)]
    [ProtoMember(14)]
    [DataMember(Name = "TestShort")]
    public virtual short TestShort { get; set; }
    
    [Index(15)]
    [ProtoMember(15)]
    [DataMember(Name = "TestShortArray")]
    public virtual short[] TestShortArray { get; set; }
    
    [Index(16)]
    [ProtoMember(16)]
    [DataMember(Name = "TestUShort")]
    public virtual ushort TestUShort { get; set; }
    
    [Index(17)]
    [ProtoMember(17)]
    [DataMember(Name = "TestUShortArray")]
    public virtual ushort[] TestUShortArray { get; set; }
    
    [Index(18)]
    [ProtoMember(18)]
    [DataMember(Name = "TestLong")]
    public virtual long TestLong { get; set; }

    [Index(19)]
    [ProtoMember(19)]
    [DataMember(Name = "TestLongArray")]
    public virtual long[] TestLongArray { get; set; }
    
    [Index(20)]
    [ProtoMember(20)]
    [DataMember(Name = "TestULong")]
    public virtual ulong TestULong { get; set; }
    
    [Index(21)]
    [ProtoMember(21)]
    [DataMember(Name = "TestULongArray")]
    public virtual ulong[] TestULongArray { get; set; }
    
    [Index(22)]
    [ProtoMember(22, DataFormat = DataFormat.Default)]
    [DataMember(Name = "TestDate")]
    public virtual DateTime TestDate { get; set; } = DateTime.UtcNow;
    
    [Index(23)]
    [ProtoMember(23)]
    [DataMember(Name = "TestTimeSpan")]
    public virtual TimeSpan TestTimeSpan { get; set; } = TimeSpan.Zero;

}