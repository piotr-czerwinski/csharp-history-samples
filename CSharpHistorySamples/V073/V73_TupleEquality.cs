namespace CSharpHistorySamples;

internal static partial class V73
{
    // https://blog.jetbrains.com/dotnet/2018/07/13/tuple-equality/
    internal static void TupleEquality()
    {
        WriteFirstLineInSample("Tuple Equality");

        var sampleTuple = (x: 1, y: 2);
        var anotherTuple = (a: 1, b: 2);

        var areTuplesEqual = sampleTuple == anotherTuple;

        WriteLine($"Are tuples equal: {areTuplesEqual}");

        /*
            Tuple equality is syntactic sugar. Aliases of tuple items are irrelevant
            code above is translated to something like:
            ValueTuple<int, int> valueTuple = new ValueTuple<int, int>(1, 2);
            ValueTuple<int, int> valueTuple2 = new ValueTuple<int, int>(1, 2);

            ValueTuple<int, int> valueTuple3 = valueTuple;
            ValueTuple<int, int> valueTuple4 = valueTuple2;
            bool value = valueTuple3.Item1 == valueTuple4.Item1 && valueTuple3.Item2 == valueTuple4.Item2;

            Console.WriteLine(value);
        */
    }
}
