namespace CSharpHistorySamples;

internal static partial class V72
{
    internal static void RefStructs()
    {
        WriteFirstLineInSample("Ref structs");

        // local variable, on the stack - all good
        var refStructLocalVar = new RefStruct();

        // can be passed as a parameter
        refStructLocalVar = Echo(refStructLocalVar);

        // or ref parameter
        EchoRef(ref refStructLocalVar);

        // cannot be used as type of an array;
        // var refStructsArray = new RefStruct[];

        // cannot be used as a type parameter
        // refStructLocalVar = EchoGeneric(refStructLocalVar);

        // or boxed (and passed as object)
        //PassAsObject(refStructLocalVar);

        // cannot be captured in lambda expression (or local function)
        //var lambda = () => refStructLocalVar;
    }
    private static RefStruct Echo(RefStruct x) => x;

    private static void EchoRef(ref RefStruct _) { }

    private static T EchoGeneric<T>(T x) => x;

    private static void PassAsObject<T>(object _) { }

    private static async Task<bool> UsedInAsyncMethod()
    {
        await Task.Delay(0);
        // cannot be declared in async method
        // var refStructInAsync = new RefStruct();

        // and this also is true for Spans
        //var span = Array.Empty<int>().AsSpan();

        return true;
    }

    // but can be used in non-async method returning Tasks
    private static Task<bool> UsedInTaskReturningNonAsyncMethod()
    {
        var refStructInAsync = new RefStruct();

        return Task.FromResult(true);
    }

    // Ref structs always allocated on the stack. It was added initially to supports Spans.
    // Compilers ensures, that those structs are never allocated or moved to the managed heap.
    private ref struct RefStruct // : ICloneable - cannot implement interface
                                 // (until C# 13 at all, and even in C# 13 ICloneable could not be implemented,
                                 // as Clone method returns object and such boxing is not allowed)
    {
        internal int property;

        internal int[] array;

        // For ref structs it is common to be composed with other ref structs.
        // non-ref structs cannot have ref struct fields
        internal Span<byte> span;
    }
}
