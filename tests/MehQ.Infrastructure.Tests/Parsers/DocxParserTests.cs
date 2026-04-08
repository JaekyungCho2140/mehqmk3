using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentAssertions;
using MehQ.Core.Models;
using MehQ.Infrastructure.Parsers;
using Xunit;

namespace MehQ.Infrastructure.Tests.Parsers;

public class DocxParserTests : IDisposable
{
    private readonly string _tempDir;
    private readonly DocxParser _parser;

    public DocxParserTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"mehq-test-{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
        _parser = new DocxParser();
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    [Fact]
    public void SupportedExtensions_ShouldContainDocx()
    {
        _parser.SupportedExtensions.Should().Contain(".docx");
    }

    [Fact]
    public async Task ParseAsync_WithSimpleDocx_ShouldReturnSegments()
    {
        var filePath = CreateDocx("test.docx", new[]
        {
            ("Hello world", false, false, false),
            ("Second paragraph", false, false, false)
        });

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(2);
        segments[0].Source.Should().Be("Hello world");
        segments[0].SequenceNumber.Should().Be(1);
        segments[1].Source.Should().Be("Second paragraph");
        segments[1].SequenceNumber.Should().Be(2);
    }

    [Fact]
    public async Task ParseAsync_WithFormattedRuns_ShouldExtractInlineTags()
    {
        var filePath = CreateDocxWithFormattedRun("formatted.docx");

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(1);
        segments[0].SourceTags.Should().NotBeEmpty();
        segments[0].SourceTags.Should().Contain(t => t.Type == InlineTagType.Opening);
        segments[0].SourceTags.Should().Contain(t => t.Type == InlineTagType.Closing);
    }

    [Fact]
    public async Task ParseAsync_WithEmptyDocx_ShouldReturnEmptyList()
    {
        var filePath = CreateDocx("empty.docx", Array.Empty<(string, bool, bool, bool)>());

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().BeEmpty();
    }

    [Fact]
    public async Task ParseAsync_ShouldSkipEmptyParagraphs()
    {
        var filePath = Path.Combine(_tempDir, "with-empty.docx");
        using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        {
            var mainPart = doc.AddMainDocumentPart();
            mainPart.Document = new Document(new Body(
                new Paragraph(new Run(new Text("First"))),
                new Paragraph(), // empty
                new Paragraph(new Run(new Text("  "))), // whitespace only
                new Paragraph(new Run(new Text("Third")))
            ));
            mainPart.Document.Save();
        }

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(2);
        segments[0].Source.Should().Be("First");
        segments[1].Source.Should().Be("Third");
    }

    private string CreateDocx(string fileName, (string text, bool bold, bool italic, bool underline)[] paragraphs)
    {
        var filePath = Path.Combine(_tempDir, fileName);
        using var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
        var mainPart = doc.AddMainDocumentPart();
        var body = new Body();

        foreach (var (text, bold, italic, underline) in paragraphs)
        {
            var run = new Run();
            if (bold || italic || underline)
            {
                var props = new RunProperties();
                if (bold) props.Append(new Bold());
                if (italic) props.Append(new Italic());
                if (underline) props.Append(new Underline { Val = UnderlineValues.Single });
                run.Append(props);
            }
            run.Append(new Text(text) { Space = SpaceProcessingModeValues.Preserve });
            body.Append(new Paragraph(run));
        }

        mainPart.Document = new Document(body);
        mainPart.Document.Save();
        return filePath;
    }

    private string CreateDocxWithFormattedRun(string fileName)
    {
        var filePath = Path.Combine(_tempDir, fileName);
        using var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
        var mainPart = doc.AddMainDocumentPart();
        var body = new Body();

        var para = new Paragraph();
        // Plain run
        para.Append(new Run(new Text("Hello ") { Space = SpaceProcessingModeValues.Preserve }));
        // Bold run
        var boldRun = new Run();
        boldRun.Append(new RunProperties(new Bold()));
        boldRun.Append(new Text("world") { Space = SpaceProcessingModeValues.Preserve });
        para.Append(boldRun);

        body.Append(para);
        mainPart.Document = new Document(body);
        mainPart.Document.Save();
        return filePath;
    }
}
