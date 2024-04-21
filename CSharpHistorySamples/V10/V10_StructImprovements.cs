using System.Text;
using System.Text.Json.Serialization;

namespace CSharpHistorySamples;

internal static partial class V10
{
    internal static void StructImprovements()
    {
        WriteFirstLineInSample("Structs Improvements");
        ParameterLessConstructor();
        WithExpressionForStructs();
    }

    private static void ParameterLessConstructor()
    {
        var sampleStruct = new SampleStruct(); // explicit parameterless constructor call
        WriteLine($"Sample struct X: {sampleStruct.X}");

        var sampleStruct2 = default(SampleStruct); // constructor not called (default value set)
        WriteLine($"Sample struct 2 X: {sampleStruct2.X}");

        var structArray = new SampleStruct[1]; // constructor not called (default value set)
        WriteLine($"Struct array element 1 X: {structArray[0].X}");
    }
    private static void WithExpressionForStructs()
    {
        WriteLine($"With expression for structs: ");

        // similar to C#9 records
        var sampleStruct = new SampleStruct();
        var updatedStruct = sampleStruct
            with
        {
            X = 3
        };

        WriteLine($"Original struct, X: {sampleStruct.X}");
        WriteLine($"New struct, X: {updatedStruct.X}");


        // also works for anonymous types
        var anonymousTypeInstance = new
        {
            X = 1,
            Y = 2,
        };

        var updatedAnonymousTypeInstance = anonymousTypeInstance with
        {
            X = 2,
        };

        WriteLine($"Original anonymous, X: {anonymousTypeInstance.X}");
        WriteLine($"New anonymous, X: {updatedAnonymousTypeInstance.X}");
    }

    public struct SampleStruct
    {
        public SampleStruct()
        {
            X = double.NaN;
            Y = double.NaN;
        }

        public double X
        {
            get; init;
        }

        public double Y
        {
            get; init;
        }
    }
}
