using MehQ.Core.Enums;

namespace MehQ.Core.Models;

public class QaWarning
{
    public Guid SegmentId { get; set; }
    public int SequenceNumber { get; set; }
    public QaCategory Category { get; set; }
    public QaSeverity Severity { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
