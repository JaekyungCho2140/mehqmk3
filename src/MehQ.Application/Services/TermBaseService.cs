using MehQ.Core.Interfaces;
using MehQ.Core.Models;

namespace MehQ.Application.Services;

public class TermBaseService
{
    private readonly ITermBaseRepository _tbRepo;

    public TermBaseService(ITermBaseRepository tbRepo) => _tbRepo = tbRepo;

    /// <summary>
    /// Look up terms matching words in the source segment.
    /// Returns matches for term highlighting in the editor.
    /// </summary>
    public async Task<IReadOnlyList<TermMatch>> LookupTermsAsync(Guid termBaseId, string sourceText, CancellationToken ct = default)
    {
        var tb = await _tbRepo.GetByIdAsync(termBaseId, ct);
        if (tb == null) return Array.Empty<TermMatch>();

        var matches = new List<TermMatch>();
        var lowerSource = sourceText.ToLowerInvariant();

        foreach (var term in tb.Terms)
        {
            var lowerTerm = term.SourceTerm.ToLowerInvariant();
            int idx = lowerSource.IndexOf(lowerTerm, StringComparison.Ordinal);
            if (idx >= 0)
            {
                matches.Add(new TermMatch
                {
                    Term = term,
                    StartIndex = idx,
                    Length = term.SourceTerm.Length
                });
            }
        }

        return matches.OrderBy(m => m.StartIndex).ToList();
    }

    /// <summary>
    /// Check target text for forbidden term violations.
    /// Returns list of forbidden terms found in target.
    /// </summary>
    public async Task<IReadOnlyList<Term>> CheckForbiddenTermsAsync(Guid termBaseId, string targetText, CancellationToken ct = default)
    {
        var tb = await _tbRepo.GetByIdAsync(termBaseId, ct);
        if (tb == null) return Array.Empty<Term>();

        var lowerTarget = targetText.ToLowerInvariant();
        return tb.Terms
            .Where(t => t.IsForbidden && lowerTarget.Contains(t.TargetTerm.ToLowerInvariant()))
            .ToList();
    }

    /// <summary>
    /// Add a new term to the term base. Quick Add Term (memoQ: Ctrl+E).
    /// </summary>
    public async Task AddTermAsync(Guid termBaseId, string sourceTerm, string targetTerm,
        bool isForbidden = false, string? definition = null, CancellationToken ct = default)
    {
        var tb = await _tbRepo.GetByIdAsync(termBaseId, ct);
        if (tb == null) return;

        // Check for duplicate
        var existing = tb.Terms.FirstOrDefault(t =>
            t.SourceTerm.Equals(sourceTerm, StringComparison.OrdinalIgnoreCase) &&
            t.TargetTerm.Equals(targetTerm, StringComparison.OrdinalIgnoreCase));

        if (existing == null)
        {
            tb.Terms.Add(new Term
            {
                TermBaseId = termBaseId,
                SourceTerm = sourceTerm,
                TargetTerm = targetTerm,
                IsForbidden = isForbidden,
                Definition = definition
            });
            await _tbRepo.UpdateAsync(tb, ct);
        }
    }
}
