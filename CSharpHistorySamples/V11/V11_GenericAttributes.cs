using System.Collections;
using static CSharpHistorySamples.V11;

namespace CSharpHistorySamples;

internal static partial class V11
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class GenericAttribute<T> : Attribute
    {
    }

    public class GenericAttributeForEnum<T> : Attribute
        where T : Enum
    {
    }

    internal static void GenericAttributes()
    {
        [GenericAttribute<string>]
        void M1() { };

        [GenericAttribute<int>]
        void M2() { };

        // Forbidden usage:

        // [GenericAtr<dynamic>]
        [GenericAttribute<object>] // as the valid solution

        // [GenericAtr<(int x, int y)>]
        [GenericAttribute<ValueTuple<int, int>>] // as the valid solution

        // [GenericAtr<int?>] // nullable
        [GenericAttribute<int>] // as the valid solution
        void M3() { };

        [GenericAttributeForEnum<FileAccess>]
        // [GenericAttributeForEnum<int>] // not valid as int is not Enum
        void M4() { };
    }

    // [GenericAtr<T>] attribute must be of constructed type to be used like GenericAtr<int> (not generic)
    private static void GenericMethod<T>()
    {
    }
}
