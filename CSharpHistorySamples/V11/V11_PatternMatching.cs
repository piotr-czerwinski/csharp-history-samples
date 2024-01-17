using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void PatternMatchingForSpans()
    {
        WriteLine("Pattern matching");

        var spanInput = "xyz".AsSpan();

        // pattern matching support for Span<char> and ReadOnlySpan<char> added
        WriteLine(spanInput switch
        {
            "x" => "This is x!",
            "y" => "This is y!",
            "z" => "This is z!",
            _ => "Some other value"
        });
    }
}
