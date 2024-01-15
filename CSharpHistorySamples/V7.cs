using System.Diagnostics.Metrics;

namespace CSharpHistorySamples
{
    internal static class V7
    {
        public static void RefRetAndRetLocals()
        {
            Console.WriteLine(Environment.NewLine + "RefRetAndRetLocals");
            var sampleArray = new int[] { 1, 2, 3, 4 };

            // ref local
            ref int firstValueRef = ref GetArrayFirstValueRef(sampleArray);

            firstValueRef = 42;
            Console.WriteLine($"firstValueRef: {sampleArray[0]}");

            // ref return and assignment
            GetArrayFirstValueRef(sampleArray) = 43;
            Console.WriteLine($"firstValueRef: {sampleArray[0]}");

            // local function && ref return
            static ref int GetArrayFirstValueRef(int[] array)
            {
                return ref array[0];
            }
        }

        public static void LocalFunctionAndEnumerator()
        {
            Console.WriteLine(Environment.NewLine + "LocalFunctionAndEnumerator");
            try
            {
                var enumerator = EnumerateYield(-1);
                Console.WriteLine("EnumerateYield: Enumerator retrieved");
                _ = enumerator.ToList();
            }
            catch { Console.WriteLine("EnumerateYield: Exception!"); }

            try
            {
                var enumerator = EnumerateLocalFunction(-1);
                Console.WriteLine("EnumerateLocalFunction: Enumerator retrieved");
                _ = enumerator.ToList();
            }
            catch { Console.WriteLine("EnumerateLocalFunction: Exception!"); }

            static IEnumerable<int> EnumerateYield(int count)
            {
                ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0);

                for (int i = 0; i <= count; i++)
                {
                    yield return i;
                }
            }

            static IEnumerable<int> EnumerateLocalFunction(int count)
            {
                ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0);

                return GetSequenceEnumerator();

                IEnumerable<int> GetSequenceEnumerator()
                {
                    for (int i = 0; i <= count; i++)
                    {
                        yield return i;
                    }
                }
            }
        }

    }
}
