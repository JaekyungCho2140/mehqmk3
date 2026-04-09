namespace MehQ.Infrastructure.Services;

/// <summary>
/// Auto-update service using Velopack.
/// Velopack NuGet package should be added when ready for release builds.
/// For now, this is a stub that will be wired up with Velopack APIs.
/// </summary>
public class AutoUpdateService
{
    private readonly string _updateUrl;

    public AutoUpdateService(string updateUrl = "")
    {
        _updateUrl = updateUrl;
    }

    /// <summary>
    /// Check for updates from the configured update URL.
    /// Returns true if an update is available.
    /// </summary>
    public async Task<bool> CheckForUpdateAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(_updateUrl))
            return false;

        // TODO: Implement with Velopack when packaging is ready
        // var mgr = new UpdateManager(_updateUrl);
        // var updateInfo = await mgr.CheckForUpdatesAsync();
        // return updateInfo != null;

        await Task.CompletedTask;
        return false;
    }

    /// <summary>
    /// Download and apply the latest update.
    /// </summary>
    public async Task ApplyUpdateAsync(CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(_updateUrl))
            return;

        // TODO: Implement with Velopack when packaging is ready
        // var mgr = new UpdateManager(_updateUrl);
        // var updateInfo = await mgr.CheckForUpdatesAsync();
        // if (updateInfo != null)
        // {
        //     await mgr.DownloadUpdatesAsync(updateInfo);
        //     mgr.ApplyUpdatesAndRestart(updateInfo);
        // }

        await Task.CompletedTask;
    }

    /// <summary>
    /// Get current application version.
    /// </summary>
    public static string GetCurrentVersion()
    {
        var assembly = System.Reflection.Assembly.GetEntryAssembly();
        return assembly?.GetName().Version?.ToString(3) ?? "0.1.0";
    }
}
