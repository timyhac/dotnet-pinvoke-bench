using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public abstract class Utf8StringBenchmarkBase
{
    protected const string Lib = "bench";
    protected const int StackallocLimit = 1024;

    [Params(0, 16, 256, 4096)]
    public int Length;

    [ParamsAllValues]
    public Payload Pay;

    protected string Input = string.Empty;
    protected byte[] PreEncoded = Array.Empty<byte>();
    protected StringBuilder Sb = new();

    [GlobalSetup]
    public void Setup()
    {
        Input = PayloadFactory.Build(Pay, Length);
        int utf8 = Encoding.UTF8.GetByteCount(Input);
        PreEncoded = new byte[utf8 + 1];
        if (utf8 > 0)
        {
            Encoding.UTF8.GetBytes(Input, 0, Input.Length, PreEncoded, 0);
        }
        Sb = new StringBuilder(Input, Math.Max(Input.Length, 1));
    }
}
