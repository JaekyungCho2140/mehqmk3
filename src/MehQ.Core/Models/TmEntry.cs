namespace MehQ.Core.Models;

public class TmEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TranslationMemoryId { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public string? Context { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public TranslationMemory? TranslationMemory { get; set; }
}
