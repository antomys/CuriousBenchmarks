using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="ServiceStackService"/>
/// </summary>
public sealed class ServiceStackTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.ServiceStackDeserialize{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = ServiceStackService.ServiceStackDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.ServiceStackSerialize{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = ServiceStackService.ServiceStackSerialize(expectedModels);
        var actualModels = ServiceStackService.ServiceStackDeserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.ServiceStackDeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = ServiceStackService.ServiceStackDeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.ServiceStackSerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = ServiceStackService.ServiceStackSerializeStream(expectedModels);
        using var serializedMemoryStream = new MemoryStream(actualMemoryStream.ToArray());
        var actualModels = ServiceStackService.ServiceStackDeserializeStream<TestModel[]>(serializedMemoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.ServiceStackDeserializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task ServiceStackDeserializeStreamAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await ServiceStackService.ServiceStackDeserializeStreamAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}