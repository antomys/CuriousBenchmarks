namespace Benchmarks.QueryBuilder.Services.Uri;

/// <summary>
///     Service for combining Uri with relative paths.
/// </summary>
public static class UriCombineService
{
    private const char UriDelimiter = '/';

    /// <summary>
    ///     Creates concatenated uri by using 'new Uri()' method.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri" />.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri" />.</returns>
    public static System.Uri NewUri(System.Uri absoluteUri, string relativePath)
    {
        return new System.Uri(absoluteUri, relativePath);
    }

    /// <summary>
    ///     Creates concatenated uri by using span and 'string.Create' method.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri" />.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri" />.</returns>
    public static System.Uri UriSpan(System.Uri absoluteUri, string relativePath)
    {
        if (string.IsNullOrEmpty(relativePath)) throw new UriFormatException(nameof(relativePath));

        var resultString = string.Create(absoluteUri.AbsoluteUri.Length + relativePath.Length,
            (absoluteUri.AbsoluteUri, relativePath),
            (span, tuple) =>
            {
                var (uri, path) = tuple;
                var index = 0;

                uri.CopyTo(span);
                index += uri.Length;

                if (uri[^1] is not UriDelimiter) span[index++] = UriDelimiter;

                if (path[0] is not UriDelimiter)
                {
                    path.CopyTo(span[index..]);

                    return;
                }

                if (path[1] is UriDelimiter) throw new UriFormatException(nameof(relativePath));

                path[1..].CopyTo(span[index..]);
            });

        var endIndex = resultString.IndexOf('\0');

        if (endIndex is not -1) resultString = resultString[..endIndex];
        return new System.Uri(resultString);
    }

    /// <summary>
    ///     Creates concatenated uri by trimming strings and interpolation.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri" />.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri" />.</returns>
    public static System.Uri UriCombine(System.Uri absoluteUri, string relativePath)
    {
        var uri1String = absoluteUri.AbsoluteUri.TrimEnd(UriDelimiter);
        relativePath = relativePath.TrimStart(UriDelimiter);

        return new System.Uri($"{uri1String}/{relativePath}");
    }

    /// <summary>
    ///     Creates concatenated uri by trimming, caching and interpolating.
    /// </summary>
    /// <param name="absoluteUri">Base <see cref="Uri" />.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri" />.</returns>
    public static System.Uri UriFastAppend(System.Uri absoluteUri, string relativePath)
    {
        if (string.IsNullOrEmpty(relativePath)) throw new UriFormatException(nameof(relativePath));

        //avoid the use of Uri as it's not needed, and adds a bit of overhead.
        var uri = absoluteUri.AbsoluteUri; //a calculated property, better cache it
        var baseUri = uri.EndsWith(UriDelimiter) ? uri : uri + UriDelimiter;

        var relative = relativePath.StartsWith(UriDelimiter)
            ? relativePath[1] is not UriDelimiter
                ? relativePath[1..]
                : throw new UriFormatException(nameof(relativePath))
            : relativePath;

        return new System.Uri(baseUri + relative);
    }

    /// <summary>
    ///     Creates concatenated uri by concatenating two uri's.
    /// </summary>
    /// <param name="uri">Base <see cref="Uri" />.</param>
    /// <param name="relativePath">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri" />.</returns>
    public static System.Uri UriAppend(System.Uri uri, string relativePath)
    {
        var isEndsWithDelimiter = uri.AbsoluteUri[^1] is UriDelimiter;

        if (string.IsNullOrEmpty(relativePath)) return uri;

        if (isEndsWithDelimiter)
            relativePath = relativePath[0] is UriDelimiter ? relativePath[1..] : relativePath;
        else
            relativePath = $"/{relativePath}";

        return new System.Uri(uri, relativePath);
    }

    /// <summary>
    ///     Creates concatenated uri by using method 'Uri.TryCreate()'.
    /// </summary>
    /// <param name="baseUrl">Base <see cref="Uri" />.</param>
    /// <param name="relativeUrl">Additional relative path.</param>
    /// <returns>Constructed and concatenated new <see cref="Uri" />.</returns>
    public static System.Uri UriBuilderTryCreate(System.Uri baseUrl, string relativeUrl)
    {
        return System.Uri.TryCreate(baseUrl, relativeUrl, out var newUri)
            ? newUri
            : throw new UriFormatException("Unable to combine specified url values");
    }
}