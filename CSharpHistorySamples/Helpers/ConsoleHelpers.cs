﻿namespace CSharpHistorySamples.Helpers;
internal static class ConsoleHelpers
{
    internal static void WriteFirstLineInSample(string text, ConsoleColor foregroundColor = ConsoleColor.Green)
    {
        WriteLine();
        ForegroundColor = foregroundColor;
        WriteLine(text);
        ResetColor();
    }

    internal static void WriteLineWithParams(string text, params string[] stringValues)
    {
        WriteLine($"{text}: {string.Join(',', stringValues)}");
    }
}
