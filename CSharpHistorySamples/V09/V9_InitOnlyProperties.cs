namespace CSharpHistorySamples.V09;

internal static partial class V9
{
    internal static void InitOnlyProperties()
    {
        WriteFirstLineInSample("Init Only Properties");
        var obj1 = new ClassWithConstructorOptionalValues(1);

        // initializer is running after the constructor
        obj1 = new ClassWithConstructorOptionalValues(1, y: 3)
        {
            Y = 2,
        };

        WriteLine($"Value of Y (constructor - 3, initializer - 2): {obj1.Y}");

        var obj2 = new ClassWithParameterlessConstructor()
        {
            X = 1,
            Y = 2,
        };
    }

    internal class ClassWithConstructorOptionalValues
    {
        // Optional properties available on initialized
        public ClassWithConstructorOptionalValues(int x, int? y = null)
        {
            X = x;
            Y = y;
        }

        // private set - can be initialized only in constructors
        internal int X { get; private set; }

        // can be initialized in initialize
        internal int? Y { get; init; }

        // can be initialized in initialize
        internal int? Z { get; init; }
    }

    internal class ClassWithParameterlessConstructor()
    {
        internal int X
        {
            get; init;
        }
        internal int Y
        {
            get; init;
        }
    }
}
