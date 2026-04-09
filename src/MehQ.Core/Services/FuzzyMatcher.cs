namespace MehQ.Core.Services;

public static class FuzzyMatcher
{
    /// <summary>
    /// Calculate match rate (0-100) between two strings using Levenshtein distance.
    /// memoQ rates: 100=exact, 95-99=high fuzzy, 75-94=medium, 50-74=low fuzzy
    /// </summary>
    public static int CalculateMatchRate(string source, string candidate)
    {
        if (string.IsNullOrEmpty(source) && string.IsNullOrEmpty(candidate))
            return 100;
        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(candidate))
            return 0;

        // Normalize: lowercase, trim
        var s = source.Trim().ToLowerInvariant();
        var c = candidate.Trim().ToLowerInvariant();

        if (s == c) return 100;

        int distance = LevenshteinDistance(s, c);
        int maxLen = Math.Max(s.Length, c.Length);

        // Convert distance to similarity percentage
        double similarity = 1.0 - ((double)distance / maxLen);
        int rate = (int)Math.Round(similarity * 100);

        return Math.Max(0, Math.Min(100, rate));
    }

    /// <summary>
    /// Standard Levenshtein distance with optimization for early termination.
    /// </summary>
    public static int LevenshteinDistance(string s, string t)
    {
        int n = s.Length, m = t.Length;
        if (n == 0) return m;
        if (m == 0) return n;

        // Use single-row optimization
        var prev = new int[m + 1];
        var curr = new int[m + 1];

        for (int j = 0; j <= m; j++)
            prev[j] = j;

        for (int i = 1; i <= n; i++)
        {
            curr[0] = i;
            for (int j = 1; j <= m; j++)
            {
                int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                curr[j] = Math.Min(
                    Math.Min(curr[j - 1] + 1, prev[j] + 1),
                    prev[j - 1] + cost);
            }
            (prev, curr) = (curr, prev);
        }

        return prev[m];
    }
}
