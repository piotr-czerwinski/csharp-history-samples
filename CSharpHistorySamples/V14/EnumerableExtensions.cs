namespace CSharpHistorySamples;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> CombineWith<T>(this IEnumerable<T> first, IEnumerable<T> second) => first.Concat(second);

    extension<TSource>(IEnumerable<TSource?> source)
    {
        public IEnumerable<TSource> NotNull() => source.Where(x => x != null).OfType<TSource>();

        public bool ContainsNull => source.Any(x => x == null);
    }

    extension<TSource>(IEnumerable<TSource>)
    {
        public static IEnumerable<TSource> Identity => [];
    }
}
