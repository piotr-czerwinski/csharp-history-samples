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
        WriteFirstLineInSample("UTF8 String literals");

        // type of UTF8 string literals is ReadOnlyString<byte> (NOT string)
        var utfStringLiteral = "Sample literal string U8"u8;
        WriteLine(utfStringLiteral.ToString());
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

        // white spaces right after and before """ are ignored. String is also adjusted to the "left"
        string multilineRawString = """
                Multiline string literals.                  
                With "quoted text". 
                    Indentation   
                """;
        WriteLine(multilineRawString);

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
