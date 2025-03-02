using BenchmarkDotNet.Running;

namespace Benchmarks.Stopwatch;

internal static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}