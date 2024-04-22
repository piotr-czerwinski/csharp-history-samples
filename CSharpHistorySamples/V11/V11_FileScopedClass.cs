namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void FileScopedClass()
    {
        WriteFirstLineInSample("File Scoped Class");

        // not accessible as defined in V11_FileScopedClass2.cs
        // _ = new FileScopedClass();

        var instance = MethodReturningFileScopedClassAsObject();
        WriteLine(instance.GetType().FullName);
    }
}


