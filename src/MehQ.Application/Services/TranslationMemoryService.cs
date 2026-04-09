using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using MehQ.Core.Services;

namespace MehQ.Application.Services;

public class TranslationMemoryService
{
    private readonly ITranslationMemoryRepository _tmRepo;

    public TranslationMemoryService(ITranslationMemoryRepository tmRepo)
    {
        _tmRepo = tmRepo;
    }

    /// <summary>
    /// Look up TM matches for a source segment. Returns matches with rates.
    /// </summary>
    public async Task<IReadOnlyList<TmMatch>> LookupAsync(Guid tmId, string sourceText, int minRate = 50, CancellationToken ct = default)
    {
        var entries = await _tmRepo.SearchAsync(tmId, sourceText, ct);

        return entries
            .Select(e => new TmMatch
            {
                Entry = e,
                MatchRate = FuzzyMatcher.CalculateMatchRate(sourceText, e.Source)
            })
            .Where(m => m.MatchRate >= minRate)
            .OrderByDescending(m => m.MatchRate)
            .ThenByDescending(m => m.Entry.UpdatedAt)
            .Take(10)
            .ToList();
    }

    /// <summary>
    /// Concordance search — find entries containing the query substring.
    /// </summary>
    public async Task<IReadOnlyList<TmEntry>> ConcordanceSearchAsync(Guid tmId, string query, bool searchTarget = false, CancellationToken ct = default)
    {
        var tm = await _tmRepo.GetByIdAsync(tmId, ct);
        if (tm == null) return Array.Empty<TmEntry>();

        var lowerQuery = query.ToLowerInvariant();

        return tm.Entries
            .Where(e => e.Source.ToLowerInvariant().Contains(lowerQuery) ||
                       (searchTarget && e.Target.ToLowerInvariant().Contains(lowerQuery)))
            .OrderByDescending(e => e.UpdatedAt)
            .Take(50)
            .ToList();
    }

    /// <summary>
    /// Store a confirmed segment pair in the TM (working memory behavior).
    /// </summary>
    public async Task StoreEntryAsync(Guid tmId, string source, string target, string? context = null, CancellationToken ct = default)
    {
        var tm = await _tmRepo.GetByIdAsync(tmId, ct);
        if (tm == null) return;

        // Check for existing exact match to update rather than duplicate
        var existing = tm.Entries.FirstOrDefault(e => e.Source == source);
        if (existing != null)
        {
            existing.Target = target;
            existing.Context = context;
            existing.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            tm.Entries.Add(new TmEntry
            {
                TranslationMemoryId = tmId,
                Source = source,
                Target = target,
                Context = context,
                CreatedBy = "mehQ"
            });
        }

        await _tmRepo.UpdateAsync(tm, ct);
    }
}
