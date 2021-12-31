// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BoxingUnboxingBenchmarks;

var _ = BenchmarkRunner.Run<EnumUnboxingTesting>();