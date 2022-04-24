using System.Collections.Specialized;
using System.Text;

namespace QueryBenchmarks.Extensions;

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
        _ = dict.Select(keyValuePair => resultStr +=$"&{keyValuePair.Key}={Uri.EscapeDataString(keyValuePair.Value)}");
        
        return resultStr;
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