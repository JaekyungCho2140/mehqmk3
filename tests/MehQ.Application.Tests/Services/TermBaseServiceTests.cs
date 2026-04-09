using FluentAssertions;
using MehQ.Application.Services;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using Moq;
using Xunit;

namespace MehQ.Application.Tests.Services;

public class TermBaseServiceTests
{
    private readonly Mock<ITermBaseRepository> _mockRepo;
    private readonly TermBaseService _service;
    private readonly Guid _tbId = Guid.NewGuid();

    public TermBaseServiceTests()
    {
        _mockRepo = new Mock<ITermBaseRepository>();
        _service = new TermBaseService(_mockRepo.Object);
    }

    [Fact]
    public async Task LookupTermsAsync_ShouldFindMatchingTerms()
    {
        var tb = new TermBase
        {
            Id = _tbId,
            Terms =
            [
                new() { SourceTerm = "computer", TargetTerm = "컴퓨터" },
                new() { SourceTerm = "mouse", TargetTerm = "마우스" },
                new() { SourceTerm = "keyboard", TargetTerm = "키보드" }
            ]
        };
        _mockRepo.Setup(r => r.GetByIdAsync(_tbId, It.IsAny<CancellationToken>())).ReturnsAsync(tb);

        var matches = await _service.LookupTermsAsync(_tbId, "Click the computer mouse to continue");

        matches.Should().HaveCount(2);
        matches[0].Term.SourceTerm.Should().Be("computer");
        matches[1].Term.SourceTerm.Should().Be("mouse");
    }

    [Fact]
    public async Task LookupTermsAsync_CaseInsensitive()
    {
        var tb = new TermBase
        {
            Id = _tbId,
            Terms = [new() { SourceTerm = "Computer", TargetTerm = "컴퓨터" }]
        };
        _mockRepo.Setup(r => r.GetByIdAsync(_tbId, It.IsAny<CancellationToken>())).ReturnsAsync(tb);

        var matches = await _service.LookupTermsAsync(_tbId, "the COMPUTER is on");

        matches.Should().HaveCount(1);
    }

    [Fact]
    public async Task CheckForbiddenTermsAsync_ShouldDetectForbiddenTerms()
    {
        var tb = new TermBase
        {
            Id = _tbId,
            Terms =
            [
                new() { SourceTerm = "terminate", TargetTerm = "종료하다", IsForbidden = false },
                new() { SourceTerm = "kill", TargetTerm = "죽이다", IsForbidden = true }
            ]
        };
        _mockRepo.Setup(r => r.GetByIdAsync(_tbId, It.IsAny<CancellationToken>())).ReturnsAsync(tb);

        var forbidden = await _service.CheckForbiddenTermsAsync(_tbId, "프로세스를 죽이다");

        forbidden.Should().HaveCount(1);
        forbidden[0].SourceTerm.Should().Be("kill");
    }

    [Fact]
    public async Task CheckForbiddenTermsAsync_NoForbidden_ShouldReturnEmpty()
    {
        var tb = new TermBase
        {
            Id = _tbId,
            Terms = [new() { SourceTerm = "ok", TargetTerm = "확인", IsForbidden = false }]
        };
        _mockRepo.Setup(r => r.GetByIdAsync(_tbId, It.IsAny<CancellationToken>())).ReturnsAsync(tb);

        var forbidden = await _service.CheckForbiddenTermsAsync(_tbId, "확인 버튼을 클릭");

        forbidden.Should().BeEmpty();
    }

    [Fact]
    public async Task AddTermAsync_ShouldAddNewTerm()
    {
        var tb = new TermBase { Id = _tbId, Terms = [] };
        _mockRepo.Setup(r => r.GetByIdAsync(_tbId, It.IsAny<CancellationToken>())).ReturnsAsync(tb);

        await _service.AddTermAsync(_tbId, "hello", "안녕하세요");

        tb.Terms.Should().HaveCount(1);
        tb.Terms[0].SourceTerm.Should().Be("hello");
        _mockRepo.Verify(r => r.UpdateAsync(tb, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task AddTermAsync_Duplicate_ShouldNotAdd()
    {
        var tb = new TermBase
        {
            Id = _tbId,
            Terms = [new() { SourceTerm = "hello", TargetTerm = "안녕하세요" }]
        };
        _mockRepo.Setup(r => r.GetByIdAsync(_tbId, It.IsAny<CancellationToken>())).ReturnsAsync(tb);

        await _service.AddTermAsync(_tbId, "Hello", "안녕하세요");

        tb.Terms.Should().HaveCount(1);
        _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<TermBase>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
