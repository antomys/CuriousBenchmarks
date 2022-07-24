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
    ///     Unit testing of method <see cref="SystemTextJsonService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = SpanJsonService.Serialize(expectedModels);
        
        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService.DeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = SpanJsonService.SerializeBytes(expectedModels);
        var actualModels = SpanJsonService.DeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService.DeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.DeserializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task SpanJsonDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await SpanJsonService.DeserializeStreamAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SerializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task SpanJsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await SpanJsonService.SerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}