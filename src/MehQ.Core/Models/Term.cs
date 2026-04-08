namespace MehQ.Core.Models;

public class Term
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TermBaseId { get; set; }
    public string SourceTerm { get; set; } = string.Empty;
    public string TargetTerm { get; set; } = string.Empty;
    public string? Definition { get; set; }
    public string? Usage { get; set; }
    public bool IsForbidden { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public TermBase? TermBase { get; set; }
}
