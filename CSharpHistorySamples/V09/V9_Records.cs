namespace CSharpHistorySamples.V09;

internal static partial class V9
{
    internal static void Records()
    {
        WriteFirstLineInSample("Records");
        DerivedRecord derivedRecord = new DerivedRecord(1, 2);
        BaseRecord baseRecord = derivedRecord;

        // baseRecord.X = 2; cannot be mutated

        // new object can be created as a copy with optionally updated props
        var updatedRecord = baseRecord with
        {
            X = 1
        };

        WriteLine($"Are base and derived same references: {ReferenceEquals(baseRecord, derivedRecord)}");
        WriteLine($"Type of updated record: {updatedRecord.GetType()}");
        WriteLine($"Are base and updated same references: {ReferenceEquals(baseRecord, updatedRecord)}");
        WriteLine($"Hash codes; derived: {derivedRecord.GetHashCode()} base: {baseRecord.GetHashCode()} updated: {updatedRecord.GetHashCode()}");
        WriteLine($"Are equal base and updated: {baseRecord.Equals(updatedRecord)}");
        WriteLine($"Are equal derived and updated: {derivedRecord.Equals(updatedRecord)}");

        var record2 = new RecordWithParameterlessConstructor()
        {
            X = 1,
            Y = 2,
        };

        var record3 = record2;
        WriteLine($"Are same objects after assignment: {ReferenceEquals(record3, record2)}");
    }

    internal abstract record BaseRecord(int X); // can be abstract

    internal record DerivedRecord(int X, int Y) : BaseRecord(X);

    internal record RecordWithParameterlessConstructor()
    {
        internal int X
        {
            get; init;
        }
        internal int Y
        {
            get; init;
        }
    }

    // cannot inherit from classes:
    // internal class SomeClass();
    // internal record DerivedFromClassRecord() : SomeClass;
}
