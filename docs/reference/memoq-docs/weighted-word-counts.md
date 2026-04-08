# Weighted Word Counts in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-weighted-word-counts.html (memoQ 12.2)

## Overview

Weighted word counts quantify productivity gains when using memoQ. The system calculates segment similarity through statistical language processing to help estimate costs and timelines.

## Match Categories & Payment Percentages

| Match Type | Payment % |
|-----------|-----------|
| No match (below 75%) | 100% paid |
| Low fuzzy (50-74%) | varies |
| Higher fuzzy (75-94%) | 40% credited |
| Exact matches (100% TM) | 30% credited |
| Repetitions | 20% credited |
| Context matches (101%) | 10% credited |
| X-translated segments | 10% credited |

## Weighting Coefficients

| Match Range | Coefficient |
|------------|-------------|
| 100% and above | 0.3 |
| 95-99% | 0.5 |
| 75-94% | 0.8 |
| Below 75% | 1.0 |
| Locked segments | excluded |

## Calculation Example

- 1000 new words (no match) = 1000 weighted words
- 1000 words at 70% match = 700 weighted words
- 1000 words at 30% match = 300 weighted words

## Limitation

Weighted word count is not available for slices of a document. Requires previously generated analysis reports for online projects.
