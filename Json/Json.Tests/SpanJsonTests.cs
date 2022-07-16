using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="SpanJsonService{T}"/>.
/// </summary>
public sealed class SpanJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService<TestModel>.SpanJsonDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService{T}.SpanJsonSerialize"/>.
    /// </summary>
    [Fact]
    public void SpanJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = SpanJsonService<TestModel>.SpanJsonSerialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService{T}.SpanJsonDeserializeBytes"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService<TestModel>.SpanJsonDeserializeBytes(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService{T}.SpanJsonDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SpanJsonService<TestModel>.SpanJsonDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService{T}.SpanJsonDeserializeAsync"/>.
    /// </summary>
    [Fact]
    public async Task SpanJsonDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await SpanJsonService<TestModel>.SpanJsonDeserializeAsync(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService{T}.SpanJsonSerializeStreamAsync"/>.
    /// </summary>
    [Fact]
    public async Task SpanJsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await SpanJsonService<TestModel>.SpanJsonSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}