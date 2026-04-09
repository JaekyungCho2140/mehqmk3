using MehQ.Application.Services;
using MehQ.Core.Interfaces;
using MehQ.Infrastructure.Data;
using MehQ.Infrastructure.Parsers;
using MehQ.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MehQ.Integration.Tests;

/// <summary>
/// Shared test fixture providing a SQLite in-memory database and DI container.
/// Each call to GetService creates a new scope with a fresh DbContext to mimic
/// real application behavior where each request gets its own context.
/// </summary>
public class TestFixture : IDisposable
{
    private readonly ServiceProvider _rootProvider;
    private readonly SqliteConnection _connection;

    public TestFixture()
    {
        // Use SQLite in-memory mode with a shared connection kept open for the fixture lifetime
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var services = new ServiceCollection();

        services.AddDbContext<MehQDbContext>(options =>
            options.UseSqlite(_connection), ServiceLifetime.Transient);

        // Infrastructure
        services.AddSingleton<IFileParser, XliffParser>();
        services.AddSingleton<IFileParser, DocxParser>();
        services.AddSingleton<IFileParser, HtmlParser>();
        services.AddSingleton<IFileParser, PlainTextParser>();
        services.AddSingleton<FileParserFactory>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<ITranslationMemoryRepository, TranslationMemoryRepository>();
        services.AddTransient<ITermBaseRepository, TermBaseRepository>();
        services.AddTransient<ILiveDocsRepository, LiveDocsRepository>();

        // Application
        services.AddTransient<IDocumentService, DocumentService>();
        services.AddTransient<TranslationMemoryService>();
        services.AddTransient<TermBaseService>();
        services.AddTransient<ProjectService>();
        services.AddTransient<QaService>();
        services.AddTransient<LiveDocsService>();

        _rootProvider = services.BuildServiceProvider();

        // Ensure schema is created
        using var db = _rootProvider.GetRequiredService<MehQDbContext>();
        db.Database.EnsureCreated();
    }

    /// <summary>
    /// Creates a new DbContext connected to the shared in-memory SQLite database.
    /// </summary>
    public MehQDbContext CreateDbContext() => _rootProvider.GetRequiredService<MehQDbContext>();

    /// <summary>
    /// Resolves a service from the DI container. Each resolution of DbContext-dependent
    /// services gets a fresh DbContext, preventing entity tracking conflicts.
    /// </summary>
    public T GetService<T>() where T : notnull => _rootProvider.GetRequiredService<T>();

    public void Dispose()
    {
        _connection.Dispose();
        _rootProvider.Dispose();
    }
}
