using FluentAssertions;
using MehQ.Core.Services;
using Xunit;

namespace MehQ.Core.Tests.Services;

public class FuzzyMatcherTests
{
    [Fact]
    public void ExactMatch_ShouldReturn100()
    {
        FuzzyMatcher.CalculateMatchRate("Hello world", "Hello world").Should().Be(100);
    }

    [Fact]
    public void CaseInsensitiveExactMatch_ShouldReturn100()
    {
        FuzzyMatcher.CalculateMatchRate("Hello World", "hello world").Should().Be(100);
    }

    [Fact]
    public void EmptyStrings_ShouldReturn100()
    {
        FuzzyMatcher.CalculateMatchRate("", "").Should().Be(100);
    }

    [Fact]
    public void OneEmpty_ShouldReturn0()
    {
        FuzzyMatcher.CalculateMatchRate("Hello", "").Should().Be(0);
    }

    [Fact]
    public void SmallDifference_ShouldReturnHighRate()
    {
        // "Hello world" vs "Hello worlds" — 1 char difference in 12 chars
        var rate = FuzzyMatcher.CalculateMatchRate("Hello world", "Hello worlds");
        rate.Should().BeInRange(85, 99);
    }

    [Fact]
    public void ModerateDifference_ShouldReturnMediumRate()
    {
        var rate = FuzzyMatcher.CalculateMatchRate("The cat sat on the mat", "The dog sat on the rug");
        rate.Should().BeInRange(60, 90);
    }

    [Fact]
    public void CompletelyDifferent_ShouldReturnLowRate()
    {
        var rate = FuzzyMatcher.CalculateMatchRate("Hello", "Xyz");
        rate.Should().BeLessThan(50);
    }

    [Fact]
    public void LevenshteinDistance_IdenticalStrings_ShouldReturn0()
    {
        FuzzyMatcher.LevenshteinDistance("test", "test").Should().Be(0);
    }

    [Fact]
    public void LevenshteinDistance_OneInsertion_ShouldReturn1()
    {
        FuzzyMatcher.LevenshteinDistance("test", "tests").Should().Be(1);
    }

    [Fact]
    public void LevenshteinDistance_OneSubstitution_ShouldReturn1()
    {
        FuzzyMatcher.LevenshteinDistance("test", "tast").Should().Be(1);
    }
}
