namespace CSharpHistorySamples;

using System;

internal static partial class V14
{
    internal static void ImplicitSpanConversionsExample()
    {
        WriteFirstLineInSample("implicit span conversions");

        Span<int> s = [1, 2, 3]; // implicit conversion from T[] to Span<T>
        ReadOnlySpan<int> rs = s; // implicit conversion from Span<T> to ReadOnlySpan<T>

        WriteLine($"Span length: {s.Length}, ReadOnlySpan length: {rs.Length}");

        ReadOnlySpan<char> stringSpan = "string";
        WriteLine($"String ReadOnlySpan length: {stringSpan.Length}");

        ReadOnlySpan<Derived> intSpan = [];
        ConsumeReadOnlySpanOfObject(intSpan);

        static void ConsumeReadOnlySpanOfObject(ReadOnlySpan<Base> span)
        {
            WriteLine($"Consumed ReadOnlySpan of Base with length: {span.Length}");
        }
    }

    private class Derived : Base
    {
    }

    private class Base
    {
    }
}
