using System.Text;
using Benchmark.Tests.Unit.Benchmarks.Serializers.Json.Models;
using Benchmarks.Serializers.Json.Extensions;
using FluentAssertions;

namespace Benchmark.Tests.Unit.Benchmarks.Serializers.Json;

/// <summary>
///     Unit tests of service <see cref="JilService"/>.
/// </summary>
public sealed class JilTests
{
    /// <summary>
    ///     Unit testing of method <see cref="JilService.Deserialize{T}"/>.
    /// </summary>
    [Fact]
    public void JilDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestJilString();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels =Jil.JSON.Deserialize<TestModel>(actualString, JsonServiceExtensions.JilOptions)!;
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.Serialize{T}"/>.
    /// </summary>
    [Fact]
    public void JilSerialize_Returns_ValidModel()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualString = Jil.JSON.Serialize(expectedModels, JsonServiceExtensions.JilOptions);
        var actualModels = Jil.JSON.Deserialize<TestModel[]>(actualString, JsonServiceExtensions.JilOptions)!;
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.DeserializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void JilDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestJilBytes();
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualModels = Jil.JSON.Deserialize<TestModel[]>(Encoding.UTF8.GetString(expectedBytes), JsonServiceExtensions.JilOptions)!;
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
    
    /// <summary>
    ///     Unit testing of method <see cref="JilService.SerializeBytes{T}"/>.
    /// </summary>
    [Fact]
    public void JilSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();
        
        // Act
        var actualBytes = Encoding.UTF8.GetBytes(Jil.JSON.Serialize(expectedModels));
        var actualModels = Jil.JSON.Deserialize<TestModel[]>(Encoding.UTF8.GetString(actualBytes), JsonServiceExtensions.JilOptions)!;
        
        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}