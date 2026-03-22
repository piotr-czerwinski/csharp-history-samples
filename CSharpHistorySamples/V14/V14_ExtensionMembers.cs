namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void ExtensionMembersExample()
    {
        WriteFirstLineInSample("extension members (instance and static)");

        var arr = new[] { 1, 2, 3, (int?)null };
        WriteLine($"Not null count: {arr.NotNull().Count()}");
        WriteLine($"Contains null: {arr.ContainsNull}");

        var identity = List<int>.Identity;
        WriteLine($"Identity is not null: {identity is not null}");
    }
}
internal static class EnumerableExtensionsV14
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