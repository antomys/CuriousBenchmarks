using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;

namespace BoxingUnboxing.Benchmarks.Benchmarks;

/// <summary>
///     Enum boxing/unboxing benchmarks base.
/// </summary>
[MemoryDiagnoser]
[CategoriesColumn, AllStatisticsColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MarkdownExporterAttribute.GitHub, CsvMeasurementsExporter, RPlotExporter]
public class EnumBenchmarksBase
{
    /// <summary>
    ///     <see cref="Consumer"/>.
    /// </summary>
    protected static readonly Consumer Consumer = new();
    /// <summary>
    ///     Collection of enums.
    /// </summary>
    protected static TestEnum[] TestEnums = default!;

    /// <summary>
    ///     Global setup of private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        TestEnums = new []
        {
            TestEnum.First,
            TestEnum.Second,
            TestEnum.Third,
            TestEnum.Fourth,
            TestEnum.Fifth,
            TestEnum.Sixth,
            TestEnum.Seventh,
            TestEnum.Eighth,
            TestEnum.Ninth,
            TestEnum.Tenth,
            TestEnum.Eleventh,
            TestEnum.Twelfth
        };
    }
}