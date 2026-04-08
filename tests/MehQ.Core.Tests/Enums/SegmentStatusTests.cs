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
    public void Confirmed_ShouldBeFour()
    {
        ((int)SegmentStatus.Confirmed).Should().Be(4);
    }

    [Fact]
    public void AllExpectedValues_ShouldExist()
    {
        Enum.GetNames<SegmentStatus>().Should().Contain(new[]
        {
            "NotStarted",
            "Draft",
            "Translated",
            "Reviewed",
            "Confirmed",
            "Locked"
        });
    }
}
