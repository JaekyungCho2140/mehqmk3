using FluentAssertions;
using MehQ.Core.Models;
using MehQ.Core.Services;
using Xunit;

namespace MehQ.Core.Tests.Services;

public class SentenceAlignerTests
{
    private readonly Guid _corpusId = Guid.NewGuid();

    [Fact]
    public void EqualLengthLists_ShouldAlignOneToOne()
    {
        var source = new[] { "Hello", "World", "Goodbye" };
        var target = new[] { "안녕", "세계", "잘가" };

        var pairs = SentenceAligner.Align(source, target, _corpusId);

        pairs.Should().HaveCount(3);
        pairs[0].Source.Should().Be("Hello");
        pairs[0].Target.Should().Be("안녕");
        pairs[2].Source.Should().Be("Goodbye");
        pairs[2].Target.Should().Be("잘가");
    }

    [Fact]
    public void MoreSourceThanTarget_ShouldLeaveUnaligned()
    {
        var source = new[] { "A", "B", "C" };
        var target = new[] { "X" };

        var pairs = SentenceAligner.Align(source, target, _corpusId);

        pairs.Should().HaveCount(3);
        pairs[0].Target.Should().Be("X");
        pairs[1].Target.Should().BeEmpty();
        pairs[2].Target.Should().BeEmpty();
    }

    [Fact]
    public void EmptyLists_ShouldReturnEmpty()
    {
        var pairs = SentenceAligner.Align(Array.Empty<string>(), Array.Empty<string>(), _corpusId);
        pairs.Should().BeEmpty();
    }

    [Fact]
    public void AllPairs_ShouldHaveSequentialNumbers()
    {
        var source = new[] { "A", "B", "C" };
        var target = new[] { "X", "Y", "Z" };

        var pairs = SentenceAligner.Align(source, target, _corpusId);

        pairs.Select(p => p.SequenceNumber).Should().BeEquivalentTo(new[] { 1, 2, 3 });
    }

    [Fact]
    public void AllPairs_ShouldHaveAutomaticConfidence()
    {
        var source = new[] { "A" };
        var target = new[] { "X" };

        var pairs = SentenceAligner.Align(source, target, _corpusId);

        pairs[0].Confidence.Should().Be(AlignmentConfidence.Automatic);
    }
}
