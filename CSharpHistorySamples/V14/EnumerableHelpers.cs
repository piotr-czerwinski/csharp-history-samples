namespace CSharpHistorySamples;

internal static class EnumerableHelpers
{
    public static IEnumerable<T> CombineWith<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Concat(second);
    public static IEnumerable<T> ConcatWith<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Concat(second);
    public static IEnumerable<T> Identity<T>() => Enumerable.Empty<T>();

    public static bool IsEmpty<T>(this IEnumerable<T> source)
    {
        foreach (var _ in source) return false;
        return true;
    }
}
