namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void CompoundAssignmentExample()
    {
        WriteFirstLineInSample("user-defined compound assignment");

        var a = new CustomNumber(5);
        // use binary operators (fallback) so the sample compiles with current toolchain
        a = a + 3;
        WriteLine($"CustomNumber after + : {a.Value}");

        a = a - 2;
        WriteLine($"CustomNumber after - : {a.Value}");
    }
}

internal struct CustomNumber
{
    public int Value;
    public CustomNumber(int v) { Value = v; }
    // binary operators as a fallback for this sample
    public static CustomNumber operator +(CustomNumber left, int right)
    {
        left.Value += right;
        return left;
    }

    public static CustomNumber operator -(CustomNumber left, int right)
    {
        left.Value -= right;
        return left;
    }
}
