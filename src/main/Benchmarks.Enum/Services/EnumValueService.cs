using Benchmarks.Enum.Extensions;

namespace Benchmarks.Enum.Services;

/// <summary>
///     Enum getting value service for benchmarks and unit testing.
/// </summary>
public static class EnumValueService
{
    /// <summary>
    ///     Getting integer value from enum using default method 'ToString' with format 'D - integer value'.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>Value of Enum.</returns>
    public static string ToStringFormatD(this TestEnum testEnum)
    {
        return testEnum.ToString("D");
    }

    /// <summary>
    ///     Getting integer value from enum by casting firstly <see cref="TestEnum" /> to <see cref="int" /> and then using
    ///     'ToString'.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>Value of Enum.</returns>
    public static string IntCastToString(this TestEnum testEnum)
    {
        return ((int)testEnum).ToString();
    }

    /// <summary>
    ///     Getting integer value from enum using method from <see cref="EnumExtensions" /> to get int value
    ///     <see cref="EnumExtensions.CustomGetValue" />.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>Value of Enum.</returns>
    public static string CustomGetValue(this TestEnum testEnum)
    {
        return testEnum.GetValue().ToString();
    }
}