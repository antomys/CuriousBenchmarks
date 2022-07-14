using MlkPwgen;
using String.Benchmarks.Services;
using Xunit;

namespace String.Tests;

/// <summary>
///     Test of <see cref="GenerationService"/>.
/// </summary>
public sealed class GenerationTests
{
    private const char EofChar = '\0';

    /// <summary>
    ///     Test of 'GenerationService.GetUniqueOriginal' method.
    /// </summary>
    /// <param name="length">Generation length.</param>
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void GetUniqueOriginal_Returns_RightString(int length)
    {
        //  Act
        var generatedString = GenerationService.GetUniqueOriginal(length);
        
        // Assert
        Assert.True(generatedString.Length == length);
        Assert.True(generatedString.IndexOf(EofChar) is -1);
    }
    
    /// <summary>
    ///     Test of 'GenerationService.GetUniqueHashSet' method.
    /// </summary>
    /// <param name="length">Generation length.</param>
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void GetUniqueHashSet_Returns_RightString(int length)
    {
        //  Act
        var generatedString = GenerationService.GetUniqueHashSet(length);
        
        // Assert
        Assert.True(generatedString.Length == length);
        Assert.True(generatedString.IndexOf(EofChar) is -1);
    }
    
    /// <summary>
    ///     Test of 'GenerationService.GetUniqueSpanOwner' method.
    /// </summary>
    /// <param name="length">Generation length.</param>
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void GetUniqueSpanOwner_Returns_RightString(int length)
    {
        //  Act
        var generatedString = GenerationService.GetUniqueSpanOwner(length);
        
        // Assert
        Assert.True(generatedString.Length == length);
        Assert.True(generatedString.IndexOf(EofChar) is -1);
    }
    
    /// <summary>
    ///     Test of 'GenerationService.GetUniqueArrayPool' method.
    /// </summary>
    /// <param name="length">Generation length.</param>
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void GetUniqueKeyNewArrayPool_Returns_RightString(int length)
    {
        //  Act
        var generatedString = GenerationService.GetUniqueArrayPool(length);
        // Assert
        Assert.True(generatedString.Length == length);
        Assert.True(generatedString.IndexOf(EofChar) is -1);
    }
    
    /// <summary>
    ///     Test of 'PasswordGenerator.Generate' method.
    /// </summary>
    /// <param name="length">Generation length.</param>
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void CryptoMlkPwger_Returns_RightString(int length)
    {
        //  Act
        var generatedString = PasswordGenerator.Generate(length);
        // Assert
        Assert.True(generatedString.Length == length);
        Assert.True(generatedString.IndexOf(EofChar) is -1);
    }
}