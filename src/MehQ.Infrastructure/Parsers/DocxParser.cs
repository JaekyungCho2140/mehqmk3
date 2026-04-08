using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Infrastructure.Parsers;

public class DocxParser : IFileParser
{
    public string[] SupportedExtensions => [".docx"];

    public Task<IReadOnlyList<Segment>> ParseAsync(string filePath, CancellationToken ct = default)
    {
        using var doc = WordprocessingDocument.Open(filePath, false);
        var body = doc.MainDocumentPart?.Document?.Body;
        if (body == null)
            return Task.FromResult<IReadOnlyList<Segment>>(Array.Empty<Segment>());

        var segments = new List<Segment>();
        int sequence = 1;

        foreach (var para in body.Elements<Paragraph>())
        {
            ct.ThrowIfCancellationRequested();

            var (text, tags) = ExtractTextAndTags(para);
            if (string.IsNullOrWhiteSpace(text))
                continue;

            segments.Add(new Segment
            {
                SequenceNumber = sequence++,
                Source = text,
                Target = string.Empty,
                Status = SegmentStatus.NotStarted,
                SourceTags = tags
            });
        }

        return Task.FromResult<IReadOnlyList<Segment>>(segments);
    }

    public Task SaveAsync(string filePath, IReadOnlyList<Segment> segments, CancellationToken ct = default)
    {
        using var doc = WordprocessingDocument.Open(filePath, true);
        var body = doc.MainDocumentPart?.Document?.Body;
        if (body == null) return Task.CompletedTask;

        var paragraphs = body.Elements<Paragraph>()
            .Where(p => !string.IsNullOrWhiteSpace(p.InnerText))
            .ToList();

        int index = 0;
        foreach (var para in paragraphs)
        {
            if (index >= segments.Count) break;
            ct.ThrowIfCancellationRequested();

            var target = segments[index].Target;
            if (!string.IsNullOrEmpty(target))
            {
                // Simple approach: replace first run's text, remove others
                var runs = para.Elements<Run>().ToList();
                if (runs.Count > 0)
                {
                    var firstRun = runs[0];
                    var textEl = firstRun.GetFirstChild<Text>();
                    if (textEl != null)
                    {
                        textEl.Text = target;
                        textEl.Space = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.SpaceProcessingModeValues>(
                            DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve);
                    }
                    // Remove additional runs (simplified — loses formatting in save)
                    for (int i = 1; i < runs.Count; i++)
                        runs[i].Remove();
                }
            }
            index++;
        }

        doc.MainDocumentPart?.Document?.Save();
        return Task.CompletedTask;
    }

    private static (string text, List<InlineTag> tags) ExtractTextAndTags(Paragraph para)
    {
        var textParts = new List<string>();
        var tags = new List<InlineTag>();
        int tagCounter = 1;

        foreach (var run in para.Elements<Run>())
        {
            var runProps = run.RunProperties;
            bool hasBold = runProps?.Bold != null;
            bool hasItalic = runProps?.Italic != null;
            bool hasUnderline = runProps?.Underline != null;
            bool hasFormatting = hasBold || hasItalic || hasUnderline;

            var text = run.GetFirstChild<Text>()?.Text ?? string.Empty;
            if (string.IsNullOrEmpty(text)) continue;

            if (hasFormatting)
            {
                var openTag = new InlineTag
                {
                    Position = string.Join("", textParts).Length,
                    Type = InlineTagType.Opening,
                    TagId = tagCounter.ToString(),
                    DisplayText = $"{{{tagCounter}}}",
                    Content = FormatDescription(hasBold, hasItalic, hasUnderline)
                };
                tags.Add(openTag);
                textParts.Add($"{{{tagCounter}}}");
                tagCounter++;

                textParts.Add(text);

                var closeTag = new InlineTag
                {
                    Position = string.Join("", textParts).Length,
                    Type = InlineTagType.Closing,
                    TagId = (tagCounter).ToString(),
                    DisplayText = $"{{{tagCounter}}}",
                    Content = "/format"
                };
                tags.Add(closeTag);
                textParts.Add($"{{{tagCounter}}}");
                tagCounter++;
            }
            else
            {
                textParts.Add(text);
            }
        }

        return (string.Join("", textParts), tags);
    }

    private static string FormatDescription(bool bold, bool italic, bool underline)
    {
        var parts = new List<string>();
        if (bold) parts.Add("b");
        if (italic) parts.Add("i");
        if (underline) parts.Add("u");
        return string.Join("+", parts);
    }
}
