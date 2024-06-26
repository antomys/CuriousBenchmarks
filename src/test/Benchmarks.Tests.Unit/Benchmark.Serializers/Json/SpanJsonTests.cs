﻿using Benchmarks.Tests.Unit.Benchmark.Serializers.Models;
using FluentAssertions;
using SpanJson;

namespace Benchmarks.Tests.Unit.Benchmark.Serializers.Json;

/// <summary>
///     Unit tests of service <see cref="SpanJsonService" />.
/// </summary>
public sealed class SpanJsonTests
{
    /// <summary>
    ///     Unit testing of method <see cref="SystemTextJsonService.Deserialize{T}" />.
    /// </summary>
    [Fact]
    public void SpanJsonDeserialize_Returns_ValidModels()
    {
        // Arrange
        var actualString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = JsonSerializer.Generic.Utf16.Deserialize<TestModel[]>(actualString);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.Serialize{T}" />.
    /// </summary>
    [Fact]
    public void SpanJsonSerialize_Returns_ValidString()
    {
        // Arrange
        var expectedString = TestsBase.GetTestString();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualString = JsonSerializer.Generic.Utf16.Serialize(expectedModels);

        // Assert
        Assert.Equal(expectedString, actualString);
        actualString.Should().BeEquivalentTo(expectedString);
    }

    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.DeserializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void SpanJsonDeserializeBytes_Returns_ValidModels()
    {
        // Arrange
        var expectedBytes = TestsBase.GetTestBytes();
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualModels = JsonSerializer.Generic.Utf8.Deserialize<TestModel[]>(expectedBytes);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }

    /// <summary>
    ///     Unit testing of method <see cref="SpanJsonService.SerializeBytes{T}" />.
    /// </summary>
    [Fact]
    public void SpanJsonSerializeBytes_Returns_ValidString()
    {
        // Arrange
        var expectedModels = TestsBase.GetTestModels();

        // Act
        var actualBytes = JsonSerializer.Generic.Utf8.Serialize(expectedModels);
        var actualModels = JsonSerializer.Generic.Utf8.Deserialize<TestModel[]>(actualBytes);

        // Assert
        actualModels.Should().BeEquivalentTo(expectedModels);
    }
}