using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MemoryPack;
using MessagePack;
using Newtonsoft.Json;
using ProtoBuf;
using Utf8Json;
using Utf8Json.Formatters;
using ZeroFormatter;

namespace Benchmark.Serializers.Models;

/// <summary>
///     Test model.
/// </summary>
[ProtoContract, ZeroFormattable, MessagePackObject(true), MemoryPackable]
public partial class ComplexModel
{
    /// <summary>
    ///     Gets or sets test string value.
    /// </summary>
    [Index(1), ProtoMember(1), DataMember(Name = "testString"), JsonPropertyName("testString"), JsonProperty("testString")]
    public virtual string TestString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets test string array values.
    /// </summary>
    [Index(24), ProtoMember(24), DataMember(Name = "testStringArray"), JsonPropertyName("testStringArray"), JsonProperty("testStringArray")]
    public virtual string[] TestStringArray { get; set; } = Array.Empty<string>();

    /// <summary>
    ///     Gets or sets test int value.
    /// </summary>
    [Index(2), ProtoMember(2), DataMember(Name = "testInt"), JsonPropertyName("testInt"), JsonProperty("testInt")]
    public virtual int TestInt { get; set; }

    /// <summary>
    ///     Gets or sets test int array values.
    /// </summary>
    [Index(3), ProtoMember(3), DataMember(Name = "testIntArray")]
    public virtual int[] TestIntArray { get; set; } = Array.Empty<int>();

    /// <summary>
    ///     Gets or sets test double value.
    /// </summary>
    [Index(4), ProtoMember(4), DataMember(Name = "testDouble")]
    public virtual double TestDouble { get; set; }

    /// <summary>
    ///     Gets or sets test double array values.
    /// </summary>
    [Index(5), ProtoMember(5), DataMember(Name = "testDoubleArray")]
    public virtual double[] TestDoubleArray { get; set; } = Array.Empty<double>();

    /// <summary>
    ///     Gets or sets test float value.
    /// </summary>
    [Index(6), ProtoMember(6), DataMember(Name = "testFloat")]
    public virtual float TestFloat { get; set; }

    /// <summary>
    ///     Gets or sets test float array values.
    /// </summary>
    [Index(7), ProtoMember(7), DataMember(Name = "testFloatArray")]
    public virtual float[] TestFloatArray { get; set; } = Array.Empty<float>();

    /// <summary>
    ///     Gets or sets test uint value.
    /// </summary>
    [Index(8), ProtoMember(8), DataMember(Name = "testUInt")]
    public virtual uint TestUInt { get; set; }

    /// <summary>
    ///     Gets or sets test uint array values.
    /// </summary>
    [Index(9), ProtoMember(9), DataMember(Name = "testUIntArray")]
    public virtual uint[] TestUIntArray { get; set; } = Array.Empty<uint>();

    /// <summary>
    ///     Gets or sets test char value.
    /// </summary>
    [Index(10), ProtoMember(10), DataMember(Name = "testChar")]
    public virtual char TestChar { get; set; }

    /// <summary>
    ///     Gets or sets test char array values.
    /// </summary>
    [Index(11), ProtoMember(11), DataMember(Name = "testCharArray")]
    public virtual char[] TestCharArray { get; set; } = Array.Empty<char>();

    /// <summary>
    ///     Gets or sets test byte value.
    /// </summary>
    [Index(12), ProtoMember(12), DataMember(Name = "testByte")]
    public virtual byte TestByte { get; set; }

    // [ZeroFormatter.Index(13)]
    // [ProtoBuf.ProtoMember(13)]
    // [DataMember(Name = "testByteArray")]
    // public virtual byte[] TestByteArray { get; set; }

    /// <summary>
    ///     Gets or sets test short value.
    /// </summary>
    [Index(14), ProtoMember(14), DataMember(Name = "testShort")]
    public virtual short TestShort { get; set; }

    /// <summary>
    ///     Gets or sets test short array values.
    /// </summary>
    [Index(15), ProtoMember(15), DataMember(Name = "testShortArray")]
    public virtual short[] TestShortArray { get; set; } = Array.Empty<short>();

    /// <summary>
    ///     Gets or sets test ushort value.
    /// </summary>
    [Index(16), ProtoMember(16), DataMember(Name = "testUShort")]
    public virtual ushort TestUShort { get; set; }

    /// <summary>
    ///     Gets or sets test ushort array values.
    /// </summary>
    [Index(17), ProtoMember(17), DataMember(Name = "testUShortArray")]
    public virtual ushort[] TestUShortArray { get; set; } = Array.Empty<ushort>();


    /// <summary>
    ///     Gets or sets test long value.
    /// </summary>
    [Index(18), ProtoMember(18), DataMember(Name = "testLong")]
    public virtual long TestLong { get; set; }

    /// <summary>
    ///     Gets or sets test long array values.
    /// </summary>
    [Index(19), ProtoMember(19), DataMember(Name = "testLongArray")]
    public virtual long[] TestLongArray { get; set; } = Array.Empty<long>();

    /// <summary>
    ///     Gets or sets test ulong value.
    /// </summary>
    [Index(20), ProtoMember(20), DataMember(Name = "testULong")]
    public virtual ulong TestULong { get; set; }

    /// <summary>
    ///     Gets or sets test ulong array values.
    /// </summary>
    [Index(21), ProtoMember(21), DataMember(Name = "testULongArray")]
    public virtual ulong[] TestULongArray { get; set; } = Array.Empty<ulong>();

    /// <summary>
    ///     Gets or sets test DateTime value.
    /// </summary>
    [Index(22), ProtoMember(22, DataFormat = DataFormat.Default), DataMember(Name = "testDate")]
    public virtual DateTime TestDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Gets or sets test TimeSpan value.
    /// </summary>
    [Index(23), ProtoMember(23), DataMember(Name = "testTimeSpan"), JsonFormatter(typeof(TimeSpanFormatter))]
    public virtual TimeSpan TestTimeSpan { get; set; } = TimeSpan.Zero;
}