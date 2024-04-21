using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace CSharpHistorySamples;

internal static partial class V10
{

    internal static void ArgumentExpression()
    {
        WriteFirstLineInSample("Argument Expression");

        InvokeDelegateSafe(() => Enumerable.Range(0, 5).TakeExact(10));
        InvokeDelegateSafe(() => new int[] { 0, 1 }.TakeExact(10));

        var intArray = new int[] { 0, 1 };
        InvokeDelegateSafe(() => intArray.TakeExact(10));
    }

    private static void InvokeDelegateSafe(Func<IEnumerable<int>> action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
            WriteLine(e.Message);
        };
    }

    public static IEnumerable<T> TakeExact<T>(this IEnumerable<T> sequence, int count,
        [CallerArgumentExpression(nameof(sequence))] string? message = null)
    {
        if (sequence.Count() < count)
        {
            throw new ArgumentException($"Expression {message} should have at least {count} elements: ", nameof(sequence));
        }

        return sequence.Take(count);
    }
}
