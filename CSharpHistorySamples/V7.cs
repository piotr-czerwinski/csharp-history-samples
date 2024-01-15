using static System.Console;

namespace CSharpHistorySamples;

internal static class V7
{
    public static void RefRetAndRetLocals()
    {
        WriteLine(Environment.NewLine + "RefRetAndRetLocals");
        var sampleArray = new int[] { 1, 2, 3, 4 };

        // ref local
        ref int firstValueRef = ref GetArrayFirstValueRef(sampleArray);

        firstValueRef = 42;
        WriteLine($"firstValueRef: {sampleArray[0]}");

        // ref return and inline value assignment
        GetArrayFirstValueRef(sampleArray) = 43;
        WriteLine($"firstValueRef: {sampleArray[0]}");

        // local function && ref return
        static ref int GetArrayFirstValueRef(int[] array)
        {
            return ref array[0];
        }
    }

    public static void LocalFunctionAndEnumerator()
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
