using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FluentAssertions;
using MehQ.Infrastructure.Parsers;
using Xunit;

namespace MehQ.Integration.Tests.Scenarios;

public class FileFormatTests : IDisposable
{
    private readonly string _tempDir;

    public FileFormatTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"mehq-format-{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose() => Directory.Delete(_tempDir, true);

    [Fact]
    public async Task XliffRoundtrip_ParseEditSaveReparse()
    {
        var parser = new XliffParser();
        var path = Path.Combine(_tempDir, "roundtrip.xlf");
        File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"">
  <file source-language=""en"" target-language=""ko"" datatype=""plaintext"">
    <body>
      <trans-unit id=""1""><source>Hello</source><target></target></trans-unit>
      <trans-unit id=""2""><source>World</source><target></target></trans-unit>
    </body>
  </file>
</xliff>");

        // Parse
        var segments = await parser.ParseAsync(path);
        segments.Should().HaveCount(2);

        // Edit
        segments[0].Target = "안녕";
        segments[0].Status = Core.Enums.SegmentStatus.TranslatorConfirmed;
        segments[1].Target = "세상";

        // Save
        await parser.SaveAsync(path, segments.ToList());

        // Reparse
        var reloaded = await parser.ParseAsync(path);
        reloaded[0].Target.Should().Be("안녕");
        reloaded[1].Target.Should().Be("세상");
    }

    [Fact]
    public async Task DocxParse_ExtractsFormattedSegments()
    {
        var parser = new DocxParser();
        var path = CreateTestDocx();

        var segments = await parser.ParseAsync(path);
        segments.Should().NotBeEmpty();
        segments[0].Source.Should().Contain("Hello");
    }

    [Fact]
    public async Task HtmlParse_ExtractsBlockElements()
    {
        var parser = new HtmlParser();
        var path = Path.Combine(_tempDir, "test.html");
        File.WriteAllText(path, "<html><body><h1>Title</h1><p>Hello <b>world</b></p><p>Goodbye</p></body></html>");

        var segments = await parser.ParseAsync(path);
        segments.Should().HaveCountGreaterOrEqualTo(2);
        segments.Should().Contain(s => s.Source.Contains("Hello"));
    }

    [Fact]
    public async Task TxtParse_LinePerSegment()
    {
        var parser = new PlainTextParser();
        var path = Path.Combine(_tempDir, "test.txt");
        File.WriteAllText(path, "Line one\n\nLine two\nLine three\n");

        var segments = await parser.ParseAsync(path);
        segments.Should().HaveCount(3); // empty line skipped
        segments[0].Source.Should().Be("Line one");
    }

    private string CreateTestDocx()
    {
        var path = Path.Combine(_tempDir, "test.docx");
        using var doc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document);
        var mainPart = doc.AddMainDocumentPart();
        mainPart.Document = new Document(new Body(
            new Paragraph(new Run(new Text("Hello world"))),
            new Paragraph(new Run(new Text("Second paragraph")))
        ));
        mainPart.Document.Save();
        return path;
    }
}
