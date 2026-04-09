namespace MehQ.Core.Models;

public class TermMatch
{
    public Term Term { get; set; } = null!;
    public int StartIndex { get; set; }
    public int Length { get; set; }
}
