using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V8
{
    // more info:
    // https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/patterns-objects
    // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/pattern-matching
    internal static void PatternMatchingSwitchExpression()
    {
        WriteFirstLineInSample("Pattern matching (switch expression)");

        // switch by constant enum (might be any other constant like int, string)
        WriteLine(FileAccess.Read switch
        {
            FileAccess.Read => $"File Read",
            FileAccess.Write => "File Write",
            _ => "Other type"
        });

        ICollection collection = new List<int>() { 42 };
        // switch by type, property value
        WriteLine(collection switch
        {
            { Count: 0 } => $"Collection is empty",
            // IList { Count: 0 } => $"List is empty", compiler generate error, as condition is unreachable
            // IList { Count: 1 } => $"List with single element", https://github.com/dotnet/roslyn/issues/71660
            IList list => $"List of size {list.Count}",
            null => "A null object reference",
            _ => $"Other type of size {collection.Count}"
        });

        // simple state machine
        DoorState GetNewDoorState(DoorState currentState, Operation operation)
        {
            return (currentState, operation) switch
            {
                (_, Operation.Knock) => currentState,
                (DoorState.Destroyed, _) => DoorState.Destroyed,
                (DoorState.Opened, Operation.Close) => DoorState.Opened,
                (DoorState.Opened, Operation.Kick) => DoorState.Opened,
                (DoorState.Closed, Operation.Open) => DoorState.Opened,
                (DoorState.Closed, Operation.Kick) => DoorState.Destroyed,
                (_, _) => throw new InvalidOperationException("Operation cannot be performed"),
            };
        }

        DoorState currentState = DoorState.Closed;

        currentState = GetNewDoorState(currentState, Operation.Knock);
        WriteLine($"Current door state {currentState}");

        currentState = GetNewDoorState(currentState, Operation.Kick);
        WriteLine($"Current door state {currentState}");
    }

    private enum DoorState
    {
        Opened, Closed, Destroyed,
    }

    private enum Operation
    {
        Open, Close, Knock, Kick
    }
}
