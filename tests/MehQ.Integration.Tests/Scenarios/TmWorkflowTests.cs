using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Models;
using MehQ.Infrastructure.Data;
using Xunit;

namespace MehQ.Integration.Tests.Scenarios;

public class TmWorkflowTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public TmWorkflowTests(TestFixture fixture) => _fixture = fixture;

    [Fact]
    public async Task TmWorkflow_StoreEntry_ThenFuzzySearch()
    {
        var tmService = _fixture.GetService<TranslationMemoryService>();

        // 1. Create TM (use separate context for seeding)
        Guid tmId;
        using (var db = _fixture.CreateDbContext())
        {
            var tm = new TranslationMemory { Name = "E2E TM", SourceLanguage = "en", TargetLanguage = "ko" };
            db.TranslationMemories.Add(tm);
            await db.SaveChangesAsync();
            tmId = tm.Id;
        }

        // 2. Store entries
        await tmService.StoreEntryAsync(tmId, "Hello world", "안녕 세상");
        await tmService.StoreEntryAsync(tmId, "Click here to continue", "계속하려면 여기를 클릭");
        await tmService.StoreEntryAsync(tmId, "Save the document", "문서를 저장");

        // 3. Exact match lookup
        var exactResults = await tmService.LookupAsync(tmId, "Hello world");
        exactResults.Should().NotBeEmpty();
        exactResults[0].MatchRate.Should().Be(100);
        exactResults[0].Entry.Target.Should().Be("안녕 세상");

        // 4. Fuzzy match lookup
        var fuzzyResults = await tmService.LookupAsync(tmId, "Hello worlds");
        fuzzyResults.Should().NotBeEmpty();
        fuzzyResults[0].MatchRate.Should().BeInRange(85, 99);

        // 5. Concordance search
        var concordance = await tmService.ConcordanceSearchAsync(tmId, "click");
        concordance.Should().HaveCount(1);
        concordance[0].Source.Should().Contain("Click here");
    }
}
