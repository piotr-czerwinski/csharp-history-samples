namespace CSharpHistorySamples;

internal static partial class V13
{
    internal static void RefStructInterfaces()
    {
        WriteFirstLineInSample("Ref struct interfaces");

        var refStruct = new RefStruct();

        // Cannot be converted
        // ISomeInterface someInterface = refStruct;
        // _ = refStruct as ISomeInterface;
        // MethodWithInterfaceParam(refStruct);

        // Try cast to ISomeInterface using reflection
        // Try cast to ISomeInterface using reflection
        var interfaceType = typeof(ISomeInterface);
        var isAssignable = interfaceType.IsAssignableFrom(typeof(RefStruct));
        WriteLine($"Is refStruct assignable to ISomeInterface: {isAssignable}");
    }

    private static void MethodWithInterfaceParam(ISomeInterface _) {}

    private ref struct RefStruct : ISomeInterface
    {
        public readonly void SomeMethod() {}

        // All methods need to be implemented, even if they have default implementation
        public readonly void SomeMethodWithDefaultImplementation() {}

        // Conversions not allowed
        //public static implicit operator ISomeInterface(RefStruct v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    private interface ISomeInterface
    {
        void SomeMethod();

        void SomeMethodWithDefaultImplementation() => Console.WriteLine("Default implementation");
    }
}
