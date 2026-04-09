using System.Text.RegularExpressions;
using MehQ.Core.Enums;
using MehQ.Core.Models;

namespace MehQ.Core.Services;

public static partial class QaChecker
{
    /// <summary>
    /// Run all QA checks on a segment. Returns list of warnings.
    /// </summary>
    public static IReadOnlyList<QaWarning> CheckSegment(Segment segment)
    {
        var warnings = new List<QaWarning>();

        // 1. Empty target check
        if (segment.Status >= SegmentStatus.TranslatorConfirmed &&
            string.IsNullOrWhiteSpace(segment.Target))
        {
            warnings.Add(CreateWarning(segment, QaCategory.EmptyTarget, QaSeverity.Error,
                "QA1001", "Target is empty but segment is confirmed"));
        }

        // 2. Identical source and target
        if (!string.IsNullOrEmpty(segment.Target) &&
            segment.Source.Trim() == segment.Target.Trim() &&
            segment.Source.Any(char.IsLetter))
        {
            warnings.Add(CreateWarning(segment, QaCategory.IdenticalSourceTarget, QaSeverity.Warning,
                "QA1002", "Source and target are identical"));
        }

        // 3. Tag mismatch
        var sourceTags = TagPattern().Matches(segment.Source).Select(m => m.Value).ToList();
        var targetTags = TagPattern().Matches(segment.Target).Select(m => m.Value).ToList();
        CheckTagMismatch(segment, sourceTags, targetTags, warnings);

        // 4. Number mismatch
        var sourceNumbers = NumberPattern().Matches(segment.Source).Select(m => m.Value).ToHashSet();
        var targetNumbers = NumberPattern().Matches(segment.Target).Select(m => m.Value).ToHashSet();
        CheckNumberMismatch(segment, sourceNumbers, targetNumbers, warnings);

        // 5. Punctuation mismatch (terminal punctuation)
        CheckPunctuationMismatch(segment, warnings);

        // 6. Leading/trailing space mismatch
        CheckSpacingErrors(segment, warnings);

        // 7. Length check (target significantly longer/shorter than source)
        CheckLengthViolation(segment, warnings);

        return warnings;
    }

    /// <summary>
    /// Run QA on all segments in a document.
    /// </summary>
    public static IReadOnlyList<QaWarning> CheckDocument(IEnumerable<Segment> segments)
    {
        var warnings = new List<QaWarning>();
        foreach (var segment in segments)
        {
            if (string.IsNullOrEmpty(segment.Target) && segment.Status == SegmentStatus.NotStarted)
                continue; // Skip untouched segments

            warnings.AddRange(CheckSegment(segment));
        }
        return warnings;
    }

    private static void CheckTagMismatch(Segment segment, List<string> sourceTags, List<string> targetTags,
        List<QaWarning> warnings)
    {
        var missingInTarget = sourceTags.Except(targetTags).ToList();
        var extraInTarget = targetTags.Except(sourceTags).ToList();

        foreach (var tag in missingInTarget)
        {
            warnings.Add(CreateWarning(segment, QaCategory.TagMismatch, QaSeverity.Error,
                "QA2001", $"Tag {tag} missing in target"));
        }

        foreach (var tag in extraInTarget)
        {
            warnings.Add(CreateWarning(segment, QaCategory.TagMismatch, QaSeverity.Warning,
                "QA2002", $"Extra tag {tag} in target"));
        }
    }

    private static void CheckNumberMismatch(Segment segment, HashSet<string> sourceNumbers,
        HashSet<string> targetNumbers, List<QaWarning> warnings)
    {
        var missingNumbers = sourceNumbers.Except(targetNumbers).ToList();
        foreach (var num in missingNumbers)
        {
            warnings.Add(CreateWarning(segment, QaCategory.NumberMismatch, QaSeverity.Warning,
                "QA3001", $"Number '{num}' in source not found in target"));
        }
    }

    private static void CheckPunctuationMismatch(Segment segment, List<QaWarning> warnings)
    {
        if (string.IsNullOrEmpty(segment.Source) || string.IsNullOrEmpty(segment.Target))
            return;

        var sourceEnd = segment.Source.TrimEnd().LastOrDefault();
        var targetEnd = segment.Target.TrimEnd().LastOrDefault();

        // Check terminal punctuation: period, exclamation, question mark, colon
        bool sourceHasTerminal = ".!?:".Contains(sourceEnd);
        bool targetHasTerminal = ".!?:".Contains(targetEnd);

        if (sourceHasTerminal && !targetHasTerminal)
        {
            warnings.Add(CreateWarning(segment, QaCategory.PunctuationMismatch, QaSeverity.Warning,
                "QA4001", $"Source ends with '{sourceEnd}' but target does not end with terminal punctuation"));
        }
    }

    private static void CheckSpacingErrors(Segment segment, List<QaWarning> warnings)
    {
        if (string.IsNullOrEmpty(segment.Target)) return;

        if (segment.Source.Length > 0 && !segment.Source.StartsWith(' ') && segment.Target.StartsWith(' '))
        {
            warnings.Add(CreateWarning(segment, QaCategory.SpacingError, QaSeverity.Warning,
                "QA5001", "Target has unexpected leading space"));
        }

        if (segment.Source.Length > 0 && !segment.Source.EndsWith(' ') && segment.Target.EndsWith(' '))
        {
            warnings.Add(CreateWarning(segment, QaCategory.SpacingError, QaSeverity.Warning,
                "QA5002", "Target has unexpected trailing space"));
        }
    }

    private static void CheckLengthViolation(Segment segment, List<QaWarning> warnings)
    {
        if (string.IsNullOrEmpty(segment.Source) || string.IsNullOrEmpty(segment.Target))
            return;

        double ratio = (double)segment.Target.Length / segment.Source.Length;
        if (ratio > 3.0)
        {
            warnings.Add(CreateWarning(segment, QaCategory.LengthViolation, QaSeverity.Info,
                "QA6001", $"Target is {ratio:F1}x longer than source"));
        }
        else if (ratio < 0.2 && segment.Source.Length > 10)
        {
            warnings.Add(CreateWarning(segment, QaCategory.LengthViolation, QaSeverity.Info,
                "QA6002", $"Target is much shorter than source ({ratio:P0})"));
        }
    }

    private static QaWarning CreateWarning(Segment segment, QaCategory category, QaSeverity severity,
        string code, string message) => new()
    {
        SegmentId = segment.Id,
        SequenceNumber = segment.SequenceNumber,
        Category = category,
        Severity = severity,
        Code = code,
        Message = message
    };

    [GeneratedRegex(@"\{\d+\}")]
    private static partial Regex TagPattern();

    [GeneratedRegex(@"-?\d+(?:[\.,]\d+)?")]
    private static partial Regex NumberPattern();
}
