namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void NameOfUnboundGenericExample()
    {
        WriteFirstLineInSample("nameof with unbound generic types");
        WriteLine($"nameof(List<>) = {nameof(List<>)}");
    }

    internal static void LambdaModifiersExample()
    {
        WriteFirstLineInSample("simple lambda parameters with modifiers");

        TryParse<int> parse1 = (text, out result) => int.TryParse(text, out result);
        if (parse1("123", out var value))
        {
            WriteLine($"Parsed: {value}");
        }
    }

    delegate bool TryParse<T>(string text, out T result);

    internal static void NullConditionalAssignmentExample()
    {
        WriteFirstLineInSample("null-conditional assignment");

        Customer? c = null;
        c?.Order = new Order("ShouldNotBeCreated"); // CreateOrder not called when c is null

        c = new Customer();
        c?.Order = new Order("Created"); // CreateOrder called
    }

    class Customer
    {
        public Order? Order
        {
            get; set;
        }
    }

    class Order
    {
        public string Name; 
        
        public Order(string n)
        {
            Name = n; 
            WriteLine($"Order created: {n}");
        }
    }
}
