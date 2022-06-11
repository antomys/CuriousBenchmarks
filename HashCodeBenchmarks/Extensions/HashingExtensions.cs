namespace HashCodeBenchmarks.Extensions;

/// <summary>
///     Collection of different hashing algorithms and tricks from stackoverflow.
/// </summary>
public static class HashingExtensions
{
    /// <summary>
    ///     Default native method
    /// </summary>
    /// <param name="testModel"></param>
    /// <returns>hash int</returns>
    public static int GetHashCodeV1(TestModel testModel)
    {
        return testModel.GetHashCode();
    }
    
    /// <summary>
    ///     Using <see cref="HashCode.Combine{T1,T2}"/>
    /// </summary>
    /// <param name="id">test model id.</param>
    /// <param name="value">test mode value.</param>
    /// <returns>hash int</returns>
    public static int GetHashCodeV2(int id, string value)
    {
        return HashCode.Combine(id, value);
    }

    public static int GetHashCodeV3(int id, string value)
    {
        unchecked // Allow arithmetic overflow, numbers will just "wrap around"
        {
            var hashcode = 1430287;
            hashcode = hashcode * 7302013 ^ id.GetHashCode();
            hashcode = hashcode * 7302013 ^ value.GetHashCode();

            return hashcode;
        }
    }
    
    public static int GetHashCodeV4(int id, string value)
    {
        unchecked
        {
            var num = 0x7e53a269;
            num = -1521134295 * num + id;
            num += num << 10;
            num ^= num >> 6;

            num = -1521134295 * num + value.GetHashCode(StringComparison.OrdinalIgnoreCase);
            num += num << 10;
            num ^= num >> 6;

            return num;
        }
    } 
    
    public static int GetHashCodeV5(int id, string value)
    {
        return HashCodeV5.Of(id).And(value);
    }
    
    public static int GetHashCodeV6(int id, string value)
    {
        return HashCodeV6.Start.Hash(id).Hash(value);
    }
}