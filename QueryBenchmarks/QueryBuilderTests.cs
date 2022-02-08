using System.Collections.Specialized;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;

namespace QueryBenchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[JsonExporterAttribute.Full, MarkdownExporterAttribute.GitHub]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
public class QueryBuilderTests
{
    private const string Url = "https://datausa.io/api/data";
    private static readonly StringBuilder StringBuilder = new("?");

    [Benchmark]
    public async Task BuildDictionaryQuery()
    {
        var queries = new Dictionary<string, string>
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var queryString = QueryHelpers.AddQueryString(Url, queries);

        await Task.CompletedTask;
    }

    [Benchmark]
    public async Task BuildFormUrlEncodedContentKeyValuePairQuery()
    {
        using var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
        {
            new("drilldowns", "Nation"),
            new("measures", "Population")
        });

        var result = content.ReadAsStringAsync();
        const string urlNew = Url + "?";

        await result;
    }

    [Benchmark]
    public async Task BuildFormUrlEncodedContentDictionaryQuery()
    {
        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        });

        var result = content.ReadAsStringAsync();
        const string urlNew = Url + "?";

        await result;
    }

    [Benchmark]
    public async Task CustomMethodQuery()
    {
        var queryParams = new NameValueCollection
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var urlNew = Url + ToQueryString(queryParams);

        await Task.CompletedTask;
    }
    
    [Benchmark]
    public async Task CustomMethodStaticStringBuilderQuery()
    {
        var queryParams = new NameValueCollection
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var urlNew = Url + StaticStringBuilderString(queryParams);

        await Task.CompletedTask;
    }

    [Benchmark]
    public async Task AspNetCoreQueryBuilderQuery()
    {
        var qb = new QueryBuilder
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var newUrl = Url + qb.ToQueryString();

        await Task.CompletedTask;
    }

    [Benchmark]
    public async Task LinqBuildQuery()
    {
        var qb = new Dictionary<string, string>
        {
            {"drilldowns", "Nation"},
            {"measures", "Population"}
        };

        var newUrl = Url + LinqQuery(qb);

        await Task.CompletedTask;
    }

    private static string LinqQuery(IDictionary<string, string> dict)
    {
        var values = dict.Select(it => $"{it.Key}={Uri.EscapeDataString(it.Value)}");

        return '?' + string.Join("&", values);
    }

    private static string ToQueryString(NameValueCollection nvc)
    {
        var sb = new StringBuilder("?");

        var first = true;

        foreach (var key in nvc.AllKeys)
        foreach (var value in nvc.GetValues(key))
        {
            if (!first) sb.Append('&');

            sb.Append($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}");

            first = false;
        }

        return sb.ToString();
    }
    
    private static string StaticStringBuilderString(NameValueCollection nvc)
    {

        var first = true;

        foreach (var key in nvc.AllKeys)
        foreach (var value in nvc.GetValues(key))
        {
            if (!first) StringBuilder.Append('&');

            StringBuilder.Append($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}");

            first = false;
        }

        var result = StringBuilder.ToString();
        StringBuilder.Clear();

        return result;
    }
}