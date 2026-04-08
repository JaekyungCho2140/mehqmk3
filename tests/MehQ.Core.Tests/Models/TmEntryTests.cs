using FluentAssertions;
using MehQ.Core.Models;
using Xunit;

namespace MehQ.Core.Tests.Models;

public class TmEntryTests
{
    [Fact]
    public void NewTmEntry_ShouldHaveNonEmptyId()
    {
        var entry = new TmEntry();

        entry.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void TmEntry_CanSetSource()
    {
        var entry = new TmEntry { Source = "Source text" };

        entry.Source.Should().Be("Source text");
    }

    [Fact]
    public void TmEntry_CanSetTarget()
    {
        var entry = new TmEntry { Target = "Target text" };

        entry.Target.Should().Be("Target text");
    }

    [Fact]
    public void TmEntry_CanSetContext()
    {
        var entry = new TmEntry { Context = "UI string" };

        entry.Context.Should().Be("UI string");
    }
}
