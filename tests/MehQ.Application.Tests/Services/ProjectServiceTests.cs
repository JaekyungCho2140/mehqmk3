using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using Moq;
using Xunit;

namespace MehQ.Application.Tests.Services;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepo;
    private readonly Mock<IDocumentService> _mockDocService;
    private readonly ProjectService _service;

    public ProjectServiceTests()
    {
        _mockProjectRepo = new Mock<IProjectRepository>();
        _mockDocService = new Mock<IDocumentService>();
        _service = new ProjectService(_mockProjectRepo.Object, _mockDocService.Object);
    }

    [Fact]
    public async Task CreateProjectAsync_ShouldCreateAndReturnProject()
    {
        _mockProjectRepo.Setup(r => r.AddAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Project p, CancellationToken _) => p);

        var project = await _service.CreateProjectAsync("Test Project", "en", "ko", "Test description");

        project.Name.Should().Be("Test Project");
        project.SourceLanguage.Should().Be("en");
        project.TargetLanguage.Should().Be("ko");
        _mockProjectRepo.Verify(r => r.AddAsync(It.IsAny<Project>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetProjectStatsAsync_ShouldCalculateCorrectStats()
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Documents =
            [
                new TranslationDocument
                {
                    Segments =
                    [
                        new Segment { Status = SegmentStatus.NotStarted },
                        new Segment { Status = SegmentStatus.Edited },
                        new Segment { Status = SegmentStatus.TranslatorConfirmed },
                        new Segment { Status = SegmentStatus.TranslatorConfirmed },
                        new Segment { Status = SegmentStatus.Reviewer1Confirmed }
                    ]
                }
            ]
        };

        _mockProjectRepo.Setup(r => r.GetByIdAsync(project.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(project);

        var stats = await _service.GetProjectStatsAsync(project.Id);

        stats.TotalDocuments.Should().Be(1);
        stats.TotalSegments.Should().Be(5);
        stats.TranslatedSegments.Should().Be(3); // 2 TR + 1 R1
        stats.EditedSegments.Should().Be(1);
        stats.EmptySegments.Should().Be(1);
        stats.CompletionPercent.Should().Be(60); // 3/5 = 60%
    }

    [Fact]
    public async Task GetProjectStatsAsync_EmptyProject_ShouldReturnZeros()
    {
        var project = new Project { Id = Guid.NewGuid(), Documents = [] };
        _mockProjectRepo.Setup(r => r.GetByIdAsync(project.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(project);

        var stats = await _service.GetProjectStatsAsync(project.Id);

        stats.TotalSegments.Should().Be(0);
        stats.CompletionPercent.Should().Be(0);
    }

    [Fact]
    public async Task DeleteProjectAsync_ShouldCallRepository()
    {
        var id = Guid.NewGuid();
        await _service.DeleteProjectAsync(id);
        _mockProjectRepo.Verify(r => r.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
    }
}
