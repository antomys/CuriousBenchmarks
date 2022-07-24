using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="JilService"/>.
/// </summary>
public sealed class JilTests
{
    /// <summary>
    ///     Unit testing of method <see cref="JilService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void JilDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestJilString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = JilService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void JilSerialize_Returns_ValidModel()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = JilService.Serialize(expectedModels);
        var actualModels = JilService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void JilDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestJilBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = JilService.DeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void JilSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = JilService.SerializeBytes(expectedModels);
        var actualModels = JilService.DeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="JilService.SerializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task JilSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await JilService.SerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        var actualModels = JilService.DeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}