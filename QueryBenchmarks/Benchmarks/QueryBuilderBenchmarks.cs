using System.Collections.Specialized;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Bogus;
using Microsoft.AspNetCore.WebUtilities;
using QueryBenchmarks.Extensions;

namespace QueryBenchmarks.Benchmarks;

/// <summary>
///     Query building methods benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
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
    public string BuildDictionaryQuery()
    {
        return QueryHelpers.AddQueryString(Url, TestValues);
    }

    /// <summary>
    ///     ASync building query with Kvp.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("Async"), Benchmark]
    public async Task<string> BuildFormUrlEncodedContentKeyValuePairQuery()
    {
        using var content = new FormUrlEncodedContent(_testKvp!);

        var result = await content.ReadAsStringAsync();
        
        return Url + "?" + result;
    }

    /// <summary>
    ///     Async creating query.
    /// </summary>
    /// <returns></returns>
    [BenchmarkCategory("Async"), Benchmark]
    public async Task<string> BuildFormUrlEncodedContentDictionaryQuery()
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
    public string CustomMethodQuery()
    {
        return Url + TestNvc.ToQueryString();
    }
    
    /// <summary>
    ///     Static version of StringBuilder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string CustomMethodStaticStringBuilderQuery()
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
    public string LinqBuildQueryV2ModV1()
    {
        return Url + TestValues.LinqQueryV2ModV1();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV2ModV2()
    {
        return Url + TestValues.LinqQueryV2ModV2();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV2ModV3()
    {
        return Url + QueryBuilderV1ValuesNew.LinqQueryV2ModV3();
    }
    
    /// <summary>
    ///     Linq query builder.
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public string LinqBuildQueryV2ModV3Span()
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