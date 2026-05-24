using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace PInvokeBench;

internal static class Program
{
    private static int Main(string[] args)
    {
        var config = ManualConfig
            .Create(DefaultConfig.Instance)
            .AddExporter(new InteractiveHtmlExporter());

        BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(args, config);
        return 0;
    }
}
