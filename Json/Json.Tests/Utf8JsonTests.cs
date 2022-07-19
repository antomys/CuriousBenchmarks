using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests for service <see cref="Utf8JsonService"/>.
/// </summary>
public sealed class Utf8JsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonDeserialize{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8JsonService.Utf8JsonDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonSerialize{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = Utf8JsonService.Utf8JsonSerialize(expectedModels);
        
        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonDeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8JsonService.Utf8JsonDeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonBytesSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonBytesSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = Utf8JsonService.Utf8JsonBytesSerializeBytes(expectedModels);
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonDeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestUtf8Bytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8JsonService.Utf8JsonDeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonDeserializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task Utf8JsonService_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestUtf8Bytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await Utf8JsonService.Utf8JsonDeserializeAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService.Utf8JsonSerializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task Utf8JsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await Utf8JsonService.Utf8JsonSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}