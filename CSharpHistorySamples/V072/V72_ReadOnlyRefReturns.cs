namespace CSharpHistorySamples;

internal static partial class V72
{
    internal static void ReadOnlyRefReturns()
    {
        WriteFirstLineInSample("Read only ref returns");

        ref readonly MutableStruct2 mutableStructRef = ref ReadOnlyReturnOfMutableStruct();
        // mutableStructRef.a = 1; // not allowed

        // method call allowed but makes defensive copy, and invoke method on that copy
        // this behaviour seems to inspect method body,
        // and makes copy only when mutation occurs
        WriteLine($"Mutable struct hash code {mutableStructRef.GetHashCode()}");
        mutableStructRef.IncrementAndWriteHashCode();
        mutableStructRef.IncrementAndWriteHashCode();
        mutableStructRef.WriteHashCode();
        mutableStructRef.WriteHashCode();

        // value of a not changed
        WriteLine($"Mutable struct value of a after invokes: {mutableStructRef.a}");

        // aliases are mutable copies
        var mutableStructRef2 = mutableStructRef;
        mutableStructRef2.a = 1;

        //ref MutableStruct2 mutableStructRef3 = ref ReadOnlyReturnOfMutableStruct(); //not valid as ref readonly required

        ref readonly ReadOnlyStruct2 readOnlyStructRef = ref ReadOnlyReturnOfReadOnlyStruct();

        //readOnlyStructRef.a = 12; // not valid
        
        //Does not make defensive copy never
        readOnlyStructRef.WriteHashCode();
    }

    private static MutableStruct2 _mutableStruct;
    private static ReadOnlyStruct2 _readOnlyStruct;
    private static ref readonly MutableStruct2 ReadOnlyReturnOfMutableStruct() 
    {
        return ref _mutableStruct;
    }

    private static ref readonly ReadOnlyStruct2 ReadOnlyReturnOfReadOnlyStruct()
    {
        return ref _readOnlyStruct;
    }

    private struct MutableStruct2()
    {
        internal int a;

        internal void IncrementAndWriteHashCode()
        {
            a++;
            WriteLine($"MutableStruct2 (value a: {a}) hashCode from the inside: {GetHashCode()}");
        }

        internal void WriteHashCode()
        {
            WriteLine($"MutableStruct2 (value a: {a}) hashCode from the inside: {GetHashCode()}");
        }
    }

    private readonly struct ReadOnlyStruct2()
    {
        internal readonly int a;

        internal void WriteHashCode()
        {
            WriteLine($"ReadOnlyStruct2 hashCode from the inside: {GetHashCode()}");
        }
    }
}
