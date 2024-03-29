using System.Buffers;
using System.Globalization;

namespace Benchmarks.String.Services;

/// <summary>
///     Additional extensions to manipulate with strings.
/// </summary>
public static class ArrayPoolStringService
{
    /// <summary>
    ///     Maximal amount of bytes for using stackalloc. If not, then using ArrayPool.
    /// </summary>
    private const ushort MaxByteSize = 63;

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
            if (function(rawString[index]))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Creates a new string from input params strings with <see cref="Constants.DashedViewDelimiter"/> between. <br/>
    ///     Uses inside string.Join. Slightly slower that ToDashFormatV2 but still relevant.
    /// </summary>
    /// <param name="inputValues">Input string parameters.</param>
    /// <returns>New created <see cref="string"/> formatted with <see cref="Constants.DashedViewDelimiter"/>.</returns>
    public static string ToDashFormat(this string[] inputValues)
        => string.Join(Constants.DashedViewDelimiter, inputValues);

    /// <summary>
    ///     Creates a new string from input string with <see cref="Constants.DashedViewDelimiter"/> between. <br/>
    ///     Inside uses method string.Create with a callback to create a new string (slightly faster than ToDashFormatV2 method).
    /// </summary>
    /// <param name="input1">First <see cref="string"/> value</param>
    /// <param name="input2">Second <see cref="string"/> value</param>
    /// <returns>
    /// <c>string.Empty</c> if either input1 or input2 is missing <br/>
    /// New created <see cref="string"/> New formatted string.
    /// </returns>
    public static string ToDashFormat(this string input1, string input2) =>
        string.Create(input1.Length + input2.Length + Constants.DashedViewDelimiter.Length, (value0: input1, input2), (span, valueTuple) =>
        {
            var index = 0;
            var (val0, val1) = valueTuple;

            val0.CopyTo(span);
            index += val0.Length;

            Constants.DashedViewDelimiter.CopyTo(span[index..]);
            index += Constants.DashedViewDelimiter.Length;

            val1.CopyTo(span[index..]);
        });

    /// <summary>
    ///     Creates slug from input parameters.
    ///     Lowers string and places <see cref="Constants.LinkDelimiter"/> between.
    /// </summary>
    /// <param name="input1">First input string. Cannot be null.</param>
    /// <param name="input2">Second input string. Can be null.</param>
    /// <param name="input3">Third input string. Can be null.</param>
    /// <returns>Formatted (slugify) string using <see cref="Constants.LinkDelimiter"/>.</returns>
    public static string ToLinkFormat(this string input1, string? input2 = default, string? input3 = default)
    {
        if (!string.IsNullOrEmpty(input2) && !string.IsNullOrEmpty(input3))
        {
            return InternalToLinkFormat(input1, input2, input3);
        }

        return !string.IsNullOrEmpty(input2) ? InternalToLinkFormat(input1, input2) : InternalToLinkFormat(input1);
    }

