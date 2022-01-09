using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;

namespace StringExtensionsBenchmarks.StringExtensions;

public static class StringExtensions
{
    private const string DashedViewDelimiter = " - ";
    private const char Space = ' ';
    private const char LinkDelimiter = '-';
    private const ushort MaxByteSize = 128;
    private static bool _isStackAlloc = true;

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
    
    /// <summary>
    /// Creates a new string from input params strings with <see cref="DashedViewDelimiter"/> between. <br/>
    /// Uses inside string.Join. Slightly slower that ToDashFormatV2 but still relevant.
    /// </summary>
    /// <param name="stringCollection">Input string collection.</param>
    /// <returns>New created <see cref="string"/> formatted with <see cref="DashedViewDelimiter"/>.</returns>
    [Obsolete($"Obsolete and changed to different implementations. Please consider using another overload")]
    public static string ToDashFormat(this IEnumerable<string> stringCollection) =>
        string.Join(DashedViewDelimiter, stringCollection);

    /// <summary>
    /// Creates a new string from input params strings with <see cref="DashedViewDelimiter"/> between. <br/>
    /// Uses inside string.Join. Slightly slower that ToDashFormatV2 but still relevant.
    /// </summary>
    /// <param name="inputValues">Input string parameters.</param>
    /// <returns>New created <see cref="string"/> formatted with <see cref="DashedViewDelimiter"/>.</returns>
    public static string ToDashFormat(string[] inputValues)
        => string.Join(DashedViewDelimiter, inputValues);

    /// <summary>
    /// Creates a new string from input string with <see cref="DashedViewDelimiter"/> between. <br/>
    /// Inside uses method string.Create with a callback to create a new string (slightly faster than ToDashFormatV2 method).
    /// </summary>
    /// <param name="value0">First <see cref="string"/> value</param>
    /// <param name="value1">Second <see cref="string"/> value</param>
    /// <returns>
    /// <c>string.Empty</c> if either <see cref="value0"/> or <see cref="value1"/> is missing <br/>
    /// New created <see cref="string"/> New formatted string.
    /// </returns>
    public static string ToDashFormat(string value0, string value1)
    {
        if (string.IsNullOrEmpty(value0) || string.IsNullOrEmpty(value1))
        {
            return string.Empty;
        }
        
        return string.Create(value0.Length + value1.Length + DashedViewDelimiter.Length, (value0, value1),
            (shit, bebe) =>
            {
                var index = 0;
                var (val0, val1) = bebe;

                val0.CopyTo(shit);
                index += val0.Length;

                DashedViewDelimiter.CopyTo(shit[index..]);
                index += DashedViewDelimiter.Length;

                val1.CopyTo(shit[index..]);
            });
    }
    
    /// <summary>
    /// Creates a new string from input string with <see cref="DashedViewDelimiter"/> between. <br/>
    /// Inside uses method string.Create with a callback to create a new string (slightly faster than ToDashFormatV2 method).
    /// </summary>
    /// <param name="inputValues">Array of input values.</param>
    /// <param name="overallLength">Overall length of all values in array</param>
    /// <returns>
    /// <c>string.Empty</c>If <see cref="inputValues"/> is missing.<br/>
    /// New created <see cref="string"/> New formatted string.
    /// </returns>
    public static string ToDashFormat(string[] inputValues, int overallLength)
    {
        if (inputValues.Length == 0)
        {
            throw new ArgumentNullException(nameof(inputValues));
        }

        overallLength = overallLength == default
            ? GetLength(inputValues, DashedViewDelimiter.Length)
            : overallLength + DashedViewDelimiter.Length * (inputValues.Length - 1);

        return string.Create(overallLength, inputValues,
            (span, stringArray) =>
            {
                int index = default;

                for (var i = 0; i < stringArray.Length - 1; i++)
                {
                    stringArray[i].CopyTo(span);
                    index += stringArray[i].Length;

                    DashedViewDelimiter.CopyTo(span[index..]);
                    index += DashedViewDelimiter.Length;
                }
                
                stringArray[^1].CopyTo(span[index..]);
            });
    }
    
