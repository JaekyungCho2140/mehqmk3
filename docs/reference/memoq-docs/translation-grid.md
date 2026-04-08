# Translation Grid: Filtering and Sorting

## Overview

Views in memoQ combine segments from multiple project documents based on user-defined filtering criteria. A view does not copy segments from the documents of the project -- it really is a view only.

## Accessing View Creation

1. Open a local project and navigate to Project home > Translations
2. Select one or more documents on the Documents tab
3. Click "Create view" on the Documents ribbon
4. Click "Advanced options" in the simplified dialog

## Core Filtering Options

### Frequency-Based Filtering

**Get Repeated Segments:**
- Enable "Minimum frequency" checkbox
- Set threshold number (e.g., 3 = segments repeating 3+ times)
- For local project: Check "Keep duplicates" to propagate changes across all occurrences
- For online project: Uncheck "Keep duplicates" to retrieve first occurrence only

### Content-Based Filtering

**Source Content List:**
Specify terms or expressions to find in source-language text. "Case sensitive" checkbox for exact matching.

**Target Content List:**
Filter segments by target-language content. Example: finding inconsistent terminology.

Both lists can be used simultaneously -- memoQ retrieves segments matching either list's criteria.

### Segment Status Filtering

#### Common Filters Tab

1. **All rows (no filtering)**: Disables status-based filtering
2. **Not confirmed in any role**: Segments lacking any confirmation
3. **Translator/Reviewer confirmed**: Targets confirmed segments
4. **Pre-translated**: Pre-translated segments without changes
5. **Match rate**: Segments within specified percentage range
6. **Error**: Segments preventing document export
7. **Change or conflict mark**: Multi-user edit indicators
8. **Repetitions/Non-repetitions**: Filter by repetition status
9. **Locked/Not locked**: Filter by lock status

#### Status Tab

**Match Rate (%):** Two numeric inputs for percentage range.

**Row Status Checkboxes:**
- Not started (empty segments)
- Edited (unconfirmed edits)
- Assembled from fragments
- Pre-translated, below 100%
- Pre-translated, unambiguous match
- Pre-translated, multiple 100% or 101%
- Machine translated
- X-translated
- Translator confirmed
- Reviewer 1 confirmed
- Reviewer 2 confirmed
- Rejected

**Locked or Not Options:**
- Both locked and unlocked rows
- Only locked rows
- Only unlocked rows

**Other Properties Checkboxes:**
- Auto-joined/split
- Error
- Unsuppressed warning
- Repetition / Not a repetition
- Track Changes match
- Commented
- Auto-propagated
- Marked by Find/Replace
- Change-tracked segment

#### Conflicts and Changes Tab

**Bilingual Update Section**
**Online Document Synchronization Section** (changes, conflicts)
**Last Changed Section** (user name, translator, modified after date)
**Inserted Match Section** (edited after insertion, translated from scratch)

#### Comment and Tags Tab

**Comment Filtering:** Find segments with comments containing specified expressions.

**Tag-Related Checkboxes:**
- Row has active language quality error
- Source/Target has memoQ {tag}
- Source/Target has inline tag (with text content filter)

**Inline Tag Attribute Syntax:**
- `tagname` - finds tags matching name
- `tagname>attributename` - tags with specific attribute
- `tagname>attributename>value` - exact attribute-value matching
- `>attributename>value` - cross-tag attribute searches
- `>>value` - finds values across all tags/attributes
- Quotation marks for values with spaces/commas
- Single quotes for exact value matching

## Segment Range Extraction

- Enable "Only segments from row" checkbox
- Input first and last segment numbers
- Range includes both boundary segments

## Sorting Options

Available sort criteria:
1. **No sorting**: Document occurrence order
2. **Alphabetical by source**: Source-language alphabetization
3. **Alphabetical by target**: Target-language alphabetization
4. **Source text length**: By character count
5. **Target text length**: By translation character count
6. **Match rate**: By pre-translation match percentage
7. **Frequency**: By repetition count
8. **Last changed**: By modification time
9. **Segment status**: By status (Not started > Pre-translated > Edited > Translator confirmed > Reviewer 1 confirmed > Reviewer 2 confirmed)

**Sort Order:** Ascending or Descending

## Static View Behavior

A view is static: memoQ checks the filtering conditions only when it creates the view. Subsequent status changes do not automatically remove segments from created views.

## Logical Operator Behavior

- Within same status group: OR logic
- Between different groups: AND logic

Example: Unlocked + (Edited OR Confirmed) + (Unsuppressed warning OR Comment)
