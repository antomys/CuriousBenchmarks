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
    ///     Unit testing of method <see cref="ServiceStackService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = ServiceStackService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = ServiceStackService.Serialize(expectedModels);
        var actualModels = ServiceStackService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.DeserializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackDeserializeStream_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = ServiceStackService.DeserializeStream<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.SerializeStream{T}"/>.
    /// </summary>
    [Fact]
    public void ServiceStackSerializeStream_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = ServiceStackService.SerializeStream(expectedModels);
        using var serializedMemoryStream = new MemoryStream(actualMemoryStream.ToArray());
        var actualModels = ServiceStackService.DeserializeStream<TestModel[]>(serializedMemoryStream);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStackService.DeserializeStreamAsync{T}"/>.
    /// </summary>
    [Fact]
    public async Task ServiceStackDeserializeStreamAsync_Returns_ValidModels()
    {
        // Arrange
        using var ms = new MemoryStream();
        ms.Write(TestsBase.GetTestBytes());
        
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = await ServiceStackService.DeserializeStreamAsync<TestModel[]>(ms);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}