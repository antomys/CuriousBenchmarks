using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using CuriousBenchmarks.Common;
using Json.Benchmarks.Models;
using Json.Benchmarks.Models.SrcGen;

namespace Json.Benchmarks.Benchmarks;

/// <summary>
///     Serialization benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class JsonComplexBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="ComplexModel"/>.
    /// </summary>
    private static readonly Bogus.Faker<ComplexModel> Faker = new();
    
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="ComplexModel"/>.
    /// </summary>
    private static readonly Bogus.Faker<ComplexSrcGenModel> FakerSrcGen = new();
    
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1)]
    public int CollectionSize { get; set; }
    
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel"/>.
    /// </summary>
    protected List<ComplexModel> ComplexModels = new();
    
    /// <summary>
    ///     Collection of testing <see cref="ComplexModel"/>.
    /// </summary>
    protected ComplexSrcGenModel[] ComplexSrcGenModels = Array.Empty<ComplexSrcGenModel>();

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    public void Setup()
    {
        ComplexModels = Faker
            .RuleFor(complexModel => complexModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
            .RuleFor(complexModel => complexModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
            .RuleFor(complexModel => complexModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
            .RuleFor(complexModel => complexModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
            .RuleFor(complexModel => complexModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
            .RuleFor(complexModel => complexModel.TestInt, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(complexModel => complexModel.TestLong, fakerSetter => fakerSetter.Random.Long())
            .RuleFor(complexModel => complexModel.TestShort, fakerSetter => fakerSetter.Random.Short())
            .RuleFor(complexModel => complexModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
            .RuleFor(complexModel => complexModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
            .RuleFor(complexModel => complexModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
            .RuleFor(complexModel => complexModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
            .RuleFor(complexModel => complexModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
            .RuleFor(complexModel => complexModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', count: 10))
            .RuleFor(complexModel => complexModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), count: 10))
            .RuleFor(complexModel => complexModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), count: 10))
            .RuleFor(complexModel => complexModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), count: 10))
            .RuleFor(complexModel => complexModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), count: 10))
            .RuleFor(complexModel => complexModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), count: 10))
            .RuleFor(complexModel => complexModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), count: 10))
            .RuleFor(complexModel => complexModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), count: 10))
            .RuleFor(complexModel => complexModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), count: 10))
            .RuleFor(complexModel => complexModel.TestULongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.ULong(), count: 10))
            .Generate(CollectionSize);
        
        ComplexSrcGenModels = FakerSrcGen
            .RuleFor(complexModel => complexModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
            .RuleFor(complexModel => complexModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
            .RuleFor(complexModel => complexModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
            .RuleFor(complexModel => complexModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
            .RuleFor(complexModel => complexModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
            .RuleFor(complexModel => complexModel.TestInt, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(complexModel => complexModel.TestLong, fakerSetter => fakerSetter.Random.Long())
            .RuleFor(complexModel => complexModel.TestShort, fakerSetter => fakerSetter.Random.Short())
            .RuleFor(complexModel => complexModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
            .RuleFor(complexModel => complexModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
            .RuleFor(complexModel => complexModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
            .RuleFor(complexModel => complexModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
            .RuleFor(complexModel => complexModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
            .RuleFor(complexModel => complexModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', count: 10))
            .RuleFor(complexModel => complexModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), count: 10))
            .RuleFor(complexModel => complexModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), count: 10))
            .RuleFor(complexModel => complexModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), count: 10))
            .RuleFor(complexModel => complexModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), count: 10))
            .RuleFor(complexModel => complexModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), count: 10))
            .RuleFor(complexModel => complexModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), count: 10))
            .RuleFor(complexModel => complexModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), count: 10))
            .RuleFor(complexModel => complexModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), count: 10))
            .Generate(CollectionSize)
            .ToArray();
    }
}