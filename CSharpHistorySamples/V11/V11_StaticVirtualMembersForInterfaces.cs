using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void StaticVirtualMembersForInterfaces()
    {
        WriteFirstLineInSample("Static Virtual Members for Interfaces");

        // Adding static virtual and abstract methods was driven by Generic Math
        // with math operators in generic interfaces for .net 7

        // Simple sample of implementation of generic Average of two values:
        var value1 = new WrappedIntWithAddition(2);
        var value2 = new WrappedIntWithAddition(4);

        WriteLine($"Value 1: {value1}");
        WriteLine($"Value 2: {value2}");
        WriteLine($"Avg: {Average(value1, value2)}");
    }

    public static T Average<T>(T value1, T value2)
        where T : ISimpleNumeric<T>
    {
        return (value1 + value2) / T.Create(2);
    }

    internal interface ISimpleNumeric<TSelf>
        where TSelf : ISimpleNumeric<TSelf>
    {
        // static abstract Members are now available. Must be implemented in the implementation
        static abstract TSelf operator +(TSelf left, TSelf right);
        static abstract TSelf operator /(TSelf left, TSelf right);

        // Virtual members can be created. Default implementation would be used if not override in the implementation.
        static virtual TSelf Create<TOther>(TOther value)
        {
            TSelf? result;

            if (typeof(TOther) == typeof(TSelf))
            {
                result = (TSelf)(object)value!;
            }
            else if (!TSelf.TryConvert<TOther>(value, out result))
            {
                throw new NotSupportedException();
            }

            return result;
        }

        protected static abstract bool TryConvert<TOther>(TOther value, out TSelf result);
    }

    public readonly record struct WrappedIntWithAddition(int Value) : ISimpleNumeric<WrappedIntWithAddition>
    {
        static WrappedIntWithAddition ISimpleNumeric<WrappedIntWithAddition>.operator +(WrappedIntWithAddition left, WrappedIntWithAddition right)
        {
            return new WrappedIntWithAddition(left.Value + right.Value);
        }
        static WrappedIntWithAddition ISimpleNumeric<WrappedIntWithAddition>.operator /(WrappedIntWithAddition left, WrappedIntWithAddition right)
        {
            // Production code would include additional validations
            return new WrappedIntWithAddition(left.Value / right.Value);
        }

        static bool ISimpleNumeric<WrappedIntWithAddition>.TryConvert<TOther>(TOther value, out WrappedIntWithAddition result)
        {
            if (typeof(TOther) == typeof(int))
            {
                int actualValue = (int)(object)value!;
                result = new WrappedIntWithAddition(actualValue);
                return true;
            }
            // else if (typeof(TOther) == typeof(double))
            // etc...
            else
            {
                result = default;
                return false;
            }
        }

        public override string ToString() => $"Wrapped {Value}";
    }
}
