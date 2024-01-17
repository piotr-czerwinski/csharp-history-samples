global using Range = (int Minimum, int Maximum);
using Point = (double X, double Y);

namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void TupleAlias()
    {
        WriteLine(Environment.NewLine + "TupleAlias");

        var rawTuple = (1, 2);
        Range range = rawTuple;
        Point point = range; // can be assigned, as int is implicitly convertible to double
        // range = point; // not valid, as opposite conversion is not valid

        WriteLine($"raw tuple: {rawTuple}");
        WriteLine($"range: {range}");
        WriteLine($"point: {point}");
    }
}
