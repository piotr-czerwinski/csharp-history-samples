using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V11
{
    internal static void StringLiteralsAndInterpolation()
    {
        WriteFirstLineInSample("String Literals");

        UTF8StringLiterals();
        RawStrings();
        NewLinesInStringInterpolation();
    }

    private static void UTF8StringLiterals()
    {
        WriteFirstLineInSample("UTF-8 String literals");

        // type of UTF-8 string literals is ReadOnlySpan<byte> (NOT string)
        var utfStringLiteral = "Sample literal string U8"u8;
        WriteLine(utfStringLiteral.ToString());

        // interpolated u8 not supported
        // var s2 = $"Sample interpolated literal string UTF-8"u8;

        // is not compile type literal.
        // cannot be used as a method param
         //void MethodWithUtf8Param(ReadOnlySpan<byte> param = ""u8) { }
    }

    private static void RawStrings()
    {
        WriteFirstLineInSample("Raw Strings");

        // multiline before C# 11
        string multilineString = @"
                Multiline string literals.                
                With ""quoted text"".
                    Indentation";
        WriteLine(multilineString);

        // At least 3 double-quotes chars required to use raw literals
        // White spaces right after starting and before ending """ are ignored.
        // String is aligned to the closing delimiter.
        string multilineRawString = """
                Multiline string literals.                  
                With "quoted text". 
                    Indentation   
                """;
        WriteLine(multilineRawString);

        // When more than 2 double-quotes are to be used inside the string (let say x).
        // The solution is to use x + 1 double-quotes as a delimiter
        string multipleDoubleQuotes = """""start """ inside quotes """" end""""";
        WriteLine(multipleDoubleQuotes);

        // for interpolated strings number of '$' corresponds to number of opening braces 
        string multilineString2 = $"""
                Sample {1}.
                """;
        WriteLine(multilineString2);

        string multilineString3 = $$"""
                Sample {{{1}}}.
                """;
        WriteLine(multilineString3);

        string multilineString4 = $$$"""
                Sample {{{{{1}}}}}.
                """;
        WriteLine(multilineString4);
    }

    private static void NewLinesInStringInterpolation()
    {
        WriteFirstLineInSample("New Lines In String Interpolation");

        // multiline before C# 11
        string sampleString = $"Interpolated string (1 + 2 + 3) = {
            //the text inside { } can span multiple lines
            1+2+
            3
            }";
        WriteLine(sampleString);
    }
}
