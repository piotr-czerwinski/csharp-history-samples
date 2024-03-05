using System.Linq.Expressions;

namespace CSharpHistorySamples;

internal static partial class V73
{
    // https://blog.jetbrains.com/dotnet/2018/07/19/unmanaged-delegate-enum-type-constraints-c-7-3-rider-resharper/
    internal static void NewGenericConstraints()
    {
        // "unmanaged" constraint
        UnmanagedConstraint(1);
        UnmanagedConstraint(FileAccess.Read);
        UnmanagedConstraint(new UnmanagedStruct());

        // Invalid Params
        // UnmanagedConstraint(string.Empty);
        // UnmanagedConstraint(Array.Empty<byte>());
        // UnmanagedConstraint(new ManagedStruct());

        // "Enum" constraint
        EnumConstraint(FileAccess.Read);

        // Invalid Params
        //EnumConstraint((FileAccess?)FileAccess.Read);

        // "Delegate" constraint
        static void localFunc() { }

        DelegateConstraint(() => { });
        DelegateConstraint((int x) => x);
        DelegateConstraint(localFunc);

        // Invalid Params
        //DelegateConstraint(Expression.Empty());
    }

    // only structs with no fields or fields being simple type, enum,
    // pointer or also satisfying unmanaged constraints (all nested levels)
    private static void UnmanagedConstraint<T>(T _) where T : unmanaged { }

    private static void EnumConstraint<T>(T _) where T : Enum { }

    private static void DelegateConstraint<T>(T _) where T : Delegate { }

    private struct UnmanagedStruct
    {
        readonly int _intField;
    }

    private struct ManagedStruct
    {
        readonly string _stringField;
    }
}
