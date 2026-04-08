using MehQ.Core.Models;

namespace MehQ.Core.Interfaces;

public interface IDocumentService
{
    Task<TranslationDocument> ImportDocumentAsync(Guid projectId, string filePath, CancellationToken ct = default);
    Task ExportDocumentAsync(TranslationDocument document, string outputPath, CancellationToken ct = default);
    Task<TranslationDocument> OpenDocumentAsync(string filePath, CancellationToken ct = default);
}
