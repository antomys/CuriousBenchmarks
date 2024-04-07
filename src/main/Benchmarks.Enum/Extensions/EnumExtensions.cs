namespace Benchmarks.Enum.Extensions;

/// <summary>
///     Enum extensions.
/// </summary>
internal static class EnumExtensions
{
    /// <summary>
    ///     The simplest method to get name of the enum.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>input enum name.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If out of range of enum.</exception>
    internal static string GetName(this TestEnum testEnum)
    {
        return testEnum switch
        {
            TestEnum.First => nameof(TestEnum.First),
            TestEnum.Second => nameof(TestEnum.Second),
            TestEnum.Third => nameof(TestEnum.Third),
            TestEnum.Fourth => nameof(TestEnum.Fourth),
            TestEnum.Fifth => nameof(TestEnum.Fifth),
            TestEnum.Sixth => nameof(TestEnum.Sixth),
            TestEnum.Seventh => nameof(TestEnum.Seventh),
            TestEnum.Eighth => nameof(TestEnum.Eighth),
            TestEnum.Ninth => nameof(TestEnum.Ninth),
            TestEnum.Tenth => nameof(TestEnum.Tenth),
            TestEnum.Eleventh => nameof(TestEnum.Eleventh),
            TestEnum.Twelfth => nameof(TestEnum.Twelfth),
            TestEnum.Zero => nameof(TestEnum.Zero),
            _ => throw new ArgumentOutOfRangeException(nameof(testEnum), testEnum, default)
        };
    }

    /// <summary>
    ///     The simplest method to get name of the enum.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum" />.</param>
    /// <returns>input enum name.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If out of range of enum.</exception>
    internal static byte GetValue(this TestEnum testEnum)
    {
        return testEnum switch
        {
            TestEnum.First => 1,
            TestEnum.Second => 2,
            TestEnum.Third => 3,
            TestEnum.Fourth => 4,
            TestEnum.Fifth => 5,
            TestEnum.Sixth => 6,
            TestEnum.Seventh => 7,
            TestEnum.Eighth => 8,
            TestEnum.Ninth => 9,
            TestEnum.Tenth => 10,
            TestEnum.Eleventh => 11,
            TestEnum.Twelfth => 12,
            TestEnum.Zero => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(testEnum), testEnum, default)
        };
    }
}