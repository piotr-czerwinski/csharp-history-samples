namespace CSharpHistorySamples;

internal static partial class V7
{
    internal static void LocalFunctionAndEnumerator()
    {
        WriteLine();

        try
        {
            var enumerator = GetRangeEnumerator(count: -1);
            WriteLine($"{Environment.NewLine}RangeEnumerator: Enumerator retrieved");
            _ = enumerator.ToList(); // ex thrown here
        }
        catch (Exception ex)
        {
            WriteLine(ex.StackTrace);
        }

        try
        {
            var enumerator = GetRangeEnumeratorLocalFunction(count: -1); // ex thrown here
            WriteLine($"{Environment.NewLine}RangeEnumeratorLocalFunction: Enumerator retrieved"); // never reach this line
        }
        catch (Exception ex)
        {
            WriteLine(ex.StackTrace);
        }
    }

    static IEnumerable<int> GetRangeEnumerator(int count)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0);

        for (int i = 0; i <= count; i++)
        {
            yield return i;
        }
    }

    static IEnumerable<int> GetRangeEnumeratorLocalFunction(int count)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0);

        return GetSequenceEnumerator();

        IEnumerable<int> GetSequenceEnumerator()
        {
            for (int i = 0; i <= count; i++)
            {
                yield return i;
            }
        }
    }

}
