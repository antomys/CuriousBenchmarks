using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Benchmarks.Serializers.Json.Models;

namespace Benchmarks.Serializers.Json.Benchmarks;

[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public partial class DeserializationBenchmark
{
    /// <summary>
    ///     Static <see cref="Faker"/> for <see cref="SimpleModel"/>.
    /// </summary>
    private readonly static Bogus.Faker<SimpleModel> Faker = new();
    
    /// <summary>
    ///     Size of generation.
    ///     **NOTE:** Intentionally left public for BenchmarkDotNet Params.
    /// </summary>
    [Params(1, 100, 1000)]
    public int CollectionSize { get; set; }

    private string _testString = string.Empty;

    private byte[] _testBytes = [];

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

        for (int i = 0; i < span.Length - 1; i++)
        {
            sb.Append(span[i].ToString());
            sb.Append(',');
        }
        sb.Append(span[^1].ToString());
        sb.Append(']');

        _testString = sb.ToString();
    }
}