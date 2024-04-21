using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace CSharpHistorySamples;

internal static partial class V10
{
    // Handler might be used for:
    // - High performant code.
    // - Custom formatting of placeholders
    // - Enforcing resulting string to conform to max fixed length
    internal static void InterpolatedStringHandler()
    {
        WriteFirstLineInSample("Interpolated String Handler");
        var logger = new SimpleLogger(loggingEnabled: true);

        logger.LogMessage("Logged sample string");
        logger.LogMessage($"Logged sample formatted string {3m} {1m:C}");

        WriteLine("Disabling logger");
        logger.LoggingEnabled = false;

        // Before C# 10 msg could be passed only as a string and was using String.Format or String.Concat
        // This resulted with additional memory and cpu overhead even if parameter had not been used (as is the case with disabled logger)
        // When using String Handlers, final string is built on GetFormattedText call, that is never invoked when logger is disabled
        logger.LogMessage($"Logged sample formatted string {3m} {1m:C}");

        WriteLine("Overriding Enabled flag logger");
        logger.LogMessageOverrideEnabled(loggingEnabledOverride: true, $"Logged sample formatted string {3m} {1m:C}");
    }

    public class SimpleLogger
    {
        public SimpleLogger(bool loggingEnabled)
        {
            LoggingEnabled = loggingEnabled;
        }

        public bool LoggingEnabled
        {
            get; set;
        }

        public void LogMessage([InterpolatedStringHandlerArgument("")] LoggerInterpolatedStringHandler builder)
        {
            if (!LoggingEnabled)
            {
                return;
            }

            WriteLine(builder.GetFormattedText());
        }

#pragma warning disable IDE0060 // Remove unused parameter (it is used by the compiler)
        public void LogMessageOverrideEnabled(bool loggingEnabledOverride, [InterpolatedStringHandlerArgument("loggingEnabledOverride")] LoggerInterpolatedStringHandler builder)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            WriteLine(builder.GetFormattedText());
        }

        // required for non-interpolated (standard) strings
        public void LogMessage(string message)
        {
            if (!LoggingEnabled)
            {
                return;
            }

            WriteLine(message);
        }
    }

    [InterpolatedStringHandler] // attribute required
    public ref struct LoggerInterpolatedStringHandler
    {
        StringBuilder? builder;
        private bool _loggingEnabled;

        public LoggerInterpolatedStringHandler(int literalLength, int formattedCount, SimpleLogger logger)
        {
            _loggingEnabled = logger.LoggingEnabled;
            InitializeHandler(literalLength, formattedCount);
        }

        public LoggerInterpolatedStringHandler(int literalLength, int formattedCount, bool loggingEnabled)
        {
            _loggingEnabled = loggingEnabled;
            InitializeHandler(literalLength, formattedCount);
        }

        // proper class shape required (Methods with matching signatures)
        public void AppendLiteral(string s)
        {
            if (!_loggingEnabled)
            {
                return;
            }

            WriteLine($"Interpolated string handler: AppendLiteral, s: {s}");
            builder!.Append(s);
        }

        public void AppendFormatted<T>(T t)
        {
            if (!_loggingEnabled)
            {
                return;
            }

            WriteLine($"Interpolated string handler: AppendFormatted, t: {t} of type {typeof(T)}");
            builder!.Append(t?.ToString());
        }

        // optional
        public void AppendFormatted<T>(T t, string format) where T : IFormattable
        {
            if (!_loggingEnabled)
            {
                return;
            }

            WriteLine($"Interpolated string handler: AppendFormatted, t: {t} with format {format} of type {typeof(T)}");
            builder!.Append(t?.ToString(format, null));
        }

        private void InitializeHandler(int literalLength, int formattedCount)
        {
            WriteLine($"Interpolated string handler: Constructor, literalLength: {literalLength}, formattedCount: {formattedCount}, logging enabled: {_loggingEnabled}");

            if (_loggingEnabled)
            {
                builder = new StringBuilder(literalLength);
            }
        }

        internal string GetFormattedText() => builder.ToString();
    }
}
