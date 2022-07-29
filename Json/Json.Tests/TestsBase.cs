using System.Text;
using System.Xml;
using Bogus;
using CuriousBenchmarks.Common;
using Json.Tests.Models;

namespace Json.Tests;

/// <summary>
///     Base class with arranged values.
/// </summary>
public static class TestsBase
{
#pragma warning disable CA1822
    
    private const int InternalCount = 10;

    private static readonly Faker<TestModel> TestModelFaker = new();
    
    private static readonly TestModel[] TestModels = TestModelFaker
        .RuleFor(testModel => testModel.TestByte, fakerSetter => fakerSetter.Random.Byte())
        .RuleFor(testModel => testModel.TestChar, fakerSetter => fakerSetter.Random.Char('a', 'z'))
        .RuleFor(testModel => testModel.TestDate, fakerSetter => fakerSetter.Date.Past().ToUniversalTime())
        .RuleFor(testModel => testModel.TestDouble, fakerSetter => fakerSetter.Random.Double())
        .RuleFor(testModel => testModel.TestFloat, fakerSetter => fakerSetter.Random.Float())
        .RuleFor(testModel => testModel.TestInt, fakerSetter => fakerSetter.Random.Int())
        .RuleFor(testModel => testModel.TestLong, fakerSetter => fakerSetter.Random.Long())
        .RuleFor(testModel => testModel.TestShort, fakerSetter => fakerSetter.Random.Short())
        .RuleFor(testModel => testModel.TestString, fakerSetter => fakerSetter.Random.String2(5, 10))
        .RuleFor(testModel => testModel.TestUInt, fakerSetter => fakerSetter.Random.UInt())
        .RuleFor(testModel => testModel.TestUShort, fakerSetter => fakerSetter.Random.UShort())
        .RuleFor(testModel => testModel.TestULong, fakerSetter => fakerSetter.Random.ULong())
        .RuleFor(testModel => testModel.TestTimeSpan, fakerSetter => fakerSetter.Date.Timespan())
        .RuleFor(testModel => testModel.TestCharArray, fakerSetter => fakerSetter.Random.Chars('a', 'z', count: InternalCount))
        .RuleFor(testModel => testModel.TestDoubleArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Double(), InternalCount))
        .RuleFor(testModel => testModel.TestFloatArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Float(), InternalCount))
        .RuleFor(testModel => testModel.TestIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Int(), InternalCount))
        .RuleFor(testModel => testModel.TestUIntArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UInt(), InternalCount))
        .RuleFor(testModel => testModel.TestLongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Long(), InternalCount))
        .RuleFor(testModel => testModel.TestShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.Short(), InternalCount))
        .RuleFor(testModel => testModel.TestStringArray, fakerSetter => fakerSetter.GetArray(func => func.Random.String2(5, 10), InternalCount))
        .RuleFor(testModel => testModel.TestUShortArray, fakerSetter => fakerSetter.GetArray(func => func.Random.UShort(), InternalCount))
        .RuleFor(testModel => testModel.TestULongArray, fakerSetter => fakerSetter.GetArray(func => func.Random.ULong(), InternalCount))
        .Generate(InternalCount)
        .ToArray();
    
    private static readonly string TestString = BuildString(TestModels, isIsoTimeSpan : false);
    
    private static readonly string TestUtf8JsonString = BuildString(TestModels, isIsoTimeSpan : false, isUtf8 : true);
    
    private static readonly string TestJilString = BuildString(TestModels, isIsoTimeSpan: true);

    /// <summary>
    ///     Gets built constructed string.
    /// </summary>
    /// <returns>built constructed string.</returns>
    public static string GetTestString() => TestString;
    
    /// <summary>
    ///     Gets built constructed string.
    /// </summary>
    /// <returns>built constructed string.</returns>
    public static string GetTestUtf8String() => TestUtf8JsonString;

    /// <summary>
    ///     Gets array of bytes from string value.
    /// </summary>
    /// <returns>Array of bytes from string value.</returns>
    public static byte[] GetTestBytes() => Encoding.UTF8.GetBytes(TestString);
    
    /// <summary>
    ///     Gets array of bytes from string value.
    /// </summary>
    /// <returns>Array of bytes from string value.</returns>
    public static byte[] GetTestUtf8Bytes() => Encoding.UTF8.GetBytes(TestUtf8JsonString);
    
    /// <summary>
    ///     Gets Jil built constructed string.
    /// </summary>
    /// <returns>built constructed string.</returns>
    public static string GetTestJilString() => TestJilString;

    /// <summary>
    ///     Gets array of bytes from string value.
    /// </summary>
    /// <returns>Array of bytes from string value.</returns>
    public static byte[] GetTestJilBytes() => Encoding.UTF8.GetBytes(TestJilString);
    
    /// <summary>
    ///     Gets List of <see cref="TestModel"/>.
    /// </summary>
    /// <returns>List of <see cref="TestModel"/>.</returns>
    public static TestModel[] GetTestModels() => TestModels;

    private static string BuildString(IReadOnlyList<TestModel> testModels, bool isIsoTimeSpan = false, bool isUtf8 = false)
    {
        var sb = new StringBuilder();
        sb.Append('[');

        for(var i = 0; i < testModels.Count - 1; i++)
        {
            BuildString(testModels[i], ref sb, isIsoTimeSpan, isUtf8);
            sb.Append(',');
        }
        BuildString(testModels[^1], ref sb, isIsoTimeSpan, isUtf8);
        sb.Append(']');
        
        return sb.ToString();
    }

    private static void BuildString(TestModel testModel, ref StringBuilder sb, bool isIsoTimeSpan = false, bool isUtf8 = false)
    {
        sb.Append('{');

        sb.Append("\"testString\":");
        sb.Append('\"');
        sb.Append(testModel.TestString);
        sb.Append('\"');
        sb.Append(',');

        sb.Append("\"testStringArray\":");
        AppendArray(testModel.TestStringArray, ref sb, isString: true);
        sb.Append(',');

        sb.Append("\"testInt\":");
        sb.Append(testModel.TestInt);
        sb.Append(',');

        sb.Append("\"testIntArray\":");
        AppendArray(testModel.TestIntArray, ref sb);
        sb.Append(',');

        sb.Append("\"testDouble\":");
        sb.Append(testModel.TestDouble);
        sb.Append(',');

        sb.Append("\"testDoubleArray\":");
        AppendArray(testModel.TestDoubleArray, ref sb);
        sb.Append(',');

        sb.Append("\"testFloat\":");
        sb.Append(testModel.TestFloat);
        sb.Append(',');

        sb.Append("\"testFloatArray\":");
        AppendArray(testModel.TestFloatArray, ref sb);
        sb.Append(',');

        sb.Append("\"testUInt\":");
        sb.Append(testModel.TestUInt);
        sb.Append(',');

        sb.Append("\"testUIntArray\":");
        AppendArray(testModel.TestUIntArray, ref sb);
        sb.Append(',');

        sb.Append("\"testChar\":");
        sb.Append('\"');
        sb.Append(testModel.TestChar);
        sb.Append('\"');
        sb.Append(',');

        sb.Append("\"testCharArray\":");
        AppendArray(testModel.TestCharArray.Select(charValue => charValue.ToString()).ToArray(), ref sb,
            isString: true);
        sb.Append(',');

        sb.Append("\"testByte\":");
        sb.Append(testModel.TestByte);
        sb.Append(',');

        sb.Append("\"testShort\":");
        sb.Append(testModel.TestShort);
        sb.Append(',');

        sb.Append("\"testShortArray\":");
        AppendArray(testModel.TestShortArray, ref sb);
        sb.Append(',');

        sb.Append("\"testUShort\":");
        sb.Append(testModel.TestUShort);
        sb.Append(',');

        sb.Append("\"testUShortArray\":");
        AppendArray(testModel.TestUShortArray, ref sb);
        sb.Append(',');

        sb.Append("\"testLong\":");
        sb.Append(testModel.TestLong);
        sb.Append(',');

        sb.Append("\"testLongArray\":");
        AppendArray(testModel.TestLongArray, ref sb);
        sb.Append(',');

        sb.Append("\"testULong\":");
        sb.Append(testModel.TestULong);
        sb.Append(',');

        sb.Append("\"testULongArray\":");
        AppendArray(testModel.TestULongArray, ref sb);
        sb.Append(',');

        sb.Append("\"testDate\":");
        sb.Append('\"');
        sb.Append(BuildDateTimeString(testModel.TestDate, isUtf8));
        sb.Append('\"');
        sb.Append(',');

        sb.Append("\"testTimeSpan\":");
        sb.Append('\"');

        var stringTimeSpan = isIsoTimeSpan
            ? XmlConvert.ToString(testModel.TestTimeSpan)
            : testModel.TestTimeSpan.ToString();
        sb.Append(stringTimeSpan);
        
        sb.Append('\"');

        sb.Append('}');
    }

    private static string BuildDateTimeString(DateTime dateTime, bool isUtf8 = false)
    {
        var testDate = dateTime.ToString("O");

        if (isUtf8)
        {
            return testDate;
        }
        
        var testDateSpan = testDate.AsSpan();
        var indexOfDot = testDateSpan.IndexOf('.');
        var slicedSpan = testDateSpan[indexOfDot..];
        slicedSpan = slicedSpan[..slicedSpan.IndexOf('Z')];

        var indexOfZero = slicedSpan[^1] is '0';
        
        while (indexOfZero)
        {
            slicedSpan = slicedSpan[..^1];
            indexOfZero = slicedSpan[^1] is '0';
        }

        return $"{testDateSpan[..indexOfDot]}{slicedSpan}Z";
    }

    private static void AppendArray<T>(IReadOnlyList<T> array, ref StringBuilder stringBuilder, bool isString = false)
    {
        stringBuilder.Append('[');
        for (var i = 0; i < array.Count - 1; i++)
        {
            stringBuilder.Append(isString ? $"\"{array[i]}\"" : array[i]);
            stringBuilder.Append(',');
        }

        stringBuilder.Append(isString ? $"\"{array[^1]}\"" : array[^1]);
        stringBuilder.Append(']');
    }
    
#pragma warning restore CA1822
}