using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;

namespace QueryBenchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class UriCombineBenchmarks
{
    private readonly Uri _defaultUri = new("https://datausa.io/");
    private const string AdditionalPiece = "/api/data/Something/Else";
    private static string? _absoluteUri;
    private const char PathDelimiter = '/';

    private readonly Consumer _consumer = new();

    public UriCombineBenchmarks()
    {
        _absoluteUri = _defaultUri.AbsoluteUri;
    }
    
    [Benchmark]
    public void NewUri()
    {
        var _ = new Uri(_defaultUri, AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriStringCombine()
    {
        Combine(_defaultUri.ToString(), AdditionalPiece).Consume(_consumer);
    }

    [Benchmark]
    public void NewUriOfficeDevPnP()
    {
        CombineV2(_defaultUri.ToString(), AdditionalPiece).Consume(_consumer);
    }
    
    [Benchmark]
    public void NewUriCombineUriBuilderToString()
    {
        CombineUrl(_defaultUri.ToString(), AdditionalPiece).Consume(_consumer);
    }
    
    [Benchmark]
    public void NewUriCombineUriBuilder()
    {
        CombineUrl(_defaultUri, AdditionalPiece).Consume(_consumer);
    }
    
    [Benchmark]
    public void NewUriCombineFormatAndNewUri()
    {
        var _ = Append(_defaultUri, AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriCombineFormatAndNoUri()
    {
        AppendFast(_defaultUri, AdditionalPiece).Consume(_consumer);
    }
    
    [Benchmark]
    public void NewUriCombineFormatAndNoUriCached()
    {
        AppendFastCached(AdditionalPiece).Consume(_consumer);
    }

    private static string Combine(string uri1, string uri2)
    {
        uri1 = uri1.TrimEnd('/');
        uri2 = uri2.TrimStart('/');
        
        return $"{uri1}/{uri2}";
    }
    
    private string CombineUrl(string baseUrl, string relativeUrl) 
    { 
        var baseUri = new UriBuilder(baseUrl);

        if (Uri.TryCreate(baseUri.Uri, relativeUrl, out var newUri))
        {
            return newUri.ToString();
        }
        
        throw new ArgumentException("Unable to combine specified url values");
    }
    
    private string CombineUrl(Uri baseUrl, string relativeUrl) 
    { 
        var baseUri = new UriBuilder(baseUrl);

        if (Uri.TryCreate(baseUri.Uri, relativeUrl, out var newUri))
        {
            return newUri.ToString();
        }
        
        throw new ArgumentException("Unable to combine specified url values");
    }

    private static Uri Append(Uri uri, string relativePath)
    {
        var baseUri = uri.AbsoluteUri.EndsWith('/') ? uri : new Uri(uri.AbsoluteUri + '/');
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return new Uri(baseUri, relative);
    }

    private static string AppendFastCached(string relativePath)
    {
        //avoid the use of Uri as it's not needed, and adds a bit of overhead.
        if (_absoluteUri is null)
        {
            throw new ArgumentNullException(_absoluteUri);
        }
        var baseUri = _absoluteUri.EndsWith('/') ? _absoluteUri : _absoluteUri + '/';
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return baseUri + relative;
    }
    
    private static string AppendFast(Uri uri, string relativePath)
    {
        //avoid the use of Uri as it's not needed, and adds a bit of overhead.
        var absoluteUri = uri.AbsoluteUri; //a calculated property, better cache it
        var baseUri = absoluteUri.EndsWith('/') ? absoluteUri : absoluteUri + '/';
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return baseUri + relative;
    }

    private static string CombineV2(string path, string relative) 
    {
        switch (relative.Length)
        {
            case 0 when path.Length == 0:
                return string.Empty;
            case 0:
                return path;
        }

        if(path.Length == 0)
            return relative;

        path = path.Replace('\\', PathDelimiter);
        relative = relative.Replace('\\', PathDelimiter);

        return path.TrimEnd(PathDelimiter) + PathDelimiter + relative.TrimStart(PathDelimiter);
    }
}