namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void CompoundAssignmentExample()
    {
        WriteFirstLineInSample("user-defined compound assignment");

        var a = new CustomNumber(5);
        a += 3; // Previously this would use binary operator, but now it will use the new compound assignment operator
        WriteLine($"CustomNumber after + : {a.Value}");

        a -= 3; // Only binary operator implemented - used as a fallback for compound assignment
        WriteLine($"CustomNumber after - : {a.Value}");
    }
}

internal struct CustomNumber(int v)
{
    public int Value = v;

    // binary operators as a fallback for this sample
    public void operator +=(int value)
    {
        WriteLine($"Using compound assignment operator for += with value: {value}");

        Value += value;
    }

    public static CustomNumber operator +(CustomNumber left, int right)
    {
        WriteLine($"Using binary operator for + with right value: {right}");

        left.Value += right;
        return left;
    }

    public static CustomNumber operator -(CustomNumber left, int right)
    {
        WriteLine($"Using binary operator for - with right value: {right}");

        left.Value -= right;
        return left;
    }
}
