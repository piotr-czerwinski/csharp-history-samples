namespace CSharpHistorySamples;

internal partial class V12
{
    internal static void PrimaryConstructors()
    {
        // Before C# 12 primary constructors were available for records only
        // In C# 12 class and structs also supports primary constructors with different behaviour
        WriteFirstLineInSample("Primary Constructors");

        PrimaryConstructorsForStructs();
        PrimaryConstructorForClasses();
    }

    private static void PrimaryConstructorsForStructs()
    {
        WriteFirstLineInSample("Primary Constructors: Structs");
        _ = new PointStruct(1, 2);

        // Primary constructor not called, when initialized as default or an array element
        var pointStruct = default(PointStruct);
        WriteLine($"PointStruct values default(PointStruct): {pointStruct}");

        var pointStructsArray = new PointStruct[1];
        WriteLine($"PointStruct values (new PointStruct[1]): {pointStructsArray[0]}");
    }

    private static void PrimaryConstructorForClasses()
    {
        WriteFirstLineInSample("Primary Constructors: Classes");

        _ = new Point(1, 2);
        var point = new Point(X: 1);
        WriteLine($"Point values: {point}");

        // point.X = 2; // not public
        point.IncrementX();
        WriteLine($"Point values after incrementation: {point}"); 
        
        var pointReadonlyProps = new PointReadonlyProps(0, 1);
        WriteLine($"Point values (readonly props): {point}");
        pointReadonlyProps.IncrementX();
        WriteLine($"Point values (readonly props) after incrementation: {point}");
    }
}
file struct PointStruct(int X, int Y = 1)
{
    public override readonly string? ToString() => $"X: {X}, Y: {Y}";
}

file class Point(int X, int Y = 0)
{
    public Point()
        : this(0, 0) // for other constructors the primary constructor must be called
    {
    }

    public void IncrementX()
    {
        X++; // in contrast to the record - fields are not readonly
    }

    public override string? ToString() => $"X: {X}, Y: {Y}";
}

file class PointReadonlyProps(int x, int y)
{
    public int X { get; } = x;

    public int Y { get; } = y;

    public void IncrementX()
    {
        // This does NOT change backing field of the X property!
        // Also warning:  Parameter 'int x' is captured into the state of the enclosing type
        // and its value is also used to initialize a field, property, or event.
        x++;

        /* Generated code
         * 
            private int <x>P;
            private readonly int <X>k__BackingField;

            public int X
            {
                get
                {
                    return <X>k__BackingField;
                }
            }

            (...)

            public PointReadonly(int x, int y)
            {
                <x>P = x;
                <X>k__BackingField = <x>P;
                <Y>k__BackingField = y;
                base..ctor();
            }

            private void IncrementX()
            {
                <x>P++;
            }
        */
    }
}