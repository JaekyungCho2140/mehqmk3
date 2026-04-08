using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using Moq;
using Xunit;

namespace MehQ.Application.Tests.Services;

public class DocumentServiceTests
{
    private readonly Mock<IFileParser> _mockParser;
    private readonly DocumentService _service;

    public DocumentServiceTests()
    {
        _mockParser = new Mock<IFileParser>();
        _mockParser.Setup(p => p.SupportedExtensions).Returns([".xlf", ".xliff"]);
        _service = new DocumentService([_mockParser.Object]);
    }

    [Fact]
    public async Task ImportDocumentAsync_ShouldCreateDocumentWithSegments()
    {
        var projectId = Guid.NewGuid();
        var segments = new List<Segment>
        {
            new() { Source = "Hello", Target = "Hola", SequenceNumber = 1 },
            new() { Source = "World", Target = "Mundo", SequenceNumber = 2 }
        };

        _mockParser.Setup(p => p.ParseAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(segments);

        var doc = await _service.ImportDocumentAsync(projectId, "test.xlf");

        doc.Should().NotBeNull();
        doc.ProjectId.Should().Be(projectId);
        doc.FileName.Should().Be("test.xlf");
        doc.FileFormat.Should().Be("xlf");
        doc.Segments.Should().HaveCount(2);
        doc.Segments[0].DocumentId.Should().Be(doc.Id);
    }

    [Fact]
    public async Task ImportDocumentAsync_WithUnsupportedFormat_ShouldThrow()
    {
        var act = async () => await _service.ImportDocumentAsync(Guid.NewGuid(), "test.doc");

        await act.Should().ThrowAsync<NotSupportedException>()
            .WithMessage("*No parser available*");
    }

    [Fact]
    public async Task OpenDocumentAsync_ShouldReturnDocumentWithEmptyProjectId()
    {
        _mockParser.Setup(p => p.ParseAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Segment> { new() { Source = "Test" } });

        var doc = await _service.OpenDocumentAsync("file.xlf");

        doc.Should().NotBeNull();
        doc.ProjectId.Should().Be(Guid.Empty);
    }
}
