using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using MehQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MehQ.Infrastructure.Repositories;

public class LiveDocsRepository : ILiveDocsRepository
{
    private readonly MehQDbContext _db;

    public LiveDocsRepository(MehQDbContext db) => _db = db;

    public async Task<LiveDocsCorpus?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.Set<LiveDocsCorpus>().Include(c => c.AlignedPairs)
            .FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task<IReadOnlyList<LiveDocsCorpus>> GetAllAsync(CancellationToken ct = default)
        => await _db.Set<LiveDocsCorpus>().ToListAsync(ct);

    public async Task<LiveDocsCorpus> AddAsync(LiveDocsCorpus corpus, CancellationToken ct = default)
    {
        _db.Set<LiveDocsCorpus>().Add(corpus);
        await _db.SaveChangesAsync(ct);
        return corpus;
    }

    public async Task UpdateAsync(LiveDocsCorpus corpus, CancellationToken ct = default)
    {
        _db.Set<LiveDocsCorpus>().Update(corpus);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var corpus = await _db.Set<LiveDocsCorpus>().FindAsync([id], ct);
        if (corpus != null)
        {
            _db.Set<LiveDocsCorpus>().Remove(corpus);
            await _db.SaveChangesAsync(ct);
        }
    }

    public async Task<IReadOnlyList<AlignedPair>> SearchAsync(Guid corpusId, string query, CancellationToken ct = default)
    {
        var lowerQuery = query.ToLowerInvariant();
        return await _db.Set<AlignedPair>()
            .Where(p => p.CorpusId == corpusId &&
                       (p.Source.ToLower().Contains(lowerQuery) ||
                        p.Target.ToLower().Contains(lowerQuery)))
            .OrderBy(p => p.SequenceNumber)
            .Take(50)
            .ToListAsync(ct);
    }
}
