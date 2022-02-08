// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using JsonBenchmarks;

var _ = BenchmarkRunner.Run<DeserializationBenchmarks>();

BenchmarkRunner.Run<SerializationBenchmarks>();