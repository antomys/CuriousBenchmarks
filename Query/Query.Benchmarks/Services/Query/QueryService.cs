using System.Buffers;
using System.Collections.Specialized;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;

namespace Query.Benchmarks.Services.Query;

/// <summary>
///     Query static service for building query urls.
/// </summary>
public static class QueryService
{
    private const char QuestionMark = '?';
    private const char Ampersand = '&';
    
    private static readonly StringBuilder StringBuilder = new();
    
    /// <summary>
    ///     Constructs query from dictionary using method 'QueryHelpers.AddQueryString'.
    ///     Note: No escaping special chars!
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary">Dictionary of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryDictionary(string url, Dictionary<string, string> queryDictionary)
    {
        return QueryHelpers.AddQueryString(url, queryDictionary);
    }
    
    /// <summary>
    ///     Constructs query from <see cref="NameValueCollection"/> using NameValueCollection and string builder.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="nameValueCollection"><see cref="NameValueCollection"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryNvcStringBuilder(string url, NameValueCollection nameValueCollection)
    {
        var sb = new StringBuilder();
        
        foreach (var key in nameValueCollection.AllKeys)
        {
            sb.Append(sb.Length > 1 ? Ampersand : QuestionMark);
            sb.Append($"{System.Uri.EscapeDataString(key!)}={System.Uri.EscapeDataString(nameValueCollection[key]!)}");
        }
        
        return $"{url}{sb}";
    }
    
    /// <summary>
    ///     Constructs query from <see cref="NameValueCollection"/> using NameValueCollection and STATIC string builder.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="nameValueCollection"><see cref="NameValueCollection"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryNvcStaticStringBuilder(string url, NameValueCollection nameValueCollection)
    {
        foreach (var key in nameValueCollection.AllKeys)
        {
            StringBuilder.Append(StringBuilder.Length > 1 ? Ampersand : QuestionMark);
            StringBuilder.Append($"{System.Uri.EscapeDataString(key!)}={System.Uri.EscapeDataString(nameValueCollection[key]!)}");
        }
        
        var result = StringBuilder.ToString();
        StringBuilder.Clear();
        
        return $"{url}{result}";
    }
    
    /// <summary>
    ///     Constructs query from <see cref="QueryBuilder"/> using QueryBuilder and it's inside 'ToString()'.
    ///     Note: No escaping special chars!
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryBuilder"><see cref="QueryBuilder"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryAspNetCore(string url, QueryBuilder queryBuilder)
    {
        return $"{url}{queryBuilder}";
    }
    
    /// <summary>
    ///     Constructs query from <see cref="QueryBuilder"/> using QueryBuilder and it's inside 'ToString()'.
    ///     Note: No escaping special chars!
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryBuilder"><see cref="QueryCustomBuilder"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryCustomBuilder(string url, QueryCustomBuilder queryBuilder)
    {
        return $"{url}{queryBuilder}";
    }
    
    /// <summary>
    ///     Constructs query from <see cref="QueryBuilder"/> using QueryBuilder and it's inside 'ToString()'.
    ///     Note: No escaping special chars!
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryBuilder"><see cref="QueryCustomBuilder"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryValueStringBuilder(string url, QueryValueStringBuilder queryBuilder)
    {
        return $"{url}{queryBuilder}";
    }
    
    /// <summary>
    ///     Constructs query from dictionary using Linq with escaping.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary">Dictionary of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string LinqSelectJoin(string url, Dictionary<string, string> queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        var values = queryDictionary.Select(keyValuePair => $"{System.Uri.EscapeDataString(keyValuePair.Key)}={System.Uri.EscapeDataString(keyValuePair.Value)}");
        
