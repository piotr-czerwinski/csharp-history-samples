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
#pragma warning disable CA1822 // Mark members as static <- Compiler does not match proper shape if method was static
        public readonly void Dispose()
        {
        }
#pragma warning restore CA1822
    }
}
