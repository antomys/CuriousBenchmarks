using Benchmarks.GroupByVsDistinct.Models;
using Benchmarks.GroupByVsDistinct.Services;
using Bogus;

namespace Benchmark.Tests.Unit.Benchmark.GroupByVsDistinct;

/// <summary>
///     Tests of <see cref="LinqService" />.
/// </summary>
public sealed class LinqTests
{
    private const string InnerTestModelConstId = "InnerTestModelConstId";

    private Dictionary<string, InnerModel> _innerTestModels = new();

    private List<SimpleModel> _testModelsList = new();

    /// <summary>
    ///     Testing of method <see cref="LinqService.GroupByTake" />.
    /// </summary>
    /// <param name="amount">Amount of input test data</param>
    [Theory, InlineData(1), InlineData(2), InlineData(5), InlineData(10), InlineData(100)]
    public void GroupByTake_Returns_Exact_Amount(int amount)
    {
        // Arrange
        Setup(amount);
        var expectedAmount = amount + 1;

        // Act
        var actData = _testModelsList.GroupByTake(_innerTestModels, InnerTestModelConstId).ToArray();

        // Assert
        Assert.Equal(expectedAmount, actData.Length);
        Assert.True(actData.All(actItem => actItem.InnerId.Equals(InnerTestModelConstId, StringComparison.Ordinal)));
    }

    /// <summary>
    ///     Testing of method <see cref="LinqService.DistinctTake" />.
    /// </summary>
    /// <param name="amount">Amount of input test data</param>
    [Theory, InlineData(1), InlineData(2), InlineData(5), InlineData(10), InlineData(100)]
    public void DistinctTake_Returns_Exact_Amount(int amount)
    {
        // Arrange
        Setup(amount);
        var expectedAmount = amount + 1;

        // Act
        var actData = _testModelsList.DistinctTake(_innerTestModels, InnerTestModelConstId).ToArray();

        // Assert
        Assert.Equal(expectedAmount, actData.Length);
        Assert.True(actData.All(actItem => actItem.InnerId.Equals(InnerTestModelConstId, StringComparison.Ordinal)));
    }

    /// <summary>
    ///     Testing of method <see cref="LinqService.DistinctByTake" />.
    /// </summary>
    /// <param name="amount">Amount of input test data</param>
    [Theory, InlineData(1), InlineData(2), InlineData(5), InlineData(10), InlineData(100)]
    public void DistinctByTake_Returns_Exact_Amount(int amount)
    {
        // Arrange
        Setup(amount);
        var expectedAmount = amount + 1;

        // Act
        var actData = _testModelsList.DistinctByTake(_innerTestModels, InnerTestModelConstId).ToArray();

        // Assert
        Assert.Equal(expectedAmount, actData.Length);
        Assert.True(actData.All(actItem => actItem.InnerId.Equals(InnerTestModelConstId, StringComparison.Ordinal)));
    }

    private void Setup(int generationSize)
    {
        var faker = new Faker<SimpleModel>();
        var genericFaker = new Faker();

        _testModelsList = faker
            .RuleFor(simpleModel => simpleModel.Integer, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(simpleModel => simpleModel.InnerTestModelId, fakerSetter => fakerSetter.Random.String2(20))
            .RuleFor(simpleModel => simpleModel.DateOnly, fakerSetter => fakerSetter.Date.Past())
            .RuleFor(simpleModel => simpleModel.TestModelId, fakerSetter => fakerSetter.Random.String2(20))
            .Generate(generationSize);

        _testModelsList.AddRange(faker
            .RuleFor(simpleModel => simpleModel.Integer, fakerSetter => fakerSetter.Random.Int())
            .RuleFor(simpleModel => simpleModel.InnerTestModelId, _ => InnerTestModelConstId)
            .RuleFor(simpleModel => simpleModel.DateOnly, fakerSetter => fakerSetter.Date.Past())
            .RuleFor(simpleModel => simpleModel.TestModelId, fakerSetter => fakerSetter.Random.String2(20))
            .Generate(generationSize));

        var testModelFaker = new Faker<InnerModel>();

        _innerTestModels = testModelFaker
            .RuleFor(innerModel => innerModel.InnerId, fakerSetter => fakerSetter.Random.String2(20))
            .RuleFor(innerModel => innerModel.DateOnly, fakerSetter => fakerSetter.Date.Past())
            .RuleFor(innerModel => innerModel.Integer, fakerSetter => fakerSetter.Random.Int())
            .Generate(generationSize * 2 - 1)
            .ToDictionary(innerModel => innerModel.InnerId);

        _innerTestModels.Add(InnerTestModelConstId, new InnerModel
        {
            InnerId = InnerTestModelConstId,
            Integer = genericFaker.Random.Int(),
            DateOnly = genericFaker.Date.Past()
        });
    }
}