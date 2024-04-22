using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V7
{
    internal static void PatternMatchingInSwitch()
    {
        WriteFirstLineInSample("Pattern matching (switch)");

        ICollection collection = new List<int>() { 42 };

        switch (collection)
        {
            case ICollection when collection.Count == 0:
                WriteLine($"Collection is empty");
                break;

            case IList when collection.Count == 0:
                WriteLine($"List is empty");
                break;

            case IList list when list.Count == 1:
                WriteLine($"List with single element");
                break;

            case IList list:
                WriteLine($"List of size {list.Count}");
                break;

            case null:
                WriteLine("A null object reference");
                break;

            default:
                WriteLine($"Other type of size {collection.Count}");
                break;
        }
    }
}
