using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Models;
using MehQ.Infrastructure.Data;
using Xunit;

namespace MehQ.Integration.Tests.Scenarios;

public class TbWorkflowTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public TbWorkflowTests(TestFixture fixture) => _fixture = fixture;

    [Fact]
    public async Task TbWorkflow_LookupTerms_CheckForbidden()
    {
        var tbService = _fixture.GetService<TermBaseService>();

        // 1. Create TB with terms (use separate context for seeding)
        Guid tbId;
        using (var db = _fixture.CreateDbContext())
        {
            var tb = new TermBase { Name = "E2E TB", SourceLanguage = "en", TargetLanguage = "ko" };
            tb.Terms.Add(new Term { SourceTerm = "computer", TargetTerm = "컴퓨터", TermBaseId = tb.Id });
            tb.Terms.Add(new Term { SourceTerm = "mouse", TargetTerm = "마우스", TermBaseId = tb.Id });
            tb.Terms.Add(new Term { SourceTerm = "kill", TargetTerm = "죽이다", IsForbidden = true, TermBaseId = tb.Id });
            db.TermBases.Add(tb);
            await db.SaveChangesAsync();
            tbId = tb.Id;
        }

        // 2. Lookup terms in source
        var matches = await tbService.LookupTermsAsync(tbId, "Use the computer mouse to click");
        matches.Should().HaveCount(2);

        // 3. Check forbidden terms in target
        var forbidden = await tbService.CheckForbiddenTermsAsync(tbId, "프로세스를 죽이다");
        forbidden.Should().HaveCount(1);
        forbidden[0].SourceTerm.Should().Be("kill");

        // 4. No forbidden terms
        var clean = await tbService.CheckForbiddenTermsAsync(tbId, "컴퓨터를 사용하세요");
        clean.Should().BeEmpty();
    }
}
