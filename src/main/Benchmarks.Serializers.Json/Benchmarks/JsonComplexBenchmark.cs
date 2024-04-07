// using System.Diagnostics.CodeAnalysis;
// using BenchmarkDotNet.Attributes;
// using BenchmarkDotNet.Configs;
// using BenchmarkDotNet.Order;
// using Benchmarks.Common;
// using Benchmarks.Serializers.Json.Models;
// using Benchmarks.Serializers.Json.Models.SrcGen;
// using Bogus;
//
// namespace Benchmarks.Serializers.Json.Benchmarks;
//
// /// <summary>
// ///     Serialization benchmarks base.
// /// </summary>
// [MemoryDiagnoser, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
//  GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
// [ExcludeFromCodeCoverage]
// public class JsonComplexBenchmark
// {
//     /// <summary>
//     ///     Static <see cref="Faker" /> for <see cref="ComplexModel" />.
//     /// </summary>
//     private readonly static Faker<ComplexModel> Faker = new();
//
//     /// <summary>
//     ///     Static <see cref="Faker" /> for <see cref="ComplexModel" />.
//     /// </summary>
//     private readonly static Faker<ComplexSrcGenModel> FakerSrcGen = new();
//
//     /// <summary>
//     ///     Collection of testing <see cref="ComplexModel" />.
//     /// </summary>
//     protected List<ComplexModel> ComplexModels = new();
//
//     /// <summary>
//     ///     Collection of testing <see cref="ComplexModel" />.
//     /// </summary>
//     protected ComplexSrcGenModel[] ComplexSrcGenModels = Array.Empty<ComplexSrcGenModel>();
//
//     /// <summary>
//     ///     Size of generation.
//     ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
//     /// </summary>
//     [Params(1)]
//     public int CollectionSize { get; set; }
//
//     /// <summary>
//     ///     Setting private fields.
//     /// </summary>
//     public void Setup()
//     {
//         ComplexModels = Faker
//             .RuleFor(complexModel => complexModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
//             .RuleFor(complexModel => complexModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
//             .RuleFor(complexModel => complexModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
//             .RuleFor(complexModel => complexModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
//             .RuleFor(complexModel => complexModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
//             .RuleFor(complexModel => complexModel.TestInt, fakerSetter => fakerSetter.Random.Int())
//             .RuleFor(complexModel => complexModel.TestLong, fakerSetter => fakerSetter.Random.Long())
//             .RuleFor(complexModel => complexModel.TestShort, fakerSetter => fakerSetter.Random.Short())
//             .RuleFor(complexModel => complexModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
//             .RuleFor(complexModel => complexModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
//             .RuleFor(complexModel => complexModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
//             .RuleFor(complexModel => complexModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
//             .RuleFor(complexModel => complexModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
//             .RuleFor(complexModel => complexModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', 10))
//             .RuleFor(complexModel => complexModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), 10))
//             .RuleFor(complexModel => complexModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), 10))
//             .RuleFor(complexModel => complexModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), 10))
//             .RuleFor(complexModel => complexModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), 10))
//             .RuleFor(complexModel => complexModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), 10))
//             .RuleFor(complexModel => complexModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), 10))
//             .RuleFor(complexModel => complexModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), 10))
//             .RuleFor(complexModel => complexModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), 10))
//             .RuleFor(complexModel => complexModel.TestULongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.ULong(), 10))
//             .Generate(CollectionSize);
//
//         ComplexSrcGenModels = FakerSrcGen
//             .RuleFor(complexModel => complexModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
//             .RuleFor(complexModel => complexModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
//             .RuleFor(complexModel => complexModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
//             .RuleFor(complexModel => complexModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
//             .RuleFor(complexModel => complexModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
//             .RuleFor(complexModel => complexModel.TestInt, fakerSetter => fakerSetter.Random.Int())
//             .RuleFor(complexModel => complexModel.TestLong, fakerSetter => fakerSetter.Random.Long())
//             .RuleFor(complexModel => complexModel.TestShort, fakerSetter => fakerSetter.Random.Short())
//             .RuleFor(complexModel => complexModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
//             .RuleFor(complexModel => complexModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
//             .RuleFor(complexModel => complexModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
//             .RuleFor(complexModel => complexModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
//             .RuleFor(complexModel => complexModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
//             .RuleFor(complexModel => complexModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', 10))
//             .RuleFor(complexModel => complexModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), 10))
//             .RuleFor(complexModel => complexModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), 10))
//             .RuleFor(complexModel => complexModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), 10))
//             .RuleFor(complexModel => complexModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), 10))
//             .RuleFor(complexModel => complexModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), 10))
//             .RuleFor(complexModel => complexModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), 10))
//             .RuleFor(complexModel => complexModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), 10))
//             .RuleFor(complexModel => complexModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), 10))
//             .Generate(CollectionSize)
//             .ToArray();
//     }
// }

