using System.Windows;
using MehQ.Application;
using MehQ.Application.Services;
using MehQ.Infrastructure;
using MehQ.Infrastructure.Data;
using MehQ.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MehQ.UI;

public partial class App : System.Windows.Application
{
    private ServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        services.AddApplication();
        services.AddInfrastructure();

        _serviceProvider = services.BuildServiceProvider();

        // Ensure database is created
        using (var scope = _serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<MehQDbContext>();
            db.Database.EnsureCreated();
        }

        // Resolve services
        var projectService = _serviceProvider.GetRequiredService<ProjectService>();
        var tmService = _serviceProvider.GetRequiredService<TranslationMemoryService>();
        var tbService = _serviceProvider.GetRequiredService<TermBaseService>();
        var qaService = _serviceProvider.GetRequiredService<QaService>();
        var docService = _serviceProvider.GetRequiredService<Core.Interfaces.IDocumentService>();

        // Create ViewModels with full service injection
        var editorVm = new ViewModels.TranslationEditorViewModel(docService, tmService, tbService, qaService);
        var mainVm = new ViewModels.MainViewModel(projectService)
        {
            EditorViewModel = editorVm
        };

        var mainWindow = new Views.MainWindow { DataContext = mainVm };
        mainWindow.Show();

        mainVm.StatusText = $"mehQ v{AutoUpdateService.GetCurrentVersion()} — Ready";

        // Load projects on startup
        _ = mainVm.LoadProjectsCommand.ExecuteAsync(null);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }
}
