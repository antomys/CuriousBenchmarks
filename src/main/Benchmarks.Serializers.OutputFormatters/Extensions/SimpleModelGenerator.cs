using Benchmarks.Serializers.Models;
using Bogus;

namespace Benchmarks.Serializers.OutputFormatters.Extensions;

public static class SimpleModelGenerator
{
    public readonly static ICollection<SimpleModel> SimpleModels = new Faker<SimpleModel>()
        .RuleFor(model => model.TestBool, y=> y.Random.Bool())
        .RuleFor(model => model.TestInt, y=> y.Random.Int())
        .RuleFor(model => model.TestString, y=> y.Name.FullName())
        .Generate(100);
}