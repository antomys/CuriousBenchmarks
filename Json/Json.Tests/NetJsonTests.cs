using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of <see cref="NetJsonService"/>.
/// </summary>
public class NetJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="NetJsonService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    // Todo: cope with incorrect data deserializing. See https://github.com/rpgmaker/NetJSON/issues/242
    public void NetJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var expectedString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = NetJsonService.Serialize(expectedModels);
        //todo: cope with System.OutOfMemoryException: Array dimensions exceeded supported range.
        var actualModels = NetJsonService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
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
        var actualString = NetJsonService.Serialize(expectedModels);
        
        // // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
}