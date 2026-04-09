using FluentAssertions;
using MehQ.Core.Enums;
using MehQ.Core.Models;
using MehQ.Core.Services;
using Xunit;

namespace MehQ.Core.Tests.Services;

public class QaCheckerTests
{
    [Fact]
    public void EmptyConfirmedTarget_ShouldReturnError()
    {
        var segment = new Segment
        {
            Source = "Hello",
            Target = "",
            Status = SegmentStatus.TranslatorConfirmed,
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);

        warnings.Should().ContainSingle(w => w.Code == "QA1001");
        warnings[0].Severity.Should().Be(QaSeverity.Error);
    }

    [Fact]
    public void IdenticalSourceTarget_ShouldWarn()
    {
        var segment = new Segment { Source = "Hello World", Target = "Hello World", SequenceNumber = 1 };
        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().ContainSingle(w => w.Code == "QA1002");
    }

    [Fact]
    public void IdenticalSourceTarget_NumbersOnly_ShouldNotWarn()
    {
        var segment = new Segment { Source = "123", Target = "123", SequenceNumber = 1 };
        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().NotContain(w => w.Code == "QA1002");
    }

    [Fact]
    public void MissingTag_ShouldReturnError()
    {
        var segment = new Segment
        {
            Source = "Click {1}here{2} to continue",
            Target = "계속하려면 여기를 클릭",
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);

        warnings.Should().Contain(w => w.Code == "QA2001" && w.Message.Contains("{1}"));
        warnings.Should().Contain(w => w.Code == "QA2001" && w.Message.Contains("{2}"));
    }

    [Fact]
    public void AllTagsPresent_ShouldNotWarn()
    {
        var segment = new Segment
        {
            Source = "Click {1}here{2}",
            Target = "{1}여기{2}를 클릭",
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().NotContain(w => w.Category == QaCategory.TagMismatch);
    }

    [Fact]
    public void NumberMissing_ShouldWarn()
    {
        var segment = new Segment
        {
            Source = "Page 42 of 100",
            Target = "42페이지",
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().Contain(w => w.Code == "QA3001" && w.Message.Contains("100"));
    }

    [Fact]
    public void PunctuationMismatch_ShouldWarn()
    {
        var segment = new Segment
        {
            Source = "Click here.",
            Target = "여기를 클릭",
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().Contain(w => w.Code == "QA4001");
    }

    [Fact]
    public void LeadingSpace_ShouldWarn()
    {
        var segment = new Segment
        {
            Source = "Hello",
            Target = " 안녕",
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().Contain(w => w.Code == "QA5001");
    }

    [Fact]
    public void CheckDocument_SkipsNotStarted()
    {
        var segments = new List<Segment>
        {
            new() { Source = "Hello", Target = "", Status = SegmentStatus.NotStarted, SequenceNumber = 1 },
            new() { Source = "World", Target = "World", Status = SegmentStatus.Edited, SequenceNumber = 2 }
        };

        var warnings = QaChecker.CheckDocument(segments);

        // Should only check segment 2, not segment 1
        warnings.Should().OnlyContain(w => w.SequenceNumber == 2);
    }

    [Fact]
    public void CleanSegment_ShouldHaveNoWarnings()
    {
        var segment = new Segment
        {
            Source = "Click {1}here{2} on page 5.",
            Target = "5페이지에서 {1}여기{2}를 클릭하세요.",
            SequenceNumber = 1
        };

        var warnings = QaChecker.CheckSegment(segment);
        warnings.Should().BeEmpty();
    }
}
