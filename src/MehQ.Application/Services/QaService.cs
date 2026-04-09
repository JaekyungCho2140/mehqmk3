using MehQ.Core.Models;
using MehQ.Core.Services;

namespace MehQ.Application.Services;

public class QaService
{
    private readonly TermBaseService _termBaseService;

    public QaService(TermBaseService termBaseService)
    {
        _termBaseService = termBaseService;
    }

    /// <summary>
    /// Run full QA on a document including terminology checks.
    /// </summary>
    public async Task<IReadOnlyList<QaWarning>> RunQaAsync(
        IReadOnlyList<Segment> segments,
        Guid? termBaseId = null,
        CancellationToken ct = default)
    {
        var warnings = new List<QaWarning>();

        // Core QA checks (tags, numbers, punctuation, etc.)
        warnings.AddRange(QaChecker.CheckDocument(segments));

        // Terminology checks (if TB assigned)
        if (termBaseId.HasValue)
        {
            foreach (var segment in segments)
            {
                if (string.IsNullOrEmpty(segment.Target)) continue;

                var forbidden = await _termBaseService.CheckForbiddenTermsAsync(
                    termBaseId.Value, segment.Target, ct);

                foreach (var term in forbidden)
                {
                    warnings.Add(new QaWarning
                    {
                        SegmentId = segment.Id,
                        SequenceNumber = segment.SequenceNumber,
                        Category = Core.Enums.QaCategory.TerminologyViolation,
                        Severity = Core.Enums.QaSeverity.Error,
                        Code = "QA7001",
                        Message = $"Forbidden term '{term.TargetTerm}' found in target (source: '{term.SourceTerm}')"
                    });
                }
            }
        }

        return warnings.OrderBy(w => w.SequenceNumber).ThenBy(w => w.Severity).ToList();
    }
}
