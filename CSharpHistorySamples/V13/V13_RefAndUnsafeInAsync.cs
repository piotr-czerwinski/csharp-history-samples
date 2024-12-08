namespace CSharpHistorySamples;

internal partial class V13
{
    internal static async Task RefAndUnsafeNewAllowedUseCases()
    {
        WriteFirstLineInSample("Lock object");

        await AsyncMethodWithRefLocal();
        IteratorWithUnsafe();
        IteratorWithRefLocal();
    }

    private static async Task AsyncMethodWithRefLocal()
    {
        Span<int> span1 = []; // could not be assigned to ref struct before C#13

        await Task.Delay(110);

        // would result with compile time error Instance of type 'System.Span<int>' cannot be preserved across 'await' or 'yield' boundary.
        // WriteLine(span1.Length);
    }

    private static IEnumerable<int> IteratorWithUnsafe()
    {
        yield return 0;

        unsafe // could not be used before C#13 in iterator at all
        {
            //yield return 1; // not supported from inside unsafe

        }
        yield return 2;
    }

    private static IEnumerable<int> IteratorWithRefLocal()
    {
        Span<int> span1 = []; // could not be assigned to ref struct before C#13

        yield return 0;

        // would result with compile time error Instance of type 'System.Span<int>' cannot be preserved across 'await' or 'yield' boundary.
        // WriteLine(span1.Length);
    }
}
