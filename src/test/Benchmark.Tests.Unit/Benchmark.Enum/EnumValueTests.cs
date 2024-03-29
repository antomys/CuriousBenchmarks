using Benchmarks.Enum;
using Benchmarks.Enum.Services;

namespace Benchmark.Tests.Unit.Benchmark.Enum;

/// <summary>
///     Tests for service <see cref="EnumValueService"/>.
/// </summary>
public sealed class EnumValueTests
{
    /// <summary>
    ///     Unit test method for checking method <see cref="EnumValueService.ToStringFormatD"/> behaviour.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <param name="enumIntAsString">Expected enum int value, converted to <see cref="string"/> <see cref="string"/>.</param>
    [Theory]
    //Assert
    [InlineData(TestEnum.Zero, "0")]
    [InlineData(TestEnum.First, "1")]
    [InlineData(TestEnum.Second, "2")]
    [InlineData(TestEnum.Third, "3")]
    [InlineData(TestEnum.Fourth, "4")]
    [InlineData(TestEnum.Fifth, "5")]
    [InlineData(TestEnum.Sixth, "6")]
    [InlineData(TestEnum.Seventh, "7")]
    [InlineData(TestEnum.Eighth, "8")]
    [InlineData(TestEnum.Ninth, "9")]
    [InlineData(TestEnum.Tenth, "10")]
    [InlineData(TestEnum.Eleventh, "11")]
    [InlineData(TestEnum.Twelfth, "12")]
    public void ToStringFormatD_ShouldReturn_Enum_Int_String(TestEnum testEnum, string enumIntAsString)
    {
        // Act
        var resultName = EnumValueService.ToStringFormatD(testEnum);
        
        //Assert
        Assert.Equal(resultName, enumIntAsString);
    }
    
    /// <summary>
    ///     Unit test method for checking method <see cref="EnumValueService.IntCastToString"/> behaviour.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <param name="enumIntAsString">Expected enum int value, converted to <see cref="string"/> <see cref="string"/>.</param>
    [Theory]
    //Assert
    [InlineData(TestEnum.Zero, "0")]
    [InlineData(TestEnum.First, "1")]
    [InlineData(TestEnum.Second, "2")]
    [InlineData(TestEnum.Third, "3")]
    [InlineData(TestEnum.Fourth, "4")]
    [InlineData(TestEnum.Fifth, "5")]
    [InlineData(TestEnum.Sixth, "6")]
    [InlineData(TestEnum.Seventh, "7")]
    [InlineData(TestEnum.Eighth, "8")]
    [InlineData(TestEnum.Ninth, "9")]
    [InlineData(TestEnum.Tenth, "10")]
    [InlineData(TestEnum.Eleventh, "11")]
    [InlineData(TestEnum.Twelfth, "12")]
    public void IntCastToString_ShouldReturn_Enum_Int_String(TestEnum testEnum, string enumIntAsString)
    {
        // Act
        var resultName = EnumValueService.IntCastToString(testEnum);
        
        //Assert
        Assert.Equal(resultName, enumIntAsString);
    }
    
    /// <summary>
    ///     Unit test method for checking method <see cref="EnumValueService.CustomGetValue"/> behaviour.
    /// </summary>
    /// <param name="testEnum"><see cref="TestEnum"/>.</param>
    /// <param name="enumIntAsString">Expected enum int value, converted to <see cref="string"/> <see cref="string"/>.</param>
    [Theory]
    //Assert
    [InlineData(TestEnum.Zero, "0")]
    [InlineData(TestEnum.First, "1")]
    [InlineData(TestEnum.Second, "2")]
    [InlineData(TestEnum.Third, "3")]
    [InlineData(TestEnum.Fourth, "4")]
    [InlineData(TestEnum.Fifth, "5")]
    [InlineData(TestEnum.Sixth, "6")]
    [InlineData(TestEnum.Seventh, "7")]
    [InlineData(TestEnum.Eighth, "8")]
    [InlineData(TestEnum.Ninth, "9")]
    [InlineData(TestEnum.Tenth, "10")]
    [InlineData(TestEnum.Eleventh, "11")]
    [InlineData(TestEnum.Twelfth, "12")]
    public void CustomGetValue_ShouldReturn_Enum_Int_String(TestEnum testEnum, string enumIntAsString)
    {
        // Act
        var resultName = EnumValueService.CustomGetValue(testEnum);
        
        //Assert
        Assert.Equal(resultName, enumIntAsString);
    }
}