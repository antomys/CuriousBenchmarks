using Bogus;

namespace Benchmarks.Common;

/// <summary>
///     <see cref="Faker" /> extensions.
/// </summary>
public static class FakerExtensions
{
    /// <summary>
    ///     Generates array by func.
    /// </summary>
    /// <param name="faker"><see cref="Faker{T}" />.</param>
    /// <param name="action">Action for generation.</param>
    /// <param name="count">Generation count.</param>
    /// <returns>Array of T, populates by action.</returns>
    public static T[] GetArray<T>(this Faker faker, Func<Faker, T> action, int count)
    {
        var result = new T[count];

        for (var i = 0; i < count; i++)
        {
            result[i] = action.Invoke(faker);
        }

        return result;
    }

    /// <summary>
    ///     Generates array by func.
    /// </summary>
    /// <param name="faker"><see cref="Faker{T}" />.</param>
    /// <param name="action">Action for generation.</param>
    /// <param name="count">Generation count.</param>
    /// <returns>Array of T, populates by action.</returns>
    public static List<T> GetList<T>(this Faker faker, Func<Faker, T> action, int count)
    {
        var result = new List<T>(count);

        for (var i = 0; i < count; i++)
        {
            result.Add(action.Invoke(faker));
        }

        return result;
    }

    /// <summary>
    ///     Generates array by func.
    /// </summary>
    /// <param name="faker"><see cref="Faker{T}" />.</param>
    /// <param name="action">Action for generation.</param>
    /// <param name="count">Generation count.</param>
    /// <returns>Array of T, populates by action.</returns>
    public static ICollection<T> GetCollection<T>(this Faker faker, Func<Faker, T> action, int count)
    {
        var result = new List<T>(count);

        for (var i = 0; i < count; i++)
        {
            result.Add(action.Invoke(faker));
        }

        return result;
    }

    /// <summary>
    ///     Generates array by func.
    /// </summary>
    /// <param name="faker"><see cref="Faker{T}" />.</param>
    /// <param name="action">Action for generation.</param>
    /// <param name="count">Generation count.</param>
    /// <returns>Array of T, populates by action.</returns>
    public static IEnumerable<T> GetEnumerable<T>(this Faker faker, Func<Faker, T> action, int count)
    {
        var result = new List<T>(count);

        for (var i = 0; i < count; i++)
        {
            result.Add(action.Invoke(faker));
        }

        return result;
    }

    /// <summary>
    ///     Generates fake dictionary.
    /// </summary>
    /// <param name="faker"><see cref="Faker{T}" />.</param>
    /// <param name="keyAction">Action for key generation.</param>
    /// <param name="valueAction">Action for value generation.</param>
    /// <param name="count">Generation count.</param>
    public static Dictionary<TKey, TValue> GetDictionary<TKey, TValue>(
        this Faker faker, Func<Faker, TKey> keyAction, Func<Faker, TValue> valueAction, int count) where TKey : notnull
    {
        var result = new Dictionary<TKey, TValue>(count);

        for (var i = 0; i < count; i++)
        {
            var key = keyAction.Invoke(faker);
            var value = valueAction.Invoke(faker);

            result.Add(key, value);
        }

        return result;
    }
}