using BenchmarkDotNet.Attributes;

namespace QueryBenchmarks;

internal enum TestEnum
{
    None = 0,
    Something = 1,
    Anything = 2
}

[MemoryDiagnoser]
public class EnumUnboxingTesting
{

    [Benchmark]
    public void UnboxByString()
    {
        TestEnum.None.ToString("D");
        TestEnum.Something.ToString("D");
        TestEnum.Anything.ToString("D");
    }

    [Benchmark]
    public void UnboxByShit()
    {
        ((int) TestEnum.None).ToString();
        ((int) TestEnum.Anything).ToString();
        ((int) TestEnum.Something).ToString();
    }
}