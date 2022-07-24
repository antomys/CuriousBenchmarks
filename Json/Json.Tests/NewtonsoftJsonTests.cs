using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="NewtonsoftService"/>.
/// </summary>
public sealed class NewtonsoftJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="NewtonsoftService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = NewtonsoftService.Deserialize<TestModel[]>(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="NewtonsoftService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = NewtonsoftService.Serialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="NewtonsoftService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var actualBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = NewtonsoftService.DeserializeBytes<TestModel[]>(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}