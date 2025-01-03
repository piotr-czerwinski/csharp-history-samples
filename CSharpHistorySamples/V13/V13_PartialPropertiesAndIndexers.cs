namespace CSharpHistorySamples;

internal static partial class V13
{
    internal static void PartialPropertiesAndIndexers()
    {
    }

    // definietions
    partial class Class
    {
        public partial string Name
        {
            get;
        }

        public partial string this[int index] { get; }
    }

    // implementation
    partial class Class
    {
        // auto-properties cannot be usued in partial methods
        //public partial string Name
        //{
        //    get;
        //}

        public partial string Name => nameof(Class);
        public partial string this[int index]
        {
            get => index.ToString();
        }
    }
}
