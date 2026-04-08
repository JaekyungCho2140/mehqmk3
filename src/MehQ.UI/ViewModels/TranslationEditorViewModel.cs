using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.UI.ViewModels;

public partial class TranslationEditorViewModel : ObservableObject
{
    private readonly IDocumentService _documentService;

    [ObservableProperty]
    private TranslationDocument? _document;

    [ObservableProperty]
    private Segment? _selectedSegment;

    [ObservableProperty]
    private string _documentTitle = "No document open";

    [ObservableProperty]
    private string _statusText = "Ready";

    [ObservableProperty]
    private int _totalSegments;

    [ObservableProperty]
    private int _translatedSegments;

    [ObservableProperty]
    private int _confirmedSegments;

    public ObservableCollection<Segment> Segments { get; } = [];

    public TranslationEditorViewModel(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    [RelayCommand]
    private async Task OpenDocumentAsync()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = "XLIFF Files (*.xlf;*.xliff)|*.xlf;*.xliff|All Files (*.*)|*.*",
            Title = "Open Translation Document"
        };

        if (dialog.ShowDialog() == true)
        {
            await LoadDocumentAsync(dialog.FileName);
        }
    }

    public async Task LoadDocumentAsync(string filePath)
    {
        try
        {
            StatusText = "Loading document...";
            Document = await _documentService.OpenDocumentAsync(filePath);
            DocumentTitle = Document.FileName;

            Segments.Clear();
            foreach (var segment in Document.Segments.OrderBy(s => s.SequenceNumber))
            {
                Segments.Add(segment);
            }

            UpdateStats();
            StatusText = $"Loaded {Segments.Count} segments from {Document.FileName}";
        }
        catch (Exception ex)
        {
            StatusText = $"Error: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task SaveDocumentAsync()
    {
        if (Document?.OriginalFilePath == null) return;

        try
        {
            StatusText = "Saving...";
            Document.Segments = [.. Segments.OrderBy(s => s.SequenceNumber)];
            await _documentService.ExportDocumentAsync(Document, Document.OriginalFilePath);
            StatusText = $"Saved {Document.FileName}";
        }
        catch (Exception ex)
        {
            StatusText = $"Save error: {ex.Message}";
        }
    }

    [RelayCommand]
    private void ConfirmSegment()
    {
        if (SelectedSegment == null) return;

        if (!string.IsNullOrWhiteSpace(SelectedSegment.Target))
        {
            SelectedSegment.Status = SegmentStatus.Confirmed;
            UpdateStats();
            MoveToNextSegment();
        }
    }

    [RelayCommand]
    private void MarkTranslated()
    {
        if (SelectedSegment == null) return;

        if (!string.IsNullOrWhiteSpace(SelectedSegment.Target))
        {
            SelectedSegment.Status = SegmentStatus.Translated;
            UpdateStats();
        }
    }

    private void MoveToNextSegment()
    {
        if (SelectedSegment == null) return;
        var currentIndex = Segments.IndexOf(SelectedSegment);
        if (currentIndex < Segments.Count - 1)
        {
            SelectedSegment = Segments[currentIndex + 1];
        }
    }

    private void UpdateStats()
    {
        TotalSegments = Segments.Count;
        TranslatedSegments = Segments.Count(s => s.Status >= SegmentStatus.Translated);
        ConfirmedSegments = Segments.Count(s => s.Status >= SegmentStatus.Confirmed);
    }
}
