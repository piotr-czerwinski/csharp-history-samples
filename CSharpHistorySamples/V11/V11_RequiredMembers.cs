using System.Diagnostics.CodeAnalysis;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void RequiredMembers()
    {
        /* 
         * Would not compile. Error:
         * Required member 'V11.Person.Last' must be set in the object initializer or attribute constructor.
        var person = new Person()
        {
            First = "First name",
        };
        */

        var person = new Person()
        {
            FirstName = "First name",
            LastName = "Last name"
        };

        _ = new SimplePerson(); // No error, as constructor marked with [SetsRequiredMembers]
    }

    // Property must be set as error states:
    // Required member 'V11.SampleAttribute.RequiredProp' must be set in the object initializer or attribute constructor
    // [SampleAtr]
    [SampleAttribute(RequiredProp = "")]
    private class Person()
    {
        // When not marked as required, it would be possible to construct object with no value set
        // as there is no constructor setting any values
        public required string FirstName { get; init; }

        public string? MiddleName { get; init; }

        public required string LastName { get; init; }
    }

    private class SampleAttribute : Attribute
    {
        public required string RequiredProp
        {
            get; init;
        }
    }

    private class SimplePerson
    {
        [SetsRequiredMembers]
        public SimplePerson()
        {
            // warning would be raised raised if values
            // had not been assigned for required properties
            FirstName = "";
            LastName = "";
        }

        public required string FirstName { get; init; }

        public required string LastName { get; init; }
    }
}
