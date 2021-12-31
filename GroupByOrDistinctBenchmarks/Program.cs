// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using GroupByOrDistinctBenchmarks;

var _ = BenchmarkRunner.Run<GroupByTest>();