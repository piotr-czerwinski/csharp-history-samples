using System.Diagnostics.CodeAnalysis;

namespace CSharpHistorySamples;

internal static partial class V10
{
    internal static void LambdaExpressionImprovements()
    {
        ExplicitReturnTypeForLambdas();
        NaturalTypeOfALambda();
        AttributesSupportForLambdas();
    }

    private static void ExplicitReturnTypeForLambdas()
    {
        // Return type might be explicitly defined (as int? in the example) without the need of casting 
        var _ = int? (int b) => b == 0 ? null : b;
    }

    private static void NaturalTypeOfALambda()
    {
        // Before C# 10 following statements resulted with errors:

        // error CS1660: Cannot convert lambda expression to type 'Delegate' because it is not a delegate type
        Delegate parse1 = (string s) => int.Parse(s);
        object parse2 = (string s) => int.Parse(s);

        // error CS0815: Cannot assign lambda expression to an implicitly-typed variable
        var parse3 = (string s) => int.Parse(s);
    }

    private static void AttributesSupportForLambdas()
    {
        Func<string?, string?> processString = [return: NotNullIfNotNull(nameof(s))] (s) => s?.ToUpper()?.ToLower();
        Func<string, string> processString2 = ([DisallowNull] s) => s.ToUpper().ToLower();


        Func<string, string> processString3 = [CustomAtr] (s) => s.ToUpper().ToLower();
    }

    [AttributeUsage(AttributeTargets.Method)]
    private sealed class CustomAtrAttribute : Attribute
    {
    }
}
