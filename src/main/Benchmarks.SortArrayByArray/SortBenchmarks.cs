using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Benchmarks.SortArrayByArray.Extensions;
using Bogus;

namespace Benchmarks.SortArrayByArray;

[MemoryDiagnoser, AllStatisticsColumn, CategoriesColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), ExcludeFromCodeCoverage]
public class SortBenchmarks
{
    private TestModel[] _models = [];
    private string[] _ids = [];
    
    private static readonly Consumer Consumer = new();

    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100000)]
    public int Size { get; set; }
    
    [GlobalCleanup]
    public void Setup()
    {
        var faker = new Faker<TestModel>();

        _models = faker
            .RuleFor(testModel => testModel.TestNumber, fakerSetter => fakerSetter.Random.Int(-100000, 100000))
            .RuleFor(testModel => testModel.Id, fakerSetter => fakerSetter.Random.String2(10))
            .Generate(Size)!
            .ToArray();
        
        var anotherModels = faker
            .RuleFor(testModel => testModel.TestNumber, fakerSetter => fakerSetter.Random.Int(-100000, 100000))
            .RuleFor(testModel => testModel.Id, fakerSetter => fakerSetter.Random.String2(10))
            .Generate(Size/2)!
            .ToArray();
        
        _ids = anotherModels
            .Select(model => model.Id)
            .Union(_models.Select(model => model.Id))
            .Shuffle()
            .ToArray();
    }

    [GlobalSetup]
    public void Clean()
    {
        _models = [];
        _ids = [];
    }

    [Benchmark(Description = "V1 order", Baseline = true)]
    public void OrderV1()
    {
        var result = _models.OrderV1(_ids);

        Consumer.Consume(result);
    }
    
    [Benchmark(Description = "V1 order Improved")]
    public void OrderV1Improved()
    {
        var result = _models.OrderV1Improved(_ids);

        Consumer.Consume(result);
    }

    [Benchmark(Description = "V2 order")]
    public void OrderV2()
    {
        var result = _models.OrderV2(_ids);

        Consumer.Consume(result);
    }
    
    // [Benchmark(Description = "V3 order")]
    // public void OrderV3()
    // {
    //     var result = _models.OrderV3(_ids);
    //
    //     Consumer.Consume(result);
    // }
    //
    // [Benchmark(Description = "V3 Improved order")]
    // public void OrderV3Improved()
    // {
    //     var result = _models.AsSpan().OrderV3Improved(_ids);
    //
    //     Consumer.Consume(result);
    // }
    //
    // [Benchmark(Description = "V4")]
    // public void OrderV4()
    // {
    //     _models.OrderV4(_ids);
    //
    //     Consumer.Consume(_models);
    // }
}