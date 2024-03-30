using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using Benchmark.Serializers.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;

namespace Benchmarks.Serializers.Json.Benchmarks;

[MemoryDiagnoser,
 CategoriesColumn,
 AllStatisticsColumn,
 Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), ExcludeFromCodeCoverage]
public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker" /> for <see cref="SimpleModel" />.
    /// </summary>
    private readonly static Faker<SimpleModel> Faker = new();

    private byte[] _testBytes = [];

    private string _testString = string.Empty;

    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 100, 1000)]
    public int CollectionSize { get; set; }

    /// <summary>
    ///     Setting private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        var models = Faker
            .RuleFor(model => model.TestBool, faker => faker.Random.Bool())
            .RuleFor(model => model.TestInt, faker => faker.Random.Int())
            .RuleFor(model => model.TestString, faker => faker.Name.FullName())
            .Generate(CollectionSize);

        var sb = new StringBuilder();
        sb.Append('[');

        var span = CollectionsMarshal.AsSpan(models);

        for (var i = 0; i < span.Length - 1; i++)
        {
            sb.Append(span[i]);
            sb.Append(',');
        }

        sb.Append(span[^1]);
        sb.Append(']');

        _testString = sb.ToString();
        _testBytes = Encoding.UTF8.GetBytes(_testString);
    }
}