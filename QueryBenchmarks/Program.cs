using BenchmarkDotNet.Running;
using QueryBenchmarks;

var _ = BenchmarkRunner.Run<UriCombineTests>();