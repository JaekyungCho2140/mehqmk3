using MehQ.Application.Services;
using MehQ.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MehQ.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IDocumentService, DocumentService>();
        services.AddTransient<Services.TranslationMemoryService>();
        return services;
    }
}
