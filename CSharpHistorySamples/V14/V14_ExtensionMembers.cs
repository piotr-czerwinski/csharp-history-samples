namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void ExtensionMembersExample()
    {
        WriteFirstLineInSample("extension members (instance and static)");

        var arr = new[] { 1, 2, 3 };
        WriteLine($"IsEmpty: {arr.IsEmpty()}");

        var combined = arr.CombineWith(new[] { 4, 5 });
        WriteLine($"Combined count: {combined.Count()} ");

        var identity = EnumerableHelpers.Identity<int>();
        WriteLine($"Identity is empty: {identity is not null}");

        var sum = arr.ConcatWith(new[] { 4, 5 });
        WriteLine($"Sum count: {sum.Count()} ");
    }
}
