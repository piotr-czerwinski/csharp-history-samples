namespace CSharpHistorySamples;

using System;

internal static partial class V14
{
    internal static void FieldBackedPropertyExample()
    {
        WriteFirstLineInSample("field-backed property");

        var holder = new MessageHolder();
        try
        {
            holder.NonNullableMessage = null!; // should throw
        }
        catch (ArgumentNullException)
        {
            WriteLine("Caught ArgumentNullException as expected");
        }

        holder.NonNullableMessage = "Hello C# 14";
        WriteLine(holder.NonNullableMessage);
    }

    class MessageHolder
    {
        public string NonNullableMessage
        {
            get => field ?? string.Empty;
            set => field = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
