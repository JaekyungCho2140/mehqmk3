# Match Rates from Translation Memories in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-match-rates-from-translation-m.html (memoQ 12.2)

## Match Rate Scale (50%-102%)

memoQ scores translation memory and LiveDocs matches on a percentage scale to indicate how closely source text aligns with previous translations.

## Match Types and Percentages

### Double Context Match (102% / XLT)
Exact source match plus both surrounding-segment context AND identifier labels (ID) matching across the document and translation memory.

### Context Match (101%)
The source text is exactly the same as the match from the translation memory. In addition, the context of the source text is also the same.

### Exact Match (100%)
The source text in the segment is exactly the same as the match from the translation memory, with no context alignment.

### Nearly Exact Match (95%-99%)
Identical source text but with minor variations: numbers, tags, punctuation marks and spaces might be different.

### Fuzzy Matches (50%-94%)
Source text shows similarity with textual differences:
- **High fuzzy (85-95%)**: Approximately one word differs
- **Medium fuzzy (75-84%)**: Around two words differ
- **Low fuzzy (50%-74%)**: More than two words differ

Note: These percentages apply primarily to segments of 8-10+ words; shorter segments show less correspondence between percentage and actual differences.

## Special Indicators

### Asterisk Prefix (*100%, *101%, *102%)
Multiple identical or context matches existed; insertion doesn't guarantee the best match was selected.

### Exclamation Mark Prefix (!)
Match rate boosted due to memoQ's automatic tag/text patching adjustments.

## Rate Variations

Displayed rates may differ from expected values due to:
- **Penalties**: applied to matches from unreliable sources, users, unreviewed alignments, or unconfirmed LiveDocs corpora
- **Automatic adjustments**: where memoQ corrects numbers
- **Patching**: where memoQ modifies tags and text from term base matches

## Double Context Match Details

### Text Flow Context
memoQ identifies matches when the previous and the following segment are the same for the surrounding source segment, stored in the TM entry.

### ID-Based Context
Matches occur when an associated string ID (e.g., a resource identifier in software code) is the same in the current document as in the TM entry.

### Missing Context Rule
Missing contexts count as matches. If neither the TM entry nor the source document has a context ID, but the text flow is identical, this produces a 102% match when double-context settings are enabled.

### Structured Documents
In XML and Excel files, text-flow context operates only within structural units. Neighboring cells with different IDs aren't considered for context matching.
