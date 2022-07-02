using HashCode.Benchmarks.Models;

namespace HashCode.Benchmarks.Extensions;

/// <summary>
///     Collection of different hashing algorithms and tricks from stackoverflow.
/// </summary>
public static class HashingExtensions
{
    /// <summary>
    ///     Default native method
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int Default(SimpleModel simpleModel)
    {
        return simpleModel.GetHashCode();
    }
    
    /// <summary>
    ///     Using <see cref="HashCode.Combine{T1,T2}"/>
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int DefaultCombine(SimpleModel simpleModel)
    {
        return System.HashCode.Combine(simpleModel.Id, simpleModel.Value);
    }

    /// <summary>
    ///     Manual method of getting hash code.
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int Manual(SimpleModel simpleModel)
    {
        unchecked // Allow arithmetic overflow, numbers will just "wrap around"
        {
            var hashcode = 1430287;
            hashcode = hashcode * 7302013 ^ simpleModel.Id.GetHashCode();
            hashcode = hashcode * 7302013 ^ simpleModel.Value.GetHashCode();

            return hashcode;
        }
    }
    
    /// <summary>
    ///     Manual method of getting hash code with bitwise operations.
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int ManualBitwise(SimpleModel simpleModel)
    {
        unchecked
        {
            var num = 0x7e53a269;
            num = -1521134295 * num + simpleModel.Id;
            num += num << 10;
            num ^= num >> 6;

            num = -1521134295 * num + simpleModel.Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
            num += num << 10;
            num ^= num >> 6;

            return num;
        }
    } 
    
    /// <summary>
    ///     <see cref="HashCodeV5"/> method of getting hash code.
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int StructV5(SimpleModel simpleModel)
    {
        return HashCodeV5.Of(simpleModel);
    }
    
    /// <summary>
    ///     <see cref="HashCodeV6"/> method of getting hash code.
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int StructV6(SimpleModel simpleModel)
    {
        return HashCodeV6.Start.Hash(simpleModel);
    }
    
    /// <summary>
    ///     <see cref="HashCodeV6Ref"/> method of getting hash code.
    /// </summary>
    /// <param name="simpleModel"><see cref="SimpleModel"/>.</param>
    /// <returns>hash int</returns>
    public static int StructV6Ref(SimpleModel simpleModel)
    {
        return HashCodeV6Ref.Hash(simpleModel);
    }
}