namespace PInvokeBench;

// UTF-8 byte width per character: Ascii=1, Latin1=2, Cjk=3.
// ANSI codepage Win-1252: Ascii/Latin1 lossless, Cjk lossy ('?').
public enum Payload
{
    Ascii,
    Latin1,
    Cjk,
}

internal static class PayloadFactory
{
    public static string Build(Payload p, int length)
    {
        if (length == 0) return string.Empty;
        char ch = p switch
        {
            Payload.Ascii  => 'x',
            Payload.Latin1 => 'ä',
            Payload.Cjk    => '日',
            _              => 'x',
        };
        return new string(ch, length);
    }
}
