namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void FileScopedClass2()
    {
        // can be accessed in the same file
        _ = new FileScopedClass();
    }


    /*
     * Not valid as:
     * File-local type 'FileScopedClass' cannot be used in a member signature in non-file-local type 'V11'     
    static internal FileScopedClass MethodReturningFileScopedClass()
    {
    }
    */

    static internal object MethodReturningFileScopedClassAsObject()
    {
        return new FileScopedClass();
    }
}

file class FileScopedClass
{
}

