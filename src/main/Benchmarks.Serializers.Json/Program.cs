using BenchmarkDotNet.Running;
using Benchmarks.Serializers.Json.Models;
using JsonSrcGen;

[assembly: JsonArray(typeof(ComplexSrcGenModel))]
[assembly: JsonArray(typeof(SimpleSrcGenModel))]

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();