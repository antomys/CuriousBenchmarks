using System.Globalization;
using BenchmarkDotNet.Attributes;

namespace QueryBenchmarks;

[MemoryDiagnoser]
public class BoxingTest
{
    private readonly DateTime _something = DateTime.Now;

    [Benchmark(Baseline = true)]
    public void ConsoleWriteBoxing()
    {
        Console.WriteLine(_something);
    }
    
    [Benchmark]
    public void ConsoleWriteToString()
    {
        Console.WriteLine(_something.ToString(CultureInfo.CurrentCulture));
    }
}