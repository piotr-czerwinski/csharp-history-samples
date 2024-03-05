namespace CSharpHistorySamples;

internal static partial class V72
{
    internal static void StackallocArraysInSafeContext(int arraySize)
    {
        // it allocated on a stack so "new" heap object allocated and no GC needed
        // before 7.2 unsafe context was required for stackalloc
        Span<byte> stackallocatedArray= stackalloc byte[10];
        stackallocatedArray[1] = 3;

        // for large size buffers, stack size might be a problem (it's 1MB for 32 bits and 4MB for 64 bits)
        Span<byte> array = arraySize > 512 * 1024 ?
            new byte[arraySize] :
            stackalloc byte[arraySize];

        // initializers from c# 7.3
        Span<byte> stackallocatedArray2 = stackalloc byte[] { 1, 2, 3, 4 };
    }
}
