using System;
using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void RequiredMembers()
    {
        /* 
         * Would not compile with en error
         * Required member 'V11.Person.Last' must be set in the object initializer or attribute constructor.
        var person = new Person()
        {
            First = "First name",
        };
        */

        var person = new Person()
        {
            First = "First name",
            Last = "Last name"
        };
    }

    // Property must be set as error states:
    // Required member 'V11.SampleAttribute.RequiredProp' must be set in the object initializer or attribute constructor
    // [SampleAtr]
    [SampleAtr(RequiredProp = "")]
    private class Person()
    {
        // When not marked as required, it would be possible to construct object with no value set
        // as there is no constructor setting any values
        public required string First { get; init;}
        public string? Middle { get; init;}
        public required string Last { get; init;}
    }

    private class SampleAtrAttribute : Attribute
    {
        public required string RequiredProp
        {
            get; init;
        }
    }
}
