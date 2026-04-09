using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MehQ.Application.Services;
using MehQ.Core.Models;

namespace MehQ.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ProjectService? _projectService;

    [ObservableProperty]
    private string _statusText = "Ready";

    [ObservableProperty]
    private object? _currentView;

    [ObservableProperty]
    private TranslationEditorViewModel? _editorViewModel;

    [ObservableProperty]
    private Project? _currentProject;

    public ObservableCollection<Project> RecentProjects { get; } = [];

    public MainViewModel() { }

    public MainViewModel(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [RelayCommand]
    private void ShowDashboard()
    {
        StatusText = "Dashboard";
    }

    [RelayCommand]
    private async Task LoadProjectsAsync()
    {
        if (_projectService == null) return;
        var projects = await _projectService.GetAllProjectsAsync();
        RecentProjects.Clear();
        foreach (var p in projects)
            RecentProjects.Add(p);
    }

    [RelayCommand]
    private async Task CreateProjectAsync()
    {
        if (_projectService == null) return;

        // Simple dialog — in future, replace with proper WPF dialog
        var project = await _projectService.CreateProjectAsync(
            $"New Project {DateTime.Now:yyyy-MM-dd HH:mm}",
            "en-US",
            "ko-KR");

        RecentProjects.Insert(0, project);
        CurrentProject = project;
        StatusText = $"Created project: {project.Name}";
    }

    [RelayCommand]
    private async Task OpenProjectAsync(Project? project)
    {
        if (project == null || _projectService == null) return;
        CurrentProject = await _projectService.GetProjectAsync(project.Id);
        StatusText = $"Opened project: {project.Name}";
    }

    [RelayCommand]
    private async Task DeleteProjectAsync(Project? project)
    {
        if (project == null || _projectService == null) return;
        await _projectService.DeleteProjectAsync(project.Id);
        RecentProjects.Remove(project);
        if (CurrentProject?.Id == project.Id)
            CurrentProject = null;
        StatusText = $"Deleted project: {project.Name}";
    }
}
