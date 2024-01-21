global using static System.Console;
using CSharpHistorySamples;

WriteLine("************************************ V6 (2015) ************************************");

// Exception and 'when' filtering 

// await V6.MakeGetRequestWithExceptionFilters("https://localHost:666");


WriteLine("************************************ V7 (3.2017) ************************************");

// local function
// ref return
// ref local

//V7.RefReturnAndRefLocals();
//V7.RefReturnForIndexer();

//V7.LocalFunctionAndEnumerator();

//V7.PatternMatchingInSwitch();

WriteLine("************************************ V7.1 (8.2017) ************************************");

V71.PatternMatchingForGenericParameter(parameter: "lorem ipsum");

WriteLine("************************************ V7.2 (11.2017) ************************************");

V72.StackallocArraysInSafeContext(arraySize: 256);
_ = new V72.DerivedFromBaseWithPrivateProtectedMember();
V72.ReadOnlyParametersAndStructs();
V72.ReadOnlyRefReturns();
V72.RefStructs();

WriteLine("************************************ V7.3 (5.2018) ************************************");
WriteLine("(default for .net standard 2.0, core <3.x and .net framework)");

WriteLine("************************************ V8 ************************************");
WriteLine("(default for .net standard 2.1, core 3.x)");

//V8.PatternMatchingSwitchExpression();

WriteLine("************************************ V9 ************************************");
WriteLine("(default for .net 5.0)");

WriteLine("************************************ V10 ************************************");
WriteLine("(default for .net 6.0)");

WriteLine("************************************ V11 ************************************");
WriteLine("(default for .net 7.0)");

V11.PatternMatchingForSpans();

WriteLine("************************************ V12 ************************************");
WriteLine("(default for .net 8.0)");

//V12.TupleAlias();