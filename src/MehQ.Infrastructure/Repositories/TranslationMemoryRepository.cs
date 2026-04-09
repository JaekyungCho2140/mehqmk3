using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using MehQ.Core.Services;
using MehQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MehQ.Infrastructure.Repositories;

public class TranslationMemoryRepository : ITranslationMemoryRepository
{
    private readonly MehQDbContext _db;

    public TranslationMemoryRepository(MehQDbContext db)
    {
        _db = db;
    }

    public async Task<TranslationMemory?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.TranslationMemories.Include(tm => tm.Entries).FirstOrDefaultAsync(tm => tm.Id == id, ct);

    public async Task<IReadOnlyList<TranslationMemory>> GetAllAsync(CancellationToken ct = default)
        => await _db.TranslationMemories.ToListAsync(ct);

    public async Task<TranslationMemory> AddAsync(TranslationMemory tm, CancellationToken ct = default)
    {
        _db.TranslationMemories.Add(tm);
        await _db.SaveChangesAsync(ct);
        return tm;
    }

    public async Task UpdateAsync(TranslationMemory tm, CancellationToken ct = default)
    {
        _db.TranslationMemories.Update(tm);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var tm = await _db.TranslationMemories.FindAsync([id], ct);
        if (tm != null)
        {
            _db.TranslationMemories.Remove(tm);
            await _db.SaveChangesAsync(ct);
        }
    }

    public async Task<IReadOnlyList<TmEntry>> SearchAsync(Guid tmId, string query, CancellationToken ct = default)
    {
        // Get all entries for the TM, then rank by fuzzy match
        var entries = await _db.TmEntries
            .Where(e => e.TranslationMemoryId == tmId)
            .ToListAsync(ct);

        return entries
            .Select(e => new { Entry = e, Rate = FuzzyMatcher.CalculateMatchRate(query, e.Source) })
            .Where(x => x.Rate >= 50) // memoQ minimum threshold
            .OrderByDescending(x => x.Rate)
            .ThenByDescending(x => x.Entry.UpdatedAt)
            .Select(x => x.Entry)
            .ToList();
    }
}
