using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CSharpHistorySamples;

internal static partial class V8
{
    internal static void NullableReferenceType()
    {
        PersonClass();
        HelperAttributes();
    }

    private static void PersonClass()
    {
        var somePerson = new Person(
            null, // warning
            null, // no warning
            null!); // no warning (silenced with null-forgiving operator)

        if (somePerson.MiddleName is not null)
        {
            _ = somePerson.MiddleName.Substring(0); // no warning
        }

        if (!string.IsNullOrWhiteSpace(somePerson.MiddleName))
        {
            // no warning, compiler can detect null check by attributes decorating IsNullOrWhiteSpace
            _ = somePerson.MiddleName.Substring(0); 
        }

        if (somePerson.HasMiddleName())
        {
            _ = somePerson.MiddleName.Substring(0); // warning, compiler not smart enough to analyse content of custom method
            _ = somePerson.MiddleName.Substring(0); // no warning. If we got here it means previous line did not throw
        }

        if (somePerson.HasMiddleName())
        {
            _ = somePerson.MiddleName!.Substring(0); // no warning - silenced
        }

        somePerson = somePerson with
        {
            MiddleName = "middle name"
        };

        ThrowsIfStringNull(somePerson.MiddleName);
        _ = somePerson.MiddleName.Substring(0); // no warning, as previous method would throw if null ([NotNull] with parameter)

        somePerson = somePerson with
        {
            MiddleName = null
        };

        if (StringValueIsNotEmpty(somePerson.MiddleName))
        {
            // no warning, StringValueIsNotEmpty parameter attributed with [NotNullWhen(true)]
            // similar to string.IsNullOrWhiteSpace
            _ = somePerson.MiddleName.Substring(0);
        }
    }

    internal record Person(string FirstName, string? MiddleName, string LastName)
    {
        internal bool HasMiddleName() => !string.IsNullOrWhiteSpace(MiddleName);
    }

    public static void ThrowsIfStringNull([NotNull] string? value) => ArgumentNullException.ThrowIfNull(value, nameof(value));

    public static bool StringValueIsNotEmpty([NotNullWhen(true)] string? value) => !string.IsNullOrWhiteSpace(value);


    internal static void HelperAttributes()
    {
        var testClass = new NullableReferencesTests();

        testClass.NotNullableProperty = null; // warning
        testClass.AllowNullNotNullableProperty = null; // no warning, as attributed with [AllowNull]
        testClass.DisallowNullNullableProperty = null; // warning, as attributed with [DisallowNull]

        SomeInterface<string> testClassAsInterface = testClass;
        string _ = testClassAsInterface.MethodResultMaybeNull(); // warning, interface method is attributed with [MaybeNull[
    }

    private interface SomeInterface<T>
    {
        [return: MaybeNull]
        T MethodResultMaybeNull();
    }

    private class NullableReferencesTests : SomeInterface<string>
    {
        public string NotNullableProperty
        {
            get => _field;
            set => _field = value;
        }

        // Implementation ensures that setter will never assign null and respectively getter would not return null
        [AllowNull]
        public string AllowNullNotNullableProperty
        {
            get => _field;
            set => _field = value ?? string.Empty;
        }

        // Although property is nullable, with this attribute, assigning null would result with warning
        [DisallowNull]
        public string? DisallowNullNullableProperty
        {
            get => _field;
            set => _field = value;
        }

        private string _field = string.Empty;

        // Implementation may be less strict than interface method declaration (and allows returning nulls)
        public string? MethodResultMaybeNull()
        {
            return _field;
        }
    }
}
