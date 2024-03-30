using System.Text.RegularExpressions;

namespace Benchmarks.String.Services;

/// <summary>
///     Old string extensions.
/// </summary>
public static class RegexStringService
{
    private readonly static Dictionary<RegexEnum, Regex> SlugRegexes = new()
    {
        {RegexEnum.InvalidCharsRegex, new Regex(@"[^a-zA-Z0-9\s-]", RegexOptions.Compiled)},
        {RegexEnum.MultilineRegex, new Regex(@"\s+", RegexOptions.Compiled)},
        {RegexEnum.HyphenRegex, new Regex(@"\s", RegexOptions.Compiled)}
    };

    /// <summary>
    ///     Joins all string values with delimiter <see cref="Constants.Space" />.
    /// </summary>
    /// <param name="inputValues">Array of input values.</param>
    /// <returns><see cref="string" />.</returns>
    public static string ToLinkFormat(params string[] inputValues)
    {
        return GenerateSlug(string.Join(Constants.LinkDelimiter, inputValues), Constants.LinkDelimiter);
    }

    /// <summary>
    ///     Joins all string values with delimiter <see cref="Constants.Space" />.
    /// </summary>
    /// <param name="inputCollection">Array of input values.</param>
    /// <param name="inputParams">inputParams</param>
    /// <returns><see cref="string" />.</returns>
    public static string ToLinkFormat(this IEnumerable<string> inputCollection, params string[] inputParams)
    {
        return GenerateSlug(string.Join(Constants.LinkDelimiter, inputCollection.Concat(inputParams)), Constants.LinkDelimiter);
    }

    /// <summary>
    ///     Joins all string values with delimiter <see cref="Constants.Space" />.
    /// </summary>
    /// <param name="stringCollection">collection of strings.</param>
    /// <returns><see cref="string" />.</returns>
    public static string ToDashFormat(this IEnumerable<string> stringCollection)
    {
        return string.Join(Constants.DashedViewDelimiter, stringCollection);
    }

    /// <summary>
    ///     Joins all string values with delimiter <see cref="Constants.Space" />.
    /// </summary>
    /// <param name="inputValues">collection of strings.</param>
    /// <returns><see cref="string" />.</returns>
    public static string ToDashFormat(params string[] inputValues)
    {
        return string.Join(Constants.DashedViewDelimiter, inputValues);
    }

    /// <summary>
    ///     Counts occurence of char in string. Probably, fastest way to do this.
    /// </summary>
    /// <param name="rawString">string, where to seek</param>
    /// <param name="function">function, char that should be seeked in string</param>
    /// <returns>number of occurrences in string</returns>
    /// <exception cref="ArgumentNullException">if input string is null</exception>
    public static bool Contains(this string? rawString, Func<char, bool> function)
    {
        switch (rawString)
        {
            case null:
                throw new ArgumentNullException(nameof(rawString));
            case "":
                return false;
        }

        var length = rawString.Length;

        for (var index = length - 1; index >= 0; index--)
        {
            if (function(rawString[index])) return true;
        }

        return false;
    }

    private static string GenerateSlug(this string phrase, char replace)
    {
        phrase = SlugRegexes[RegexEnum.InvalidCharsRegex].Replace(phrase, string.Empty).Trim();
        phrase = SlugRegexes[RegexEnum.MultilineRegex].Replace(phrase, replace.ToString()).Trim();
        phrase = SlugRegexes[RegexEnum.HyphenRegex].Replace(phrase, replace.ToString()).Trim();

        return phrase;
    }

    private enum RegexEnum
    {
        InvalidCharsRegex,

        MultilineRegex,

        HyphenRegex
    }
}