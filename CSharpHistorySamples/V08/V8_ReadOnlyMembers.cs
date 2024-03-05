namespace CSharpHistorySamples;

internal static partial class V8
{
    // Main purpose is to avoid hidden copies when invoking struct methods 
    // more info:
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/readonly-instance-members#design
    internal static void ReadOnlyMembers()
    {
        var someReadOnlyStruct = new SomeReadOnlyStruct();
        OperationOnStruct(someReadOnlyStruct);
    }

    private static void OperationOnStruct(in SomeReadOnlyStruct someReadOnlyStruct)
    {
        // will compile as
        // var tmp = someReadOnlyStruct; <-- hidden copy
        // return tmp.IncrementMightMutateState();
        someReadOnlyStruct.IncrementMutatesState();

        // will not create hidden copy
        someReadOnlyStruct.IncrementDoesNotMutateState();
    }

    internal struct SomeReadOnlyStruct
    {
        private int a;
        private IDictionary<string, int> valuesDict;

        public SomeReadOnlyStruct()
        {
            a = 0;
            valuesDict = new Dictionary<string, int>
            {
                ["a"] = 0
            };
        }

        internal void IncrementMutatesState()
        {
            a++;
            valuesDict["a"] = valuesDict["a"] + 1;
        }

        internal void NoOp()
        {
        }

        internal readonly void IncrementDoesNotMutateState()
        {
            //a++; compiler error

            // this does not mutate anything in the struct (does not change valueDict reference)
            valuesDict["a"] = valuesDict["a"] + 1;

            // generates compiler warning for hidden copy (might be resolved with adding readonly modifier to NoOp
            NoOp();

            // even getter results with warning if not marked as readonly
            _ = AAccessor;
        }

        public readonly int A
        {
            get
            {
                return a;
            }
            set
            {
                //a = value; compiler error
                valuesDict["a"] = value;
            }
        }

        public int AAccessor => a;
    }
}
