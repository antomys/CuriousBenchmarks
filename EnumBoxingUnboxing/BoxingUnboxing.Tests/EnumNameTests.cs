using BoxingUnboxing.Benchmarks;
using BoxingUnboxing.Benchmarks.Services;
using Xunit;

namespace BoxingUnboxing.Tests;

/// <summary>
///     Tests for service <see cref="EnumNameService"/>.
/// </summary>
public sealed class EnumNameTests
{
    /// <summary>
    ///     Unit test method for checking method <see cref="EnumNameService.DefaultToString"/> behaviour.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <param name="enumName">Expected enum name.</param>
    [Theory]
    //Assert
    [InlineData(TestEnum.Zero, "Zero")]
    [InlineData(TestEnum.First, "First")]
    [InlineData(TestEnum.Second, "Second")]
    [InlineData(TestEnum.Third, "Third")]
    [InlineData(TestEnum.Fourth, "Fourth")]
    [InlineData(TestEnum.Fifth, "Fifth")]
    [InlineData(TestEnum.Sixth, "Sixth")]
    [InlineData(TestEnum.Seventh, "Seventh")]
    [InlineData(TestEnum.Eighth, "Eighth")]
    [InlineData(TestEnum.Ninth, "Ninth")]
    [InlineData(TestEnum.Tenth, "Tenth")]
    [InlineData(TestEnum.Eleventh, "Eleventh")]
    [InlineData(TestEnum.Twelfth, "Twelfth")]
    public void DefaultToString_ShouldReturn_Enum_Name(TestEnum testEnum, string enumName)
    {
        // Act
        var resultName = EnumNameService.DefaultToString(testEnum);
        
        //Assert
        Assert.Equal(resultName, enumName);
    }
    
    /// <summary>
    ///     Unit test method for checking method <see cref="EnumNameService.EnumGetName"/> behaviour.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <param name="enumName">Expected enum name.</param>
    [Theory]
    //Assert
    [InlineData(TestEnum.Zero, "Zero")]
    [InlineData(TestEnum.First, "First")]
    [InlineData(TestEnum.Second, "Second")]
    [InlineData(TestEnum.Third, "Third")]
    [InlineData(TestEnum.Fourth, "Fourth")]
    [InlineData(TestEnum.Fifth, "Fifth")]
    [InlineData(TestEnum.Sixth, "Sixth")]
    [InlineData(TestEnum.Seventh, "Seventh")]
    [InlineData(TestEnum.Eighth, "Eighth")]
    [InlineData(TestEnum.Ninth, "Ninth")]
    [InlineData(TestEnum.Tenth, "Tenth")]
    [InlineData(TestEnum.Eleventh, "Eleventh")]
    [InlineData(TestEnum.Twelfth, "Twelfth")]
    public void EnumGetName_ShouldReturn_Enum_Name(TestEnum testEnum, string enumName)
    {
        // Act
        var resultName = EnumNameService.EnumGetName(testEnum);
        
        //Assert
        Assert.Equal(resultName, enumName);
    }
    
    /// <summary>
    ///     Unit test method for checking method <see cref="EnumNameService.CustomGetName"/> behaviour.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <param name="enumName">Expected enum name.</param>
    [Theory]
    //Assert
    [InlineData(TestEnum.Zero, "Zero")]
    [InlineData(TestEnum.First, "First")]
    [InlineData(TestEnum.Second, "Second")]
    [InlineData(TestEnum.Third, "Third")]
    [InlineData(TestEnum.Fourth, "Fourth")]
    [InlineData(TestEnum.Fifth, "Fifth")]
    [InlineData(TestEnum.Sixth, "Sixth")]
    [InlineData(TestEnum.Seventh, "Seventh")]
    [InlineData(TestEnum.Eighth, "Eighth")]
    [InlineData(TestEnum.Ninth, "Ninth")]
    [InlineData(TestEnum.Tenth, "Tenth")]
    [InlineData(TestEnum.Eleventh, "Eleventh")]
    [InlineData(TestEnum.Twelfth, "Twelfth")]
    public void CustomGetName_ShouldReturn_Enum_Name(TestEnum testEnum, string enumName)
    {
        // Act
        var resultName = EnumNameService.CustomGetName(testEnum);
        
        //Assert
        Assert.Equal(resultName, enumName);
    }
}