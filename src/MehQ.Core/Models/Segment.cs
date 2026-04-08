using MehQ.Core.Enums;

namespace MehQ.Core.Models;

public class Segment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DocumentId { get; set; }
    public int SequenceNumber { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public SegmentStatus Status { get; set; } = SegmentStatus.NotStarted;
    public bool IsLocked { get; set; }
    public string? Comment { get; set; }
    public TranslationDocument? Document { get; set; }
}
