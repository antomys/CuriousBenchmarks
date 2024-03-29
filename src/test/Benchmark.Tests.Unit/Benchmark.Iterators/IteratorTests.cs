using Benchmarks.Iterators.Models;
using Benchmarks.Iterators.Services;
using Bogus;

namespace Benchmark.Tests.Unit.Benchmark.Iterators;

/// <summary>
///     Tests for "Iterators.Benchmarks.Services.IterationService"..
/// </summary>
public sealed class IteratorTests
{
    /// <summary>
    ///     Unit testing method "IterationService.For".
    /// </summary>
    /// <param name="size">Size of a testing collection.</param>
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void For_ShouldReturn_SerializedValues(int size)
    {
        // Arrange
        var dictionaryTestModels = SetupTestModels(size).ToDictionary(model => model.JsonModel, model => model.SimpleModel);
        var simpleModels = dictionaryTestModels.Select(model => model.Value).ToList();

        // Act
        var jsonCollection = simpleModels.For();
        
        // Assert
        Assert.True(dictionaryTestModels.Keys.All(value=> jsonCollection.Contains(value)));
    }
    
    /// <summary>
    ///     Unit testing method "IterationService.Foreach".
    /// </summary>
    /// <param name="size">Size of a testing collection.</param>
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Foreach_ShouldReturn_SerializedValues(int size)
    {
        // Arrange
        var dictionaryTestModels = SetupTestModels(size).ToDictionary(model => model.JsonModel, model => model.SimpleModel);
        var simpleModels = dictionaryTestModels.Select(model => model.Value).ToList();

        // Act
        var jsonCollection = simpleModels.Foreach();
        
        // Assert
        Assert.True(dictionaryTestModels.Keys.All(value=> jsonCollection.Contains(value)));
    }
    
    /// <summary>
    ///     Unit testing method "IterationService.Linq".
    /// </summary>
    /// <param name="size">Size of a testing collection.</param>
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Linq_ShouldReturn_SerializedValues(int size)
    {
        // Arrange
        var dictionaryTestModels = SetupTestModels(size).ToDictionary(model => model.JsonModel, model => model.SimpleModel);
        var simpleModels = dictionaryTestModels.Select(model => model.Value).ToList();

        // Act
        var jsonCollection = simpleModels.Linq();
        
        // Assert
        Assert.True(dictionaryTestModels.Keys.All(value=> jsonCollection.Contains(value)));
    }
    
    /// <summary>
    ///     Unit testing method "IterationService.Yield".
    /// </summary>
    /// <param name="size">Size of a testing collection.</param>
    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Yield_ShouldReturn_SerializedValues(int size)
    {
        // Arrange
        var dictionaryTestModels = SetupTestModels(size).ToDictionary(model => model.JsonModel, model => model.SimpleModel);
        var simpleModels = dictionaryTestModels.Select(model => model.Value).ToList();

        // Act
        var jsonCollection = simpleModels.Yield();
        
        // Assert
        Assert.True(dictionaryTestModels.Keys.All(value=> jsonCollection.Contains(value)));
    }
    
    /// <summary>
    ///     Arranges collection of "TestModel"..
    /// </summary>
    /// <returns>List of "TestModel"..</returns>
    private static IEnumerable<TestModel> SetupTestModels(int size)
    {
        var faker = new Faker<SimpleModel>();
        Randomizer.Seed = new Random(420);
        
        var testInputModels = faker
            .RuleFor(testModel => testModel.TestInd, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(testModel => testModel.TestString, fakerSetter=> fakerSetter.Random.String2(10))
            .RuleFor(testModel => testModel.TestDateTime, fakerSetter=> fakerSetter.Date.Past())
            .Generate(size)!;

        return testInputModels.Select(model => new TestModel(model));
    }
}