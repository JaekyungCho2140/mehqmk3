using FluentAssertions;
using MehQ.Core.Models;
using MehQ.Infrastructure.Parsers;
using Xunit;

namespace MehQ.Infrastructure.Tests.Parsers;

public class HtmlParserTests : IDisposable
{
    private readonly string _tempDir;
    private readonly HtmlParser _parser;

    public HtmlParserTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"mehq-test-{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
        _parser = new HtmlParser();
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    [Fact]
    public void SupportedExtensions_ShouldContainHtmlAndHtm()
    {
        _parser.SupportedExtensions.Should().Contain(".html");
        _parser.SupportedExtensions.Should().Contain(".htm");
    }

    [Fact]
    public async Task ParseAsync_WithSimpleHtml_ShouldReturnSegmentsPerBlock()
    {
        var html = @"<html><body>
            <h1>Title</h1>
            <p>First paragraph</p>
            <p>Second paragraph</p>
        </body></html>";
        var filePath = WriteFile("simple.html", html);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(3);
        segments[0].Source.Should().Be("Title");
        segments[1].Source.Should().Be("First paragraph");
        segments[2].Source.Should().Be("Second paragraph");
    }

    [Fact]
    public async Task ParseAsync_WithInlineTags_ShouldExtractAsInlineTagObjects()
    {
        var html = @"<html><body>
            <p>Hello <b>bold</b> world</p>
        </body></html>";
        var filePath = WriteFile("inline.html", html);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(1);
        segments[0].SourceTags.Should().HaveCount(2); // opening + closing
        segments[0].SourceTags[0].Type.Should().Be(InlineTagType.Opening);
        segments[0].SourceTags[0].Content.Should().Be("<b>");
        segments[0].SourceTags[1].Type.Should().Be(InlineTagType.Closing);
        segments[0].SourceTags[1].Content.Should().Be("</b>");
    }

    [Fact]
    public async Task ParseAsync_WithItalicTag_ShouldExtractInlineTag()
    {
        var html = @"<html><body>
            <p>This is <i>italic</i> text</p>
        </body></html>";
        var filePath = WriteFile("italic.html", html);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(1);
        segments[0].SourceTags.Should().Contain(t => t.Content == "<i>");
        segments[0].SourceTags.Should().Contain(t => t.Content == "</i>");
    }

    [Fact]
    public async Task ParseAsync_WithListItems_ShouldReturnSegmentPerLi()
    {
        var html = @"<html><body>
            <ul>
                <li>Item one</li>
                <li>Item two</li>
            </ul>
        </body></html>";
        var filePath = WriteFile("list.html", html);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(2);
        segments[0].Source.Should().Be("Item one");
        segments[1].Source.Should().Be("Item two");
    }

    [Fact]
    public async Task ParseAsync_WithEmptyHtml_ShouldReturnEmptyList()
    {
        var html = @"<html><body></body></html>";
        var filePath = WriteFile("empty.html", html);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().BeEmpty();
    }

    [Fact]
    public async Task ParseAsync_WithHeadings_ShouldReturnSegments()
    {
        var html = @"<html><body>
            <h1>Heading 1</h1>
            <h2>Heading 2</h2>
            <h3>Heading 3</h3>
        </body></html>";
        var filePath = WriteFile("headings.html", html);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(3);
        segments[0].Source.Should().Be("Heading 1");
        segments[1].Source.Should().Be("Heading 2");
        segments[2].Source.Should().Be("Heading 3");
    }

    private string WriteFile(string fileName, string content)
    {
        var path = Path.Combine(_tempDir, fileName);
        File.WriteAllText(path, content);
        return path;
    }
}
