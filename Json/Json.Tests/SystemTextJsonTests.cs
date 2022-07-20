using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of <see cref="SystemTextJsonService"/>
/// </summary>
public sealed class SystemTextJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonDeserialize{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService.SystemTextJsonDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonSerialize{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = SystemTextJsonService.SystemTextJsonSerialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonDeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService.SystemTextJsonDeserializeBytes<TestModel[]>(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonSerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = SystemTextJsonService.SystemTextJsonSerializeBytes(expectedModels);
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonDeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService.SystemTextJsonDeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = SystemTextJsonService.SystemTextJsonSerializeStream(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonDeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public async Task SystemTextJsonDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await SystemTextJsonService.SystemTextJsonDeserializeAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.SystemTextJsonSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public async Task SystemTextJsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await SystemTextJsonService.SystemTextJsonSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}