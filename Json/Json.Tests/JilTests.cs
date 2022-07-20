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
    ///     Unit testing of method <see cref="JilService.JilDeserialize{T}"/>.
    /// </summary>
    [Fact]
    public void JilDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestJilString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = JilService.JilDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.JilSerialize{T}"/>.
    /// </summary>
    [Fact]
    public void JilSerialize_Returns_ValidModel()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = JilService.JilSerialize(expectedModels);
        var actualModels = JilService.JilDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.JilDeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void JilDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestJilBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = JilService.JilDeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.JilSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void JilSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = JilService.JilSerializeBytes(expectedModels);
        var actualModels = JilService.JilDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="JilService.JilSerializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task JilSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await JilService.JilSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        var actualModels = JilService.JilDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}