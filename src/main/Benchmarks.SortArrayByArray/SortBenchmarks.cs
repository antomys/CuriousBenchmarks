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
    ///     Parameter for model count.
    ///     **NOTE: ** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(10, 100000)]
    public int Size { get; set; }
    
    [GlobalSetup]
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

    [GlobalCleanup]
    public void Clean()
    {
        _models = [];
        _ids = [];
    }

    [Benchmark(Description = "Distinct + Select + ToDictionary + Order by Dictionary key", Baseline = true)]
    public void OrderV1()
    {
        var order = _ids
            .Distinct()
            .Select((s, i) => (s, i))
            .ToDictionary(kvp => kvp.s, kvp => kvp.i);
        
        var result = _models
            .OrderBy(i => order.GetValueOrDefault(i.Id, int.MaxValue));

        Consumer.Consume(result);
    }
    
    [Benchmark(Description = "Distinct + Span Add to Dict + Order by Dictionary key")]
    public void OrderV1Improved()
    {
        var order = new Dictionary<string, int>(_ids.Length);

        var idsSpan = _ids.AsSpan();
        for (var i = 0; i < idsSpan.Length; i++)
        {
            order.TryAdd(idsSpan[i], i);
        }
        
        var result = _models
            .OrderBy(i => order.GetValueOrDefault(i.Id, int.MaxValue));

        Consumer.Consume(result);
    }

    [Benchmark(Description = "Order by Array Index of")]
    public void OrderV2()
    {
        var result = _models.OrderBy(model =>
        {
            var index = Array.IndexOf(_ids, model.Id);
            
            return index is -1 ? int.MaxValue : index;
        });

        Consumer.Consume(result);
    }
    
    [Benchmark(Description = "Iterate over array and add to list")]
    public void OrderV3()
    {
        var result = new List<TestModel>();
        
        for (var i = 0; i < _ids.Length; i++) 
        { // "i" spares indexof.
            for (int j = 0, l = _models.Length; j < l; j++)
            {
                if (!_ids[i].Equals(_models[j].Id))
                {
                    continue;
                }
                
                result.Add(_models[j]);
                //might as well Remove from listToBeSorted to decrease complexity.
                //listToBeSorted.RemoveAt(j);
                break;
            }
        }
    
        Consumer.Consume(result);
    }
    
    [Benchmark(Description = "V3 Improved order")]
    public void OrderV3Improved()
    {
        var result = new List<TestModel>(_models.Length);
        
        for (var i = 0; i < _ids.Length; i++) 
        { // "i" spares indexof.
            for (int j = 0, l = _models.Length; j < l; j++)
            {
                if (!_ids[i].Equals(_models[j].Id))
                {
                    continue;
                }
                
                result.Add(_models[j]);
                //might as well Remove from listToBeSorted to decrease complexity.
                //listToBeSorted.RemoveAt(j);
                break;
            }
        }
    
        Consumer.Consume(result);
    }
    
    [Benchmark(Description = "Sort by span method")]
    public void OrderV4()
    {
        _models.AsSpan().Sort((model1, model2) => Comparison(model1, model2, _ids));

        Consumer.Consume(_models);

        int Comparison(TestModel x, TestModel y, Span<string> ids)
        {
            var idx1 = ids.IndexOf(x.Id);
            var idx2 = ids.IndexOf(y.Id);

            return Comparer<int>.Default.Compare(idx1, idx2);
        }
    }
}