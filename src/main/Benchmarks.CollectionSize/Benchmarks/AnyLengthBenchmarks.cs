using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Benchmarks.CollectionSize.Models;
using Benchmarks.CollectionSize.Services;
using Benchmarks.Common;
using Bogus;

namespace Benchmarks.CollectionSize.Benchmarks;

/// <summary>
///     Benchmarks of <see cref="AnyLengthService"/>.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub]
public class AnyLengthBenchmarks
{
    private TestCollections[] _testCollections = null!;
    
    /// <summary>
    ///     Size of a collection.
    /// </summary>
    [Params(10000)]
    public int Size { get; set; }
    
    /// <summary>
    ///     Globally setting up fake data to every benchmark run.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _testCollections = new TestCollections[2];
        
        _testCollections[0] = new Faker<TestCollections>()
            .RuleFor(testCollections => testCollections.TestArray, fakerSetter => fakerSetter.GetArray(fake => fake.Random.String2(5, 10), Size))
            .RuleFor(testCollections => testCollections.TestList, fakerSetter => fakerSetter.GetList(fake => fake.Random.String2(5, 10), Size))
            .RuleFor(testCollections => testCollections.TestICollection, fakerSetter => fakerSetter.GetCollection(fake => fake.Random.String2(5, 10), Size))
            .RuleFor(testCollections => testCollections.TestIEnumerable, fakerSetter => fakerSetter.GetEnumerable(fake => fake.Random.String2(5, 10), Size))
            .Generate(1)[0];

        _testCollections[1] = new TestCollections();
    }

    /// <summary>
    ///     Test of 'CountArray' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountExists), Benchmark]
    public bool ArrayCountExists()
    {
        return _testCollections[0].TestArray.CountArray();
    }
    
    /// <summary>
    ///     Test of 'CountList' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountExists), Benchmark]
    public bool ListCountExists()
    {
        return _testCollections[0].TestList.CountList();
    }
    
    /// <summary>
    ///     Test of 'CountCollection' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountExists), Benchmark]
    public bool CollectionCountExists()
    {
        return _testCollections[0].TestICollection.CountCollection();
    }
    
    /// <summary>
    ///     Test of 'CountArrayPattern' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountPatternExists), Benchmark]
    public bool ArrayCountPatternExists()
    {
        return _testCollections[0].TestArray.CountArrayPattern();
    }
    
    /// <summary>
    ///     Test of 'CountListPattern' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountPatternExists), Benchmark]
    public bool ListCountPatternExists()
    {
        return _testCollections[0].TestList.CountListPattern();
    }
    
    /// <summary>
    ///     Test of 'CountCollectionPattern' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountPatternExists), Benchmark]
    public bool CollectionCountPatternExists()
    {
        return _testCollections[0].TestICollection.CountCollectionPattern();
    }
    
    /// <summary>
    ///     Test of 'CountEnumerable' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountExists), Benchmark]
    public bool EnumerableCountExists()
    {
        return _testCollections[0].TestIEnumerable.CountEnumerable();
    }
    
    /// <summary>
    ///     Test of 'AnyArray' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyExists), Benchmark]
    public bool ArrayAnyExists()
    {
        return _testCollections[0].TestArray.AnyArray();
    }
    
    /// <summary>
    ///     Test of 'AnyList' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyExists), Benchmark]
    public bool ListAnyExists()
    {
        return _testCollections[0].TestList.AnyList();
    }
    
    /// <summary>
    ///     Test of 'AnyCollection' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyExists), Benchmark]
    public bool CollectionAnyExists()
    {
        return _testCollections[0].TestICollection.AnyCollection();
    }
    
    /// <summary>
    ///     Test of 'AnyEnumerable' when collection is full.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyExists), Benchmark]
    public bool EnumerableAnyExists()
    {
        return _testCollections[0].TestIEnumerable.AnyEnumerable();
    }
    
    /// <summary>
    ///     Test of 'CountArray' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountEmpty), Benchmark]
    public bool ArrayCountEmpty()
    {
        return _testCollections[1].TestArray.CountArray();
    }
    
    /// <summary>
    ///     Test of 'CountList' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountEmpty), Benchmark]
    public bool ListCountEmpty()
    {
        return _testCollections[1].TestList.CountList();
    }
    
    /// <summary>
    ///     Test of 'CountCollection' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountEmpty), Benchmark]
    public bool CollectionCountEmpty()
    {
        return _testCollections[1].TestICollection.CountCollection();
    }
    
    /// <summary>
    ///     Test of 'CountArrayPattern' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountPatternEmpty), Benchmark]
    public bool ArrayCountPatternEmpty()
    {
        return _testCollections[1].TestArray.CountArrayPattern();
    }
    
    /// <summary>
    ///     Test of 'CountListPattern' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountPatternEmpty), Benchmark]
    public bool ListCountPatternEmpty()
    {
        return _testCollections[1].TestList.CountListPattern();
    }
    
    /// <summary>
    ///     Test of 'CountCollectionPattern' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountPatternEmpty), Benchmark]
    public bool CollectionCountPatternEmpty()
    {
        return _testCollections[1].TestICollection.CountCollectionPattern();
    }
    
    /// <summary>
    ///     Test of 'CountCollectionPattern' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.CountEmpty), Benchmark]
    public bool EnumerableCountEmpty()
    {
        return _testCollections[1].TestIEnumerable.CountEnumerable();
    }
    
    /// <summary>
    ///     Test of 'AnyArray' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyEmpty), Benchmark]
    public bool ArrayAnyEmpty()
    {
        return _testCollections[1].TestArray.AnyArray();
    }
    
    /// <summary>
    ///     Test of 'AnyList' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyEmpty), Benchmark]
    public bool ListAnyEmpty()
    {
        return _testCollections[1].TestList.AnyList();
    }
    
    /// <summary>
    ///     Test of 'AnyCollection' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyEmpty), Benchmark]
    public bool CollectionAnyEmpty()
    {
        return _testCollections[1].TestICollection.AnyCollection();
    }
    
    /// <summary>
    ///     Test of 'AnyEnumerable' when collection is empty.
    /// </summary>
    /// <returns>Boolean.</returns>
    [BenchmarkCategory(Group.AnyEmpty), Benchmark]
    public bool EnumerableAnyEmpty()
    {
        return _testCollections[1].TestIEnumerable.AnyEnumerable();
    }
}