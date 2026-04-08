using MehQ.Core.Interfaces;
using MehQ.Infrastructure.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace MehQ.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFileParser, XliffParser>();
        services.AddSingleton<FileParserFactory>();
        return services;
    }
}
