using System.Runtime.CompilerServices;
using static CSharpHistorySamples.V12;

namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void Interceptors()
    {
        // Experimental feature in C# 12. Requires adding InterceptsLocationAttribute manually
        // and enabling interception in the csproj
        WriteFirstLineInSample("Interceptors");

        var interceptableClass = new InterceptableClass(3);
        interceptableClass.MethodToBeIntercepted();
    }

    internal class InterceptableClass(int x)
    {
        public int X { get; } = x;

        public override string? ToString() => $"InterceptableClass X: {X}";

        internal void MethodToBeIntercepted() => WriteLine("InterceptableClass.MethodToBeIntercepted called");
    }
}

file static class Interceptor
{
    // From the documentation:
    // In prior experimental releases of the feature,
    // a well-known constructor signature InterceptsLocation(string path, int line, int column)] was also supported.
    // Support for this constructor will be dropped prior to stable release of the feature.
    [InterceptsLocation("V12_Interceptors.cs", 15, 28)]
    public static void InterceptMethod(this InterceptableClass input)
    {
        WriteLine($"Interceptor.InterceptMethod called (with parameter: {input.ToString()})");
    }
}