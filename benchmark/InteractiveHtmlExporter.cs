using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace PInvokeBench;

// Emits a single self-contained report.html alongside BDN's markdown/CSV
// outputs. Data for every benchmark class is embedded inline; the template
// (report.template.html, embedded resource) provides the structure, analysis
// text, and chart-rendering JS. Observable Plot is loaded from a CDN.
public class InteractiveHtmlExporter : IExporter
{
    public string Name => "InteractiveHtml";

    public IEnumerable<string> ExportToFiles(Summary summary, ILogger consoleLogger)
    {
        var dataDir = Path.Combine(summary.ResultsDirectoryPath, ".report-data");
        Directory.CreateDirectory(dataDir);

        // BenchmarkSwitcher gives us one Summary per benchmark Type, so each
        // session sees only its own class's data. Write a per-class sidecar
        // JSON, then rebuild report.html by aggregating every sidecar that
        // exists. A run that touches only one class still produces a complete
        // report, using prior data for the other classes.
        foreach (var group in summary.BenchmarksCases.GroupBy(b => b.Descriptor.Type))
        {
            var classJson = BuildClassJson(summary, group.ToList());
            File.WriteAllText(Path.Combine(dataDir, $"{group.Key.Name}.json"), classJson);
        }

        var allDataJson = AssembleDataJson(dataDir);
        var meta = BuildMeta(summary);
        var html = LoadTemplate()
            .Replace("__META__JS", '"' + JsonEscape(meta) + '"')
            .Replace("__META__", System.Net.WebUtility.HtmlEncode(meta))
            .Replace("__DATA__", allDataJson);

        var path = Path.Combine(summary.ResultsDirectoryPath, "report.html");
        File.WriteAllText(path, html);
        consoleLogger.WriteLine($"  InteractiveHtmlExporter -> report.html");
        return new[] { path };
    }

    private static string AssembleDataJson(string dataDir)
    {
        var sb = new StringBuilder();
        sb.Append('{');
        bool first = true;
        foreach (var file in Directory.GetFiles(dataDir, "*.json").OrderBy(f => f, StringComparer.Ordinal))
        {
            var className = Path.GetFileNameWithoutExtension(file);
            if (!first) sb.Append(',');
            first = false;
            sb.Append('"').Append(JsonEscape(className)).Append("\":");
            sb.Append(File.ReadAllText(file));
        }
        sb.Append('}');
        return sb.ToString();
    }

    public void ExportToLog(Summary summary, ILogger logger) { }

    private static string LoadTemplate()
    {
        var asm = typeof(InteractiveHtmlExporter).Assembly;
        const string name = "PInvokeBench.report.template.html";
        using var stream = asm.GetManifestResourceStream(name)
            ?? throw new InvalidOperationException($"Embedded resource '{name}' not found.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private static string BuildMeta(Summary summary)
    {
        var job = summary.BenchmarksCases.FirstOrDefault()?.Job?.DisplayInfo ?? "";
        var runtime = summary.HostEnvironmentInfo.RuntimeVersion ?? "";
        return $"{job}  •  {runtime}";
    }

    private static string BuildClassJson(Summary summary, List<BenchmarkCase> cases)
    {
        var inv = CultureInfo.InvariantCulture;
        var sb = new StringBuilder();

        var paramNames = cases
            .SelectMany(c => c.Parameters.Items.Select(p => p.Name))
            .Distinct()
            .ToList();

        sb.Append("{\"paramCols\":[");
        for (int i = 0; i < paramNames.Count; i++)
        {
            if (i > 0) sb.Append(',');
            sb.Append('"').Append(JsonEscape(paramNames[i])).Append('"');
        }
        sb.Append("],\"rows\":[");

        bool firstRow = true;
        foreach (var c in cases)
        {
            if (!firstRow) sb.Append(',');
            firstRow = false;

            var report = summary[c];
            double mean = report?.ResultStatistics?.Mean ?? 0;
            double err = report?.ResultStatistics?.StandardError ?? 0;
            long alloc = 0;
            try { alloc = report?.GcStats.GetBytesAllocatedPerOperation(c) ?? 0; }
            catch { alloc = 0; }

            sb.Append('{');
            sb.Append("\"Method\":\"").Append(JsonEscape(c.Descriptor.WorkloadMethod.Name)).Append('"');
            sb.Append(",\"Mean\":").Append(mean.ToString("R", inv));
            sb.Append(",\"Error\":").Append(err.ToString("R", inv));
            sb.Append(",\"Allocated\":").Append(alloc.ToString(inv));

            foreach (var name in paramNames)
            {
                var p = c.Parameters.Items.FirstOrDefault(x => x.Name == name);
                sb.Append(",\"").Append(JsonEscape(name)).Append("\":");
                AppendJsonValue(sb, p?.Value, inv);
            }
            sb.Append('}');
        }
        sb.Append("]}");
        return sb.ToString();
    }

    private static void AppendJsonValue(StringBuilder sb, object? v, CultureInfo inv)
    {
        switch (v)
        {
            case null: sb.Append("null"); break;
            case bool b: sb.Append(b ? "true" : "false"); break;
            case sbyte or byte or short or ushort or int or uint or long or ulong:
                sb.Append(Convert.ToString(v, inv)); break;
            case float f: sb.Append(f.ToString("R", inv)); break;
            case double d: sb.Append(d.ToString("R", inv)); break;
            default: sb.Append('"').Append(JsonEscape(v.ToString() ?? "")).Append('"'); break;
        }
    }

    private static string JsonEscape(string s)
    {
        var sb = new StringBuilder(s.Length + 4);
        foreach (var ch in s)
        {
            switch (ch)
            {
                case '\\': sb.Append("\\\\"); break;
                case '"':  sb.Append("\\\""); break;
                case '\n': sb.Append("\\n");  break;
                case '\r': sb.Append("\\r");  break;
                case '\t': sb.Append("\\t");  break;
                case '<':  sb.Append("\\u003c"); break;
                case '>':  sb.Append("\\u003e"); break;
                case '&':  sb.Append("\\u0026"); break;
                default:
                    if (ch < 0x20) sb.Append("\\u").Append(((int)ch).ToString("x4"));
                    else sb.Append(ch);
                    break;
            }
        }
        return sb.ToString();
    }
}
