using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace Benchmarks;

[MemoryDiagnoser]
public class V12_InlineArrays
{
    [Benchmark]
    public int ArrayInit()
    {
        var array = new int[100];

        return array[0];
    }

    [Benchmark]
    public int StackAllocInit()
    {
        Span<int> numbers = stackalloc int[100];

        return numbers[0];
    }

    [Benchmark]
    [SkipLocalsInit]
    public int StackAllocInitSkipLocalsInit()
    {
        Span<int> numbers = stackalloc int[100];
        return numbers[0];
    }

    [Benchmark]
    public int InlineArrayInit()
    {
        var inlineArray = new InlineArray();
        return inlineArray[0];
    }

    [Benchmark]
    [SkipLocalsInit]
    public int InlineArrayInitSkipLocalsInit()
    {
        var inlineArray = new InlineArray();
        return inlineArray[0];
    }

    [InlineArray(100)]
    private struct InlineArray
    {
        private int _element0;
    }

}