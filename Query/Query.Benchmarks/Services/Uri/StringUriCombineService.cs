namespace Query.Benchmarks.Services.Uri;

/// <summary>
///     Service for combining Uri with relative paths using theirs string interpretations.
/// </summary>
public static class StringUriCombineService
{
    private const char UriDelimiter = '/';
    
    /// <summary>
    ///     Creates concatenated uri by using span and 'string.Create' method.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri"/>.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri"/>.</returns>
    public static System.Uri UriSpan(string absoluteUri, string relativePath)
    {
        var resultString = string.Create(absoluteUri.Length + relativePath.Length,
            (absoluteUri, relativePath),
            (span, tuple) =>
            {
                var (uri, path) = tuple;
                var index = 0;
                
                uri.CopyTo(span);
                index += uri.Length;

                if (uri[^1] is not UriDelimiter)
                {
                    span[index++] = UriDelimiter;
                }

                if (path[0] is not UriDelimiter)
                {
                    path.CopyTo(span[index..]);
                    
                    return;
                }

                if (path[1] is UriDelimiter)
                {
                    throw new UriFormatException(nameof(relativePath));
                }
                    
                path[1..].CopyTo(span[index..]);
            });

        var endIndex = resultString.IndexOf('\0');
                
        if (endIndex is not -1)
        {
            resultString = resultString[..endIndex];
        }
        return new System.Uri(resultString);
    }
    
    /// <summary>
    ///     Creates concatenated uri by interpolation of two relative strings.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri"/>.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri"/>.</returns>
    public static System.Uri UriCombine(string absoluteUri, string relativePath)
    {
        absoluteUri = absoluteUri.TrimEnd(UriDelimiter);
        relativePath = relativePath.TrimStart(UriDelimiter);
        
        return new System.Uri($"{absoluteUri}/{relativePath}");
    }
    
    /// <summary>
    ///     Creates concatenated uri by switch case and regex.
    /// </summary>
    /// <param name="path">Base <see cref="Uri"/>.</param>
    /// <param name="relative">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri"/>.</returns>
    public static System.Uri UriSwitch(string path, string relative)
    {
        switch (relative.Length)
        {
            case 0 when path.Length is 0:
                throw new UriFormatException();
            case 0:
                return new System.Uri(path);
        }

        if(path.Length is 0)
        {
            throw new UriFormatException();
        }

        path = path.Replace('\\', UriDelimiter);
        relative = relative.Replace('\\', UriDelimiter);

        return new System.Uri($"{path.TrimEnd(UriDelimiter)}{UriDelimiter}{relative.TrimStart(UriDelimiter)}");
    }
    
    /// <summary>
    ///     Creates concatenated uri by using <see cref="UriBuilder"/>.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri"/>.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri"/>.</returns>
    public static System.Uri UriBuilderTryCreate(string absoluteUri, string relativePath)
    {
        var baseUri = new UriBuilder(absoluteUri);

        if (!System.Uri.TryCreate(baseUri.Uri, relativePath, out var newUri))
        {
            throw new UriFormatException("Unable to combine specified url values");
        }
        
        return newUri;
    }
    
    /// <summary>
    ///     Creates concatenated uri by using combination with caching.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri"/>.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri"/>.</returns>
    public static System.Uri UriCombineCached(string absoluteUri, string relativePath)
    {
        // Avoid the use of Uri as it's not needed, and adds a bit of overhead.
        if (string.IsNullOrEmpty(absoluteUri))
        {
            throw new ArgumentNullException(absoluteUri);
        }
        
        var baseUri = absoluteUri.EndsWith(UriDelimiter) ? absoluteUri : absoluteUri + UriDelimiter;
        var relative = relativePath.StartsWith(UriDelimiter)
            ? relativePath[1] is not UriDelimiter 
                ? relativePath[1..] 
                : throw new UriFormatException(nameof(relativePath))
            : relativePath;
        
        return new System.Uri(baseUri + relative);
    }
    
    /// <summary>
    ///     Creates concatenated uri by using interpolation.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri"/>.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri"/>.</returns>
    public static System.Uri UriAppend(string absoluteUri, string relativePath)
    {
        if (string.IsNullOrEmpty(absoluteUri))
        {
            throw new ArgumentNullException(nameof(absoluteUri));
        }

        var isEndsWithDelimiter = absoluteUri[^1] is UriDelimiter;
        
        relativePath = !isEndsWithDelimiter
            ? $"/{relativePath}"
            : relativePath[0] is UriDelimiter 
                ? relativePath[1] is not UriDelimiter 
                    ? relativePath[1..] 
                    : throw new UriFormatException(nameof(absoluteUri)) 
                : relativePath;

        return new System.Uri($"{absoluteUri}{relativePath}");
    }
}