    /// <summary>
    /// Creates slug from <see cref="inputStrings"/>.
    /// Lowers string and places <see cref="LinkDelimiter"/> between.
    /// </summary>
    /// <param name="inputStrings">Array of input string variables</param>
    /// <param name="overallLength">Aggregated length of all string variables from string</param>
    /// <returns>New Formatter slug <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">If <see cref="inputStrings"/> is empty.</exception>
    public static string ToLinkFormat(string[] inputStrings, int overallLength = default)
    {
        if (inputStrings.Length == default)
        {
            throw new ArgumentNullException(nameof(inputStrings));
        }

        overallLength = overallLength == default
            ? GetLength(inputStrings, 1) 
            : overallLength + inputStrings.Length - 1;
        
        int currentPosition = default;
        var resultSpan = overallLength < MaxByteSize
            ? stackalloc char[overallLength]
            : ArrayPool<char>.Shared.Rent(overallLength);

        if (overallLength >= MaxByteSize)
        {
            _isStackAlloc = false;
        }

        for (var i = 0; i < inputStrings.Length - 1; i++)
        {
            BuildPart(inputStrings[i], true, resultSpan, ref currentPosition, LinkDelimiter);
        }
        
        BuildPart(inputStrings[^1], true, resultSpan, ref currentPosition);
        
        RemoveSpaces(resultSpan, ref currentPosition);

        if (_isStackAlloc)
        {
            return resultSpan.ToString();
        }

        var result = resultSpan.ToString();
        
        ArrayPool<char>.Shared.Return(resultSpan.ToArray());

        return result;
    }
    
    /// <summary>
    /// Aggressive variant of <see cref="ToLinkFormat(string[],int)"/>. Removes all occured special characters.
    /// </summary>
    /// <param name="inputStrings">Input array of strings.</param>
    /// <param name="overallLength">Overall length of all input strings.</param>
    /// <returns>Formatted string.</returns>
    /// <exception cref="ArgumentNullException">If input array is empty.</exception>
    public static string ToLinkFormatAggressive(string[] inputStrings, int overallLength = default)
    {
        if (inputStrings.Length == default)
        {
            throw new ArgumentNullException(nameof(inputStrings));
        }

        overallLength = overallLength == default
            ?GetLength(inputStrings, 1) 
            : overallLength + inputStrings.Length - 1;
        
        int currentPosition = default;
        var resultSpan = overallLength < MaxByteSize
            ? stackalloc char[overallLength]
            : ArrayPool<char>.Shared.Rent(overallLength);

        if (overallLength >= MaxByteSize)
            _isStackAlloc = false;

        for (var i = 0; i < inputStrings.Length - 1; i++)
        {
            BuildPart(inputStrings[i], true, resultSpan, ref currentPosition, LinkDelimiter);
        }
        
        BuildPart(inputStrings[^1], true, resultSpan, ref currentPosition);

        resultSpan = RemoveSpecialCharacters(resultSpan);

        if (_isStackAlloc)
        {
            return resultSpan.ToString();
        }

        var result = resultSpan.ToString();
        
        ArrayPool<char>.Shared.Return(resultSpan.ToArray());

        return result;
    }
    
    /// <summary>
    /// Creates slug from <see cref="inputString"/>.
    /// Lowers string and places <see cref="LinkDelimiter"/> between.
    /// </summary>
    /// <param name="inputString">input string variable</param>
    /// <returns>New Formatter slug <see cref="string"/>.</returns>
    /// <exception cref="ArgumentNullException">If <see cref="inputString"/> is null or empty.</exception>
    public static string ToLinkFormat(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentNullException(nameof(inputString));
        }
        
        var currentPosition = 0;

        // This is allocation of Char array.
        // Span<char> result char is, frankly speaking, pointer to this array.
        // (value type!)
        var resultSpan = inputString.Length < 128
            ? stackalloc char[inputString.Length]
            : new char[inputString.Length];
        
        BuildPart(inputString, true, resultSpan, ref currentPosition);

