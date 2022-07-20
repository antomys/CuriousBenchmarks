using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;
using Microsoft.AspNetCore.Http.Extensions;
using Query.Benchmarks.Services.Query;

namespace Query.Benchmarks.Benchmarks;

/// <summary>
///     Query building methods benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class QueryBuilderBenchmarks
{
    /// <summary>
    ///     Parameter for models count.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 2, 5, 10)]
    public int QueryCount { get; set; }
    
    private const string Url = "https://localhost";

    // Note: Shutting up compiler. Method below assures that there will be no methods with null.
    private static QueryValueStringBuilder _queryValueStringBuilder = default!;
    private static Dictionary<string, string> _testDictionary = default!;
    private static KeyValuePair<string, string>[] _testKvp = default!;
    private static QueryCustomBuilder _queryCustomBuilder = default!;
    private static QueryDictionary _testQueryDictionary = default!;
    private static NameValueCollection _testNvc = default!;
    private static QueryBuilder _queryBuilder = default!;

    /// <summary>
    ///     Global setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var faker = new Faker();

        _testDictionary = new Dictionary<string, string>(QueryCount);
        _queryValueStringBuilder = new QueryValueStringBuilder();
        _testKvp = new KeyValuePair<string, string>[QueryCount];
        _testQueryDictionary = new QueryDictionary(QueryCount);
        _testNvc = new NameValueCollection(QueryCount);
        _queryCustomBuilder = new QueryCustomBuilder();
        _queryBuilder = new QueryBuilder();

        for (var i = 0; i < QueryCount; i++)
        {
            var (testKey, testValue) = (faker.Random.String2(5), faker.Random.String2(5));

            _testKvp[i] = KeyValuePair.Create(testKey, testValue);
            _queryValueStringBuilder.Add(testKey,testValue);
            _testQueryDictionary.Add(testKey, testValue);
            _queryCustomBuilder.Add(testKey, testValue);
            _testDictionary.Add(testKey, testValue);
            _testNvc.Add(testKey, testValue);
            _queryBuilder.Add(testKey, testValue);
        }
    }

    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryDictionary"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark(Baseline = true)]
    public string QueryDictionary()
    {
        return QueryService.QueryDictionary(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.LinqQueryAggregate"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string LinqQueryAggregate()
    {
        return QueryService.LinqQueryAggregate(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.LinqSelectJoin"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string LinqSelectJoin()
    {
        return QueryService.LinqSelectJoin(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryConcatString"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryConcatString()
    {
        return QueryService.QueryConcatString(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryStringCreate"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryStringCreate()
    {
        return QueryService.QueryStringCreate(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.LinqQuerySpanVer2"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string LinqQuerySpanVer2()
    {
        return QueryService.LinqQuerySpanVer2(Url, _testQueryDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryAspNetCore"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryAspNetCore()
    {
        return QueryService.QueryAspNetCore(Url, _queryBuilder);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryCustomBuilder"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryCustomBuilder()
    {
        return QueryService.QueryCustomBuilder(Url, _queryCustomBuilder);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryCustomBuilder"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryValueStringBuilder()
    {
        return QueryService.QueryValueStringBuilder(Url, _queryValueStringBuilder);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryNvcStringBuilder"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryNvcStringBuilder()
    {
        return QueryService.QueryNvcStringBuilder(Url, _testNvc);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryStringCreateConcat"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryStringCreateConcat()
    {
        return QueryService.QueryStringCreateConcat(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryStringCreateStack"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryStringCreateStack()
    {
        return QueryService.QueryStringCreateStack(Url, _testQueryDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryFormUrlEncodedContent"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryFormUrlEncodedContent()
    {
        return QueryService.QueryFormUrlEncodedContent(Url, _testDictionary);
    }
    
    /// <summary>
    ///     Benchmarking method <see cref="QueryService.QueryNvcStaticStringBuilder"/>.
    /// </summary>
    /// <returns>Constructed string.</returns>
    [Benchmark]
    public string QueryNvcStaticStringBuilder()
    {
        return QueryService.QueryNvcStaticStringBuilder(Url, _testNvc);
    }
}