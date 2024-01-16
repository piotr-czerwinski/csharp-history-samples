namespace CSharpHistorySamples;

internal static partial class V7
{
    public static void RefReturnAndRefLocals()
    {
        WriteLine(Environment.NewLine + "RefRetAndRetLocals");
        var sampleArray = new int[] { 1, 2, 3, 4 };

        // ref local
        ref int firstValueRef = ref GetArrayFirstValueRef(sampleArray);

        firstValueRef = 42;
        WriteLine($"firstValueRef: {sampleArray[0]}");

        // ref return and inline value assignment
        GetArrayFirstValueRef(sampleArray) = 43;
        WriteLine($"firstValueRef: {sampleArray[0]}");

        // local function && ref return
        ref int GetArrayFirstValueRef(int[] array)
        {
            return ref array[0];
        }
    }

    public static void RefReturnForIndexer()
    {
        WriteLine(Environment.NewLine + "RefReturnForIndexer");

        var setGetIndexerStruct = new SetGetIndexerStruct();
        setGetIndexerStruct[0] = 1;
        WriteLine($"SetGetIndexerStruct: {setGetIndexerStruct[0]}");

        var refReturnIndexerStruct = new RefReturnIndexerStruct();
        refReturnIndexerStruct[0] = 2;
        WriteLine($"RefReturnIndexerStruct: {refReturnIndexerStruct[0]}");
    }

    private readonly struct SetGetIndexerStruct
    {
        readonly int[] _array;

        public SetGetIndexerStruct()
        {
            _array = new int[100];
        }

        public readonly int this[int i]
        {
            get => _array[i];
            set => _array[i] = value;
        }
    }

    private readonly struct RefReturnIndexerStruct
    {
        readonly int[] _array;

        public RefReturnIndexerStruct()
        {
            _array = new int[100];
        }

        public readonly ref int this[int i]
        {
            get => ref _array[i];
        }
    }


}
