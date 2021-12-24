using BenchmarkDotNet.Running;
using QueryBenchmarks.JsonSourceGen;

namespace QueryBenchmarks;

class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<SerializationBenchmarks>();
    } 
}