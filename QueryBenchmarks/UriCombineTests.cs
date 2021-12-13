using BenchmarkDotNet.Attributes;

namespace QueryBenchmarks;

[MemoryDiagnoser]
public class UriCombineTests
{
    private readonly Uri _defaultUri = new("https://datausa.io/");
    private const string AdditionalPiece = "/api/data/Something/Else";
    private const char PathDelimiter = '/';
    
    [Benchmark]
    public void NewUri()
    {
        var newUri = new Uri(_defaultUri, AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriStringCombine()
    {
        var newUri = Combine(_defaultUri.ToString(), AdditionalPiece);
    }

    [Benchmark]
    public void NewUriOfficeDevPnP()
    {
        var newUri = CombineV2(_defaultUri.ToString(), AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriCombineUriBuilderToString()
    {
        var newUri = CombineUrl(_defaultUri.ToString(), AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriCombineUriBuilder()
    {
        var newUri = CombineUrl(_defaultUri, AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriCombineFormatAndNewUri()
    {
        var newUri = Append(_defaultUri, AdditionalPiece);
    }
    
    [Benchmark]
    public void NewUriCombineFormatAndNoUri()
    {
        var newUri = AppendFast(_defaultUri, AdditionalPiece);
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

    private static string AppendFast(Uri uri, string relativePath)
    {
        //avoid the use of Uri as it's not needed, and adds a bit of overhead.
        var absoluteUri = uri.AbsoluteUri; //a calculated property, better cache it
        var baseUri = absoluteUri.EndsWith('/') ? absoluteUri : absoluteUri + '/';
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return baseUri + relative;
    }
    
    public static string CombineV2(string path, string relative) 
    {
        
        relative ??= string.Empty;

        path ??= string.Empty;

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