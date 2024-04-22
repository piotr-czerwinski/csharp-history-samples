using System.Runtime.CompilerServices;

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

            WriteLine(builder.ToStringAndClear());
        }

#pragma warning disable IDE0060 // Remove unused parameter (it is used by the compiler)
        public void LogMessageOverrideEnabled(bool loggingEnabledOverride, [InterpolatedStringHandlerArgument("loggingEnabledOverride")] LoggerInterpolatedStringHandler builder)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (!LoggingEnabled)
            {
                return;
            }

            WriteLine(builder.ToStringAndClear());
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
        private DefaultInterpolatedStringHandler _builder;

        public LoggerInterpolatedStringHandler(int literalLength, int formattedCount, SimpleLogger logger, out bool handlerIsValid)
        {
            handlerIsValid = logger.LoggingEnabled;
            InitializeHandler(literalLength, formattedCount, handlerIsValid);
        }

        public LoggerInterpolatedStringHandler(int literalLength, int formattedCount, bool loggingEnabled, out bool handlerIsValid)
        {
            handlerIsValid = loggingEnabled;
            InitializeHandler(literalLength, formattedCount, handlerIsValid);
        }

        // proper class shape required (Methods with matching signatures)
        public void AppendLiteral(string s)
        {
            WriteLine($"Interpolated string handler: AppendLiteral, s: {s}");
            _builder.AppendLiteral(s);
        }

        public void AppendFormatted<T>(T t)
        {
            WriteLine($"Interpolated string handler: AppendFormatted, t: {t} of type {typeof(T)}");
            _builder.AppendFormatted(t?.ToString());
        }

        // optional
        public void AppendFormatted<T>(T t, string format) where T : IFormattable
        {
            WriteLine($"Interpolated string handler: AppendFormatted, t: {t} with format {format} of type {typeof(T)}");
            _builder.AppendFormatted(t?.ToString(), format: format);
        }

        private void InitializeHandler(int literalLength, int formattedCount, bool loggingEnabled)
        {
            WriteLine($"Interpolated string handler: Constructor, literalLength: {literalLength}, formattedCount: {formattedCount}, logging enabled: {loggingEnabled}");
            _builder = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
        }
        public string ToStringAndClear() => _builder.ToStringAndClear();
    }
}
