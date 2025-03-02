using BenchmarkDotNet.Running;

namespace Benchmarks.Flattening;

internal static class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}