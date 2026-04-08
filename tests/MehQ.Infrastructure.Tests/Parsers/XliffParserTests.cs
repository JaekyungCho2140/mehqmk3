using FluentAssertions;
using MehQ.Core.Enums;
using MehQ.Infrastructure.Parsers;
using Xunit;

namespace MehQ.Infrastructure.Tests.Parsers;

public class XliffParserTests : IDisposable
{
    private readonly string _tempDir;
    private readonly XliffParser _parser;

    public XliffParserTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), $"mehq-test-{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
        _parser = new XliffParser();
    }

    public void Dispose()
    {
        if (Directory.Exists(_tempDir))
            Directory.Delete(_tempDir, recursive: true);
    }

    [Fact]
    public void SupportedExtensions_ShouldIncludeXlfAndXliff()
    {
        _parser.SupportedExtensions.Should().Contain(".xlf");
        _parser.SupportedExtensions.Should().Contain(".xliff");
    }

    [Fact]
    public async Task ParseAsync_WithValidXliff12_ShouldReturnSegments()
    {
        var xliff = CreateXliff12("Hello", "Hola", "World", "Mundo");
        var filePath = WriteFile("test.xlf", xliff);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(2);
        segments[0].Source.Should().Be("Hello");
        segments[0].Target.Should().Be("Hola");
        segments[0].SequenceNumber.Should().Be(1);
        segments[1].Source.Should().Be("World");
        segments[1].Target.Should().Be("Mundo");
        segments[1].SequenceNumber.Should().Be(2);
    }

    [Fact]
    public async Task ParseAsync_WithTranslatedState_ShouldMapToTranslatedStatus()
    {
        var xliff = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"">
  <file source-language=""en"" target-language=""ko"" datatype=""plaintext"">
    <body>
      <trans-unit id=""1"">
        <source>Hello</source>
        <target state=""translated"">안녕하세요</target>
      </trans-unit>
      <trans-unit id=""2"">
        <source>Goodbye</source>
        <target state=""final"">안녕히 가세요</target>
      </trans-unit>
      <trans-unit id=""3"">
        <source>New</source>
        <target state=""new""></target>
      </trans-unit>
    </body>
  </file>
</xliff>";
        var filePath = WriteFile("states.xlf", xliff);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(3);
        segments[0].Status.Should().Be(SegmentStatus.TranslatorConfirmed);
        segments[1].Status.Should().Be(SegmentStatus.Reviewer2Confirmed);
        segments[2].Status.Should().Be(SegmentStatus.NotStarted);
    }

    [Fact]
    public async Task ParseAsync_WithNoTarget_ShouldReturnEmptyTarget()
    {
        var xliff = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"">
  <file source-language=""en"" target-language=""ko"" datatype=""plaintext"">
    <body>
      <trans-unit id=""1"">
        <source>Hello</source>
      </trans-unit>
    </body>
  </file>
</xliff>";
        var filePath = WriteFile("notarget.xlf", xliff);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(1);
        segments[0].Source.Should().Be("Hello");
        segments[0].Target.Should().BeEmpty();
    }

    [Fact]
    public async Task ParseAsync_WithoutNamespace_ShouldStillParse()
    {
        var xliff = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"">
  <file source-language=""en"" target-language=""ko"">
    <body>
      <trans-unit id=""1"">
        <source>Test</source>
        <target>테스트</target>
      </trans-unit>
    </body>
  </file>
</xliff>";
        var filePath = WriteFile("nons.xlf", xliff);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().HaveCount(1);
        segments[0].Source.Should().Be("Test");
        segments[0].Target.Should().Be("테스트");
    }

    [Fact]
    public async Task SaveAsync_ShouldUpdateTargetValues()
    {
        var xliff = CreateXliff12("Hello", "", "World", "");
        var filePath = WriteFile("save-test.xlf", xliff);

        var segments = await _parser.ParseAsync(filePath);
        segments[0].Target = "Hola";
        segments[0].Status = SegmentStatus.TranslatorConfirmed;
        segments[1].Target = "Mundo";
        segments[1].Status = SegmentStatus.Reviewer2Confirmed;

        await _parser.SaveAsync(filePath, segments.ToList());

        var reloaded = await _parser.ParseAsync(filePath);
        reloaded[0].Target.Should().Be("Hola");
        reloaded[0].Status.Should().Be(SegmentStatus.TranslatorConfirmed);
        reloaded[1].Target.Should().Be("Mundo");
        reloaded[1].Status.Should().Be(SegmentStatus.Reviewer2Confirmed);
    }

    [Fact]
    public async Task ParseAsync_EmptyFile_ShouldReturnEmptyList()
    {
        var xliff = @"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"">
  <file source-language=""en"" target-language=""ko"" datatype=""plaintext"">
    <body />
  </file>
</xliff>";
        var filePath = WriteFile("empty.xlf", xliff);

        var segments = await _parser.ParseAsync(filePath);

        segments.Should().BeEmpty();
    }

    private static string CreateXliff12(params string[] sourceTargetPairs)
    {
        var units = new System.Text.StringBuilder();
        for (int i = 0; i < sourceTargetPairs.Length; i += 2)
        {
            var id = (i / 2) + 1;
            units.AppendLine($@"      <trans-unit id=""{id}"">
        <source>{sourceTargetPairs[i]}</source>
        <target>{sourceTargetPairs[i + 1]}</target>
      </trans-unit>");
        }

        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"">
  <file source-language=""en"" target-language=""es"" datatype=""plaintext"">
    <body>
{units}    </body>
  </file>
</xliff>";
    }

    private string WriteFile(string fileName, string content)
    {
        var path = Path.Combine(_tempDir, fileName);
        File.WriteAllText(path, content);
        return path;
    }
}
