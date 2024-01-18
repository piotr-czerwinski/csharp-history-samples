namespace CSharpHistorySamples;

internal static partial class V71
{
    internal static void PatternMatchingForGenericParameter<T>(T parameter)
    {
        WriteLine();
#pragma warning disable IDE0059 // Unnecessary assignment of a value
        // allows for pattern matching on generic 'T' parameter of the method
        WriteLine($"""Passed "{parameter}" as parameter. Is it string? {parameter is string a}""");

#pragma warning restore IDE0059
    }
}
