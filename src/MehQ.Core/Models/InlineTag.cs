namespace MehQ.Core.Models;

public class InlineTag
{
    public int Position { get; set; }
    public InlineTagType Type { get; set; }
    public string TagId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty; // Original markup
    public string DisplayText { get; set; } = string.Empty; // e.g., "{1}", "<b>", etc.
}

public enum InlineTagType
{
    Opening,
    Closing,
    Empty // Self-closing, e.g., <br/>
}
