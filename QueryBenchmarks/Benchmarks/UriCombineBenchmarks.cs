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
    private readonly Uri _defaultUri = new("https://datausa.io/");
    private const string AdditionalPiece = "/api/data/Something/Else";
    private static string? _absoluteUri;

    private readonly Consumer _consumer = new();
    
    /// <summary>
    ///     Global setup of private methods.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _absoluteUri = _defaultUri.AbsoluteUri;
    }
    
    /// <summary>
    ///     Creates new uri with relative url.
    /// </summary>
    [Benchmark]
    public void NewUri()
    {
        var _ = new Uri(_defaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     New uri string combine. V1
    /// </summary>
    [Benchmark]
    public void NewUriStringCombine()
    {
       _defaultUri.ToString().CombineV1(AdditionalPiece).Consume(_consumer);
    }

    /// <summary>
    ///     Combine v3.
    /// </summary>
    [Benchmark]
    public void NewUriOfficeDevPnP()
    {
        _defaultUri.ToString().CombineV3(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combine v2.
    /// </summary>
    [Benchmark]
    public void NewUriCombineUriBuilderToString()
    {
        _defaultUri.ToString().CombineV2(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Combine v2 original.
    /// </summary>
    [Benchmark]
    public void NewUriCombineUriBuilder()
    {
        _defaultUri.CombineV2(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Append.
    /// </summary>
    [Benchmark]
    public void NewUriCombineFormatAndNewUri()
    {
        var _ = _defaultUri.Append(AdditionalPiece);
    }
    
    /// <summary>
    ///     Append fast.
    /// </summary>
    [Benchmark]
    public void NewUriCombineFormatAndNoUri()
    {
        _defaultUri.AppendFast(AdditionalPiece).Consume(_consumer);
    }
    
    /// <summary>
    ///     Append fast with caching.
    /// </summary>
    [Benchmark]
    public void NewUriCombineFormatAndNoUriCached()
    {
        AdditionalPiece.AppendFastCached(_absoluteUri!).Consume(_consumer);
    }
}