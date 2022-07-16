using FluentAssertions;
using Json.Benchmarks.Services;
using Json.Tests.Models;
using Xunit;

namespace Json.Tests;

/// <summary>
///     Unit tests of service <see cref="NewtonsoftService{T}"/>.
/// </summary>
public sealed class NewtonsoftJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = NewtonsoftService<TestModel>.NewtonsoftDeserialize(actualString);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonSerialize"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = NewtonsoftService<TestModel>.NewtonsoftSerialize(expectedModels);
        
        // Assert
        actualString.Should().BeEquivalentTo(expectedString);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService{T}.SystemTextJsonDeserialize"/>.
    /// </summary>
    [Fact]
    public void NewtonsoftDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var actualBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = NewtonsoftService<TestModel>.NewtonsoftDeserializeBytes(actualBytes);
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}