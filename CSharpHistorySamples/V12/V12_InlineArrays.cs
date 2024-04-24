namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void InlineArrays()
    {
        WriteFirstLineInSample("Inline Arrays");

        // allocated on stack
        var buffer = new BufferAsInlineArray<int>();

        buffer[0] = 2;
        buffer[3] = 2;

        // compiler check. Will not allow out of range index
        // buffer[4] = 2;

        // no compiler check:
        try
        {
            for (int i = 0; i < 5; i++)
            {
                WriteLine(buffer[i]);

            }
        }
        catch (Exception ex)
        {
            WriteLine($"Exception: {ex.Message}");
        }
    }
}

[System.Runtime.CompilerServices.InlineArray(4)]
file struct BufferAsInlineArray<T> // might be generic or not
{
    private T _element0; // only single field allowed
}
