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
    public int MatchRate { get; set; } // 0-102, where 101=context match, 102=double context
    public bool IsLocked { get; set; }
    public string? Comment { get; set; }
    public List<InlineTag> SourceTags { get; set; } = [];
    public List<InlineTag> TargetTags { get; set; } = [];
    public TranslationDocument? Document { get; set; }
}
