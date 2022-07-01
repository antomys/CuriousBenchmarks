using System.Collections.Specialized;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using Microsoft.AspNetCore.WebUtilities;
using Query.Benchmarks.Extensions;

namespace Query.Benchmarks.Benchmarks;

/// <summary>
///     Query building methods benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class QueryBuilderBenchmarks
{
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1,2,3,4,5,6,7,8,9,10)]
    public int Count { get; set; }
    
    private const string Url = "https://datausa.io/api/data";
    
    private static readonly StringBuilder StringBuilder = new("?");
    private static readonly Dictionary<string, string> TestValues = new();
    private static readonly NameValueCollection TestNvc = new();
    private static readonly Microsoft.AspNetCore.Http.Extensions.QueryBuilder QueryBuilder = new();
    private static readonly QueryBuilderV1 QueryBuilderV1ValuesNew = new();
    
    private static KeyValuePair<string, string>[]? _testKvp;

    /// <summary>
    ///     Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker();
        Randomizer.Seed = new Random(420);
        _testKvp = new KeyValuePair<string, string>[10];

        for (var i = 0; i < 10; i++)
        {
            var (testKey, testValue) = (faker.Random.String2(5), faker.Random.String2(5));

            TestValues.Add(testKey, testValue);
            TestNvc.Add(testKey, testValue);
            QueryBuilder.Add(testKey, testValue);
            QueryBuilderV1ValuesNew.Add(testKey, testValue);
            
            _testKvp[i] = KeyValuePair.Create(testKey, testValue);
        }
    }
    /// <summary>
    ///     Build query from dict.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string QueryFromDictionary()
    {
        return QueryHelpers.AddQueryString(Url, TestValues);
    }

    /// <summary>
    ///     Async building query with Kvp.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(GroupConstants.Async), Benchmark]
    public async Task<string> FormUrlEncodedContentQueryAsync()
    {
        using var content = new FormUrlEncodedContent(_testKvp!);

        var result = await content.ReadAsStringAsync();
        
        return Url + "?" + result;
    }

    /// <summary>
    ///     Async creating query.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory(GroupConstants.Async), Benchmark]
    public async Task<string> FormUrlEncodedContentDictionaryQueryAsync()
    {
        using var content = new FormUrlEncodedContent(TestValues);

        var result = await content.ReadAsStringAsync();
        
        return Url + "?" + result;
    }

    /// <summary>
    ///     Custom method.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string CustomQuery()
    {
        return Url + TestNvc.ToQueryString();
    }
    
    /// <summary>
    ///     Static version of StringBuilder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string CustomStaticStringBuilderQuery()
    {
        return Url + StaticStringBuilderString(TestNvc);
    }

    /// <summary>
    ///     Asp.net query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark(Baseline = true)]
    public string AspNetCoreQueryBuilderQuery()
    {
        return Url + QueryBuilder.ToQueryString();
    }

    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV1()
    {
        return Url + TestValues.LinqQuery();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV2()
    {
        return Url + TestValues.LinqQueryV2();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV21()
    {
        return Url + TestValues.LinqQueryV2ModV1();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV22()
    {
        return Url + TestValues.LinqQueryV2ModV2();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV23()
    {
        return Url + QueryBuilderV1ValuesNew.LinqQueryV2ModV3();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV23Span()
    {
        var query = QueryBuilderV1ValuesNew.LinqQueryV2ModV3();

        return string.Create(Url.Length + query.Length, (Url, query), (span, tuple) =>
        {
            var (url, s) = tuple;
            url.CopyTo(span);
            s.CopyTo(span[url.Length..]);
        });
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV3()
    {
        return Url + TestValues.LinqQueryV3();
    }
    
    private static string StaticStringBuilderString(NameValueCollection nvc)
    {
        var first = true;

        foreach (var key in nvc.AllKeys)
        foreach (var value in nvc.GetValues(key)!)
        {
            if (!first) StringBuilder.Append('&');

            StringBuilder.Append($"{Uri.EscapeDataString(key!)}={Uri.EscapeDataString(value)}");

            first = false;
        }

        var result = StringBuilder.ToString();
        StringBuilder.Clear();

        return result;
    }
}