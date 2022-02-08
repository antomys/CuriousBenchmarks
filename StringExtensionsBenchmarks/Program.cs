using BenchmarkDotNet.Running;
using StringExtensionsBenchmarks;

var _ = BenchmarkRunner.Run<StringExtensionsTests>();

BenchmarkRunner.Run<InterpolationTests>();