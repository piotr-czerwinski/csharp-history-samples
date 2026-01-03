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

        var obj = new EventHolder();
        obj.MyEvent += (s, e) => WriteLine("Event fired");
        obj.Raise();
    }
}

partial class PartialType
{
    public int Value { get; private set; }

    // defining declaration
    partial void Construct(int v);

    public PartialType(int v)
    {
        Construct(v);
    }
}

partial class PartialType
{
    // implementing declaration
    partial void Construct(int v)
    {
        Value = v;
    }
}

partial class EventHolder
{
    // defining declaration - field-like event
    public partial event EventHandler? MyEvent;
}

partial class EventHolder
{
    // implementing declaration - provide add/remove
    public partial event EventHandler? MyEvent
    {
        add { _myEvent += value; }
        remove { _myEvent -= value; }
    }

    private EventHandler? _myEvent;

    public void Raise() => _myEvent?.Invoke(this, EventArgs.Empty);
}
