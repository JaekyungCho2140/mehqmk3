using FluentAssertions;
using MehQ.Core.Enums;
using Xunit;

namespace MehQ.Core.Tests.Enums;

public class SegmentStatusTests
{
    [Fact]
    public void NotStarted_ShouldBeZero()
    {
        ((int)SegmentStatus.NotStarted).Should().Be(0);
    }

    [Fact]
    public void TranslatorConfirmed_ShouldBeFour()
    {
        ((int)SegmentStatus.TranslatorConfirmed).Should().Be(4);
    }

    [Fact]
    public void Locked_ShouldBeEight()
    {
        ((int)SegmentStatus.Locked).Should().Be(8);
    }

    [Fact]
    public void AllExpectedValues_ShouldExist()
    {
        Enum.GetNames<SegmentStatus>().Should().Contain(new[]
        {
            "NotStarted",
            "Edited",
            "PreTranslated",
            "FragmentAssembled",
            "TranslatorConfirmed",
            "Reviewer1Confirmed",
            "Reviewer2Confirmed",
            "Rejected",
            "Locked"
        });
    }
}
