namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void AutoDefaultStructs()
    {
        WriteFirstLineInSample("Auto-Default Structs");

        var structInstance = new StructWithAutoDefaultInits(x: 1);
        WriteLine(structInstance);
    }

    private record struct StructWithAutoDefaultInits
    {
        public StructWithAutoDefaultInits(int x)
        {
            X = x;

            /*
             * Before C# 11 Y would also need to be initialized here
             * In C# 11 all not explicitly initialized values are set to default by the compiler.
             * In Sharplab.io compiler generates:
             
                public StructWithAutoDefaultInits(int x)
                {
                    <Y>k__BackingField = 0;
                    X = x;
                }
            */

        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
