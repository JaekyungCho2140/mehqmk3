namespace MehQ.Core.Models;

public class ProjectStats
{
    public int TotalDocuments { get; set; }
    public int TotalSegments { get; set; }
    public int TranslatedSegments { get; set; }
    public int EditedSegments { get; set; }
    public int EmptySegments { get; set; }
    public int CompletionPercent { get; set; }
}
