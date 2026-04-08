# Post-Translation Analysis in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-post-translation-analysis.html (memoQ 12.2)

## Overview

Post-translation analysis (PTA) provides actual translation memory savings data after project completion, rather than estimates from traditional pre-analysis methods.

## How It Works

The system examines actual match rates displayed at each segment level. PTA uses the number next to the segment, to the left of the check mark or the X — it does not look up segments in translation memories.

### Match Rate Bands
Same as Statistics: 101%, 100%, 95-99%, 85-94%, 75-84%, 50-74%, and No match.

## Critical Requirements

- **Default State**: Match rates display as zero/N/A unless segments are populated through pre-translation or automatic lookup
- **Availability**: Exclusive to project manager edition
- **Data Source**: Requires handoff packages, delivery packages, or online projects

## Tracked Information

When translators confirm segments, memoQ records:
- User identification
- Timestamp
- Visible match rate in translation grid

## Analysis Output

- Results are disaggregated by translator
- Provides individual TM savings data per team member
- A comprehensive summary follows user tables
- Displays total project savings across all translators

## Project Type Considerations

- Local projects require at least one document delivered through a delivery package
- Segments lacking translator confirmation don't appear in calculations
