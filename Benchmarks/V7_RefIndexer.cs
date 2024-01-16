using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Benchmarks;


// More info https://devblogs.microsoft.com/premier-developer/performance-traps-of-ref-locals-and-ref-returns-in-c/
[SimpleJob]
[MemoryDiagnoser]
public class V7_RefIndexer
{
    long[]? sampleArray;
    GetSetIndexerList<long>? getSetIndexerList;

    long randomLong;
    int randomIndex;

    [GlobalSetup]
    public void Setup()
    {
        sampleArray = Enumerable.Range(0, 100).Select(x => (long)x).ToArray();
        getSetIndexerList = new GetSetIndexerList<long>(sampleArray);

        randomLong = Random.Shared.NextInt64();
        randomIndex = Random.Shared.Next(0, sampleArray.Length - 1);
    }

    [Benchmark]
    public long SetBySetter() => getSetIndexerList[randomIndex] = randomLong;

    [Benchmark]
    public long SetByRef() => sampleArray.AsSpan()[randomIndex] = randomLong;


    private class GetSetIndexerList<T>
    {
        private readonly T[] _items;

        public GetSetIndexerList(T[] items)
        {
            _items = new T[items.Length];
            Array.Copy(items, _items, items.Length);
        }

        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _items[i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => _items[i] = value;
        }
    }

    #region Span Internal Implementation

    private readonly ref struct RefStyleSpan<T>
    {
        /// <summary>A byref or a native ptr.</summary>
        internal readonly ByReference<T> _pointer;
        /// <summary>The number of elements this Span contains.</summary>
        private readonly int _length;

        public RefStyleSpan(T[] array)
        {
            _pointer = new ByReference<T>(ref MemoryMarshal.GetArrayDataReference(array));
            _length = array.Length;
        }

        public ref T this[int index]
        {
            //[Intrinsic]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            //[NonVersionable]
            get
            {
                ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _length);
                return ref Unsafe.Add(ref _pointer.Value, index);
            }
        }
    }

    internal readonly ref struct ByReference<T>
    {
#pragma warning disable CA1823, 169 // private field '{blah}' is never used
        private readonly IntPtr _value;
#pragma warning restore CA1823, 169

        //[Intrinsic]
        public ByReference(ref T value)
        {
            // Implemented as a JIT intrinsic - This default implementation is for
            // completeness and to provide a concrete error if called via reflection
            // or if intrinsic is missed.
            throw new PlatformNotSupportedException();
        }

        public ref T Value
        {
            // Implemented as a JIT intrinsic - This default implementation is for
            // completeness and to provide a concrete error if called via reflection
            // or if the intrinsic is missed.
            //[Intrinsic]
            get => throw new PlatformNotSupportedException();
        }
    }

    #endregion
}
