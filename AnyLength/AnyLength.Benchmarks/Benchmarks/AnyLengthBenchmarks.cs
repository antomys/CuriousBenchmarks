using AnyLength.Benchmarks.Models;
using AnyLength.Benchmarks.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using CuriousBenchmarks.Common;

namespace AnyLength.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[CategoriesColumn]
[AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub]
[CsvMeasurementsExporter]
[RPlotExporter]
public class AnyLengthBenchmarks
{
    private TestCollections[] _testCollections = null!;
    
    [Params(10000)]
    public int Size { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        _testCollections = new TestCollections[2];
        
        _testCollections[0] = new Faker<TestCollections>()
            .RuleFor(testCollections => testCollections.TestArray, fakerSetter => fakerSetter.GetArray(fake => fake.Random.String2(5, 10), Size))
            .RuleFor(testCollections => testCollections.TestList, fakerSetter => fakerSetter.GetList(fake => fake.Random.String2(5, 10), Size))
            .RuleFor(testCollections => testCollections.TestICollection, fakerSetter => fakerSetter.GetCollection(fake => fake.Random.String2(5, 10), Size))
            .RuleFor(testCollections => testCollections.TostIEnumerable, fakerSetter => fakerSetter.GetEnumerable(fake => fake.Random.String2(5, 10), Size))
            .Generate(1)[0];

        _testCollections[1] = new TestCollections();
    }

    [BenchmarkCategory(BenchmarkCategories.CountExists), Benchmark]
    public bool ArrayCountExists()
    {
        return _testCollections[0].TestArray.CountArray();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountExists), Benchmark]
    public bool ListCountExists()
    {
        return _testCollections[0].TestList.CountList();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountExists), Benchmark]
    public bool CollectionCountExists()
    {
        return _testCollections[0].TestICollection.CountCollection();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountPatternExists), Benchmark]
    public bool ArrayCountPatternExists()
    {
        return _testCollections[0].TestArray.CountArray();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountPatternExists), Benchmark]
    public bool ListCountPatternExists()
    {
        return _testCollections[0].TestList.CountList();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountPatternExists), Benchmark]
    public bool CollectionCountPatternExists()
    {
        return _testCollections[0].TestICollection.CountCollection();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountExists), Benchmark]
    public bool EnumerableCountExists()
    {
        return _testCollections[0].TostIEnumerable.CountEnumerable();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyExists), Benchmark]
    public bool ArrayAnyExists()
    {
        return _testCollections[0].TestArray.AnyArray();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyExists), Benchmark]
    public bool ListAnyExists()
    {
        return _testCollections[0].TestList.AnyList();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyExists), Benchmark]
    public bool CollectionAnyExists()
    {
        return _testCollections[0].TestICollection.AnyCollection();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyExists), Benchmark]
    public bool EnumerableAnyExists()
    {
        return _testCollections[0].TostIEnumerable.AnyEnumerable();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountEmpty), Benchmark]
    public bool ArrayCountEmpty()
    {
        return _testCollections[1].TestArray.CountArray();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountEmpty), Benchmark]
    public bool ListCountEmpty()
    {
        return _testCollections[1].TestList.CountList();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountEmpty), Benchmark]
    public bool CollectionCountEmpty()
    {
        return _testCollections[1].TestICollection.CountCollection();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountPatternEmpty), Benchmark]
    public bool ArrayCountPatternEmpty()
    {
        return _testCollections[1].TestArray.CountArray();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountPatternEmpty), Benchmark]
    public bool ListCountPatternEmpty()
    {
        return _testCollections[1].TestList.CountList();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountPatternEmpty), Benchmark]
    public bool CollectionCountPatternEmpty()
    {
        return _testCollections[1].TestICollection.CountCollection();
    }
    
    [BenchmarkCategory(BenchmarkCategories.CountEmpty), Benchmark]
    public bool EnumerableCountEmpty()
    {
        return _testCollections[1].TostIEnumerable.CountEnumerable();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyEmpty), Benchmark]
    public bool ArrayAnyEmpty()
    {
        return _testCollections[1].TestArray.AnyArray();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyEmpty), Benchmark]
    public bool ListAnyEmpty()
    {
        return _testCollections[1].TestList.AnyList();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyEmpty), Benchmark]
    public bool CollectionAnyEmpty()
    {
        return _testCollections[1].TestICollection.AnyCollection();
    }
    
    [BenchmarkCategory(BenchmarkCategories.AnyEmpty), Benchmark]
    public bool EnumerableAnyEmpty()
    {
        return _testCollections[1].TostIEnumerable.AnyEnumerable();
    }
}