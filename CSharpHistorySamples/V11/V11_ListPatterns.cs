using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void ListPatterns()
    {
        WriteFirstLineInSample("List patterns"); // works also for arrays, spans

        var ints = new int[] { 1, 2, 3 };

        WriteLine($"Sum ints array {Sum(ints)}");
        WriteLine($"Sum ints span {SumOnSpan(ints)}");

        static bool MoreThanTwoWithFirstAndLastPositive(params int[] ints) => ints is [> 0, .., > 0];

        WriteLine($"Check [0]: {MoreThanTwoWithFirstAndLastPositive([0])}");
        WriteLine($"Check [1] {MoreThanTwoWithFirstAndLastPositive([1])}");
        WriteLine($"Check [1, 2] {MoreThanTwoWithFirstAndLastPositive([1])}");
        WriteLine($"Check [1, 0, 2] {MoreThanTwoWithFirstAndLastPositive([1, 0, 2])}");
    }

    private static int Sum(int[] ints) => ints switch
    {
        [] => 0,
        // This case is not required for the algorithm to work. Just as a showcase
        [var value] => value,
        // .. operator constructs new array with all elements except explicitly defined first (value)
        [var value, .. var rest] => value + Sum(rest), 
    };

    private static int SumOnSpan(ReadOnlySpan<int> ints) => ints switch
    {
        [] => 0,
        // no allocation, as operating on Span
        [var value, .. var rest] => value + SumOnSpan(rest),
    };
}
