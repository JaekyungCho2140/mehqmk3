using MehQ.Core.Interfaces;
using MehQ.Core.Models;
using MehQ.Core.Services;

namespace MehQ.Application.Services;

public class LiveDocsService
{
    private readonly ILiveDocsRepository _liveDocsRepo;

    public LiveDocsService(ILiveDocsRepository liveDocsRepo) => _liveDocsRepo = liveDocsRepo;

    public async Task<LiveDocsCorpus> CreateCorpusAsync(string name, string sourceLanguage,
        string targetLanguage, LiveDocsType type, CancellationToken ct = default)
    {
        var corpus = new LiveDocsCorpus
        {
            Name = name,
            SourceLanguage = sourceLanguage,
            TargetLanguage = targetLanguage,
            Type = type
        };
        return await _liveDocsRepo.AddAsync(corpus, ct);
    }

    /// <summary>
    /// Align source and target documents to create a bilingual corpus (LiveAlign).
    /// </summary>
    public async Task<LiveDocsCorpus> AlignDocumentsAsync(string name, string sourceLanguage,
        string targetLanguage, IReadOnlyList<string> sourceSentences,
        IReadOnlyList<string> targetSentences, CancellationToken ct = default)
    {
        var corpus = new LiveDocsCorpus
        {
            Name = name,
            SourceLanguage = sourceLanguage,
            TargetLanguage = targetLanguage,
            Type = LiveDocsType.MonolingualPair
        };

        var pairs = SentenceAligner.Align(sourceSentences, targetSentences, corpus.Id);
        corpus.AlignedPairs = pairs.ToList();

        return await _liveDocsRepo.AddAsync(corpus, ct);
    }

    /// <summary>
    /// Search across all corpora for concordance-like results.
    /// </summary>
    public async Task<IReadOnlyList<AlignedPair>> SearchAsync(Guid corpusId, string query, CancellationToken ct = default)
        => await _liveDocsRepo.SearchAsync(corpusId, query, ct);

    /// <summary>
    /// Lookup matches from LiveDocs for a source segment (ActiveTM behavior).
    /// Returns aligned pairs where source matches, ranked by fuzzy match rate.
    /// </summary>
    public async Task<IReadOnlyList<LiveDocsMatch>> LookupAsync(Guid corpusId, string sourceText,
        int minRate = 50, CancellationToken ct = default)
    {
        var corpus = await _liveDocsRepo.GetByIdAsync(corpusId, ct);
        if (corpus == null) return Array.Empty<LiveDocsMatch>();

        return corpus.AlignedPairs
            .Where(p => !string.IsNullOrEmpty(p.Target))
            .Select(p => new LiveDocsMatch
            {
                Pair = p,
                MatchRate = FuzzyMatcher.CalculateMatchRate(sourceText, p.Source)
            })
            .Where(m => m.MatchRate >= minRate)
            .OrderByDescending(m => m.MatchRate)
            .Take(10)
            .ToList();
    }
}
