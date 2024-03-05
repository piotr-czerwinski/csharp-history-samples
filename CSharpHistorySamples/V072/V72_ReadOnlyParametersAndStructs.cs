namespace CSharpHistorySamples;

internal static partial class V72
{
    internal static void ReadOnlyParametersAndStructs()
    {
        WriteLine();

        var mutableStruct = new MutableStruct()
        {
            a = 5
        };

        var readonlyStruct = new ReadOnlyStruct();

        // MethodWithReadOnlyParameter(in mutableStruct, in readonlyStruct) is also valid
        MethodWithReadOnlyParameter(mutableStruct, readonlyStruct);
        WriteLine($"Mutable struct member value: {mutableStruct.a}");
    }

    // read only reference parameters avoid copy of the whole structure
    // similar to ref parameters. But guarantee is made, that parameter state is not modified
    private static void MethodWithReadOnlyParameter(
        in MutableStruct mutableStruct,
        in ReadOnlyStruct readOnlyStruct
        ) 
    {
        //structValue = new SampleStruct(); // not allowed
        //structValue.a = 5; // not allowed

        // invoking methods is allowed, but results with defensive copy of the struct
        mutableStruct.IncrementA();

        // no defensive copy as state is not mutable
        readOnlyStruct.DontIncrementA();

        // more at https://sharplab.io/#gist:7a9a144ab7b73c077a8ce0512c2e06f6
    }

    private struct MutableStruct()
    {
        internal int a;

        internal void IncrementA()
        {
            a++;
        }
    }

    private readonly struct ReadOnlyStruct()
    {
        // needs to be readonly
        internal readonly int a;

        internal void DontIncrementA()
        {
            // a++; not allowed
        }
    }
}
