namespace MehQ.Core.Models;

public class TranslationDocument
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProjectId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileFormat { get; set; } = string.Empty; // xliff, docx, html, txt
    public string? OriginalFilePath { get; set; }
    public DateTime ImportedAt { get; set; } = DateTime.UtcNow;
    public List<Segment> Segments { get; set; } = [];
    public Project? Project { get; set; }
}
