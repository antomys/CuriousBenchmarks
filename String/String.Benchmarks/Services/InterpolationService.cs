using System.Text;

namespace String.Benchmarks.Services;

/// <summary>
///     Service for interpolating strings.
/// </summary>
public static class InterpolationService
{
    private const string TestTemplate = "{0}{1}";
    
    private static readonly StringBuilder StringBuilder = new();
    
    /// <summary>
    ///     Interpolates string using string interpolation.
    /// </summary>
    /// <param name="firstValue">First interpolation value.</param>
    /// <param name="secondValue">Second interpolation value.</param>
    /// <returns>Constructed string.</returns>
    public static string Interpolate(string firstValue, string secondValue)
    {
        return $"{firstValue}{secondValue}";
    }
    
    /// <summary>
    ///     Interpolates string using 'string.Format'.
    /// </summary>
    /// <param name="firstValue">First interpolation value.</param>
    /// <param name="secondValue">Second interpolation value.</param>
    /// <returns>Constructed string.</returns>
    public static string Format(string firstValue, string secondValue)
    {
        return string.Format(TestTemplate, firstValue, secondValue);
    }
    
    /// <summary>
    ///     Interpolates string using 'string.Concat'.
    /// </summary>
    /// <param name="firstValue">First interpolation value.</param>
    /// <param name="secondValue">Second interpolation value.</param>
    /// <returns>Constructed string.</returns>
    public static string Concat(string firstValue, string secondValue)
    { 
        return string.Concat(firstValue, secondValue);
    }
    
    /// <summary>
    ///     Interpolates string using <see cref="StringBuilder"/> and appending.
    /// </summary>
    /// <param name="firstValue">First interpolation value.</param>
    /// <param name="secondValue">Second interpolation value.</param>
    /// <returns>Constructed string.</returns>
    public static string StringBuilderAppend(string firstValue, string secondValue)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(firstValue);
        stringBuilder.Append(secondValue);

        return stringBuilder.ToString();
    }
    
    /// <summary>
    ///     Interpolates string using static <see cref="StringBuilder"/>, appending and cleaning.
    /// </summary>
    /// <param name="firstValue">First interpolation value.</param>
    /// <param name="secondValue">Second interpolation value.</param>
    /// <returns>Constructed string.</returns>
    public static string StaticStringBuilderAppend(string firstValue, string secondValue)
    {
        StringBuilder.Append(firstValue);
        StringBuilder.Append(secondValue);

        var str = StringBuilder.ToString();
        StringBuilder.Clear();

        return str;
    }
    
    /// <summary>
    ///     Interpolates string using 'string.Create'.
    /// </summary>
    /// <param name="firstValue">First interpolation value.</param>
    /// <param name="secondValue">Second interpolation value.</param>
    /// <returns>Constructed string.</returns>
    public static string Create(string firstValue, string secondValue)
    {
        return string.Create(firstValue.Length + secondValue.Length, (firstValue, secondValue),
            (shit, bebe) =>
            {
                var index = 0;
                var (val0, val1) = bebe;

                val0.CopyTo(shit);
                index += val0.Length;

                val1.CopyTo(shit[index..]);
            });
    }
}