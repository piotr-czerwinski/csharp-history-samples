using System.CommandLine;

namespace CSharpHistorySamples;

internal static class SampleRunner
{
    public static RootCommand BuildCommandLine(
        IEnumerable<(string token, Delegate handler)> allSamples
        )
    {
        Dictionary<string, Option<bool>>  options = [];
        foreach (var (token, _) in allSamples)
        {
            var aliases = token.Contains('.')
                ? new[] { $"-{token}", $"--{token}", $"-{token.Replace(".", "_")}", $"--{token.Replace(".", "_")}" }
                : [$"-{token}", $"--{token}"];
            var option = new Option<bool>(aliases, $"Run C# {token} samples");
            options[token] = option;
        }

        var allOption = new Option<bool>(["-all", "--all"], "Run all C# version samples");

        var rootCommand = new RootCommand("CSharp History Samples - Run C# version feature examples");
        foreach (var option in options.Values)
        {
            rootCommand.Add(option);
        }
        rootCommand.Add(allOption);

        rootCommand.SetHandler(async (context) =>
        {
            var all = context.ParseResult.GetValueForOption(allOption);
            var selectedSamples = new List<(string token, Delegate handler)>();

            if (all)
            {
                selectedSamples.AddRange(allSamples);
            }
            else
            {
                foreach (var (token, handler) in allSamples)
                {
                    if (context.ParseResult.GetValueForOption(options[token]))
                    {
                        selectedSamples.Add((token, handler));
                    }
                }

                if (selectedSamples.Count == 0)
                {
                    selectedSamples.AddRange(allSamples);
                }
            }

            await RunAsync(allSamples, selectedSamples);
        });

        return rootCommand;
    }

    public static async Task RunAsync(
        IEnumerable<(string token, Delegate handler)> allSamples,
        IEnumerable<(string token, Delegate handler)> selectedSamples)
    {
        foreach (var (_, handler) in selectedSamples)
        {
            // Check if handler returns a Task (async method)
            var result = handler.DynamicInvoke();
            if (result is Task task)
            {
                await task;
            }
        }
    }
}
