using static System.Formats.Asn1.AsnWriter;
using System.Reflection.Metadata;
using System;
using System.Linq.Expressions;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void ScopedRef()
    {
        ScopedParam();
        ScopedLocal(spanLength: 10, maxStackLength: 1024);
    }

    private static void ScopedParam()
    {
        Span<int> intsSpan = stackalloc int[] { 1 };

        var instance = new ClassForScopedRefTest();

        // without marking param with scoped keyword following error occurs:
        // CS8350 This combination of arguments to 'V11.ClassForScopedRefTest.MethodWithScopedRefParam(ReadOnlySpan<int>)'
        // is disallowed because it may expose variables referenced by parameter '_' outside of their declaration scope

        instance.MethodWithScopedRefParam(intsSpan);
    }

    private static void ScopedLocal(int spanLength, int maxStackLength)
    {
        scoped Span<byte> span;

        if (spanLength < maxStackLength)
        {
            // without scoped decleratiopn on span initialization this line would not compile:
            //CS8353 A result of a stackalloc expression of type 'Span<byte>' cannot be used in this context
            //because it may be exposed outside of the containing method
            span = stackalloc byte[spanLength];
        }
        else
        {
            span = new byte[spanLength];
        }
    }

    public ref struct ClassForScopedRefTest
    {
        ReadOnlySpan<int> _spanField;
        public void MethodWithScopedRefParam(scoped ReadOnlySpan<int> span)
        {
            // not allowed in scoped context, as would expose the parameter
            // _spanField = span;
        }
    }
}
