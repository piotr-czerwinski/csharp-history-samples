using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace Benchmarks;

public class V9_SkipLocalsInit
{
    [Benchmark]
    public void StackAlloc()
    {
        Span<int> numbers = stackalloc int[120];
    }

    [Benchmark]
    [SkipLocalsInit]
    public void StackAllocSkipLocalInit()
    {
        Span<int> numbers = stackalloc int[120];
    }
}