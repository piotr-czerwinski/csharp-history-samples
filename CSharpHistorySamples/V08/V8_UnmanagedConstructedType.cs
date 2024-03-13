namespace CSharpHistorySamples;

internal static partial class V8
{
    internal static void UnmanagedConstructedType()
    {
        // A type is called constructed if it is generic and the type parameter is already defined,
        // such as Point<string> or Point <int>.
        // Before C# 8, constructed types were not treated as unmanaged (and couldn't be used in unsafe context, like stackalloc)
        // C# onwards, if all fields are unmanaged, than also whole struct is treated as unmanaged

        Span<Point<int>> points = stackalloc[]
        {
            new Point<int> { X = 0, Y = 0 },
        };

        /* 
         * String is a managed type so not possible to allocate with stackalloc
        Span<Point<string>> points2 = stackalloc[]
        {
            new Point<string> { X = "0", Y = "0" },
        };
        */
    }

    public struct Point<T>
    {
        public T X;
        public T Y;
    }
}
