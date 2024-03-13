namespace CSharpHistorySamples;

internal static partial class V8
{
    internal static void StackallocInNestedContext()
    {
        // Before C# 8
        Span<char> whitespaces = stackalloc[] { ' ', '\r', '\n' };
        _ = "someString ".AsSpan().Trim(whitespaces);

        // C# 8 onward it is possible to
        _ = "someString ".AsSpan().Trim(stackalloc[] { ' ', '\r', '\n' });
    }
}
