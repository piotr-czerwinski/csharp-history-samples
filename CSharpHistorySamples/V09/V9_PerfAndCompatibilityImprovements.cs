using System.Runtime.CompilerServices;

namespace CSharpHistorySamples;

internal static partial class V9
{
    internal static void PerfAndCompatibilityImprovements()
    {
        NativeIntegers();
        ModuleInitializers();
        SkipLocalsInit();
        FunctionPointers();
    }

    private static void NativeIntegers()
    {
        WriteFirstLineInSample("Native Integers");
        //nint and nuint Its represented by IntPtr and UIntPtr internally
        int x = 1;
        nint y = 2;
        nuint z = 3;
        long l = 1;

        y = nint.MaxValue;

        WriteLine($"Type of int (x): {x.GetType()}");
        WriteLine($"Type of nint (y): {y.GetType()}");
        WriteLine($"Type of nuint (z): {z.GetType()}");
        WriteLine($"Type of int x + nint y: {(x + y).GetType()}");
        WriteLine($"nint.MaxValue: {nint.MaxValue}");
        WriteLine($"Type of long l + nint y: {(l + y).GetType()}");
        WriteLine($"Size of nint: {Unsafe.SizeOf<nint>()}");
    }

    private static void ModuleInitializers()
    {
        WriteFirstLineInSample("ModuleInitializers");
        WriteLine($"Text created during module initialization: {TextCreatedDuringModuleInitialization}");
    }

    private static string? TextCreatedDuringModuleInitialization
    {
        get; set;
    }

    // Called by the runtime when the assembly loads.
    [ModuleInitializer]
    public static void Init1()
    {
        TextCreatedDuringModuleInitialization += "Added by Init1 ";
    }

    [ModuleInitializer]
    public static void Init2()
    {
        TextCreatedDuringModuleInitialization += "Added by Init2 ";
    }

    [SkipLocalsInit]
    static void SkipLocalsInit()
    {
        WriteFirstLineInSample("SkipLocalsInit");
        // Local variables are NOT initialized with their default values when SkipLocalsInit is used.
        // For normal vars compiler is ensuring they are not accessed.
        // But with stackalloc it is possible to see garbage data
        Span<int> numbers = stackalloc int[200];
        var nonZeroNumbers = numbers
                            .ToArray()
                            .Select((number, index) => (number, index))
                            .Where(x => x.number > 0)
                            .Take(5);
        foreach (var (number, index) in nonZeroNumbers)
        {
            WriteLine($"Value on {index} element:{number}");
        }
    }

    // only in unsafe context
    unsafe static void FunctionPointers()
    {
        WriteFirstLineInSample("SkipLocalsInit");

        delegate*<string, int> getLength;

        // Avoids allocation in compression with delegates (before .NET 7).
        // Uses '&' to get address of the function
        getLength = &GetStringLength;

        // slightly faster invokes than delegates (avoid callvirt in favour of calli)
        WriteLine($"Length of xyz {getLength("xyz")}");

        // implicit cast
        void* genericFunctionParameter = getLength;

        // explicit cast when convert from void*
        getLength = (delegate*<string, int>)genericFunctionParameter;
        WriteLine($"Length of xyz {getLength("xyz")} (after casting)");
    }

    private static int GetStringLength(string input) => input.Length;
}
