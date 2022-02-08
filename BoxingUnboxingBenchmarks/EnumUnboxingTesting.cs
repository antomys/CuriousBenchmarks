using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters.Csv;

namespace BoxingUnboxingBenchmarks;

[MemoryDiagnoser]
[RankColumn, MinColumn, MaxColumn, Q1Column, Q3Column, AllStatisticsColumn]
[JsonExporterAttribute.Full, CsvMeasurementsExporter, CsvExporter(CsvSeparator.Comma), HtmlExporter, MarkdownExporterAttribute.GitHub]
public class EnumUnboxingTesting
{
    private readonly Consumer _consumer = new();
    
    private static readonly TestEnum[] TestEnums = {
        TestEnum.None,
        TestEnum.None1,
        TestEnum.None11,
        TestEnum.None111,
        TestEnum.Something,
        TestEnum.Something1,
        TestEnum.Something11,
        TestEnum.Something111,
        TestEnum.Anything,
        TestEnum.Anything1,
        TestEnum.Anything11,
        TestEnum.Anything111,
    };
    
    [Benchmark]
    public void UnboxByString()
    {
        foreach (var @enum in TestEnums)
        {
            @enum.ToString("D").Consume(_consumer);
        }
    }

    [Benchmark]
    public void UnboxByCast()
    {
        foreach (var @enum in TestEnums)
        {
            ((int) @enum).ToString().Consume(_consumer);
        }
    }

    [Benchmark]
    public void EnumToString()
    {
        foreach (var @enum in TestEnums)
        {
            @enum.ToString().Consume(_consumer);
        }
    }
    
    [Benchmark]
    public void EnumGetName()
    {
        foreach (var @enum in TestEnums)
        {
            Enum.GetName(@enum).Consume(_consumer);
        }
    }
}