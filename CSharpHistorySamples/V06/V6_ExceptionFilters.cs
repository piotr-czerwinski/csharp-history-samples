﻿namespace CSharpHistorySamples;

internal static partial class V6
{
    // When in a catch clause
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/when#when-in-a-catch-clause
    internal static async Task MakeGetRequestWithExceptionFilters(string requestURI, bool catchWhenUnknownStatusCode = true)
    {
        WriteFirstLineInSample("Exception filters");
        var client = new HttpClient();
        var streamTask = client.GetStringAsync(requestURI);
        try
        {
            var responseText = await streamTask;

            WriteLine("MakeGet Success");
        }
        catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.Moved ||
                                             e.StatusCode == System.Net.HttpStatusCode.MovedPermanently)
        {
            WriteLine("Site Moved");
        }
        catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            WriteLine("Site Not Found");
        }
        catch (HttpRequestException e) when (e.StatusCode is not null)
        {
            WriteLine($"Failed with status code {e.StatusCode}. Message: {e.Message}");
        }
        catch (HttpRequestException e) when (catchWhenUnknownStatusCode)
        {
            WriteLine($"Unknown status code of response. Message: {e.Message}");
        }
    }
}

