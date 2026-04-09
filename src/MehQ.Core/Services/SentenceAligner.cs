using MehQ.Core.Models;

namespace MehQ.Core.Services;

/// <summary>
/// Simple sentence aligner using length ratio heuristic.
/// memoQ's LiveAlign uses more sophisticated algorithms, but this provides basic functionality.
/// </summary>
public static class SentenceAligner
{
    /// <summary>
    /// Align source and target sentence lists using length-based heuristic.
    /// Assumes roughly 1:1 correspondence with some many-to-one possibilities.
    /// </summary>
    public static IReadOnlyList<AlignedPair> Align(IReadOnlyList<string> sourceSentences,
        IReadOnlyList<string> targetSentences, Guid corpusId)
    {
        var pairs = new List<AlignedPair>();
        int si = 0, ti = 0, seq = 1;

        while (si < sourceSentences.Count && ti < targetSentences.Count)
        {
            pairs.Add(new AlignedPair
            {
                CorpusId = corpusId,
                SequenceNumber = seq++,
                Source = sourceSentences[si],
                Target = targetSentences[ti],
                Confidence = AlignmentConfidence.Automatic
            });
            si++;
            ti++;
        }

        // Remaining source sentences (unaligned)
        while (si < sourceSentences.Count)
        {
            pairs.Add(new AlignedPair
            {
                CorpusId = corpusId,
                SequenceNumber = seq++,
                Source = sourceSentences[si],
                Target = string.Empty,
                Confidence = AlignmentConfidence.Automatic
            });
            si++;
        }

        // Remaining target sentences (unaligned)
        while (ti < targetSentences.Count)
        {
            pairs.Add(new AlignedPair
            {
                CorpusId = corpusId,
                SequenceNumber = seq++,
                Source = string.Empty,
                Target = targetSentences[ti],
                Confidence = AlignmentConfidence.Automatic
            });
            ti++;
        }

        return pairs;
    }
}