        return $"{url}{QuestionMark}{string.Join(Ampersand, values)}";
    }
    
    /// <summary>
    ///     Constructs query from dictionary using string concatenation of iteration.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary">Dictionary of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryConcatString(string url, Dictionary<string, string> queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        var resultStr = string.Empty;

        foreach (var (key, value) in queryDictionary)
        {
            resultStr += resultStr.Length < 1 ? QuestionMark.ToString() : Ampersand.ToString();
            resultStr += $"{System.Uri.EscapeDataString(key)}={System.Uri.EscapeDataString(value)}";
        }
        
        return $"{url}{resultStr}";
    }
    
    /// <summary>
    ///     Constructs query from dictionary using string.Create concatenation of iteration.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary">Dictionary of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryStringCreateConcat(string url, Dictionary<string, string> queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        var resultStr = string.Empty;

        var index = 0;
        
        var globalLength = 0;

        foreach (var (key, value) in queryDictionary)
        {
            var escapedKey = System.Uri.EscapeDataString(key);
            var escapedValue = System.Uri.EscapeDataString(value);
            
            globalLength += escapedKey.Length + escapedValue.Length + 2;
            
            resultStr += string.Create(escapedKey.Length + escapedValue.Length + 2, (escapedKey, escapedValue, index), (span, tuple) =>
            {
                var (k, v, innerIndex) = tuple;
                var internalIndex = 0;
                
                span[internalIndex++] = innerIndex is 0 ? QuestionMark : Ampersand;
                
                k.CopyTo(span[internalIndex..]);
                internalIndex += k.Length;
                
                span[internalIndex++] = '=';
                
                v.CopyTo(span[internalIndex..]);
            });
            
            index++;
        }
        
        var endIndex = resultStr.IndexOf('\0');
        
        return endIndex is -1
            ? $"{url}{resultStr[..globalLength]}"
            : $"{url}{resultStr[..(endIndex > globalLength ? endIndex : globalLength)]}";
    }
    
    /// <summary>
    ///     Constructs query from dictionary using stack and filling Span{char}.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary">Dictionary of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryStringCreate(string url, Dictionary<string, string> queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        var queryLength = queryDictionary.Sum(x=> x.Key.Length + x.Value.Length) * 2;

        var isStackAlloc = queryLength <= 64;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(queryLength);
        var resultSpan = isStackAlloc ? stackalloc char[queryLength] : array;

        try
        {
            foreach (var (key, value) in queryDictionary)
            {
                resultSpan[currentPosition] = currentPosition is not 0 ? Ampersand : QuestionMark;
                currentPosition++;
               
                var escapedKey = System.Uri.EscapeDataString(key);
                escapedKey.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedKey.Length;

                resultSpan[currentPosition++] = '=';
                
                var escapedValue = System.Uri.EscapeDataString(value);
                escapedValue.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedValue.Length;
            }

            var endIndex = resultSpan.IndexOf('\0');
            
            return endIndex is -1
                ? $"{url}{resultSpan}"[..currentPosition]
                : $"{url}{resultSpan[..(endIndex > currentPosition ? currentPosition : endIndex)]}";
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<char>.Shared.Return(array);
            }
        }
    }
    
    /// <summary>
    ///     Constructs query from dictionary using stack and filling Span{char}.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary"><see cref="QueryDictionary"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryStringCreateStack(string url, QueryDictionary queryDictionary)
    {
        if (queryDictionary.QueryLength is 0)
        {
            return url;
        }
        
        var queryLength = queryDictionary.Sum(x=> x.Key.Length + x.Value.Length) * 2;

        var isStackAlloc = queryLength <= 64;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(queryLength);
        var resultSpan = isStackAlloc ? stackalloc char[queryLength] : array;

        try
        {
            foreach (var (key, value) in queryDictionary)
            {
                resultSpan[currentPosition] = currentPosition is not 0 ? Ampersand : QuestionMark;
                currentPosition++;
               
                var escapeKey = System.Uri.EscapeDataString(key);
                escapeKey.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapeKey.Length;

                resultSpan[currentPosition++] = '=';
                
                var escapedValue = System.Uri.EscapeDataString(value);
                escapedValue.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedValue.Length;
            }
            
            var endIndex = resultSpan.IndexOf('\0');
            
            return endIndex is -1
                ? $"{url}{resultSpan[..currentPosition]}"
                : $"{url}{resultSpan[..(endIndex > currentPosition ? currentPosition : endIndex)]}";
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<char>.Shared.Return(array);
            }
        }
    }
    
    /// <summary>
    ///     Constructs query from dictionary using stack and filling Span{char}. Version 2
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary"><see cref="QueryDictionary"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string LinqQuerySpanVer2(string url, QueryDictionary queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        var globalLength = url.Length + queryDictionary.QueryLength * 2;

        var isStackAlloc = globalLength <= 64;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(globalLength);
        var resultSpan = isStackAlloc ? stackalloc char[globalLength] : array;

        try
        {
            url.CopyTo(resultSpan[currentPosition..]);
            currentPosition += url.Length;

            foreach (var (key, value) in queryDictionary)
            {
                resultSpan[currentPosition] = currentPosition != url.Length ? Ampersand : QuestionMark;
                currentPosition++;
               
                var escapedKey = System.Uri.EscapeDataString(key);
                escapedKey.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedKey.Length;

                resultSpan[currentPosition++] = '=';
                
                var escapedValue = System.Uri.EscapeDataString(value);
                escapedValue.CopyTo(resultSpan[currentPosition..]);
                
                currentPosition += escapedValue.Length;
            }

            var endIndex = resultSpan.IndexOf('\0');

            return endIndex is -1
                ? resultSpan[..currentPosition].ToString()
                : resultSpan[..(endIndex > currentPosition ? currentPosition : endIndex)].ToString();
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<char>.Shared.Return(array);
            }
        }
    }
    
    /// <summary>
    ///     Constructs query from dictionary using linq aggregation.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary"><see cref="QueryDictionary"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string LinqQueryAggregate(string url, Dictionary<string, string> queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        var query = queryDictionary.Aggregate("?",
            (current, keyValuePair) => current.Length > 1
                ? current + $"&{System.Uri.EscapeDataString(keyValuePair.Key)}={System.Uri.EscapeDataString(keyValuePair.Value)}"
                : current + $"{System.Uri.EscapeDataString(keyValuePair.Key)}={System.Uri.EscapeDataString(keyValuePair.Value)}");

        return $"{url}{query}";
    }
    
    /// <summary>
    ///     Constructs query from dictionary using <see cref="FormUrlEncodedContent"/>.
    /// </summary>
    /// <param name="url">Input string url.</param>
    /// <param name="queryDictionary"><see cref="QueryDictionary"/> of queries.</param>
    /// <returns>Constructed query string</returns>
    public static string QueryFormUrlEncodedContent(string url, Dictionary<string, string> queryDictionary)
    {
        if (queryDictionary.Count is 0)
        {
            return url;
        }
        
        using var content = new FormUrlEncodedContent(queryDictionary);

        var result = content.ReadAsStringAsync();

        return $"{url}?{result.Result}";
    }
}