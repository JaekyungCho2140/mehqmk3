using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Models;
using Xunit;

namespace MehQ.Integration.Tests.Scenarios;

public class LiveDocsWorkflowTests : IClassFixture<TestFixture>
{
    private readonly TestFixture _fixture;

    public LiveDocsWorkflowTests(TestFixture fixture) => _fixture = fixture;

    [Fact]
    public async Task LiveDocsWorkflow_AlignAndLookup()
    {
        var liveDocsService = _fixture.GetService<LiveDocsService>();

        // 1. Align source/target sentences
        var source = new[] { "Hello world", "How are you", "Good morning" };
        var target = new[] { "안녕 세상", "어떻게 지내", "좋은 아침" };

        var corpus = await liveDocsService.AlignDocumentsAsync("E2E Corpus", "en", "ko", source, target);
        corpus.AlignedPairs.Should().HaveCount(3);
        corpus.Type.Should().Be(LiveDocsType.MonolingualPair);

        // 2. ActiveTM-style lookup (exact)
        var exactMatches = await liveDocsService.LookupAsync(corpus.Id, "Hello world");
        exactMatches.Should().NotBeEmpty();
        exactMatches[0].MatchRate.Should().Be(100);
        exactMatches[0].Pair.Target.Should().Be("안녕 세상");

        // 3. Fuzzy lookup
        var fuzzyMatches = await liveDocsService.LookupAsync(corpus.Id, "Hello worlds");
        fuzzyMatches.Should().NotBeEmpty();
        fuzzyMatches[0].MatchRate.Should().BeGreaterThan(50);
    }
}
