using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="ServiceStackService{T}"/>
/// </summary>
public sealed class ServiceStackTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService{T}.ServiceStackDeserialize"/>.
    /// </summary>
    [Fact]
    public void FastJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = ServiceStackService<TestModel>.ServiceStackDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService{T}.ServiceStackSerialize"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = ServiceStackService<TestModel>.ServiceStackSerialize(expectedModels);
        var actualModels = ServiceStackService<TestModel>.ServiceStackDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService{T}.ServiceStackDeserializeStream"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = ServiceStackService<TestModel>.ServiceStackDeserializeStream(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService{T}.ServiceStackSerializeStream"/>.
    /// </summary>
    [Fact]
    public void ServiceStackSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = ServiceStackService<TestModel>.ServiceStackSerializeStream(expectedModels);
        using var serializedMemoryStream = new MemoryStream(actualMemoryStream.ToArray());
        var actualModels = ServiceStackService<TestModel>.ServiceStackDeserializeStream(serializedMemoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService{T}.ServiceStackDeserializeStreamAsync"/>.
    /// </summary>
    [Fact]
    public async Task ServiceStackDeserializeStreamAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await ServiceStackService<TestModel>.ServiceStackDeserializeStreamAsync(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}