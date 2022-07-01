using System.Buffers;
using System.Collections.Specialized;
using System.Text;

namespace Query.Benchmarks.Extensions;

/// <summary>
///     Query string extensions.
/// </summary>
public static class QueryExtensions
{
    /// <summary>
    ///     Creates query using linq and interpolation.
    /// </summary>
    /// <param name="dict">Input dictionary.</param>
    /// <returns>string.</returns>
    public static string LinqQuery(this Dictionary<string, string> dict)
    {
        var values = dict.Select(keyValuePair => $"{keyValuePair.Key}={Uri.EscapeDataString(keyValuePair.Value)}");

        return '?' + string.Join("&", values);
    }
    
    /// <summary>
    ///     Creates query using linq and interpolation.
    /// </summary>
    /// <param name="dict">Input dictionary.</param>
    /// <returns>string.</returns>
    public static string LinqQueryV2(this Dictionary<string, string> dict)
    {
        var resultStr = "?";
        
        foreach (var (key, value) in dict)
        {
            resultStr += $"&{key}={Uri.EscapeDataString(value)}";
        }

        return resultStr;
    }
    
    /// <summary>
    ///     Creates query using linq and interpolation.
    /// </summary>
    /// <param name="dict">Input dictionary.</param>
    /// <returns>string.</returns>
    public static string LinqQueryV2ModV1(this Dictionary<string, string> dict)
    {
        var resultStr = string.Empty;

        var index = 0;
        
        foreach (var kvp in dict)
        {
            resultStr += string.Create(kvp.Key.Length + kvp.Value.Length + 2, (kvp, index), (span, tuple) =>
            {
                var (innerKvp, innerIndex) = tuple;
                var internalIndex = 0;
                
                span[internalIndex++] = innerIndex is 0 ? '?' : '&';

                innerKvp.Key.CopyTo(span[internalIndex..]);
                internalIndex += innerKvp.Key.Length;
                
                span[internalIndex++] = '=';
                
                Uri.EscapeDataString(innerKvp.Value).CopyTo(span[internalIndex..]);
            });

            index++;
        }
        
        return resultStr;
    }
    
    /// <summary>
    ///     Creates query using linq and interpolation.
    /// </summary>
    /// <param name="dict">Input dictionary.</param>
    /// <returns>string.</returns>
    public static string LinqQueryV2ModV2(this Dictionary<string, string> dict)
    {
        var overallLength = dict.Sum(x=> x.Key.Length + x.Value.Length) + dict.Count * 2;
        
        var isStackAlloc = overallLength <= 64;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(overallLength);
        var resultSpan = isStackAlloc ? stackalloc char[overallLength] : array;

        try
        {
            foreach (var (key, value) in dict)
            {
                resultSpan[currentPosition] = currentPosition is not 0 ? '&' : '?';
                currentPosition++;
               
                key.CopyTo(resultSpan[currentPosition..]);
                currentPosition += key.Length;

                resultSpan[currentPosition++] = '=';
                
                var escapedValue = Uri.EscapeDataString(value);
                escapedValue.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedValue.Length;
            }

            return resultSpan.ToString();
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
    ///     Creates query using linq and interpolation.
    /// </summary>
    /// <param name="dict">Input dictionary.</param>
    /// <returns>string.</returns>
    public static string LinqQueryV2ModV3(this QueryBuilderV1 dict)
    {
        var overallLength = dict.GetOverallLength() + dict.Count * 2;
        
        var isStackAlloc = overallLength <= 64;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(overallLength);
        var resultSpan = isStackAlloc ? stackalloc char[overallLength] : array;

        try
        {
            foreach (var (key, value) in dict)
            {
                resultSpan[currentPosition] = currentPosition is not 0 ? '&' : '?';
                currentPosition++;
               
                key.CopyTo(resultSpan[currentPosition..]);
                currentPosition += key.Length;

                resultSpan[currentPosition++] = '=';
                
                var escapedValue = Uri.EscapeDataString(value);
                escapedValue.CopyTo(resultSpan[currentPosition..]);
                currentPosition += escapedValue.Length;
            }

            return isStackAlloc
                ? resultSpan.ToString()
                : resultSpan[..resultSpan.IndexOf('\0')].ToString();
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
    ///     Creates query using linq and interpolation.
    /// </summary>
    /// <param name="dict">Input dictionary.</param>
    /// <returns>string.</returns>
    public static string LinqQueryV3(this Dictionary<string, string> dict)
    {
        return dict.Aggregate("?", (current, keyValuePair) => current + $"&{keyValuePair.Key}={Uri.EscapeDataString(keyValuePair.Value)}");
    }

    /// <summary>
    ///     Creates query using StringBuilder.
    /// </summary>
    /// <param name="nvc"></param>
    /// <returns></returns>
    public static string ToQueryString(this NameValueCollection nvc)
    {
        var sb = new StringBuilder("?");

        var first = true;

        foreach (var key in nvc.AllKeys) 
        foreach (var value in nvc.GetValues(key)!)
        {
            if (!first) sb.Append('&');

            sb.Append($"{Uri.EscapeDataString(key!)}={Uri.EscapeDataString(value)}");

            first = false;
        }

        return sb.ToString();
    }
}