using CSharpHistorySamples;

Console.WriteLine("************************************ V6 ************************************");

// Exception and 'when' filtering 

// await V6.MakeGetRequestWithExceptionFilters("https://localHost:666");
// await V6.MakeGetRequestWithExceptionFilters($"https://google.com/not-existing-site/{Random.Shared.NextDouble()}");


Console.WriteLine("************************************ V7 ************************************");

// local function
// ref return
// ref local

V7.RefRetAndRetLocals();
V7.LocalFunctionAndEnumerator();


Console.WriteLine("************************************ V7.1 ************************************");