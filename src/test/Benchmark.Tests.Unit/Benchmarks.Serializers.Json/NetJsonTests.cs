using Benchmark.Tests.Unit.Benchmarks.Serializers.Json.Models;
using Benchmarks.Serializers.Json.Extensions;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmarks.Serializers.Json;

/// <summary>
///     Unit tests of <see cref="NetJsonService"/>.
/// </summary>
public class NetJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="NetJsonService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void NetJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var expectedString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = NetJSON.NetJSON.Serialize(expectedModels);
        var actualModels = NetJSON.NetJSON.Deserialize<ICollection<TestModel>>(actualString, JsonServiceExtensions.NetJsonOptions);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="NetJsonService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void NetJsonSerialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = NetJSON.NetJSON.Serialize(expectedModels);
        
        // // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
}