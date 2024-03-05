﻿global using static System.Console;
global using static CSharpHistorySamples.Helpers.ConsoleHelpers;

using CSharpHistorySamples;

//await V6Samples();
//V7Samples();
//V7_1Samples();
//V7_2Samples();
//V7_3Samples();
V8Samples();
//V9Samples();
//V10Samples();
//V11Samples();
//V12Samples();

async Task V6Samples()
{
    WriteFirstLineInSample("************************************ V6 (2015) ************************************");

    // Exception and 'when' filtering 
    await V6.MakeGetRequestWithExceptionFilters("https://localHost:666");
}

void V7Samples()
{
    WriteFirstLineInSample("************************************ V7 (3.2017) ************************************");

    V7.RefReturnAndRefLocals();
    V7.RefReturnForIndexer();

    V7.LocalFunctionAndEnumerator();

    V7.PatternMatchingInSwitch();
}

void V7_1Samples()
{
    WriteFirstLineInSample("************************************ V7.1 (8.2017) ************************************");

    V71.PatternMatchingForGenericParameter(parameter: "lorem ipsum");
}

void V7_2Samples()
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

void V8Samples()
{
    WriteFirstLineInSample("************************************ V8 (9.2019) ************************************");
    WriteLine("(default for .net standard 2.1, core 3.x)");

    V8.PatternMatchingSwitchExpression();
    V8.ReadOnlyMembers();
    V8.InterfaceDefaultMethodsImplementation();
}

void V9Samples()
{
    WriteFirstLineInSample("************************************ V9 ************************************");
    WriteLine("(default for .net 5.0)");
}

void V10Samples()
{
    WriteFirstLineInSample("************************************ V10 ************************************");
    WriteLine("(default for .net 6.0)");
}

void V11Samples()
{
    WriteFirstLineInSample("************************************ V11 ************************************");
    WriteLine("(default for .net 7.0)");

    V11.PatternMatchingForSpans();
}

void V12Samples()
{
    WriteFirstLineInSample("************************************ V12 ************************************");
    WriteLine("(default for .net 8.0)");

    V12.TupleAlias();
}

