using System.Text.RegularExpressions;

namespace StringExtensionsBenchmarks.StringExtensions;

public static class OldStringExtensions
{
    private const string DashDelimiter = "-";
    private const string WhiteSpaceDelimiter = " ";

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
        GenerateSlug(string.Join(WhiteSpaceDelimiter, inputValues));

    public static string ToLinkFormat(this IEnumerable<string> inputCollection, params string[] inputParams)
        => GenerateSlug(string.Join(WhiteSpaceDelimiter, inputCollection.Concat(inputParams)));
    
    private static string GenerateSlug(this string phrase)
    {
        if (string.IsNullOrWhiteSpace(phrase))
        {
            throw new ArgumentNullException(nameof(phrase));
        }

        phrase = SlugRegexes[RegexEnum.InvalidCharsRegex].Replace(phrase, string.Empty);
        phrase = SlugRegexes[RegexEnum.MultilineRegex].Replace(phrase, WhiteSpaceDelimiter).Trim();
        phrase = SlugRegexes[RegexEnum.HyphenRegex].Replace(phrase, DashDelimiter);

        return phrase;
    }
}