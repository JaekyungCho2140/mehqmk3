using FluentAssertions;
using MehQ.Core.Models;
using Xunit;

namespace MehQ.Core.Tests.Models;

public class ProjectTests
{
    [Fact]
    public void NewProject_ShouldHaveNonEmptyId()
    {
        var project = new Project();

        project.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void NewProject_ShouldHaveCreatedAtCloseToUtcNow()
    {
        var before = DateTime.UtcNow;
        var project = new Project();
        var after = DateTime.UtcNow;

        project.CreatedAt.Should().BeOnOrAfter(before).And.BeOnOrBefore(after);
    }

    [Fact]
    public void NewProject_ShouldHaveEmptyButNotNullCollections()
    {
        var project = new Project();

        project.Documents.Should().NotBeNull().And.BeEmpty();
        project.TranslationMemories.Should().NotBeNull().And.BeEmpty();
        project.TermBases.Should().NotBeNull().And.BeEmpty();
    }

    [Fact]
    public void Project_CanSetName()
    {
        var project = new Project { Name = "Test Project" };

        project.Name.Should().Be("Test Project");
    }

    [Fact]
    public void Project_CanSetSourceLanguage()
    {
        var project = new Project { SourceLanguage = "en-US" };

        project.SourceLanguage.Should().Be("en-US");
    }

    [Fact]
    public void Project_CanSetTargetLanguage()
    {
        var project = new Project { TargetLanguage = "ko-KR" };

        project.TargetLanguage.Should().Be("ko-KR");
    }
}
