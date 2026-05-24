using System;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace PInvokeBench;

[MemoryDiagnoser]
public abstract class Utf16StringBenchmarkBase
{
    protected const string Lib = "bench";

    [Params(0, 16, 256, 4096)]
    public int Length;

    [ParamsAllValues]
    public Payload Pay;

    protected string Input = string.Empty;
    protected char[] PreEncodedChars = Array.Empty<char>();
    protected StringBuilder Sb = new();

    [GlobalSetup]
    public void Setup()
    {
        Input = PayloadFactory.Build(Pay, Length);
        PreEncodedChars = new char[Input.Length + 1];
        if (Input.Length > 0) Input.CopyTo(0, PreEncodedChars, 0, Input.Length);
        Sb = new StringBuilder(Input, Math.Max(Input.Length, 1));
    }
}
