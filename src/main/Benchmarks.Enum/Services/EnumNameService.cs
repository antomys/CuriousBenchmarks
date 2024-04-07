using Benchmarks.Enum.Extensions;

namespace Benchmarks.Enum.Services;

/// <summary>
///     Enum getting name service for benchmarks and unit testing.
/// </summary>
public static class EnumNameService
{
    /// <summary>
    ///     Gets enum name by using default 'ToString' method.
    ///     <para>
    ///         Note: Boxing allocation: inherited 'System.Object' virtual method call on value type instance.
    ///     </para>
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>Name of Enum.</returns>
    public static string DefaultToString(this TestEnum testEnum)
    {
        return testEnum.ToString();
    }

    /// <summary>
    ///     Gets enum name by using default extensions method of <see cref="Enum" /> class <see cref="Enum.GetName" />
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>Name of Enum.</returns>
    public static string? EnumGetName(this TestEnum testEnum)
    {
        return System.Enum.GetName(testEnum);
    }

    /// <summary>
    ///     Gets enum name by using custom-made method from <see cref="EnumExtensions" />.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>Name of Enum.</returns>
    public static string CustomGetName(this TestEnum testEnum)
    {
        return testEnum.GetName();
    }
}