using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace Benchmarks;

public class V7_RefReturnOfStruct
{
    public struct BigStruct
    {
        public long l1, l2;
    }

    BigStruct structValue;

    [GlobalSetup]
    public void Setup()
    {
        structValue.l1 = Random.Shared.NextInt64();
    }

    [Benchmark]
    public long RetByValue()
    {
        long result = 0;
        for (int i = 0; i < 100; i++)
            result = MethodRetByByValue().l1;

        return result;
    }

    [Benchmark]
    public long RetByReference()
    {
        long result = 0;
        for (int i = 0; i < 100; i++)
            result = MethodRetByByReference().l1;

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    BigStruct MethodRetByByValue() => structValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    ref BigStruct MethodRetByByReference() => ref structValue;
}