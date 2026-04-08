using FluentAssertions;
using MehQ.Core.Enums;
using MehQ.Core.Models;
using Xunit;

namespace MehQ.Core.Tests.Models;

public class SegmentTests
{
    [Fact]
    public void NewSegment_ShouldHaveNotStartedStatus()
    {
        var segment = new Segment();

        segment.Status.Should().Be(SegmentStatus.NotStarted);
    }

    [Fact]
    public void NewSegment_ShouldHaveIsLockedFalse()
    {
        var segment = new Segment();

        segment.IsLocked.Should().BeFalse();
    }

    [Fact]
    public void Segment_CanSetSourceText()
    {
        var segment = new Segment { Source = "Hello, world!" };

        segment.Source.Should().Be("Hello, world!");
    }

    [Fact]
    public void Segment_CanSetTargetText()
    {
        var segment = new Segment { Target = "안녕하세요!" };

        segment.Target.Should().Be("안녕하세요!");
    }
}
