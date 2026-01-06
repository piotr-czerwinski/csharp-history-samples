namespace CSharpHistorySamples;

internal static partial class V14
{
    internal static void ExtensionMembersExample()
    {
        WriteFirstLineInSample("extension members (instance and static)");

        var arr = new[] { 1, 2, 3, (int?)null };
        WriteLine($"Not null count: {arr.NotNull().Count()}");
        WriteLine($"Contains null: {arr.ContainsNull}");

        var identity = List<int>.Identity;
        WriteLine($"Identity is not null: {identity is not null}");
    }
}
