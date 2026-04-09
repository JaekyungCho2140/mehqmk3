using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Enums;
using MehQ.Core.Models;
using MehQ.Core.Services;
using MehQ.Infrastructure.Data;
using Xunit;

namespace MehQ.Integration.Tests.Scenarios;

public class QaWorkflowTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public QaWorkflowTests(TestFixture fixture) => _fixture = fixture;

    [Fact]
    public async Task QaWorkflow_DetectAllIssues()
    {
        var qaService = _fixture.GetService<QaService>();

        // Create TB with forbidden term for terminology check (use separate context)
        Guid tbId;
        using (var db = _fixture.CreateDbContext())
        {
            var tb = new TermBase { Name = "QA TB", SourceLanguage = "en", TargetLanguage = "ko" };
            tb.Terms.Add(new Term { SourceTerm = "error", TargetTerm = "에러", IsForbidden = true, TermBaseId = tb.Id });
            db.TermBases.Add(tb);
            await db.SaveChangesAsync();
            tbId = tb.Id;
        }

        var segments = new List<Segment>
        {
            // Tag mismatch
            new() { SequenceNumber = 1, Source = "Click {1}here{2}", Target = "여기를 클릭", Status = SegmentStatus.Edited },
            // Number mismatch
            new() { SequenceNumber = 2, Source = "Page 42 of 100", Target = "42페이지", Status = SegmentStatus.Edited },
            // Empty confirmed target
            new() { SequenceNumber = 3, Source = "Hello", Target = "", Status = SegmentStatus.TranslatorConfirmed },
            // Forbidden term in target
            new() { SequenceNumber = 4, Source = "Fix the error", Target = "에러를 수정하세요", Status = SegmentStatus.Edited },
            // Clean segment
            new() { SequenceNumber = 5, Source = "Save.", Target = "저장.", Status = SegmentStatus.Edited }
        };

        var warnings = await qaService.RunQaAsync(segments, tbId);

        // Tag mismatch on segment 1
        warnings.Should().Contain(w => w.SequenceNumber == 1 && w.Category == QaCategory.TagMismatch);
        // Number mismatch on segment 2 (100 missing)
        warnings.Should().Contain(w => w.SequenceNumber == 2 && w.Category == QaCategory.NumberMismatch);
        // Empty target on segment 3
        warnings.Should().Contain(w => w.SequenceNumber == 3 && w.Category == QaCategory.EmptyTarget);
        // Forbidden term on segment 4
        warnings.Should().Contain(w => w.SequenceNumber == 4 && w.Category == QaCategory.TerminologyViolation);
        // Segment 5 should be clean
        warnings.Should().NotContain(w => w.SequenceNumber == 5);
    }
}
