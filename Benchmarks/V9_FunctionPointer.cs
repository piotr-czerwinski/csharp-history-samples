using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace Benchmarks;

[MemoryDiagnoser]
public class V9_FunctionPointer
{
    [Benchmark]
    public unsafe string FunctionPointer()
    {
        delegate*<string> functionPointer =  &GetString;
        return functionPointer();
    }

    [Benchmark]
    public string Delegate()
    {
        // Optimized in .NET 7 runtime to allocate only once. Some perf diff still visible (callvirt vs calli Opts)
        Func<string> @delegate = GetString;
        return @delegate();
    }

    private static string GetString() => string.Empty;
}