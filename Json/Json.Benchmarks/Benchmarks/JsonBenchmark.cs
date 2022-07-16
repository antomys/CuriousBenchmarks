using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using Json.Benchmarks.Extensions;
using Json.Benchmarks.Models;

namespace Json.Benchmarks.Benchmarks;

/// <summary>
///     Serialization benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class JsonBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="SimpleModel"/>.
    /// </summary>
    private static readonly Faker<SimpleModel> Faker = new();
    
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1000, 10000, 100000, 1000000)]
    public int CollectionSize { get; set; }
    
    /// <summary>
    ///     Collection of testing <see cref="SimpleModel"/>.
    /// </summary>
    protected List<SimpleModel> SimpleModels = new();

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        SimpleModels = Faker
            .RuleFor(simpleModel => simpleModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
            .RuleFor(simpleModel => simpleModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
            .RuleFor(simpleModel => simpleModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
            .RuleFor(simpleModel => simpleModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
            .RuleFor(simpleModel => simpleModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
            .RuleFor(simpleModel => simpleModel.TestInt, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(simpleModel => simpleModel.TestLong, fakerSetter => fakerSetter.Random.Long())
            .RuleFor(simpleModel => simpleModel.TestShort, fakerSetter => fakerSetter.Random.Short())
            .RuleFor(simpleModel => simpleModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
            .RuleFor(simpleModel => simpleModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
            .RuleFor(simpleModel => simpleModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
            .RuleFor(simpleModel => simpleModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
            .RuleFor(simpleModel => simpleModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
            .RuleFor(simpleModel => simpleModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', count: CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), CollectionSize))
            .RuleFor(simpleModel => simpleModel.TestULongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.ULong(), CollectionSize))
            .Generate(CollectionSize);
    }
}