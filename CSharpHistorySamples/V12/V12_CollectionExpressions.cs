using System.Collections;
using System.Runtime.CompilerServices;

namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void CollectionExpressions()
    {
        WriteFirstLineInSample("Collection Expressions");

        CollectionConstruction();
        SpreadElement();
    }

    private static void CollectionConstruction()
    {
        int[] intsArray = [1, 2];
        List<int> intsList = [1, 2];
        Span<int> intsSpan = [1, 2];
        int[][] intsJaggedArray = [[1, 2], [3, 4]];

        CustomCollection customInts = [1, 2];
    }

    private static void SpreadElement()
    {
        int[] ints1 = [1, 2, 3];
        int[] ints2 = [4, 5, 6];
        int[] ints3 = [7, 8, 9];

        int[] allInts = [.. ints1, .. ints2, .. ints3];

        WriteLine($"allInts: {string.Join(", ", allInts)}");
    }
}

// Attribute required
[CollectionBuilder(typeof(CustomCollectionBuilder), "Create")]
file class CustomCollection : IEnumerable<int>
{
    private readonly int[] _internalStorage;

    public CustomCollection(ReadOnlySpan<int> input)
    {
        WriteLine($"CustomCollection constructor");
        _internalStorage = input.ToArray();
    }

    public IEnumerator<int> GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}

file static class CustomCollectionBuilder
{
    // Must match signature:
    // name: "Create"
    // returns: constructed
    // parameter ReadOnlySpan<T>
    internal static CustomCollection Create(ReadOnlySpan<int> values)
    {
        WriteLine($"CustomCollectionBuilder Create");
        return new CustomCollection(values);
    }
}
