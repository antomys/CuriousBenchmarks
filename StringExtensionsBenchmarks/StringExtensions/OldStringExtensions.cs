using System.Text.RegularExpressions;

namespace StringExtensionsBenchmarks.StringExtensions;

public static class OldStringExtensions
{
    private static readonly Dictionary<RegexEnum, Regex> SlugRegexes = new()
    {
        { RegexEnum.InvalidCharsRegex, new Regex(@"[^a-zA-Z0-9\s-]", RegexOptions.Compiled) },
        { RegexEnum.MultilineRegex, new Regex(@"\s+", RegexOptions.Compiled) },
        { RegexEnum.HyphenRegex, new Regex(@"\s", RegexOptions.Compiled) },
    };

    private enum RegexEnum
    {
        InvalidCharsRegex,
        MultilineRegex,
        HyphenRegex,
    }

    public static string ToLinkFormat(params string[] inputValues) =>
        GenerateSlug(string.Join(Constants.Space, inputValues));

    public static string ToLinkFormat(this IEnumerable<string> inputCollection, params string[] inputParams)
        => GenerateSlug(string.Join(Constants.Space, inputCollection.Concat(inputParams)));

    public static string ToDashedView(this IEnumerable<string> stringCollection) =>
        string.Join(Constants.Space, stringCollection);

    public static string ToDashedView(params string[] inputValues)
        => string.Join(Constants.Space, inputValues);

    /// <summary>
    /// Counts occurence of char in string. Probably, fastest way to do this.
    /// </summary>
    /// <param name="rawString">string, where to seek</param>
    /// <param name="function">function, char that should be seeked in string</param>
    /// <returns>number of occurrences in string</returns>
    /// <exception cref="ArgumentNullException">if input string is null</exception>
    public static bool Contains(this string rawString, Func<char, bool> function)
    {
        if (rawString == null)
        {
            throw new ArgumentNullException(nameof(rawString));
        }

        var length = rawString.Length;

        for (var index = length - 1; index >= 0; index--)
        {
            if (function(rawString[index]))
            {
                return true;
            }
        }

        return false;
    }

    private static string GenerateSlug(this string phrase)
    {
        phrase = SlugRegexes[RegexEnum.InvalidCharsRegex].Replace(phrase, string.Empty);
        phrase = SlugRegexes[RegexEnum.MultilineRegex].Replace(phrase, Constants.Space.ToString()).Trim();
        phrase = SlugRegexes[RegexEnum.HyphenRegex].Replace(phrase, Constants.DashedViewDelimiter);

        return phrase;
    }
}
