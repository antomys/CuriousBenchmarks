using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Query.Benchmarks.Services.Uri;

namespace Query.Benchmarks.Benchmarks;

/// <summary>
///     Url combination benchmarks.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter]
public class UriCombineBenchmarks
{
    private static readonly Uri DefaultUri = new("https://localhost");
    private const string AdditionalPiece = "/api/data";
    
    private static readonly string AbsoluteUriString = DefaultUri.AbsoluteUri;

    /// <summary>
    ///     <see cref="UriCombineService.NewUri"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.UriUrl), Benchmark(Baseline = true)]
    public Uri NewUri()
    {
        return UriCombineService.NewUri(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="UriCombineService.UriSpan"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.UriUrl), Benchmark]
    public Uri UriSpan()
    {
        return UriCombineService.UriSpan(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="UriCombineService.UriCombine"/>. 
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.UriUrl), Benchmark]
    public Uri UriCombine()
    {
        return UriCombineService.UriCombine(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="UriCombineService.UriAppend"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.UriUrl), Benchmark]
    public Uri UriAppend()
    {
        return UriCombineService.UriAppend(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="UriCombineService.UriFastAppend"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.UriUrl), Benchmark]
    public Uri UriFastAppend()
    {
        return UriCombineService.UriFastAppend(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="UriCombineService.UriBuilderTryCreate"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.UriUrl), Benchmark]
    public Uri UriBuilderTryCreate()
    {
        return UriCombineService.UriBuilderTryCreate(DefaultUri, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="StringUriCombineService.UriSpan"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.StringUrl), Benchmark(Baseline = true)]
    public Uri StringUriSpan()
    {
        return StringUriCombineService.UriSpan(AbsoluteUriString, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="StringUriCombineService.UriAppend"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.StringUrl), Benchmark]
    public Uri StringUriAppend()
    {
        return StringUriCombineService.UriAppend(AbsoluteUriString, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="StringUriCombineService.UriCombine"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.StringUrl), Benchmark]
    public Uri StringUriCombine()
    {
        return StringUriCombineService.UriCombine(AbsoluteUriString, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="StringUriCombineService.UriSwitch"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.StringUrl), Benchmark]
    public Uri StringUriSwitch()
    {
        return StringUriCombineService.UriSwitch(AbsoluteUriString, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="StringUriCombineService.UriCombineCached"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.StringUrl), Benchmark]
    public Uri StringUriCombineCached()
    {
        return StringUriCombineService.UriCombineCached(AbsoluteUriString, AdditionalPiece);
    }
    
    /// <summary>
    ///     <see cref="StringUriCombineService.UriBuilderTryCreate"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="Uri"/>.</returns>
    [BenchmarkCategory(GroupConstants.StringUrl), Benchmark]
    public Uri StringUriBuilderTryCreate()
    {
        return StringUriCombineService.UriBuilderTryCreate(AbsoluteUriString, AdditionalPiece);
    }
}