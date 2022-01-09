# 1. Enum unboxing test

In this test i've benchmarked unboxing and different approaches to retrieve either name of value from enum.

 - BenchmarkDotNet=v0.13.1
 - OS=Windows 10.0.19044.1415 (21H2)
 - Intel Core i7-7500U CPU 2.70GHz (Kaby Lake)
   - 1 CPU
   - 4 logical and 2 physical cores
 - .NET SDK=6.0.101
[Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


|        Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
|-------------- |----------:|---------:|---------:|-------:|----------:|
| UnboxByString | 267.67 ns | 5.396 ns | 9.592 ns | 0.1683 |     352 B |
|   UnboxByCast |  75.36 ns | 1.499 ns | 1.329 ns | 0.0305 |      64 B |
|  EnumToString | 427.66 ns | 7.960 ns | 7.446 ns | 0.1373 |     288 B |
|   EnumGetName | 386.31 ns | 7.308 ns | 6.836 ns |      - |         - |

## Conclusion :

1. Best way to take enum int value is `((int) @enum).ToString();`.
2. Best way to get enum name is `Enum.GetName(@enum);`


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
    }`
