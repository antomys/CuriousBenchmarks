using System.Text;
using Benchmarks.Tests.Unit.Benchmark.Serializers.Models;
using Bogus;

namespace Benchmarks.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Base class with arranged values.
/// </summary>
public static class TestsBase
{
    private const int InternalCount = 10;

    private readonly static Faker<TestModel> TestModelFaker = new();

    private readonly static TestModel[] TestModels = TestModelFaker
        .RuleFor(testModel => testModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
        .RuleFor(testModel => testModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
        .RuleFor(testModel => testModel.TestDouble, fakerSetter => double.Parse(fakerSetter.Random.Double().ToString("N4")))
        .RuleFor(testModel => testModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
        .RuleFor(testModel => testModel.TestInt, fakerSetter => fakerSetter.Random.Int())
        .RuleFor(testModel => testModel.TestLong, fakerSetter => fakerSetter.Random.Long())
        .RuleFor(testModel => testModel.TestShort, fakerSetter => fakerSetter.Random.Short())
        .RuleFor(testModel => testModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
        .RuleFor(testModel => testModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
        .RuleFor(testModel => testModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
        .RuleFor(testModel => testModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
        .Generate(InternalCount)
        .ToArray();

    private readonly static string TestString = BuildString(TestModels);

    /// <summary>
    ///     Gets built constructed string.
    /// </summary>
    /// <returns>built constructed string.</returns>
    public static string GetTestString()
    {
        return TestString;
    }

    /// <summary>
    ///     Gets array of bytes from string value.
    /// </summary>
    /// <returns>Array of bytes from string value.</returns>
    public static byte[] GetTestBytes()
    {
        return Encoding.UTF8.GetBytes(TestString);
    }

    /// <summary>
    ///     Gets List of <see cref="TestModel" />.
    /// </summary>
    /// <returns>List of <see cref="TestModel" />.</returns>
    public static TestModel[] GetTestModels()
    {
        return TestModels;
    }

    private static string BuildString(Span<TestModel> testModels)
    {
        var sb = new StringBuilder();
        sb.Append('[');

        for (var i = 0; i < testModels.Length - 1; i++)
        {
            sb.Append(testModels[i]);
            sb.Append(',');
        }

        sb.Append(testModels[^1]);
        sb.Append(']');

        return sb.ToString();
    }
}