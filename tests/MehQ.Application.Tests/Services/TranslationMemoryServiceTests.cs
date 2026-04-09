using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using Moq;
using Xunit;

namespace MehQ.Application.Tests.Services;

public class TranslationMemoryServiceTests
{
    private readonly Mock<ITranslationMemoryRepository> _mockRepo;
    private readonly TranslationMemoryService _service;
    private readonly Guid _tmId = Guid.NewGuid();

    public TranslationMemoryServiceTests()
    {
        _mockRepo = new Mock<ITranslationMemoryRepository>();
        _service = new TranslationMemoryService(_mockRepo.Object);
    }

    [Fact]
    public async Task LookupAsync_ShouldReturnMatchesAboveThreshold()
    {
        var entries = new List<TmEntry>
        {
            new() { Source = "Hello world", Target = "Hola mundo", TranslationMemoryId = _tmId },
            new() { Source = "Hello worlds", Target = "Hola mundos", TranslationMemoryId = _tmId },
            new() { Source = "Goodbye", Target = "Adiós", TranslationMemoryId = _tmId }
        };

        _mockRepo.Setup(r => r.SearchAsync(_tmId, It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(entries);

        var results = await _service.LookupAsync(_tmId, "Hello world");

        results.Should().NotBeEmpty();
        results[0].MatchRate.Should().Be(100);
    }

    [Fact]
    public async Task ConcordanceSearchAsync_ShouldFindSubstringMatches()
    {
        var tm = new TranslationMemory
        {
            Id = _tmId,
            Entries =
            [
                new() { Source = "The quick brown fox", Target = "El rápido zorro marrón" },
                new() { Source = "A lazy dog", Target = "Un perro perezoso" },
                new() { Source = "Quick response", Target = "Respuesta rápida" }
            ]
        };

        _mockRepo.Setup(r => r.GetByIdAsync(_tmId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(tm);

        var results = await _service.ConcordanceSearchAsync(_tmId, "quick");

        results.Should().HaveCount(2);
    }

    [Fact]
    public async Task StoreEntryAsync_NewEntry_ShouldAddToTm()
    {
        var tm = new TranslationMemory { Id = _tmId, Entries = [] };

        _mockRepo.Setup(r => r.GetByIdAsync(_tmId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(tm);

        await _service.StoreEntryAsync(_tmId, "Hello", "Hola");

        tm.Entries.Should().HaveCount(1);
        tm.Entries[0].Source.Should().Be("Hello");
        tm.Entries[0].Target.Should().Be("Hola");
        _mockRepo.Verify(r => r.UpdateAsync(tm, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task StoreEntryAsync_ExistingEntry_ShouldUpdate()
    {
        var tm = new TranslationMemory
        {
            Id = _tmId,
            Entries = [new() { Source = "Hello", Target = "Old translation" }]
        };

        _mockRepo.Setup(r => r.GetByIdAsync(_tmId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(tm);

        await _service.StoreEntryAsync(_tmId, "Hello", "New translation");

        tm.Entries.Should().HaveCount(1);
        tm.Entries[0].Target.Should().Be("New translation");
    }
}
