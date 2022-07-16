using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;
using Bogus;
using Json.Tests.Models;

namespace Json.Tests;

public class TestsBase : IDisposable
{
    private const int internalCount = 10;

    private static readonly Faker<TestModel> _testModelFaker = new();
    private static List<TestModel> _testModels;
    private static string _testString;

    public string GetTestString() => _testString;

    public byte[] GetTestBytes() => Encoding.UTF8.GetBytes(_testString);
    
    public List<TestModel> GetTestModels() => _testModels; 
    
    public TestsBase()
    {
        _testModels = _testModelFaker
            .RuleFor(x => x.TestByte, y => y.Random.Byte())
            .RuleFor(x => x.TestChar, y => y.Random.Char('a', 'z'))
            .RuleFor(x => x.TestDate, y => y.Date.Past())
            .RuleFor(x => x.TestDouble, y => y.Random.Double())
            .RuleFor(x => x.TestFloat, y => y.Random.Float())
            .RuleFor(x => x.TestInt, y => y.Random.Int())
            .RuleFor(x => x.TestLong, y => y.Random.Long())
            .RuleFor(x => x.TestShort, y => y.Random.Short())
            .RuleFor(x => x.TestString, y => y.Random.String2(5, 10))
            .RuleFor(x => x.TestUInt, y => y.Random.UInt())
            .RuleFor(x => x.TestUShort, y => y.Random.UShort())
            .RuleFor(x => x.TestULong, y => y.Random.ULong())
            .RuleFor(x => x.TestTimeSpan, y => y.Date.Timespan())
            // .RuleFor(x => x.TestByteArray, y => y.Random.Bytes(internalCount))
            .RuleFor(x => x.TestCharArray, y => y.Random.Chars('a', 'z', count: internalCount))
            .RuleFor(x => x.TestDoubleArray, y => GetArray(y, func => func.Random.Double(), internalCount))
            .RuleFor(x => x.TestFloatArray, y => GetArray(y, func => func.Random.Float(), internalCount))
            .RuleFor(x => x.TestIntArray, y => GetArray(y, func => func.Random.Int(), internalCount))
            .RuleFor(x => x.TestUIntArray, y => GetArray(y, func => func.Random.UInt(), internalCount))
            .RuleFor(x => x.TestLongArray, y => GetArray(y, func => func.Random.Long(), internalCount))
            .RuleFor(x => x.TestShortArray, y => GetArray(y, func => func.Random.Short(), internalCount))
            .RuleFor(x => x.TestStringArray, y => GetArray(y, func => func.Random.String2(5, 10), internalCount))
            .RuleFor(x => x.TestUShortArray, y => GetArray(y, func => func.Random.UShort(), internalCount))
            .RuleFor(x => x.TestULongArray, y => GetArray(y, func => func.Random.ULong(), internalCount))
            .Generate(internalCount);

        _testString = BuildString(_testModels);
    }
    
    public void Dispose()
    {
        _testModels.Clear();
        _testString = string.Empty;
    }

    private static string BuildString(List<TestModel> testModels)
    {
        var sb = new StringBuilder();
        sb.Append('[');

        for(var i = 0; i < testModels.Count - 1; i++)
        {
            BuildString(testModels[i], ref sb);
            sb.Append(',');
        }
        BuildString(testModels[^1], ref sb);
        sb.Append(']');
        
        return sb.ToString();
    }

    private static void BuildString(TestModel testModel, ref StringBuilder sb)
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
        AppendArray(testModel.TestCharArray.Select(x=> x.ToString()).ToArray(), ref sb, isString: true);
        sb.Append(',');

        sb.Append("\"testByte\":");
        sb.Append(testModel.TestByte);
        sb.Append(',');

        // sb.Append("\"testByteArray\":");
        // sb.Append('\"');
        // foreach (var byteItem in testModel.TestByteArray)
        // {
        //     sb.Append((char) byteItem);
        // }
        // sb.Append('\"');
        //
        // sb.Append(',');

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
        sb.Append(testModel.TestDate.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFZ"));
        sb.Append('\"');
        sb.Append(',');

        sb.Append("\"testTimeSpan\":");
        sb.Append('\"');
        sb.Append(testModel.TestTimeSpan.ToString("c"));
        sb.Append('\"');

        sb.Append('}');
    }
    
    private static string ToLiteral(string input)
    {
        using var writer = new StringWriter();
        using var provider = CodeDomProvider.CreateProvider("CSharp");
        provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
        
        return writer.ToString();
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

    private static T[] GetArray<T>(Faker faker, Func<Faker,T> action, int count)
    {
        var result = new T[count];

        for (var i = 0; i < count; i++)
        {
            result[i] = action.Invoke(faker);
        }

        return result;
    }
}