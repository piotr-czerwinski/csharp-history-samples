namespace CSharpHistorySamples;

internal static partial class V8
{
    internal static void StaticLocalFunction()
    {
        WriteFirstLineInSample("StaticLocalFunction");

        int a = 1, b = 2;
        WriteLine("Add result: " + Add());
        WriteLine("Add result: " + AddStatic(a, b));

        int Add() => a + b;
        // static int AddStatic() => a + b; // does not compile as cannot capture local variables
        static int AddStatic(int a, int b) => a + b;

       // static long AddStatic(long a, long b) => a + b; // cannot use the same name (local vaiable cannot have the same name)
    }
}
