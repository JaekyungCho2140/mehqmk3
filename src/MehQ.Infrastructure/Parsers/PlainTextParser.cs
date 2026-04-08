using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Infrastructure.Parsers;

public class PlainTextParser : IFileParser
{
    public string[] SupportedExtensions => [".txt"];

    public async Task<IReadOnlyList<Segment>> ParseAsync(string filePath, CancellationToken ct = default)
    {
        var lines = await File.ReadAllLinesAsync(filePath, ct);
        var segments = new List<Segment>();
        int sequence = 1;

        foreach (var line in lines)
        {
            ct.ThrowIfCancellationRequested();
            if (string.IsNullOrWhiteSpace(line)) continue;

            segments.Add(new Segment
            {
                SequenceNumber = sequence++,
                Source = line,
                Target = string.Empty,
                Status = SegmentStatus.NotStarted
            });
        }

        return segments;
    }

    public async Task SaveAsync(string filePath, IReadOnlyList<Segment> segments, CancellationToken ct = default)
    {
        var lines = segments
            .OrderBy(s => s.SequenceNumber)
            .Select(s => string.IsNullOrEmpty(s.Target) ? s.Source : s.Target);

        await File.WriteAllLinesAsync(filePath, lines, ct);
    }
}
