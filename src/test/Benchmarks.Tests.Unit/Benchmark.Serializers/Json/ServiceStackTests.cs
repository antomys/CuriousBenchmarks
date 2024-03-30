using Benchmarks.Serializers.Json.Extensions;
using Benchmarks.Tests.Unit.Benchmark.Serializers.Models;
using FluentAssertions;
using ServiceStack.Text;

namespace Benchmarks.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Unit tests of service <see cref="ServiceStack" />
/// </summary>
public sealed class ServiceStackTests
{
    /// <summary>
    ///     Unit testing of method <see cref="ServiceStack.Text.JsonSerializer" />.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        TestModel[] actualModels;

        using (JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            actualModels = JsonSerializer.DeserializeFromSpan<TestModel[]>(actualString);
        }

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="ServiceStack.Text.JsonSerializer" />.
    /// </summary>
    [Fact]
    public void ServiceStackDeserialize_Returns_ValidStringModels()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();

        // Act
        TestModel[] actualModels;

        using (JsConfig.With(JsonServiceExtensions.ServiceStackOptions))
        {
            var actualString = JsonSerializer.SerializeToString(expectedModels);
            actualModels = JsonSerializer.DeserializeFromSpan<TestModel[]>(actualString);
        }

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}