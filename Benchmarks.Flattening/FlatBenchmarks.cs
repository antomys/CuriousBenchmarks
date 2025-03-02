using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Bogus;

namespace Benchmarks.Flattening;

[MemoryDiagnoser, MarkdownExporter, CategoriesColumn, AllStatisticsColumn, Orderer(SummaryOrderPolicy.FastestToSlowest),
 GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory), ExcludeFromCodeCoverage]
public class FlatBenchmarks
{
    /// <summary>
    ///     Gets collection of enums.
    /// </summary>
    private UnflatModel _model = null!;

    /// <summary>
    ///     Global setup of private fields.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
        _model = new Faker<UnflatModel>()
            .RuleFor(x => x.InternalModel, y => new InternalModel
            {
                Address = y.Address.FullAddress(),
                City = y.Address.City(),
                Country = y.Address.Country(),
            })
            .RuleFor(x => x.IsEmailConfirmed, y => y.Random.Bool())
            .RuleFor(x => x.Email, y => y.Person.Email)
            .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
            .RuleFor(x => x.IsPhoneConfirmed, y => y.Random.Bool())
            .Generate(1)
            .First();
    }

    [Benchmark(Description = "ToFlat with reflection")]
    public Dictionary<string, string?> ToFlatReflection()
    {
        return ToFlatModelReflection(_model);
    }
    
    [Benchmark(Description = "ToFlat direct model")]
    public Dictionary<string, string?>? ToFlatDirectModel()
    {
        return ToFlatModel(_model);
    }
    
    private static Dictionary<string, string?>? ToFlatModel(UnflatModel request)
    {
        var flatModel = new Dictionary<string, string?>();

        AddIfNotNull(flatModel, "email", request.Email);
        AddIfNotNull(flatModel, "isEmailTrusted", request.IsEmailConfirmed);
        AddIfNotNull(flatModel, "isPhoneTrusted", request.IsPhoneConfirmed);
        AddIfNotNull(flatModel, "phone", request.Phone);

        if (request.InternalModel is null)
        {
            return flatModel;
        }

        AddIfNotNull(flatModel, "address", request.InternalModel.Address);
        AddIfNotNull(flatModel, "city", request.InternalModel.City);
        AddIfNotNull(flatModel, "country", request.InternalModel.Country);

        return flatModel;
    }

    private static void AddIfNotNull(Dictionary<string, string?> dict, string key, object? value)
    {
        if (value is not null)
            dict[key] = value.ToString();
    }

    private static Dictionary<string, string?> ToFlatModelReflection(object request)
    {
        if (request is null)
        {
            return new Dictionary<string, string?>();
        }

        var flatModel = new Dictionary<string, string?>();
        var type = request.GetType();

        foreach (var prop in type.GetProperties())
        {
            var value = prop.GetValue(request);

            if (value is null)
                continue;

            var key = prop.Name;

            if (value is string || value is bool || value is DateTime || value.GetType().IsPrimitive)
            {
                flatModel.TryAdd(key, value.ToString());
                continue;
            }

            foreach (var kvp in ToFlatModelReflection(value))
            {
                flatModel.TryAdd(kvp.Key, kvp.Value);
            }
        }

        return flatModel;
    }
}