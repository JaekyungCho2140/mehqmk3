using MehQ.Core.Models;

namespace MehQ.Core.Interfaces;

public interface ITranslationMemoryRepository
{
    Task<TranslationMemory?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<TranslationMemory>> GetAllAsync(CancellationToken ct = default);
    Task<TranslationMemory> AddAsync(TranslationMemory tm, CancellationToken ct = default);
    Task UpdateAsync(TranslationMemory tm, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<TmEntry>> SearchAsync(Guid tmId, string query, CancellationToken ct = default);
}
