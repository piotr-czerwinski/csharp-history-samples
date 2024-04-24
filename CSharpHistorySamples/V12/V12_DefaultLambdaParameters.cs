namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void DefaultLambdaParameters()
    {
        WriteFirstLineInSample("Default Lambda Parameters");

        var lambda = (int x = 2) => x * 2;
        WriteLine($"Call (int x = 2) => x * 2; with no param (lambda()): {lambda()}");

    }
}
