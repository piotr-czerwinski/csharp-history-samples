// global usings - introduced in C# 10
global using static System.Console;
global using static CSharpHistorySamples.Helpers.ConsoleHelpers;

using CSharpHistorySamples;
using CSharpHistorySamples.V09;

#pragma warning disable CS8321 // Local function is declared but never used

//await V6Samples();
//V7Samples();
//V7_1Samples();
//V7_2Samples();
//V7_3Samples();
//await V8Samples();
//V9Samples();
//V10Samples();
V11Samples();
//V12Samples();

static async Task V6Samples()
{
    WriteFirstLineInSample("************************************ V6 (2015) ************************************");

    // Exception and 'when' filtering 
    await V6.MakeGetRequestWithExceptionFilters("https://localHost:666");
}

static void V7Samples()
{
    WriteFirstLineInSample("************************************ V7 (3.2017) ************************************");

    V7.RefReturnAndRefLocals();
    V7.RefReturnForIndexer();

    V7.LocalFunctionAndEnumerator();

    V7.PatternMatchingInSwitch();
}

static void V7_1Samples()
{
    WriteFirstLineInSample("************************************ V7.1 (8.2017) ************************************");

    V71.PatternMatchingForGenericParameter(parameter: "lorem ipsum");
}

static void V7_2Samples()
{
    WriteFirstLineInSample("************************************ V7.2 (11.2017) ************************************");

    V72.StackallocArraysInSafeContext(arraySize: 256);
    _ = new V72.DerivedFromBaseWithPrivateProtectedMember();
    V72.ReadOnlyParametersAndStructs();
    V72.ReadOnlyRefReturns();
    V72.RefStructs();
}

void V7_3Samples()
{
    WriteFirstLineInSample("************************************ V7.3 (5.2018) ************************************");
    WriteLine("(default for .net standard 2.0, core <3.x and .net framework)");

    V73.NewGenericConstraints();
    V73.TupleEquality();
}

static async Task V8Samples()
{
    WriteFirstLineInSample("************************************ V8 (9.2019) ************************************");
    WriteLine("(default for .net standard 2.1, core 3.x)");

    V8.PatternMatchingSwitchExpression();
    V8.ReadOnlyMembers();
    V8.InterfaceDefaultMethodsImplementation();
    V8.StaticLocalFunction();
    V8.DisposableRefStruct();
    V8.NullableReferenceType();
    await V8.AsyncStreams();
    V8.RangesAndIndices();
    V8.UnmanagedConstructedType();
    V8.StackallocInNestedContext();
}

static void V9Samples()
{
    WriteFirstLineInSample("************************************ V9 ************************************");
    WriteLine("(default for .net 5.0)");

    V9.Records();
    V9.InitOnlyProperties();
    V9.PatternMatchingImprovements();
    V9.PerfAndCompatibilityImprovements();
    V9.PartialMethods();
    V9.LocalAndAnonymousFunctionsEnhancements();
    V9.CovariantReturnTypes();
}

static void V10Samples()
{
    WriteFirstLineInSample("************************************ V10 ************************************");
    WriteLine("(default for .net 6.0)");

    V10.RecordStructs();
    V10.StructImprovements();
    V10.InterpolatedStringHandler();
    V10.PropertyPatternImprovement();
    V10.LambdaExpressionImprovements();
    V10.ArgumentExpression();
}

static void V11Samples()
{
    WriteFirstLineInSample("************************************ V11 ************************************");
    WriteLine("(default for .net 7.0)");

    V11.PatternMatchingForSpans();
    V11.StringLiteralsAndInterpolation();
    V11.StaticVirtualMembersForInterfaces();
    V11.GenericAttributes();
    V11.RequiredMembers();
    V11.ListPatterns();
    V11.CheckedOperators();
    V11.NameofScope();
    V11.FileScopedClass();
    V11.FileScopedClass2();
}

static void V12Samples()
{
    WriteFirstLineInSample("************************************ V12 ************************************");
    WriteLine("(default for .net 8.0)");

    V12.TupleAlias();
}

#pragma warning restore CS8321