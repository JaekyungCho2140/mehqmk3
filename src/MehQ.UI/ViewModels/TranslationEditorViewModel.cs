using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MehQ.Application.Services;
using MehQ.Core.Enums;
using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.UI.ViewModels;

public partial class TranslationEditorViewModel : ObservableObject
{
    private readonly IDocumentService _documentService;
    private readonly TranslationMemoryService? _tmService;
    private readonly TermBaseService? _tbService;
    private readonly QaService? _qaService;
    private Guid? _activeTmId;
    private Guid? _activeTbId;

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

    [ObservableProperty]
    private int _editedSegments;

    [ObservableProperty]
    private int _emptySegments;

    [ObservableProperty]
    private int _preTranslatedSegments;

    [ObservableProperty]
    private int _qaErrorCount;

    [ObservableProperty]
    private int _completionPercentage;

    public ObservableCollection<Segment> Segments { get; } = [];
    public ObservableCollection<TmMatch> TmMatches { get; } = [];
    public ObservableCollection<TermMatch> TermMatches { get; } = [];
    public ObservableCollection<QaWarning> QaWarnings { get; } = [];

    public TranslationEditorViewModel(IDocumentService documentService,
        TranslationMemoryService? tmService = null,
        TermBaseService? tbService = null,
        QaService? qaService = null)
    {
        _documentService = documentService;
        _tmService = tmService;
        _tbService = tbService;
        _qaService = qaService;
    }

    public void SetActiveTm(Guid tmId) => _activeTmId = tmId;
    public void SetActiveTb(Guid tbId) => _activeTbId = tbId;

    partial void OnSelectedSegmentChanged(Segment? value)
    {
        if (value != null)
        {
            _ = LookupMatchesAsync(value);
        }
    }

    private async Task LookupMatchesAsync(Segment segment)
    {
        // TM lookup
        TmMatches.Clear();
        if (_tmService != null && _activeTmId.HasValue)
        {
            try
            {
                var matches = await _tmService.LookupAsync(_activeTmId.Value, segment.Source);
                foreach (var m in matches)
                    TmMatches.Add(m);
            }
            catch { /* TM not available yet */ }
        }

        // TB lookup
        TermMatches.Clear();
        if (_tbService != null && _activeTbId.HasValue)
        {
            try
            {
                var matches = await _tbService.LookupTermsAsync(_activeTbId.Value, segment.Source);
                foreach (var m in matches)
                    TermMatches.Add(m);
            }
            catch { /* TB not available yet */ }
        }
    }

    [RelayCommand]
    private async Task OpenDocumentAsync()
    {
        var dialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = "All Supported|*.xlf;*.xliff;*.docx;*.html;*.htm;*.txt|XLIFF|*.xlf;*.xliff|Word Documents|*.docx|HTML|*.html;*.htm|Plain Text|*.txt|All Files|*.*",
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

    // Keyboard shortcut: Ctrl+Enter
    [RelayCommand]
    private void ConfirmSegment()
    {
        if (SelectedSegment == null) return;
        if (string.IsNullOrWhiteSpace(SelectedSegment.Target)) return;

        SelectedSegment.Status = SegmentStatus.TranslatorConfirmed;
        UpdateStats();

        // Store confirmed pair in TM
        if (_tmService != null && _activeTmId.HasValue)
        {
            _ = _tmService.StoreEntryAsync(_activeTmId.Value,
                SelectedSegment.Source, SelectedSegment.Target);
        }

        MoveToNextSegment();
    }

    // Keyboard shortcut: Ctrl+E
    [RelayCommand]
    private void MarkTranslated()
    {
        if (SelectedSegment == null) return;

        if (!string.IsNullOrWhiteSpace(SelectedSegment.Target))
        {
            SelectedSegment.Status = SegmentStatus.TranslatorConfirmed;
            UpdateStats();
        }
    }

    // Keyboard shortcut: Ctrl+Shift+C — copy source text to target
    [RelayCommand]
    private void CopySourceToTarget()
    {
        if (SelectedSegment == null) return;

        SelectedSegment.Target = SelectedSegment.Source;
        SelectedSegment.Status = SegmentStatus.Edited;
        UpdateStats();
    }

    // Keyboard shortcut: Ctrl+Shift+R — reject segment (reviewer action)
    [RelayCommand]
    private void RejectSegment()
    {
        if (SelectedSegment == null) return;

        SelectedSegment.Status = SegmentStatus.Rejected;
        UpdateStats();
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

    [RelayCommand]
    private async Task RunQaAsync()
    {
        if (Segments.Count == 0) return;

        QaWarnings.Clear();
        var warnings = await (_qaService?.RunQaAsync(
            Segments.ToList(), _activeTbId) ?? Task.FromResult<IReadOnlyList<QaWarning>>([]));

        foreach (var w in warnings)
            QaWarnings.Add(w);

        QaErrorCount = warnings.Count;
        StatusText = $"QA complete: {warnings.Count} issues found";
    }

    private void UpdateStats()
    {
        TotalSegments = Segments.Count;
        EmptySegments = Segments.Count(s => s.Status == SegmentStatus.NotStarted);
        EditedSegments = Segments.Count(s => s.Status == SegmentStatus.Edited);
        PreTranslatedSegments = Segments.Count(s => s.Status == SegmentStatus.PreTranslated);
        TranslatedSegments = Segments.Count(s => s.Status >= SegmentStatus.TranslatorConfirmed);
        ConfirmedSegments = Segments.Count(s => s.Status >= SegmentStatus.TranslatorConfirmed);
        CompletionPercentage = TotalSegments == 0 ? 0 :
            (int)Math.Round(100.0 * ConfirmedSegments / TotalSegments);
    }
}
