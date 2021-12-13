using BenchmarkDotNet.Running;

namespace QueryBenchmarks;

class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<HttpMethods>();
    }
}