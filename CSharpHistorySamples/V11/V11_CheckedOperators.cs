namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void CheckedOperators()
    {
        WriteFirstLineInSample("Checked operators");

        var vector1 = new Vector2D(int.MaxValue, int.MaxValue);

        var result = vector1 + vector1; // this overflows
        WriteLine($"Sum result {vector1} + {vector1} = {result}");

        try
        {
            var result2 = checked(vector1 + vector1);
            WriteLine($"Sum result checked({vector1} + {vector1}) = {result}");
        }
        catch (OverflowException)
        {
            WriteLine("Checked operation throws OverflowException");
        }
    }

    public record Vector2D(int X, int Y)
    {
        public static Vector2D operator +(Vector2D value1, Vector2D value2)
        {
            return new(value1.X + value2.X, value1.Y + value2.Y);
        }

        public static Vector2D operator checked +(Vector2D value1, Vector2D value2)
        {
            return new(checked(value1.X + value2.X), checked(value1.Y + value2.Y));
        }
    }
}
