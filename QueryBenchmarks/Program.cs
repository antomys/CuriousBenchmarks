using BenchmarkDotNet.Running;
using QueryBenchmarks.Benchmarks;

BenchmarkRunner.Run<UriCombineBenchmarks>();

BenchmarkRunner.Run<QueryBuilderBenchmarks>();