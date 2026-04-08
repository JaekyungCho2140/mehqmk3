using FluentAssertions;
using MehQ.Core.Enums;
using MehQ.Infrastructure.Parsers;
using Xunit;

namespace MehQ.Infrastructure.Tests.Parsers;

public class PlainTextParserTests : IDisposable
{
    private readonly string _tempDir;
    private readonly PlainTextParser _parser;

    public PlainTextParserTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"mehq-test-{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
        _parser = new PlainTextParser();
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    [Fact]
    public void SupportedExtensions_ShouldContainTxt()
    {
        _parser.SupportedExtensions.Should().Contain(".txt");
    }

    [Fact]
    public async Task ParseAsync_WithMultipleLines_ShouldReturnSegmentPerLine()
    {
        var content = "Hello world\nSecond line\nThird line";
        var filePath = WriteFile("multi.txt", content);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(3);
        segments[0].Source.Should().Be("Hello world");
        segments[0].SequenceNumber.Should().Be(1);
        segments[1].Source.Should().Be("Second line");
        segments[1].SequenceNumber.Should().Be(2);
        segments[2].Source.Should().Be("Third line");
        segments[2].SequenceNumber.Should().Be(3);
    }

    [Fact]
    public async Task ParseAsync_ShouldSkipEmptyLines()
    {
        var content = "First\n\n\nSecond\n  \nThird";
        var filePath = WriteFile("empty-lines.txt", content);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(3);
        segments[0].Source.Should().Be("First");
        segments[1].Source.Should().Be("Second");
        segments[2].Source.Should().Be("Third");
    }

    [Fact]
    public async Task ParseAsync_WithEmptyFile_ShouldReturnEmptyList()
    {
        var filePath = WriteFile("empty.txt", "");

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().BeEmpty();
    }

    [Fact]
    public async Task ParseAsync_AllSegments_ShouldHaveNotStartedStatus()
    {
        var content = "Line one\nLine two";
        var filePath = WriteFile("status.txt", content);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().AllSatisfy(s => s.Status.Should().Be(SegmentStatus.NotStarted));
    }

    [Fact]
    public async Task SaveAsync_ShouldWriteTargetText()
    {
        var content = "Hello\nWorld";
        var filePath = WriteFile("save.txt", content);

        var segments = await _parser.ParseAsync(filePath);
        segments[0].Target = "Hola";
        segments[1].Target = "Mundo";

        await _parser.SaveAsync(filePath, segments.ToList());

        var lines = await File.ReadAllLinesAsync(filePath);
        lines.Should().Contain("Hola");
        lines.Should().Contain("Mundo");
    }

    [Fact]
    public async Task SaveAsync_WithEmptyTarget_ShouldFallBackToSource()
    {
        var content = "Hello\nWorld";
        var filePath = WriteFile("fallback.txt", content);

        var segments = await _parser.ParseAsync(filePath);
        segments[0].Target = "Hola";
        // segments[1].Target remains empty

        await _parser.SaveAsync(filePath, segments.ToList());

        var lines = await File.ReadAllLinesAsync(filePath);
        lines[0].Should().Be("Hola");
        lines[1].Should().Be("World"); // falls back to source
    }

    private string WriteFile(string fileName, string content)
    {
        var path = Path.Combine(_tempDir, fileName);
        File.WriteAllText(path, content);
        return path;
    }
}
