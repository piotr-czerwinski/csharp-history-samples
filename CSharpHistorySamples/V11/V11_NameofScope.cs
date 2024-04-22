using System.Collections;
using System.Runtime.CompilerServices;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void NameofScope()
    {
    }

    public static int SampleExtensionMethod<T>(
        this int value,
        //[CallerArgumentExpression("sequence")] // before C# 11
        [CallerArgumentExpression(nameof(value))] // C# 11 - magic string can be removed
        string? message = null)
    {
        return value;
    }
}
