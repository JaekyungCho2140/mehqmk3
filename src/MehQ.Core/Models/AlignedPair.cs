namespace MehQ.Core.Models;

public class AlignedPair
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CorpusId { get; set; }
    public int SequenceNumber { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public AlignmentConfidence Confidence { get; set; } = AlignmentConfidence.Automatic;
    public LiveDocsCorpus? Corpus { get; set; }
}

public enum AlignmentConfidence
{
    Automatic,  // Machine-aligned
    Confirmed,  // User-verified
    Manual      // Manually created
}
