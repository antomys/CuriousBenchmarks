using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of <see cref="SystemTextJsonService{T}"/>
/// </summary>
public sealed class SystemTextJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService<TestModel>.SystemTextJsonDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerialize"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = SystemTextJsonService<TestModel>.SystemTextJsonSerialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserializeBytes"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService<TestModel>.SystemTextJsonDeserializeBytes(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = SystemTextJsonService<TestModel>.SystemTextJsonSerializeBytes(expectedModels);
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = SystemTextJsonService<TestModel>.SystemTextJsonDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerializeStream"/>.
    /// </summary>
    [Fact]
    public void SystemTextJsonSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = SystemTextJsonService<TestModel>.SystemTextJsonSerializeStream(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserializeStream"/>.
    /// </summary>
    [Fact]
    public async Task SystemTextJsonDeserializeAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await SystemTextJsonService<TestModel>.SystemTextJsonDeserializeAsync(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerializeStream"/>.
    /// </summary>
    [Fact]
    public async Task SystemTextJsonSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await SystemTextJsonService<TestModel>.SystemTextJsonSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        
        // Assert
        actualBytes.Should().BeEquivalentTo(expectedBytes);
    }
}