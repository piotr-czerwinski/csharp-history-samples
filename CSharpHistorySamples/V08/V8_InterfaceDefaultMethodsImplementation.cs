namespace CSharpHistorySamples;

internal static partial class V8
{
    // Main purpose is to avoid hidden copies when invoking struct methods 
    // more info:
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/readonly-instance-members#design
    // Not available in .NET framework
    internal static void InterfaceDefaultMethodsImplementation()
    {
        WriteFirstLineInSample("Interface default methods implementation");
        Shape shape = new();

        WriteLine("Calling M1 on Shape: " + shape.M1());
        //WriteLine("Calling M2 on Shape " + rectangleCastedToShape.M2()); // does not compile

        IDrawableObject shapeAsInterface = shape;
        WriteLine("Calling M1 on IDrawableObject (Shape): "+ shapeAsInterface.M1());
        WriteLine("Calling M2 on IDrawableObject (Shape): " + shapeAsInterface.M2());

        IDrawableObject rectangleAsInterface = new Rectangle();
        WriteLine("Calling M1 on IDrawableObject (Rectangle): " + rectangleAsInterface.M1());
        WriteLine("Calling M2 on IDrawableObject (Rectangle): " + rectangleAsInterface.M2());

        IDrawableObject squareAsInterface = new Square();
        WriteLine("Calling M2 on IDrawableObject (Square): " + squareAsInterface.M2());
    }

    internal interface IDrawableObject
    {
        string M1() => "Default M1";
        string M2() => "Default M2";
    }

    internal class Shape : IDrawableObject
    {
        public virtual string M1() => "Shape M1";
    }

    internal class Rectangle : Shape
    {
        public override string M1() => "Rectangle M1";

        public string M2() => "Rectangle M2";
    }

    internal class Square : Shape, IDrawableObject
    {
        public override string M1() => "M1 in Square";

        public string M2() => "M2 in Square";
    }

    internal interface IInterfaceWithProperty
    {
        // altrough property is composed from methods, this is not treated as default implementation
        // as interface cannot own backing fields
        int Prop
        {
            get; set;
        }
    }

    internal class ClassWithProperty : IInterfaceWithProperty
    {
        // implementation required
        public int Prop
        {
            get;set;
        }
    }
}
