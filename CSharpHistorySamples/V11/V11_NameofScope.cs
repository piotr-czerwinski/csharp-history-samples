using System.Runtime.CompilerServices;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void NameofScope()
    {
    }

    [Name(nameof(value))] // instead of [Name("value")]
    public static int SampleExtensionMethod<T>(
        this int value,
        //[CallerArgumentExpression("value")] // before C# 11
        [CallerArgumentExpression(nameof(value))] // C# 11 - magic string can be removed
        string? message = null)
    {
        return value;
    }

    private class NameAttribute : Attribute
    {
        public NameAttribute(string description)
        {
            Description = description;
        }

        public string Description
        {
            get; set;
        }
    }
}
