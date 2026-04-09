using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using Moq;
using Xunit;

namespace MehQ.Application.Tests.Services;

public class LiveDocsServiceTests
{
    private readonly Mock<ILiveDocsRepository> _mockRepo;
    private readonly LiveDocsService _service;

    public LiveDocsServiceTests()
    {
        _mockRepo = new Mock<ILiveDocsRepository>();
        _service = new LiveDocsService(_mockRepo.Object);
    }

    [Fact]
    public async Task AlignDocumentsAsync_ShouldCreateCorpusWithPairs()
    {
        _mockRepo.Setup(r => r.AddAsync(It.IsAny<LiveDocsCorpus>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((LiveDocsCorpus c, CancellationToken _) => c);

        var source = new[] { "Hello world", "How are you" };
        var target = new[] { "안녕 세상", "어떻게 지내" };

        var corpus = await _service.AlignDocumentsAsync("Test", "en", "ko", source, target);

        corpus.AlignedPairs.Should().HaveCount(2);
        corpus.Type.Should().Be(LiveDocsType.MonolingualPair);
        corpus.AlignedPairs[0].Source.Should().Be("Hello world");
    }

    [Fact]
    public async Task LookupAsync_ShouldReturnFuzzyMatches()
    {
        var corpus = new LiveDocsCorpus
        {
            Id = Guid.NewGuid(),
            AlignedPairs =
            [
                new() { Source = "Hello world", Target = "안녕 세상" },
                new() { Source = "Goodbye world", Target = "잘가 세상" },
                new() { Source = "Something else", Target = "다른 것" }
            ]
        };

        _mockRepo.Setup(r => r.GetByIdAsync(corpus.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(corpus);

        var matches = await _service.LookupAsync(corpus.Id, "Hello world");

        matches.Should().NotBeEmpty();
        matches[0].MatchRate.Should().Be(100);
        matches[0].Pair.Target.Should().Be("안녕 세상");
    }
}
