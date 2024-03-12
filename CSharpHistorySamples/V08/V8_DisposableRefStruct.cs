namespace CSharpHistorySamples;

internal static partial class V8
{
    internal static void DisposableRefStruct()
    {
        // Although ref struct does not implement IDisposable pattern
        // It suffices that the Dispose method exists for the compiler to allow using "using"
        using var refStruct = new RefStructWithDispose();
    }

    private ref struct RefStructWithDispose// : IDisposable <- ref structs cannot implement any interface (C# 7.2 ref structs)
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
