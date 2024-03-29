using Benchmarks.Serializers.Json.Models.SrcGen;

[assembly: JsonSrcGen.JsonArray(typeof(ComplexSrcGenModel))]
[assembly: JsonSrcGen.JsonArray(typeof(SimpleSrcGenModel))]

BenchmarkDotNet.Running.BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();