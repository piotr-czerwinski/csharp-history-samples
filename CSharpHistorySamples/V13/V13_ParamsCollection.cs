namespace CSharpHistorySamples;

internal partial class V13
{
    internal static void ParamsCollection()
    {
        WriteFirstLineInSample("Params Collection");

        ParamsCollectionBasic();


        //SampleMethodWithIntParamsConcreteType(1);  // ambiguous call

        //SampleMethodWithIntParamsConcreteType(1);
        //SampleMethodWithIntParamsConcreteType([]); // ambiguous
        SampleMethodWithIntParamsConcreteTypes(new List<int>());
        SampleMethodWithIntParamsConcreteTypes(Array.Empty<int>());
        SampleMethodWithIntParamsConcreteTypes(Array.Empty<int>().AsSpan());

        var _ = SampleMethodWithDiffReturn(1);
        long __ = SampleMethodWithDiffReturn(1); // still method with int result selected (no override decission based on left side of the assignment)
        var lExpected = SampleMethodWithDiffReturn(new List<int>()); // long returned
    }

    private static void ParamsCollectionBasic()
    {
        // array params selected
        SampleMethodWithIntParams(1);
        SampleMethodWithIntParams([1]);
        SampleMethodWithIntParams(Array.Empty<int>());
        SampleMethodWithIntParams(new List<int>()); // IList override selected
        //SampleMethodWithIntParams(Array.Empty<int>().AsSpan()); // no match        
        SampleMethodWithIntParams((byte)1);
        //SampleMethodWithIntParams(Array.Empty<byte>()); fails asdifferent type
    }

    private static int SampleMethodWithIntParams(params int[] _) => 0; // suported before C#13
    private static int SampleMethodWithIntParams(params IEnumerable<int> paramNames) => 0;
    private static int SampleMethodWithIntParams(params ICollection<int> paramNames) => 0;
    private static int SampleMethodWithIntParams(params IList<int> paramNames) => 0;


    private static int SampleMethodWithIntParamsConcreteType(params int[] _) => 0;
    private static int SampleMethodWithIntParamsConcreteType(params List<int> paramNames) => 0;

    private static int SampleMethodWithIntParamsConcreteTypes(params int[] _) => 0;
    private static int SampleMethodWithIntParamsConcreteTypes(params List<int> paramNames) => 0;
    private static int SampleMethodWithIntParamsConcreteTypes(params Span<int> paramNames) => 0;

    private static int SampleMethodWithDiffReturn(params int[] paramNames) => 0;
    private static long SampleMethodWithDiffReturn(params ICollection<int> paramNames) => 0;
}
