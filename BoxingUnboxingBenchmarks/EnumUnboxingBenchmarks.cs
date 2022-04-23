using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
// ReSharper disable ForCanBeConvertedToForeach

namespace BoxingUnboxingBenchmarks;

/// <summary>
///     Enum boxing/unboxing benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class EnumUnboxingBenchmarks
{
    private readonly Consumer _consumer = new();

    private static TestEnum[] _testEnums = default!;

    /// <summary>
    ///     Global setup of private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _testEnums = new []
        {
            TestEnum.First,
            TestEnum.Second,
            TestEnum.Third,
            TestEnum.Fourth,
            TestEnum.Fifth,
            TestEnum.Sixth,
            TestEnum.Seventh,
            TestEnum.Eighth,
            TestEnum.Ninth,
            TestEnum.Tenth,
            TestEnum.Eleventh,
            TestEnum.Twelfth
        };
    }

    /// <summary>
    ///     The simplest method to get name of the enum
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>input enum name.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If out of range of enum.</exception>
    private static string GetName(TestEnum testEnum) 
        => testEnum switch
        {
            TestEnum.First => nameof(TestEnum.First),
            TestEnum.Second => nameof(TestEnum.Second),
            TestEnum.Third => nameof(TestEnum.Third),
            TestEnum.Fourth => nameof(TestEnum.Fourth),
            TestEnum.Fifth => nameof(TestEnum.Fifth),
            TestEnum.Sixth => nameof(TestEnum.Sixth),
            TestEnum.Seventh => nameof(TestEnum.Seventh),
            TestEnum.Eighth => nameof(TestEnum.Eighth),
            TestEnum.Ninth => nameof(TestEnum.Ninth),
            TestEnum.Tenth => nameof(TestEnum.Tenth),
            TestEnum.Eleventh => nameof(TestEnum.Eleventh),
            TestEnum.Twelfth => nameof(TestEnum.Twelfth),
            TestEnum.Zero => nameof(TestEnum.Zero),
            _ => throw new ArgumentOutOfRangeException(nameof(testEnum), testEnum, null)
        };

    /// <summary>
    ///     Getting int value from enum by .ToString().
    /// </summary>
    [BenchmarkCategory("Int from Enum"), Benchmark]
    public string IntFromEnumToString()
    {
        return _testEnums[0].ToString("D");
    }
    
    /// <summary>
    ///     Getting int value from enum by implicit cast of enum
    /// </summary>
    [BenchmarkCategory("Int from Enum"), Benchmark]
    public string IntFromEnumCast()
    {
        return ((int) _testEnums[0]).ToString();
    }
    
    /// <summary>
    ///     Getting string enum name by .ToString(). (Boxing allocation).
    /// </summary>
    [BenchmarkCategory("String from Enum"), Benchmark]
    public string StringFromEnumToString()
    {
        return _testEnums[0].ToString();
    }
    
    /// <summary>
    ///     Getting string enum name by Enum.GetName().
    /// </summary>
    [BenchmarkCategory("String from Enum"), Benchmark]
    public string? StringFromEnumGetName()
    {
       return Enum.GetName(_testEnums[0]);
    }
    
    /// <summary>
    ///     Getting string enum name by written custom method.
    /// </summary>
    [BenchmarkCategory("String from Enum"), Benchmark]
    public string StringFromEnumCustom()
    {
        return GetName(_testEnums[0]);
    }
    
    /// <summary>
    ///     <see cref="IntFromEnumToString"/>
    /// </summary>
    [BenchmarkCategory("Array. Int from Enum"), Benchmark]
    public void EnumIntByToString()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            _testEnums[i].ToString("D").Consume(_consumer);
        }
    }

    /// <summary>
    ///     <see cref="IntFromEnumCast"/>
    /// </summary>
    [BenchmarkCategory("Array. Int from Enum"), Benchmark]
    public void EnumIntByCast()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            ((int) _testEnums[i]).ToString().Consume(_consumer);
        }
    }

    /// <summary>
    ///     <see cref="StringFromEnumToString"/>
    /// </summary>
    [BenchmarkCategory("Array. String from Enum"), Benchmark]
    public void EnumToString()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            _testEnums[i].ToString().Consume(_consumer);
        }
    }
    
    /// <summary>
    ///     <see cref="StringFromEnumGetName"/>
    /// </summary>
    [BenchmarkCategory("Array. String from Enum"), Benchmark]
    public void EnumGetName()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            Enum.GetName(_testEnums[i]).Consume(_consumer);
        }
    }
    
    /// <summary>
    ///     <see cref="StringFromEnumGetName"/>
    /// </summary>
    [BenchmarkCategory("Array. String from Enum"), Benchmark]
    public void EnumGetNameCustom()
    {
        for(var i = 0; i < _testEnums.Length; i++)
        {
            GetName(_testEnums[i]).Consume(_consumer);
        }
    }
    
    /// <summary>
    ///     <see cref="EnumIntByToString"/>
    /// </summary>
    [BenchmarkCategory("Array. Int from Enum Linq"), Benchmark]
    public void EnumIntByToStringLinq()
    {
        _testEnums.Select(testEnum => testEnum.ToString("D")).Consume(_consumer);
    }

    /// <summary>
    ///     <see cref="EnumIntByToString"/>
    /// </summary>
    [BenchmarkCategory("Array. Int from Enum Linq"), Benchmark]
    public void EnumIntByCastLinq()
    {
        _testEnums.Select(testEnum =>  ((int) testEnum).ToString()).Consume(_consumer);
    }
    
    /// <summary>
    ///     <see cref="EnumIntByToString"/>
    /// </summary>
    [BenchmarkCategory("Array. String from Enum Linq"), Benchmark]
    public void EnumToStringLinq()
    {
        _testEnums.Select(testEnum =>  testEnum.ToString()).Consume(_consumer);
    }
    
    /// <summary>
    ///     <see cref="EnumIntByToString"/>
    /// </summary>
    [BenchmarkCategory("Array. String from Enum Linq"), Benchmark]
    public void EnumGetNameLinq()
    {
        _testEnums.Select(Enum.GetName).Consume(_consumer);
    }
    
    /// <summary>
    ///     <see cref="EnumIntByToString"/>
    /// </summary>
    [BenchmarkCategory("Array. String from Enum Linq"), Benchmark]
    public void EnumGetNameCustomLinq()
    {
        _testEnums.Select(GetName).Consume(_consumer);
    }
}