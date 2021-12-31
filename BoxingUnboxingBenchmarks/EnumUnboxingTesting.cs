using BenchmarkDotNet.Attributes;

namespace BoxingUnboxingBenchmarks;

internal enum TestEnum
{
    None = 0,
    Something = 1,
    Anything = 2,
    None1 = 3,
    Something1 = 4,
    Anything1 = 5,
    None11 = 6,
    Something11 = 7,
    Anything11 = 8,
    None111 = 9,
    Something111 = 11,
    Anything111 = 10,
}

[MemoryDiagnoser]
public class EnumUnboxingTesting
{
    private static readonly TestEnum[] _testEnums = {
        TestEnum.None,
        TestEnum.None1,
        TestEnum.None11,
        TestEnum.None111,
        TestEnum.Something,
        TestEnum.Something1,
        TestEnum.Something11,
        TestEnum.Something111,
        TestEnum.Anything,
        TestEnum.Anything1,
        TestEnum.Anything11,
        TestEnum.Anything111,
    };
    
    [Benchmark]
    public void UnboxByString()
    {
        foreach (var @enum in _testEnums)
        {
            @enum.ToString("D");
        }
    }

    [Benchmark]
    public void UnboxByCast()
    {
        foreach (var @enum in _testEnums)
        {
            ((int) @enum).ToString();
        }
    }

    [Benchmark]
    public void EnumToString()
    {
        foreach (var @enum in _testEnums)
        {
            @enum.ToString();
        }
    }
    
    [Benchmark]
    public void EnumGetName()
    {
        foreach (var @enum in _testEnums)
        {
            Enum.GetName(@enum);
        }
    }
}