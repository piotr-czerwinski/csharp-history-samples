namespace CSharpHistorySamples;

internal partial class V13
{
    internal static void LockObject()
    {
        WriteFirstLineInSample("Lock object");

        NewLockObjectLocking();

        M(new Lock()); // could warn here
    }

    private static void NewLockObjectLocking()
    {
        var @lock = new Lock();

        WriteLine($"IsHeldByCurrentThread before lock: {@lock.IsHeldByCurrentThread}");
        lock (@lock)
        {
            WriteLine($"IsHeldByCurrentThread in locked context: {@lock.IsHeldByCurrentThread}");
        }
        using var lockScope = @lock.EnterScope();
        WriteLine($"IsHeldByCurrentThread after EnterScope context: {@lock.IsHeldByCurrentThread}");

        /*
        Both compiles to
        Lock.Scope scope = @lock.EnterScope();
        try
        {
        }
        finally
        {
            scope.Dispose();
        }
        */
    }

    static void M(object x)
    {
        ArgumentNullException.ThrowIfNull(x);
        lock (x) { } // because this uses Monitor

        /*
         * Compiles to:
        bool lockTaken = false;
        try
        {
            Monitor.Enter(x, ref lockTaken);
        }
        finally
        {
            if (lockTaken)
            {
                Monitor.Exit(x);
            }
        }
        */
    }
}
