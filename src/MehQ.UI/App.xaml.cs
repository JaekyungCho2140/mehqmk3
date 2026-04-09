using System.Windows;
using MehQ.Application;
using MehQ.Application.Services;
using MehQ.Infrastructure;
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
        ConfigureServices(services);

        _serviceProvider = services.BuildServiceProvider();

        var mainVm = new ViewModels.MainViewModel(_serviceProvider.GetRequiredService<ProjectService>());
        mainVm.EditorViewModel = _serviceProvider.GetRequiredService<ViewModels.TranslationEditorViewModel>();

        var mainWindow = new Views.MainWindow { DataContext = mainVm };
        mainWindow.Show();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ViewModels.TranslationEditorViewModel>();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }
}
