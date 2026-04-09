using MehQ.Core.Models;

namespace MehQ.Core.Interfaces;

public interface ILiveDocsRepository
{
    Task<LiveDocsCorpus?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<LiveDocsCorpus>> GetAllAsync(CancellationToken ct = default);
    Task<LiveDocsCorpus> AddAsync(LiveDocsCorpus corpus, CancellationToken ct = default);
    Task UpdateAsync(LiveDocsCorpus corpus, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<AlignedPair>> SearchAsync(Guid corpusId, string query, CancellationToken ct = default);
}
