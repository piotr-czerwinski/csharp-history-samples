namespace CSharpHistorySamples;

internal static partial class V9
{
    internal static void PatternMatchingImprovements()
    {
        WriteFirstLineInSample("Pattern Matching Enhancements");
        WriteLine($"Season for date 2023.7.1: {GetSeason(new DateTime(2023, 7, 1))}");
    }

    private static string GetSeason(DateTime date) => date.Month switch
    {   // Relational patterns (using greater than, less than etc.)
        >= 3 and < 6 => "Spring", //Conjunctive 'and' patterns
        >= 6 and < 9 => "Summer",
        >= 9 and < 12 => "Autumn",
        12 or (>= 1 and < 3) => "Winter", // Disjunctive 'or' patterns and Parenthesized patterns
        not >= 0 => throw new ArgumentOutOfRangeException(nameof(date), "Not positive month"), // Negated 'not' patterns
        _ => throw new ArgumentOutOfRangeException(nameof(date)),
    };
}
