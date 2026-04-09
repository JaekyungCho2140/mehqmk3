namespace MehQ.Core.Models;

public class LiveDocsCorpus
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string SourceLanguage { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
    public LiveDocsType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<AlignedPair> AlignedPairs { get; set; } = [];
}

public enum LiveDocsType
{
    BilingualDocument,  // Pre-aligned bilingual docs
    MonolingualPair,    // Source + target docs aligned via LiveAlign
    TmxImport           // Imported from TMX as reference
}
