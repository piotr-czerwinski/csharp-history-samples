namespace CSharpHistorySamples
{
#pragma warning disable CS8619 // Nullability of reference types not existing in C# 6
    internal static class V6
    {
        // When in a catch clause
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/when#when-in-a-catch-clause
        public static async Task MakeGetRequestWithExceptionHandling(string requestURI, bool catchWhenUnknownStatusCode = true)
        {
            var client = new HttpClient();
            var streamTask = client.GetStringAsync(requestURI);
            try
            {
                var responseText = await streamTask;

                Console.WriteLine("MakeGet Success");
            }
            catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.Moved ||
                                                 e.StatusCode == System.Net.HttpStatusCode.MovedPermanently)
            {
                Console.WriteLine("Site Moved");
            }
            catch (HttpRequestException e) when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Site Not Found");
            }
            catch (HttpRequestException e) when (e.StatusCode is not null)
            {
                Console.WriteLine($"Failed with status code {e.StatusCode}. Message: {e.Message}");
            }
            catch (HttpRequestException e) when (catchWhenUnknownStatusCode)
            {
                Console.WriteLine($"Unknown status code of response. Message: {e.Message}");
            }
        }
    }
#pragma warning restore CS8619
}
