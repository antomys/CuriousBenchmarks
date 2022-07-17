using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="JilService{T}"/>.
/// </summary>
public sealed class JilTests
{
    /// <summary>
    ///     Unit testing of method <see cref="JilService{T}.JilDeserialize"/>.
    /// </summary>
    [Fact]
    public void JilDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestJilString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = JilService<TestModel>.JilDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService{T}.JilSerialize"/>.
    /// </summary>
    [Fact]
    public void JilSerialize_Returns_ValidModel()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = JilService<TestModel>.JilSerialize(expectedModels);
        var actualModels = JilService<TestModel>.JilDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService{T}.JilDeserializeBytes"/>.
    /// </summary>
    [Fact]
    public void JilDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestJilBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = JilService<TestModel>.JilDeserializeBytes(expectedBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService{T}.JilSerializeBytes"/>.
    /// </summary>
    [Fact]
    public void JilSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = JilService<TestModel>.JilSerializeBytes(expectedModels);
        var actualModels = JilService<TestModel>.JilDeserializeBytes(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="JilService{T}.JilSerializeStreamAsync"/>.
    /// </summary>
    [Fact]
    public async Task JilSerializeStreamAsync_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        using var actualMemoryStream = await JilService<TestModel>.JilSerializeStreamAsync(expectedModels);
        var actualBytes = actualMemoryStream.ToArray();
        var actualModels = JilService<TestModel>.JilDeserializeBytes(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}