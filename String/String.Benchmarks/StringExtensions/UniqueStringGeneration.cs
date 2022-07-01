using System.Buffers;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Toolkit.HighPerformance.Buffers;

namespace String.Benchmarks.StringExtensions;

/// <summary>
///     Extensions for generating unique strings.
/// </summary>
public static class UniqueStringGeneration
{
    private static readonly char[] Chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

    private const int ByteSize = 0x100;

    /// <summary>
    ///     Generates and gets unique string (original version).
    /// </summary>
    /// <param name="size">Size of generated string.</param>
    /// <returns><see cref="string"/>.</returns>
    public static string GetUniqueOriginal(int size)
    {
        var data = new byte[4 * size];
        using (var crypto = RandomNumberGenerator.Create())
        {
            crypto.GetBytes(data);
        }

        return string.Create(size, (Chars, size, data), (span, tuple) =>
        {
            var (chars, internalSize, internalData) = tuple;

            for (var i = 0; i < internalSize; i++)
            {
                var rnd = BitConverter.ToUInt32(internalData, i * 4);
                var idx = rnd % chars.Length;

                span[i] = chars[idx];
            }
        });
    }

    /// <summary>
    ///     Generates unique string value of a gives size.
    /// </summary>
    /// <param name="length">Given size of generated string.</param>
    /// <returns>Generated string.</returns>
    public static string GetUniqueHashSet(int length) 
    {
        var allowedCharSet = new HashSet<char>(Chars).ToArray();
        
        using var rng = RandomNumberGenerator.Create();
        var result = new StringBuilder();
        var buf = new byte[128];
        
        while (result.Length < length) 
        {
            rng.GetBytes(buf);
            for (var i = 0; i < buf.Length && result.Length < length; ++i) {
                var outOfRangeStart = ByteSize - ByteSize % allowedCharSet.Length;
                if (outOfRangeStart <= buf[i]) continue;
                result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
            }
        }
        return result.ToString();
    }

    /// <summary>
    ///     Generates unique string value of a gives size.
    /// </summary>
    /// <param name="length">Given size of generated string.</param>
    /// <returns>Generated string.</returns>
    public static string GetUniqueSpanOwner(int length) 
    {
        switch (length <= 64)
        {
            case true:
            {
                Span<char> result = stackalloc char[length];
                
                return InternalGetUniqueKey(result, length);
            }
            default:
            {
                using var array = SpanOwner<char>.Allocate(length);

                return InternalGetUniqueKey(array.Span, length);
            }
        }
    }
    
    /// <summary>
    ///     Generates unique string value of a gives size.
    /// </summary>
    /// <param name="length">Given size of generated string.</param>
    /// <returns>Generated string.</returns>
    public static string GetUniqueKeyNewArrayPool(int length) 
    {
        switch (length <= 64)
        {
            case true:
            {
                Span<char> result = stackalloc char[length];
                
                return InternalGetUniqueKey(result, length);
            } 
            default:
            {
                var array = ArrayPool<char>.Shared.Rent(length);
                try
                {
                    return InternalGetUniqueKey(array.AsSpan(), length);
                }
                finally
                {
                    ArrayPool<char>.Shared.Return(array);
                }
            }
        }
    }

    private static string InternalGetUniqueKey(this Span<char> charSpan, int length)
    {
        var buf = RandomNumberGenerator.GetBytes(length);

        for (var i = 0; i < length; i++) 
        {
            charSpan[i] = Chars[buf[i] % Chars.Length];
        }

        return charSpan.Length > length 
            ? charSpan[..length].ToString() 
            : charSpan.ToString();
    }
}