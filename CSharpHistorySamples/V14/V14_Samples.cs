namespace CSharpHistorySamples;

using System;
using System.Runtime.CompilerServices;

internal static partial class V14
{
    internal static void FieldBackedPropertyExample()
    {
        WriteFirstLineInSample("field-backed property");

        var holder = new MessageHolder();
        try
        {
            holder.NonNullableMessage = null!; // should throw
        }
        catch (ArgumentNullException)
        {
            WriteLine("Caught ArgumentNullException as expected");
        }

        holder.NonNullableMessage = "Hello C# 14";
        WriteLine(holder.NonNullableMessage);
    }

    class MessageHolder
    {
        public string NonNullableMessage
        {
            get => field ?? string.Empty;
            set => field = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    internal static void ImplicitSpanConversionsExample()
    {
        WriteFirstLineInSample("implicit span conversions");

        Span<int> s = [1, 2, 3]; // implicit conversion from T[] to Span<T>
        ReadOnlySpan<int> rs = s; // implicit conversion from Span<T> to ReadOnlySpan<T>

        WriteLine($"Span length: {s.Length}, ReadOnlySpan length: {rs.Length}");

        ReadOnlySpan<char> stringSpan = "string";
        WriteLine($"String ReadOnlySpan length: {stringSpan.Length}");

        ReadOnlySpan<Derived> intSpan = Array.Empty<Derived>();
        ConsumeReadOnlySpanOfObject(intSpan);

        static void ConsumeReadOnlySpanOfObject(ReadOnlySpan<Base> span)
        {
            WriteLine($"Consumed ReadOnlySpan of Base with length: {span.Length}");
        }
    }

    private class Derived : Base
    {
    }

    private class Base
    {
    }
    internal static void NameOfUnboundGenericExample()
    {
        WriteFirstLineInSample("nameof with unbound generic types");
        WriteLine($"nameof(List<>) = {nameof(System.Collections.Generic.List<>)}");
    }

    internal static void NullConditionalAssignmentExample()
    {
        WriteFirstLineInSample("null-conditional assignment");

        Customer? c = null;
        c?.Order = CreateOrder("ShouldNotBeCreated"); // CreateOrder not called when c is null

        c = new Customer();
        c?.Order = CreateOrder("Created"); // CreateOrder called
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
        public string Name; public Order(string n)
        {
            Name = n; WriteLine($"Order created: {n}");
        }
    }
    static Order CreateOrder(string name)
    {
        WriteLine($"CreateOrder invoked for {name}"); return new Order(name);
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
