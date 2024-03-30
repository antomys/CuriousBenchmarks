using Benchmark.Tests.Unit.Benchmark.Serializers.Models;
using Benchmarks.Serializers.Json.Extensions;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Unit tests of <see cref="NetJsonService" />.
/// </summary>
public class NetJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="NetJsonService.Deserialize{T}" />.
    /// </summary>
    [Fact]
    public void NetJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualString = NetJSON.NetJSON.Serialize(expectedModels);
        var actualModels = NetJSON.NetJSON.Deserialize<ICollection<TestModel>>(actualString, JsonServiceExtensions.NetJsonOptions);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
        actualString.Should().BeEquivalentTo(expectedString);
    }

    /// <summary>
    ///     Unit testing of method <see cref="NetJsonService.Serialize{T}" />.
    /// </summary>
    [Fact]
    public void NetJsonSerialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualString = NetJSON.NetJSON.Serialize(expectedModels, JsonServiceExtensions.NetJsonOptions);

        // // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
}