using System.Runtime.CompilerServices;

namespace CSharpHistorySamples.V09;

internal static partial class V9
{
    internal static void LocalAndAnonymousFunctionsEnhancements()
    {
        var localVar = 0;

        // Anonymous static - cannot access other values than passed as arguments
        Func<string, int> local1 = static arg => arg.Length;
        
        // Would not compile as localVar is not passed as arg (would be captured):
        // Func<string, int> local2 = static arg => arg.Length + localVar; 

        LocalFuncWithAttribute();
        // Attributes can be added
        [SkipLocalsInit]
        static void LocalFuncWithAttribute() { };
    }
}
