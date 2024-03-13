namespace CSharpHistorySamples;

internal static partial class V8
{
    internal static void RangesAndIndices()
    {
        string[] nameOfMonths = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

        WriteLine("nameOfMonths[0]: " + nameOfMonths[0]);


        WriteLineWithParams("nameOfMonths[^1]", nameOfMonths[^1]); // equiv. nameOfMonths.Last()
        WriteLineWithParams("nameOfMonths[2..5]", nameOfMonths[2..5]); // equiv. nameOfMonths.Skip(2).Take(3)
        WriteLineWithParams("nameOfMonths[^2..^0]", nameOfMonths[^2..^0]); // last two
        WriteLineWithParams("nameOfMonths[new Index(1, fromEnd: true)]", nameOfMonths[new Index(1, fromEnd: true)]); // equiv of [^1]

        // Would throw IndexOutOfRangeException:
        // WriteLine("nameOfMonths[^0]", nameOfMonths[^0]); 
        // similar to nameOfMonths[nameOfMonths.Length]

        // ArgumentOutOfRangeException for:
        // WriteLineWithParams("nameOfMonths[8..1]", nameOfMonths[8..1]); 
        // WriteLineWithParams("nameOfMonths[^2..1]", nameOfMonths[^2..1]);
    }
}
