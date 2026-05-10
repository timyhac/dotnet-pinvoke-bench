using BenchmarkDotNet.Running;

namespace PInvokeBench;

internal static class Program
{
    // Run the benchmark for whichever TFM the host is currently using:
    //
    //   dotnet run -c Release -f net8.0 --filter '*'
    //   dotnet run -c Release -f net10.0 --filter '*Fill*'
    //   dotnet run -c Release -f net481 --filter '*Noop*'
    //
    // Re-run for each TFM and compare the report tables.
    private static int Main(string[] args)
    {
        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(args);
        return 0;
    }
}
