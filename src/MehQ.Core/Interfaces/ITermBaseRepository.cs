using MehQ.Core.Models;

namespace MehQ.Core.Interfaces;

public interface ITermBaseRepository
{
    Task<TermBase?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<TermBase>> GetAllAsync(CancellationToken ct = default);
    Task<TermBase> AddAsync(TermBase termBase, CancellationToken ct = default);
    Task UpdateAsync(TermBase termBase, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Term>> SearchTermsAsync(Guid termBaseId, string query, CancellationToken ct = default);
}
