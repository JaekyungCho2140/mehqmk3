using MehQ.Core.Interfaces;
using MehQ.Infrastructure.Data;
using MehQ.Infrastructure.Parsers;
using MehQ.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MehQ.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<MehQDbContext>(options =>
            options.UseSqlite("Data Source=mehq.db"));
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITranslationMemoryRepository, TranslationMemoryRepository>();
        services.AddScoped<ITermBaseRepository, TermBaseRepository>();
        services.AddScoped<ILiveDocsRepository, LiveDocsRepository>();

        services.AddSingleton<IFileParser, XliffParser>();
        services.AddSingleton<IFileParser, DocxParser>();
        services.AddSingleton<IFileParser, HtmlParser>();
        services.AddSingleton<IFileParser, PlainTextParser>();
        services.AddSingleton<FileParserFactory>();
        return services;
    }
}
