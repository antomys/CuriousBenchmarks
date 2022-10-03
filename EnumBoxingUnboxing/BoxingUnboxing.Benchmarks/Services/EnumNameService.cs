using BoxingUnboxing.Benchmarks.Extensions;

namespace BoxingUnboxing.Benchmarks.Services;

/// <summary>
///     Enum getting name service for benchmarks and unit testing.
/// </summary>
public static class EnumNameService
{
    /// <summary>
    ///     Gets enum name by using default 'ToString' method.
    /// <para>
    ///     Note: Boxing allocation: inherited 'System.Object' virtual method call on value type instance.
    /// </para>
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static string DefaultToString(this TestEnum testEnum)
    {
        return testEnum.ToString();
    }

    /// <summary>
    ///     Gets enum name by using default extensions method of <see cref="Enum"/> class <see cref="Enum.GetName"/>
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static string? EnumGetName(this TestEnum testEnum)
    {
        return Enum.GetName(testEnum);
    }

    /// <summary>
    ///     Gets enum name by using custom-made method from <see cref="EnumExtensions"/>.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static string CustomGetName(this TestEnum testEnum)
    {
        return EnumExtensions.CustomGetName(testEnum);
    }
}
/// <summary>
///     Enum getting name service for benchmarks and unit testing.
/// </summary>
public static class NameEnumService
{
    /// <summary>
    ///     Gets enum name by using default 'ToString' method.
    /// <para>
    ///     Note: Boxing allocation: inherited 'System.Object' virtual method call on value type instance.
    /// </para>
    /// </summary>
    /// <param name="testStringEnum">string of <see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static TestEnum EnumTryParse(this string testStringEnum)
    {
        Enum.TryParse<TestEnum>(testStringEnum, false, out var testEnum);

        return testEnum;
    }
    
    /// <summary>
    ///     Gets enum name by using custom-made method from <see cref="EnumExtensions"/>.
    /// </summary>
    /// <param name="testStringEnum"> string of <see cref="TestEnum"/>.</param>
    /// <returns>Name of Enum.</returns>
    public static TestEnum CustomGetEnumFromName(this string testStringEnum)
    {
        return GetEnumNameInternal(testStringEnum);
    }
    private static TestEnum GetEnumNameInternal(this string testStringEnum)
    {
        return testStringEnum switch
        {
            "Zero" => TestEnum.Zero,
            "First" => TestEnum.First,
            "Second" => TestEnum.Second,
            "Third" => TestEnum.Third,
            "Fourth" => TestEnum.Fourth,
            "Fifth" => TestEnum.Fifth,
            "Sixth" => TestEnum.Sixth,
            "Seventh" => TestEnum.Seventh,
            "Eighth" => TestEnum.Eighth,
            "Ninth" => TestEnum.Ninth,
            "Tenth" => TestEnum.Tenth,
            "Eleventh" => TestEnum.Eleventh,
            "Twelfth" => TestEnum.Twelfth,
            _ => throw new ArgumentOutOfRangeException(nameof(testStringEnum)),
        };
    }
}