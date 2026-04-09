using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Application.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepo;
    private readonly IDocumentService _documentService;

    public ProjectService(IProjectRepository projectRepo, IDocumentService documentService)
    {
        _projectRepo = projectRepo;
        _documentService = documentService;
    }

    public async Task<Project> CreateProjectAsync(string name, string sourceLanguage, string targetLanguage,
        string? description = null, CancellationToken ct = default)
    {
        var project = new Project
        {
            Name = name,
            SourceLanguage = sourceLanguage,
            TargetLanguage = targetLanguage,
            Description = description
        };
        return await _projectRepo.AddAsync(project, ct);
    }

    public async Task<IReadOnlyList<Project>> GetAllProjectsAsync(CancellationToken ct = default)
        => await _projectRepo.GetAllAsync(ct);

    public async Task<Project?> GetProjectAsync(Guid id, CancellationToken ct = default)
        => await _projectRepo.GetByIdAsync(id, ct);

    public async Task DeleteProjectAsync(Guid id, CancellationToken ct = default)
        => await _projectRepo.DeleteAsync(id, ct);

    public async Task<TranslationDocument> ImportDocumentAsync(Guid projectId, string filePath, CancellationToken ct = default)
    {
        var doc = await _documentService.ImportDocumentAsync(projectId, filePath, ct);
        var project = await _projectRepo.GetByIdAsync(projectId, ct);
        if (project != null)
        {
            project.Documents.Add(doc);
            await _projectRepo.UpdateAsync(project, ct);
        }
        return doc;
    }

    public async Task ExportDocumentAsync(Guid projectId, Guid documentId, string outputPath, CancellationToken ct = default)
    {
        var project = await _projectRepo.GetByIdAsync(projectId, ct);
        var doc = project?.Documents.FirstOrDefault(d => d.Id == documentId);
        if (doc != null)
        {
            await _documentService.ExportDocumentAsync(doc, outputPath, ct);
        }
    }

    /// <summary>
    /// Get project statistics: total segments, translated, confirmed per document.
    /// </summary>
    public async Task<ProjectStats> GetProjectStatsAsync(Guid projectId, CancellationToken ct = default)
    {
        var project = await _projectRepo.GetByIdAsync(projectId, ct);
        if (project == null) return new ProjectStats();

        var allSegments = project.Documents.SelectMany(d => d.Segments).ToList();
        return new ProjectStats
        {
            TotalDocuments = project.Documents.Count,
            TotalSegments = allSegments.Count,
            TranslatedSegments = allSegments.Count(s => s.Status >= Core.Enums.SegmentStatus.TranslatorConfirmed),
            EditedSegments = allSegments.Count(s => s.Status == Core.Enums.SegmentStatus.Edited),
            EmptySegments = allSegments.Count(s => s.Status == Core.Enums.SegmentStatus.NotStarted),
            CompletionPercent = allSegments.Count == 0 ? 0 :
                (int)Math.Round(100.0 * allSegments.Count(s => s.Status >= Core.Enums.SegmentStatus.TranslatorConfirmed) / allSegments.Count)
        };
    }
}
