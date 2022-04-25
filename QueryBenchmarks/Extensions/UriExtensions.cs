namespace QueryBenchmarks.Extensions;

/// <summary>
///     Url combination extensions.
/// </summary>
public static class UriExtensions
{
    private const char PathDelimiter = '/';
    
    /// <summary>
    ///     Combination by concatenation.
    /// </summary>
    /// <param name="uri1">First url</param>
    /// <param name="uri2">Second url.</param>
    /// <returns>string.</returns>
    public static string CombineV1(this string uri1, string uri2)
    {
        uri1 = uri1.TrimEnd('/');
        uri2 = uri2.TrimStart('/');
        
        return $"{uri1}/{uri2}";
    }
    
    /// <summary>
    ///     Second version. Uses Uri.TryCreate
    /// </summary>
    /// <param name="baseUrl">Base Url</param>
    /// <param name="relativeUrl">Relative url.</param>
    /// <returns>string.</returns>
    /// <exception cref="ArgumentException">If Unable to combine specified url values.</exception>
    public static string UriBuilderTryCreate(this string baseUrl, string relativeUrl) 
    { 
        var baseUri = new UriBuilder(baseUrl);

        if (Uri.TryCreate(baseUri.Uri, relativeUrl, out var newUri))
        {
            return newUri.ToString();
        }
        
        throw new ArgumentException("Unable to combine specified url values");
    }
    
    /// <summary>
    ///     Second version. Uses Uri.TryCreate
    /// </summary>
    /// <param name="baseUrl">Base Url</param>
    /// <param name="relativeUrl">Relative url.</param>
    /// <returns>string.</returns>
    /// <exception cref="ArgumentException">If Unable to combine specified url values.</exception>
    public static string UriBuilderTryCreate(this Uri baseUrl, string relativeUrl) 
    { 
        var baseUri = new UriBuilder(baseUrl);

        if (Uri.TryCreate(baseUri.Uri, relativeUrl, out var newUri))
        {
            return newUri.ToString();
        }
        
        throw new ArgumentException("Unable to combine specified url values");
    }

    /// <summary>
    ///     V3.
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="relativePath"></param>
    /// <returns></returns>
    public static Uri Append(this Uri uri, string relativePath)
    {
        var baseUri = uri.AbsoluteUri.EndsWith('/') ? uri : new Uri(uri.AbsoluteUri + '/');
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return new Uri(baseUri, relative);
    }

    /// <summary>
    ///     V4.1 with caching.
    /// </summary>
    /// <param name="relativePath"></param>
    /// <param name="absoluteUri"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string AppendFastCached(this string relativePath, string absoluteUri)
    {
        //avoid the use of Uri as it's not needed, and adds a bit of overhead.
        if (absoluteUri is null)
        {
            throw new ArgumentNullException(absoluteUri);
        }
        var baseUri = absoluteUri.EndsWith('/') ? absoluteUri : absoluteUri + '/';
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return baseUri + relative;
    }
    
    /// <summary>
    ///     V4. Fast.
    /// </summary>
    /// <param name="uri"></param>
    /// <param name="relativePath"></param>
    /// <returns></returns>
    public static string AppendFast(this Uri uri, string relativePath)
    {
        //avoid the use of Uri as it's not needed, and adds a bit of overhead.
        var absoluteUri = uri.AbsoluteUri; //a calculated property, better cache it
        var baseUri = absoluteUri.EndsWith('/') ? absoluteUri : absoluteUri + '/';
        var relative = relativePath.StartsWith('/') ? relativePath[1..] : relativePath;
        
        return baseUri + relative;
    }

    /// <summary>
    ///     Combines.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="relative"></param>
    /// <returns></returns>
    public static string SwitchCaseMethod(this string path, string relative) 
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