using System.Xml.Linq;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Infrastructure.Parsers;

public class XliffParser : IFileParser
{
    private static readonly XNamespace XliffNs = "urn:oasis:names:tc:xliff:document:1.2";

    public string[] SupportedExtensions => [".xlf", ".xliff"];

    public Task<IReadOnlyList<Segment>> ParseAsync(string filePath, CancellationToken ct = default)
    {
        var doc = XDocument.Load(filePath);
        var segments = new List<Segment>();
        int sequence = 1;

        // Try with namespace first, then without (for files missing namespace)
        var transUnits = doc.Descendants(XliffNs + "trans-unit");
        if (!transUnits.Any())
        {
            transUnits = doc.Descendants("trans-unit");
        }

        foreach (var tu in transUnits)
        {
            ct.ThrowIfCancellationRequested();

            var sourceEl = tu.Element(XliffNs + "source") ?? tu.Element("source");
            var targetEl = tu.Element(XliffNs + "target") ?? tu.Element("target");

            var segment = new Segment
            {
                SequenceNumber = sequence++,
                Source = sourceEl?.Value ?? string.Empty,
                Target = targetEl?.Value ?? string.Empty,
                Status = MapState(targetEl?.Attribute("state")?.Value)
            };

            segments.Add(segment);
        }

        return Task.FromResult<IReadOnlyList<Segment>>(segments);
    }

    public Task SaveAsync(string filePath, IReadOnlyList<Segment> segments, CancellationToken ct = default)
    {
        var doc = XDocument.Load(filePath);

        var transUnits = doc.Descendants(XliffNs + "trans-unit").ToList();
        if (!transUnits.Any())
        {
            transUnits = doc.Descendants("trans-unit").ToList();
        }

        int index = 0;
        foreach (var tu in transUnits)
        {
            if (index >= segments.Count) break;
            ct.ThrowIfCancellationRequested();

            var targetEl = tu.Element(XliffNs + "target") ?? tu.Element("target");
            if (targetEl == null)
            {
                var sourceEl = tu.Element(XliffNs + "source") ?? tu.Element("source");
                var ns = sourceEl?.Name.Namespace ?? XNamespace.None;
                targetEl = new XElement(ns + "target");
                sourceEl?.AddAfterSelf(targetEl);
            }

            targetEl.Value = segments[index].Target;
            targetEl.SetAttributeValue("state", MapStatusToState(segments[index].Status));
            index++;
        }

        doc.Save(filePath);
        return Task.CompletedTask;
    }

    private static SegmentStatus MapState(string? state) => state switch
    {
        "translated" => SegmentStatus.TranslatorConfirmed,
        "reviewed" => SegmentStatus.Reviewer1Confirmed,
        "final" => SegmentStatus.Reviewer2Confirmed,
        "signed-off" => SegmentStatus.Reviewer2Confirmed,
        "needs-translation" => SegmentStatus.Edited,
        _ => SegmentStatus.NotStarted
    };

    private static string MapStatusToState(SegmentStatus status) => status switch
    {
        SegmentStatus.NotStarted => "new",
        SegmentStatus.Edited => "needs-translation",
        SegmentStatus.PreTranslated => "translated",
        SegmentStatus.FragmentAssembled => "translated",
        SegmentStatus.TranslatorConfirmed => "translated",
        SegmentStatus.Reviewer1Confirmed => "reviewed",
        SegmentStatus.Reviewer2Confirmed => "final",
        SegmentStatus.Rejected => "needs-translation",
        SegmentStatus.Locked => "final",
        _ => "new"
    };
}
