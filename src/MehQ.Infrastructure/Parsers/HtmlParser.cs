using HtmlAgilityPack;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Infrastructure.Parsers;

public class HtmlParser : IFileParser
{
    private static readonly HashSet<string> BlockElements = new(StringComparer.OrdinalIgnoreCase)
    {
        "p", "h1", "h2", "h3", "h4", "h5", "h6",
        "li", "td", "th", "div", "blockquote", "dt", "dd", "caption", "title"
    };

    private static readonly HashSet<string> InlineElements = new(StringComparer.OrdinalIgnoreCase)
    {
        "b", "i", "u", "em", "strong", "a", "span", "sub", "sup", "code", "abbr"
    };

    public string[] SupportedExtensions => [".html", ".htm"];

    public Task<IReadOnlyList<Segment>> ParseAsync(string filePath, CancellationToken ct = default)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.Load(filePath);

        var segments = new List<Segment>();
        int sequence = 1;

        var textNodes = htmlDoc.DocumentNode.SelectNodes(
            "//p | //h1 | //h2 | //h3 | //h4 | //h5 | //h6 | //li | //td | //th | //title");

        if (textNodes == null)
            return Task.FromResult<IReadOnlyList<Segment>>(Array.Empty<Segment>());

        foreach (var node in textNodes)
        {
            ct.ThrowIfCancellationRequested();

            var (text, tags) = ExtractTextAndTags(node);
            if (string.IsNullOrWhiteSpace(text.Replace("{", "").Replace("}", "")))
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
        var htmlDoc = new HtmlDocument();
        htmlDoc.Load(filePath);

        var textNodes = htmlDoc.DocumentNode.SelectNodes(
            "//p | //h1 | //h2 | //h3 | //h4 | //h5 | //h6 | //li | //td | //th | //title");

        if (textNodes == null) return Task.CompletedTask;

        int index = 0;
        foreach (var node in textNodes)
        {
            if (index >= segments.Count) break;
            ct.ThrowIfCancellationRequested();

            var target = segments[index].Target;
            if (!string.IsNullOrEmpty(target))
            {
                // Strip tag placeholders for simple text replacement
                var cleanText = System.Text.RegularExpressions.Regex.Replace(target, @"\{\d+\}", "");
                node.InnerHtml = System.Net.WebUtility.HtmlEncode(cleanText);
            }
            index++;
        }

        htmlDoc.Save(filePath);
        return Task.CompletedTask;
    }

    private static (string text, List<InlineTag> tags) ExtractTextAndTags(HtmlNode node)
    {
        var textParts = new List<string>();
        var tags = new List<InlineTag>();
        int tagCounter = 1;

        foreach (var child in node.ChildNodes)
        {
            if (child.NodeType == HtmlNodeType.Text)
            {
                var text = System.Net.WebUtility.HtmlDecode(child.InnerText);
                if (!string.IsNullOrEmpty(text))
                    textParts.Add(text);
            }
            else if (child.NodeType == HtmlNodeType.Element && InlineElements.Contains(child.Name))
            {
                tags.Add(new InlineTag
                {
                    Position = string.Join("", textParts).Length,
                    Type = InlineTagType.Opening,
                    TagId = tagCounter.ToString(),
                    DisplayText = $"{{{tagCounter}}}",
                    Content = $"<{child.Name}>"
                });
                textParts.Add($"{{{tagCounter}}}");
                tagCounter++;

                textParts.Add(System.Net.WebUtility.HtmlDecode(child.InnerText));

                tags.Add(new InlineTag
                {
                    Position = string.Join("", textParts).Length,
                    Type = InlineTagType.Closing,
                    TagId = tagCounter.ToString(),
                    DisplayText = $"{{{tagCounter}}}",
                    Content = $"</{child.Name}>"
                });
                textParts.Add($"{{{tagCounter}}}");
                tagCounter++;
            }
        }

        return (string.Join("", textParts), tags);
    }
}
