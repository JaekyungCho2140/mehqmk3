using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MehQ.Core.Models;

namespace MehQ.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _statusText = "Ready";

    [ObservableProperty]
    private object? _currentView;

    public ObservableCollection<Project> RecentProjects { get; } = [];

    [RelayCommand]
    private void ShowDashboard()
    {
        StatusText = "Dashboard";
    }
}
