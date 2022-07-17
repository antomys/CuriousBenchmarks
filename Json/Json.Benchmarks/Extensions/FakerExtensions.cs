using Bogus;

namespace Json.Benchmarks.Extensions;

/// <summary>
///     <see cref="Faker"/> extensions.
/// </summary>
public static class FakerExtensions
{
    /// <summary>
    ///     Generates array by func.
    /// </summary>
    /// <param name="faker"><see cref="Faker{T}"/>.</param>
    /// <param name="action">Action for generation.</param>
    /// <param name="count">Generation count.</param>
    /// <returns>Array of T, populates by action.</returns>
    public static T[] GetArray<T>(this Faker faker, Func<Faker,T> action, int count)
    {
        var result = new T[count];

        for (var i = 0; i < count; i++)
        {
            result[i] = action.Invoke(faker);
        }

        return result;
    }
}