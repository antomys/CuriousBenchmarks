using BenchmarkDotNet.Running;
using Benchmarks.SortArrayByArray;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();