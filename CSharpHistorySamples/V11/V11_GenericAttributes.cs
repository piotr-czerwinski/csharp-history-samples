using System.Collections;
using static CSharpHistorySamples.V11;

namespace CSharpHistorySamples;

internal static partial class V11
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GenericAtrAttribute<T> : Attribute
    {
    }

    internal static void GenericAttributes()
    {
        [GenericAtr<string>]
        static void M1() { };

        [GenericAtr<int>]
        static void M2() { };

        // Forbidden usage:
        // [GenericAtr<dynamic>]
        [GenericAtr<object>] // as the valid solution
        // [GenericAtr<(int x, int y)>]
        [GenericAtr<ValueTuple<int, int>>] // as the valid solution
        // [GenericAtr<int?>] // nullable
        [GenericAtr<int>] // as the valid solution
        static void M3() { };
    }

    // [GenericAtr<T>] attribute must be of constructed type to be used like GenericAtr<int> (not generic)
    private static void GenericMethod<T>()
    {
    }
}
