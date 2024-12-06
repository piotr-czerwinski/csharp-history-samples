namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void RefReadOnlyParams()
    {
        // 'ref readonly' params are close, but not identical to 'in' params
        // both forbid changing value of the param.
        // Difference are on the call site:
        int x = 0;
        MethodWithInParam(x);

        // warning: Argument 1 should be passed with 'ref' or 'in' keyword
        MethodWithRefReadonlyParam(x); 
        MethodWithRefReadonlyParam(ref x); // no warning
        MethodWithRefReadonlyParam(in x); // no warning with 'in' too


        MethodWithInParam(1); // can be rvalue (any expression)

        // warning: Argument 1 should be a variable because it is passed to a 'ref readonly'
        MethodWithRefReadonlyParam(1);

        //compilation error: A ref or out value must be an assignable variable
        //MethodWithRefReadonlyParam(ref 1);

        static void MethodWithInParam(in int x)
        {
            // changing value not allowed
            // x++;
        }

        static void MethodWithRefReadonlyParam(ref readonly int x)
        {
            // changing value not allowed
            // x++;
        }
    }
}