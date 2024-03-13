using System.Runtime.CompilerServices;

namespace CSharpHistorySamples;

internal static partial class V8
{
    internal async static Task AsyncStreams()
    {
        WriteFirstLineInSample("AsyncStreams");
        await AsyncDisposable();
        await AsyncStream();
    }

    private async static Task AsyncDisposable()
    {
        await using var classWithAsync = new ClassWithAsyncDispose();

        WriteLine("Using ClassWithAsyncDispose");
    }

    private class ClassWithAsyncDispose : IAsyncDisposable
    {
        // It is advised to also implement IDisposable, as consumer may not use async context

        public async ValueTask DisposeAsync()
        {
            // Flush to file asynchronously. Save file asynchronously, Send http request etc.
            await Task.Delay(1);
            WriteLine("In DisposeAsync");
        }
    }

    private async static Task AsyncStream()
    {
        var tokenSource = new CancellationTokenSource();
        await foreach (var iteration in GetAsyncEnumerable(3).WithCancellation(tokenSource.Token))
        {
            WriteLine("Async Stream (IAsyncEnumerable), iteration: " + iteration);
        }

        /*
         * It is also possible to pass token directly to the method,
         * await foreach (var iteration in GetAsyncEnumerable(5, tokenSource.Token))
         * But it behaves differently.
         * More on it: https://learn.microsoft.com/en-us/archive/msdn-magazine/2019/november/csharp-iterating-with-async-enumerables-in-csharp-8#a-tour-through-async-enumerables
         */

        await foreach (var iteration in new ClassWithAsyncEnumerableShape(3))
        {
            WriteLine("Async Stream (proper shape), iteration: " + iteration);
        }
    }


    static async IAsyncEnumerable<int> GetAsyncEnumerable(
        int iterationCount,
        [EnumeratorCancellation] CancellationToken token = default) // <- filled by the compiler
    {
        while (!token.IsCancellationRequested && iterationCount > 0)
        {
            await Task.Delay(100, token);
            yield return iterationCount--;
        }
    }

    internal class ClassWithAsyncEnumerableShape
    {
        private readonly int _iterationCount;

        public ClassWithAsyncEnumerableShape(int iterationCount)
        {
            _iterationCount = iterationCount;
        }

        // must be public or extension method. Name must be `GetAsyncEnumerator`
        public AsyncEnumeratorShape GetAsyncEnumerator()
            => new AsyncEnumeratorShape(_iterationCount);

        internal class AsyncEnumeratorShape // : IAsyncEnumerator<int> may implement, but also works if class has a proper shape
        {
            private int _iterationCount;

            public AsyncEnumeratorShape(int iterationCount)
            {
                _iterationCount = iterationCount;
            }

            // Required to match shape
            public int Current => _iterationCount + 1;

            // Required to match shape
            public async ValueTask<bool> MoveNextAsync()
            {
                await Task.Delay(100); 

                _iterationCount--;
                return _iterationCount >= 0;
            }

            // Optional Dispose
#pragma warning disable CA1822 // Mark members as static <- when not implementing interface and not accessing any field, property, etc
            public async ValueTask DisposeAsync()
            {
                await Task.Delay(1);
                WriteLine("In DisposeAsync of AsyncEnumeratorShape");
            }
#pragma warning restore CA1822
        }
    }
}
