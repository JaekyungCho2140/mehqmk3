namespace MehQ.Core.Models;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string SourceLanguage { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<TranslationDocument> Documents { get; set; } = [];
    public List<TranslationMemory> TranslationMemories { get; set; } = [];
    public List<TermBase> TermBases { get; set; } = [];
}
