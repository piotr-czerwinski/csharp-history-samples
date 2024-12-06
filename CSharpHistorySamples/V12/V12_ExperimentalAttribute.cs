using System.Diagnostics.CodeAnalysis;

namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void ExperimentalAttribute()
    {
        // without explicitly disabled warning:
        //IdToBeDisplayedByTheCompiler 'CSharpHistorySamples.V12.ExperimentalMethod()' is for evaluation purposes only and is subject to change or removal in future updates.
        //Suppress this diagnostic to proceed

#pragma warning disable IdToBeDisplayedByTheCompiler // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        ExperimentalMethod();
#pragma warning restore IdToBeDisplayedByTheCompiler // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    }

    [Experimental("IdToBeDisplayedByTheCompiler")]
    private static void ExperimentalMethod()
    {
    }
}
