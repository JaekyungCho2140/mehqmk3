using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IEnumerable<IFileParser> _parsers;

    public DocumentService(IEnumerable<IFileParser> parsers)
    {
        _parsers = parsers;
    }

    public async Task<TranslationDocument> ImportDocumentAsync(Guid projectId, string filePath, CancellationToken ct = default)
    {
        var parser = GetParser(filePath);
        var segments = await parser.ParseAsync(filePath, ct);

        var document = new TranslationDocument
        {
            ProjectId = projectId,
            FileName = Path.GetFileName(filePath),
            FileFormat = Path.GetExtension(filePath).TrimStart('.').ToLowerInvariant(),
            OriginalFilePath = filePath,
        };

        foreach (var segment in segments)
        {
            segment.DocumentId = document.Id;
            document.Segments.Add(segment);
        }

        return document;
    }

    public async Task ExportDocumentAsync(TranslationDocument document, string outputPath, CancellationToken ct = default)
    {
        if (document.OriginalFilePath == null)
            throw new InvalidOperationException("Document has no original file path for export.");

        // Copy original to output, then update targets
        if (document.OriginalFilePath != outputPath)
            File.Copy(document.OriginalFilePath, outputPath, overwrite: true);

        var parser = GetParser(outputPath);
        await parser.SaveAsync(outputPath, document.Segments.OrderBy(s => s.SequenceNumber).ToList(), ct);
    }

    public async Task<TranslationDocument> OpenDocumentAsync(string filePath, CancellationToken ct = default)
    {
        return await ImportDocumentAsync(Guid.Empty, filePath, ct);
    }

    private IFileParser GetParser(string filePath)
    {
        var extension = Path.GetExtension(filePath).ToLowerInvariant();
        var parser = _parsers.FirstOrDefault(p => p.SupportedExtensions.Contains(extension));
        return parser ?? throw new NotSupportedException($"No parser available for file extension: {extension}");
    }
}
