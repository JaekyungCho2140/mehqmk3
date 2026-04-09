using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using MehQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MehQ.Infrastructure.Repositories;

public class TermBaseRepository : ITermBaseRepository
{
    private readonly MehQDbContext _db;

    public TermBaseRepository(MehQDbContext db) => _db = db;

    public async Task<TermBase?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.TermBases.Include(tb => tb.Terms).FirstOrDefaultAsync(tb => tb.Id == id, ct);

    public async Task<IReadOnlyList<TermBase>> GetAllAsync(CancellationToken ct = default)
        => await _db.TermBases.ToListAsync(ct);

    public async Task<TermBase> AddAsync(TermBase termBase, CancellationToken ct = default)
    {
        _db.TermBases.Add(termBase);
        await _db.SaveChangesAsync(ct);
        return termBase;
    }

    public async Task UpdateAsync(TermBase termBase, CancellationToken ct = default)
    {
        _db.TermBases.Update(termBase);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var tb = await _db.TermBases.FindAsync([id], ct);
        if (tb != null)
        {
            _db.TermBases.Remove(tb);
            await _db.SaveChangesAsync(ct);
        }
    }

    public async Task<IReadOnlyList<Term>> SearchTermsAsync(Guid termBaseId, string query, CancellationToken ct = default)
    {
        var lowerQuery = query.ToLowerInvariant();
        return await _db.Terms
            .Where(t => t.TermBaseId == termBaseId &&
                       (t.SourceTerm.ToLower().Contains(lowerQuery) ||
                        t.TargetTerm.ToLower().Contains(lowerQuery)))
            .OrderBy(t => t.SourceTerm)
            .ToListAsync(ct);
    }
}
