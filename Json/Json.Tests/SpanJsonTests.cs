using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="SpanJsonService"/>.
/// </summary>
public sealed class SpanJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonDeserialize{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService.SpanJsonDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SpanJsonSerialize{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = SpanJsonService.SpanJsonSerialize(expectedModels);
        
        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SpanJsonDeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService.SpanJsonDeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SpanJsonSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = SpanJsonService.SpanJsonSerializeBytes(expectedModels);
        var actualModels = SpanJsonService.SpanJsonDeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SpanJsonDeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService.SpanJsonDeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SpanJsonDeserializeAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task SpanJsonDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await SpanJsonService.SpanJsonDeserializeAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SpanJsonSerializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task SpanJsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await SpanJsonService.SpanJsonSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}