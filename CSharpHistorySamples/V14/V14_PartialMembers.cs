namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void PartialConstructorsExample()
    {
        WriteFirstLineInSample("partial constructors demonstration");

        var p = new PartialType(42);
        WriteLine($"PartialType value: {p.Value}");
    }

    internal static void PartialEventsExample()
    {
        WriteFirstLineInSample("partial events demonstration");

        var obj = new PartialType(42);
        obj.MyEvent += (s, e) => WriteLine("Event fired");
        obj.Raise();
    }
}

partial class PartialType
{
    // implementing defining declaration
    public partial PartialType(int v);

    // defining declaration - field-like event
    public partial event EventHandler? MyEvent;
}

partial class PartialType
{
    public int Value { get; private set; }

    // implementing  declaration
    public partial PartialType(int v)
    {
        Value = v;
    }

    // implementing declaration - provide add/remove
    public partial event EventHandler? MyEvent
    {
        add
        {
            _myEvent += value;
        }
        remove
        {
            _myEvent -= value;
        }
    }

    private EventHandler? _myEvent;

    public void Raise() => _myEvent?.Invoke(this, EventArgs.Empty);
}