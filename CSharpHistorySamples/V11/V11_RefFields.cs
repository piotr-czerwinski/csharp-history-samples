using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void RefFields()
    {
        WriteFirstLineInSample("Ref Fields"); // works also for arrays, spans

        var intsWrapper = new IntArrayRefWrapper(new int[] { 1, 2, 3 });

        WriteLine($"intsWrapper state: {intsWrapper.ToString()}");

        intsWrapper.ReassingValueForTheFirstElement(67);
        WriteLine($"intsWrapper state: {intsWrapper.ToString()}");

        intsWrapper.ReassingIntsRef(new int[] { 4, 5, 6 });
        WriteLine($"intsWrapper state: {intsWrapper.ToString()}");

        WriteLine($"Is ref null: {intsWrapper.IsRefNull()}");
        intsWrapper.SetRefsNull();
        WriteLine($"Is ref null after SetRefsNull call: {intsWrapper.IsRefNull()}");
    }

    private ref struct IntArrayRefWrapper
    {
        // Are only allowed in ref structs (more at V72_RefStructs)
        private ref int _intsRef;
        private readonly ref int _intsReadonlyRef;
        private ref readonly int _intsRefReadonly;
        private readonly ref readonly int _intsReadonlyRefReadonly;

        public IntArrayRefWrapper(int[] intsArray)
        {
            _intsRef = ref MemoryMarshal.GetArrayDataReference(intsArray);
            _intsReadonlyRef = ref MemoryMarshal.GetArrayDataReference(intsArray);
            _intsRefReadonly = ref MemoryMarshal.GetArrayDataReference(intsArray);
            _intsReadonlyRefReadonly = ref MemoryMarshal.GetArrayDataReference(intsArray);
        }

        public void ReassingValueForTheFirstElement(int newValue)
        {
            _intsRef = newValue;
            _intsReadonlyRef = newValue;

            // ref readonly forbids assigning a value with '=' besides the constructor
            // _intsRefReadonly = 2;
            // _intsReadonlyRefReadonly = 2;
                        
            // all four refs may reference the same place int the memory, changing value for
            // _intsRef may also change value for _intsRefReadonly or _intsReadonlyRefReadonly
        }

        public void ReassingIntsRef(int[] intsArray)
        {
            _intsRef = ref MemoryMarshal.GetArrayDataReference(intsArray);
            _intsRefReadonly = ref MemoryMarshal.GetArrayDataReference(intsArray);

            // for redonly ref assigning a reference is only allowed inside constructors or init initializers
            // _intsReadonlyRef = ref MemoryMarshal.GetArrayDataReference(intsArray);
            // _intsReadonlyRefReadonly = ref MemoryMarshal.GetArrayDataReference(intsArray);
        }

        public void SetRefsNull()
        {
            // null can be assigned or checked by helper methods
            _intsRef = ref System.Runtime.CompilerServices.Unsafe.NullRef<int>();
        }

        public bool IsRefNull()
        {
            return System.Runtime.CompilerServices.Unsafe.IsNullRef(ref _intsRef);
        }

        public override string ToString()
        {
            return $"""
            IntArrayRefWrapper with value: 
            _intsRef: {_intsRef}
            _intsReadonlyRef: {_intsReadonlyRef}
            _intsRefReadonly: {_intsRefReadonly}
            _intsReadonlyRefReadonly: {_intsReadonlyRefReadonly}
            """;
        }
    }
}
