using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using QueryBenchmarks.Extensions;

namespace QueryBenchmarks.Benchmarks;

/// <summary>
///     Url combination benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class UriCombineBenchmarks
{
    private static readonly Uri DefaultUri = new("https://datausa.io/");
    private const string AdditionalPiece = "/api/data/Something/Else";
    private static readonly string AbsoluteUri = DefaultUri.AbsoluteUri;

    private readonly Consumer _consumer = new();

    /// <summary>
    ///     Creates new uri with relative url.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void NewUri()
    {
        var _ = new Uri(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     Creates new uri with relative url.
    /// </summary>
    [Benchmark]
    public void StringUriWithSpan()
    {
        var result = string.Create(AbsoluteUri.Length + AdditionalPiece.Length,
            (AbsoluteUri, AdditionalPiece),
            (span, tuple) =>
            {
                var (def, add) = tuple;
                var index = 0;
                def.CopyTo(span);
                index += def.Length;

                if (def[^1] is not '/')
                {
                    span[index++] = '/';
                }

                if (add[0] is '/')
                {
                    add[1..].CopyTo(span[index..]);

                    return;
                }

                add.CopyTo(span[index..]);
            });
        
        result.Consume(_consumer);
    }
    
    /// <summary>
    ///     New uri string combine. V1
    /// </summary>
    [Benchmark]
    public void StringUriCombine()
    {
        AbsoluteUri.CombineV1(AdditionalPiece).Consume(_consumer);
    }

    /// <summary>
    ///     Combine v3.
    /// </summary>
    [Benchmark]
    public void StringUriSwitchCase()
    {
        AbsoluteUri.SwitchCaseMethod(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combine v2.
    /// </summary>
    [Benchmark]
    public void NewUriBuilderTryCreate()
    {
        AbsoluteUri.UriBuilderTryCreate(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combine v2 original.
    /// </summary>
    [Benchmark]
    public void StringUriBuilderTryCreate()
    {
        DefaultUri.UriBuilderTryCreate(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Append.
    /// </summary>
    [Benchmark]
    public void NewUriCombineFormatAndNewUri()
    {
        var _ = DefaultUri.Append(AdditionalPiece);
    }
    
    /// <summary>
    ///     Append fast.
    /// </summary>
    [Benchmark]
    public void NewUriCombineFormatAndNoUri()
    {
        DefaultUri.AppendFast(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Append fast with caching.
    /// </summary>
    [Benchmark]
    public void NewUriCombineFormatAndNoUriCached()
    {
        AdditionalPiece.AppendFastCached(AbsoluteUri).Consume(_consumer);
    }
}