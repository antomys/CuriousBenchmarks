using System.Collections.Specialized;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using QueryBenchmarks.Extensions;

namespace QueryBenchmarks.Benchmarks;

/// <summary>
///     Query building methods benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class QueryBuilderBenchmarks
{
    private const string Url = "https://datausa.io/api/data";
    private static readonly StringBuilder StringBuilder = new("?");

    private static readonly Dictionary<string, string> TestValues = new()
    {
        { "drilldowns", "Nation" },
        { "measures", "Population" }
    };
    
    private static readonly NameValueCollection TestNvc = new()
    {
        {"drilldowns", "Nation"},
        {"measures", "Population"}
    };

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
        using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("drilldowns", "Nation"),
            new("measures", "Population")
        });

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
    [Benchmark]
    public string AspNetCoreQueryBuilderQuery()
    {
        var qb = new QueryBuilder
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        return Url + qb.ToQueryString();
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