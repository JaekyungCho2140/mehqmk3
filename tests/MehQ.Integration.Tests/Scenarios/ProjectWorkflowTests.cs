using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Enums;
using MehQ.Infrastructure.Parsers;
using Xunit;

namespace MehQ.Integration.Tests.Scenarios;

public class ProjectWorkflowTests : IClassFixture<TestFixture>, IDisposable
{
    private readonly TestFixture _fixture;
    private readonly string _tempDir;

    public ProjectWorkflowTests(TestFixture fixture)
    {
        _fixture = fixture;
        _tempDir = Path.Combine(Path.GetTempPath(), $"mehq-e2e-{Guid.NewGuid()}");
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose() => Directory.Delete(_tempDir, true);

    [Fact]
    public async Task FullWorkflow_CreateProject_ImportXliff_EditSegment_Confirm()
    {
        var projectService = _fixture.GetService<ProjectService>();

        // 1. Create project
        var project = await projectService.CreateProjectAsync("E2E Test", "en", "ko");
        project.Should().NotBeNull();
        project.Name.Should().Be("E2E Test");

        // 2. Import XLIFF
        var xliffPath = CreateTestXliff();
        var doc = await projectService.ImportDocumentAsync(project.Id, xliffPath);
        doc.Segments.Should().HaveCount(3);
        doc.Segments[0].Source.Should().Be("Hello world");

        // 3. Edit segment (simulate user typing)
        doc.Segments[1].Target = "계속하려면 여기를 클릭하세요.";
        doc.Segments[1].Status = SegmentStatus.Edited;
        doc.Segments[1].Status.Should().Be(SegmentStatus.Edited);

        // 4. Confirm segment
        doc.Segments[1].Status = SegmentStatus.TranslatorConfirmed;
        doc.Segments[1].Status.Should().Be(SegmentStatus.TranslatorConfirmed);

        // 5. Verify project stats
        var stats = await projectService.GetProjectStatsAsync(project.Id);
        stats.TotalSegments.Should().Be(3);
    }

    private string CreateTestXliff()
    {
        var path = Path.Combine(_tempDir, "test.xlf");
        File.WriteAllText(path, @"<?xml version=""1.0"" encoding=""utf-8""?>
<xliff version=""1.2"" xmlns=""urn:oasis:names:tc:xliff:document:1.2"">
  <file source-language=""en"" target-language=""ko"" datatype=""plaintext"">
    <body>
      <trans-unit id=""1""><source>Hello world</source><target>안녕 세상</target></trans-unit>
      <trans-unit id=""2""><source>Click here to continue.</source><target></target></trans-unit>
      <trans-unit id=""3""><source>Page 42 of 100</source><target state=""translated"">100페이지 중 42</target></trans-unit>
    </body>
  </file>
</xliff>");
        return path;
    }
}
