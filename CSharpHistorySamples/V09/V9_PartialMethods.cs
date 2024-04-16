namespace CSharpHistorySamples.V09;

internal static partial class V9
{
    internal static void PartialMethods()
    {
    }

    partial class Class : IInterface
    {
        /* Before C#9 partial methods could not:
         - return value
         - have out parameters
         - have accessibility defined (public, protected)
        With C#9 onward it is possible, but implementation is required
        It was added to support Code Generators like RegexGenerated attributed methods:
        [RegexGenerated("[a-zA-Z]"]
        public partial bool IsAsciiLetter(string input);
        */
        partial void PartialBeforeCSharp8();

        private partial void PrivatePartial();

        public partial void PublicPartial();

        private partial int PartialWithReturnValue();

        private partial void MethodWithOutParameter(out int result);

        public partial void InterfaceMethod();
    }

    partial class Class
    {
        private partial void PrivatePartial() { }

        public partial void PublicPartial() { }

        private partial int PartialWithReturnValue() => 0;

        private partial void MethodWithOutParameter(out int result) => result = 0;

        public partial void InterfaceMethod() {}
    }

    public interface IInterface
    {
        void InterfaceMethod();
    }
}
