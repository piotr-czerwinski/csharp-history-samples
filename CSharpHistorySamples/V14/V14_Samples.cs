namespace CSharpHistorySamples;

using System;

internal static partial class V14
{
    // Removed aggregator BasicFeature. Individual feature methods are exposed below.

    internal static void NameOfUnboundGenericExample()
    {
        WriteFirstLineInSample("nameof with unbound generic types");
        WriteLine($"nameof(List<>) = {nameof(System.Collections.Generic.List<>)}");
    }

    internal static void FieldBackedPropertyExample()
    {
        WriteFirstLineInSample("field-backed property");

        var holder = new MessageHolder();
        try
        {
            holder.Message = null!; // should throw
        }
        catch (ArgumentNullException)
        {
            WriteLine("Caught ArgumentNullException as expected");
        }

        holder.Message = "Hello C# 14";
        WriteLine(holder.Message);
    }

    class MessageHolder
    {
        public string Message
        {
            get;
            set => field = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    internal static void NullConditionalAssignmentExample()
    {
        WriteFirstLineInSample("null-conditional assignment");

        Customer? c = null;
        c?.Order = CreateOrder("ShouldNotBeCreated"); // CreateOrder not called when c is null

        c = new Customer();
        c?.Order = CreateOrder("Created"); // CreateOrder called
    }

    class Customer { public Order? Order { get; set; } }
    class Order { public string Name; public Order(string n) { Name = n; WriteLine($"Order created: {n}"); } }
    static Order CreateOrder(string name) { WriteLine($"CreateOrder invoked for {name}"); return new Order(name); }

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

    internal static void ImplicitSpanConversionsExample()
    {
        WriteFirstLineInSample("implicit span conversions");

        Span<int> s = new int[] { 1, 2, 3 }; // implicit conversion from T[] to Span<T>
        ReadOnlySpan<int> rs = s; // implicit conversion from Span<T> to ReadOnlySpan<T>

        WriteLine($"Span length: {s.Length}, ReadOnlySpan length: {rs.Length}");
    }

    internal static async Task AsyncFeature()
    {
        WriteFirstLineInSample("V14 Async Feature Placeholder");
        await Task.Delay(1);
        WriteLine("AsyncFeature completed");
    }

    internal static void PatternsAndImprovements()
    {
        WriteFirstLineInSample("V14 Patterns and Improvements Placeholder");
        string? s = null;
        WriteLine(s ?? "null");
    }
}
