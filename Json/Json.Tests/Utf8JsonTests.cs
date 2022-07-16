using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests for service <see cref="Utf8JsonService{T}"/>.
/// </summary>
public sealed class Utf8JsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8JsonService<TestModel>.Utf8JsonDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonSerialize"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestUtf8String();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = Utf8JsonService<TestModel>.Utf8JsonSerialize(expectedModels);
        
        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonDeserializeBytes"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8JsonService<TestModel>.Utf8JsonDeserializeBytes(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonBytesSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonBytesSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = Utf8JsonService<TestModel>.Utf8JsonBytesSerializeBytes(expectedModels);
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void Utf8JsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestUtf8Bytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Utf8JsonService<TestModel>.Utf8JsonDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonDeserializeAsync"/>.
    /// </summary>
    [Fact]
    public async Task Utf8JsonService_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestUtf8Bytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await Utf8JsonService<TestModel>.Utf8JsonDeserializeAsync(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="Utf8JsonService{T}.Utf8JsonSerializeStreamAsync"/>.
    /// </summary>
    [Fact]
    public async Task Utf8JsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestUtf8Bytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await Utf8JsonService<TestModel>.Utf8JsonSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}