    /// <summary>
    ///     Creates slug from array of input strings.
    ///     Lowers string and places <see cref="Constants.LinkDelimiter"/> between.
    /// </summary>
    /// <param name="inputStrings">Array of input string variables.</param>
    /// <returns>New Formatter slug <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">
    ///     If array of input strings is empty.
    /// </exception>
    public static string ToLinkFormat(string[] inputStrings)
    {
        if (inputStrings.Length is 0)
        {
            throw new ArgumentNullException(nameof(inputStrings));
        }

        var overallLength = GetLength(inputStrings, 1);
        var isStackAlloc = overallLength <= MaxByteSize;
        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(overallLength);
        var resultSpan = isStackAlloc ? stackalloc char[overallLength] : array;

        try
        {
            for (var i = 0; i < inputStrings.Length - 1; i++)
            {
                BuildPart(inputStrings[i], resultSpan, ref currentPosition, Constants.LinkDelimiter);
            }

            BuildPart(inputStrings[^1], resultSpan, ref currentPosition);

            RemoveSpaces(resultSpan, ref currentPosition);

            var endIndex = resultSpan.IndexOf('\0');
            
            return endIndex is -1
                ? resultSpan[..overallLength].ToString() 
                : resultSpan[..(endIndex < overallLength ? endIndex : overallLength)].ToString();
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<char>.Shared.Return(array);
            }
        }
    }

    private static string InternalToLinkFormat(string input1)
    {
        var overallLength = input1.Length;
        var isStackAlloc = overallLength <= MaxByteSize;

        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(overallLength);
        var resultSpan = isStackAlloc ? stackalloc char[overallLength] : array;

        try
        {
            BuildPart(input1, resultSpan, ref currentPosition, Constants.LinkDelimiter);

            RemoveSpaces(resultSpan, ref currentPosition);

            var endIndex = resultSpan.IndexOf('\0');
            
            return endIndex is -1
                ? resultSpan[..overallLength].ToString() 
                : resultSpan[..(endIndex < overallLength ? endIndex : overallLength)].ToString();
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<char>.Shared.Return(array);
            }
        }
    }

    private static string InternalToLinkFormat(string input1, string input2)
    {
        var overallLength = input1.Length + input2.Length + 1;
        var isStackAlloc = overallLength <= MaxByteSize;

        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(overallLength);
        var resultSpan = isStackAlloc ? stackalloc char[overallLength] : array;

        try
        {
            BuildPart(input1, resultSpan, ref currentPosition, Constants.LinkDelimiter);
            BuildPart(input2, resultSpan, ref currentPosition);

            RemoveSpaces(resultSpan, ref currentPosition);

            var endIndex = resultSpan.IndexOf('\0');
            
            return endIndex is -1
                ? resultSpan[..overallLength].ToString() 
                : resultSpan[..(endIndex < overallLength ? endIndex : overallLength)].ToString();
        }
        finally
        {
            if (array is not null)
            {
                ArrayPool<char>.Shared.Return(array);
            }
        }
    }

    private static string InternalToLinkFormat(string input1, string input2, string input3)
    {
        var overallLength = input1.Length + input2.Length + input3.Length + 2;
        var isStackAlloc = overallLength <= MaxByteSize;

        var currentPosition = 0;

        var array = isStackAlloc ? null : ArrayPool<char>.Shared.Rent(overallLength);
        var resultSpan = isStackAlloc ? stackalloc char[overallLength] : array;

        try
        {
            BuildPart(input1, resultSpan, ref currentPosition, Constants.LinkDelimiter);
            BuildPart(input2, resultSpan, ref currentPosition, Constants.LinkDelimiter);
            BuildPart(input3, resultSpan, ref currentPosition);

            RemoveSpaces(resultSpan, ref currentPosition);

            var endIndex = resultSpan.IndexOf('\0');
            
            return endIndex is -1
                ? resultSpan[..overallLength].ToString() 
                : resultSpan[..(endIndex < overallLength ? endIndex : overallLength)].ToString();
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
    ///     Method to retrieve overall length of all array values.
    /// </summary>
    /// <param name="inputStrings">Collection of input strings.</param>
    /// <param name="fixedLength">Fixed length to be added to the overall length (delimiter length). By default - 0.</param>
    /// <returns><see cref="int"/> value of overall length.</returns>
    private static int GetLength(IReadOnlyList<string> inputStrings, int fixedLength = default)
    {
        var length = 0;

        for (var i = 0; i < inputStrings.Count; i++)
        {
            length = length + inputStrings[i].Length + fixedLength;
        }

        return length - fixedLength;
    }

    /// <summary>
    ///     Builds part of global span from input string variable.
    /// </summary>
    /// <param name="input">Input string variable.</param>
    /// <param name="overallSpan">Global <see cref="Span{T}"/>.</param>
    /// <param name="globalIndex">Global indexer for global <see cref="Span{T}"/>.</param>
    /// <param name="delimiter">Delimiter to be placed at the end.</param>
    /// <exception cref="ArgumentNullException">If input is null or empty.</exception>
    private static void BuildPart(string input, Span<char> overallSpan, ref int globalIndex, char delimiter = default)
    {
        var trimmedResult = MemoryExtensions.TrimEnd(input, Constants.Space);
        trimmedResult.ToLower(overallSpan[globalIndex..], CultureInfo.InvariantCulture);
        
        globalIndex += trimmedResult.Length;

        if (delimiter != default && globalIndex < overallSpan.Length)
        {
            overallSpan[globalIndex++] = delimiter;
        }
    }

    /// <summary>
    ///     Method that removed <see cref="Constants.Space"/> from <see cref="Span{T}"/> and
    ///     changes into <see cref="Constants.LinkDelimiter"/>.
    /// </summary>
    /// <param name="globalSpan">Span of chars.</param>
    /// <param name="currentPosition">Global indexer for globalSpan.</param>
    private static void RemoveSpaces(Span<char> globalSpan, ref int currentPosition)
    {
        var remaining = globalSpan[..currentPosition];

        var indexOfSpace = remaining.IndexOf(Constants.Space);

        if (indexOfSpace < 0)
        {
            return;
        }

        while (indexOfSpace != -1)
        {
            remaining[indexOfSpace] = Constants.LinkDelimiter;
            remaining = remaining[(indexOfSpace + 1)..];
            indexOfSpace = remaining.IndexOf(Constants.Space);
        }
    }
}