        return resultSpan.ToString(); // Another allocation
    }
    
    /// <summary>
    /// Aggressive version of <see cref="ToLinkFormat(string[],int)"/>. Removes all occured special characters.
    /// </summary>
    /// <param name="inputString">Input string.</param>
    /// <returns>Formatted string.</returns>
    /// <exception cref="ArgumentNullException">If input string is null or empty.</exception>
    public static string ToLinkFormatAggressive(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentNullException(nameof(inputString));
        }
        
        var currentPosition = 0;

        // This is allocation of Char array.
        // Span<char> result char is, frankly speaking, pointer to this array.
        // (value type!!!)
        var resultSpan = inputString.Length < 128
            ? stackalloc char[inputString.Length]
            : new char[inputString.Length];
        
        BuildPart(inputString, true, resultSpan, ref currentPosition);

        resultSpan = RemoveSpecialCharacters(resultSpan);

        return resultSpan.ToString(); // Another allocation
    }

    /// <summary>
    /// Method to retrieve overall length of all array values.
    /// </summary>
    /// <param name="inputStrings">Collection of input strings.</param>
    /// <param name="fixedLength">Fixed length to be added to the overall length (delimiter length). By default - 0.</param>
    /// <returns><see cref="Int32"/> value of overall length.</returns>
    private static int GetLength(IReadOnlyList<string> inputStrings, int fixedLength = default)
    {
        int length = default;

        for (var i = 0; i < inputStrings.Count; i++)
        {
            length = length + inputStrings[i].Length + fixedLength;
        }

        return length - fixedLength;
    }
    
    /// <summary>
    /// Builds part of global span from input string variable.
    /// </summary>
    /// <param name="input">Input string variable.</param>
    /// <param name="isToLower">Whether copying should be lowercased.</param>
    /// <param name="overallSpan">Global <see cref="Span{T}"/>.</param>
    /// <param name="globalIndex">Global indexer for global <see cref="Span{T}"/>.</param>
    /// <param name="delimiter">Delimiter to be placed at the end.</param>
    /// <exception cref="ArgumentNullException">If input is null or empty.</exception>
    private static void BuildPart(string input, bool isToLower, Span<char> overallSpan, ref int globalIndex, char delimiter = default)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        switch (isToLower)
        {
            case true:
                MemoryExtensions.ToLower(input, overallSpan[globalIndex..], CultureInfo.InvariantCulture);
                break;
            default:
                input.CopyTo(overallSpan[globalIndex..]);
                break;
        }
        
        globalIndex += input.Length;

        if (delimiter != default)
        {
            overallSpan[globalIndex++] = delimiter;
        }
    }
    
    /// <summary>
    /// Method that removed <see cref="Space"/> from <see cref="Span{T}"/> and
    /// changes into <see cref="LinkDelimiter"/>.
    /// </summary>
    /// <param name="globalSpan">Span of chars</param>
    /// <param name="currentPosition">Global indexer for globalSpan</param>
    private static void RemoveSpaces(Span<char> globalSpan, ref int currentPosition)
    {
        var remaining = globalSpan[..currentPosition];

        var indexOfSpace = remaining.IndexOf(Space);

        if (indexOfSpace < 0)
        {
            return;
        }

        while (indexOfSpace != -1)
        {
            remaining[indexOfSpace] = LinkDelimiter;
            remaining = remaining[(indexOfSpace + 1)..];
            indexOfSpace = remaining.IndexOf(Space);
        }
    }
    
    /// <summary>
    /// Removes all special characters occured on way and changes to <see cref="LinkDelimiter"/>
    /// </summary>
    /// <param name="str">input ReadOnlySpan</param>
    /// <returns>Span</returns>
    private static Span<char> RemoveSpecialCharacters(this ReadOnlySpan<char> str)
    {
        Span<char> buffer = new char[str.Length];
        int idx = default;

        foreach (var c in str)
        {
            if (!char.IsLetterOrDigit(c))
            {
                if(buffer[idx - 1] == LinkDelimiter)
                {
                    continue;
                }
                buffer[idx++] = LinkDelimiter;
                continue;
            }
            buffer[idx] = c;
            idx++;
        }

        return buffer[..idx];
    }
}
