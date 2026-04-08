# Segment Statuses in memoQ

## Advanced Filters: Segment Status Filtering

### Overview
The Advanced Filters window enables filtering of translation editor rows based on multiple conditions. memoQ will show those rows that meet the conditions.

### Access Method
1. Open a project
2. Open a document for editing
3. Click the Advanced filters icon at the top of the translation editor

### Filter Categories

#### Common Filters (Simple Status Selection)

- **All rows (no filtering)**: Displays segments without status-based filtering
- **Not confirmed in any role**: Shows segments lacking confirmation from translator, Reviewer 1, or Reviewer 2
- **Translator/Reviewer confirmed**: Displays segments confirmed by specific roles
- **Pre-translated**: Shows segments filled via pre-translation that remain unchanged
- **Match rate**: Displays segments with specified match percentages (range-based)
- **Error**: Shows segments with export-preventing errors
- **Change or conflict mark**: Displays segments modified by multiple users in online projects
- **Repetitions**: Shows segments marked as repetitions
- **Non-repetitions**: Displays non-repetitive segments
- **Locked/Not locked**: Filters by segment lock status

#### Status Tab (Comprehensive Segment Status Options)

**Match Rate (%)**: Filters by percentage ranges during original pre-translation or fill-in.

**Row Status Options**:
- Not started (empty segments)
- Edited (confirmed pending)
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

**Locked or Not**:
- Both locked and unlocked rows
- Only locked rows
- Only unlocked rows

**Other Properties**:
- Auto-joined/split segments
- Errors preventing export
- Unsuppressed warnings (non-blocking)
- Repetition status (positive/negative)
- Track Changes matches
- Commented segments
- Auto-propagated segments
- Find/Replace marked segments
- Change-tracked segments

#### Conflicts and Changes Tab

**Bilingual Update**: Detects segments modified during document updates from bilingual files.

**Online Document Synchronization**:
- Changes downloaded from server
- Conflicts with client version stored on server
- Conflicts with client version rejected by server

**Last Changed**:
- User name filtering
- Translator name filtering
- Modified after specific date/time
- Get user names function for selection

**Inserted Match**:
- Edited after match insertion
- Translated from scratch (no match inserted)

#### Tags and QA Tab

**QA Filters**:
- Active language quality errors
- memoQ uninterpreted formatting tags (source/target)
- Inline tags with specific text (source/target)

**Inline Tag Attribute Syntax**:
- `tagname`: Finds tags containing the name
- `tagname>attributename`: Finds tags with specific attributes
- `tagname>attributename>value`: Finds tags with specific attribute values
- Omission support for flexible matching
- Quote handling for spaces/commas in values
- Single quotes for exact value matching
- Escape sequences for quote characters

### Multiple Condition Logic
If you check two or more checkboxes (even on different tabs), memoQ shows segments that meet _any_ of those conditions (OR relationship).

**Exception**: The "Locked or not" setting operates in AND relation with other selections.

**AND Relations**: Clear the "Clear previous filter results" checkbox in Filtering options, then apply conditions sequentially.

---

## Change Segment Status

### Overview
This feature allows users to revert segments to earlier statuses when accidental changes occur. It's particularly useful when Undo is not possible after closing memoQ or a document.

### Access
Navigate to a project or open a document in the translation editor, then select "Change Segment Status" from the Preparation ribbon.

### Available Target Statuses
Users can only change segments back to three statuses:
- Not started
- Edited
- Pre-translated

**Note:** Segments cannot be moved to Confirmed status through this tool; confirmation requires separate commands.

### Scope Options
Choose one scope to define which documents are affected:

- **Project:** All segments across all documents in the current project
- **Active document:** All segments in the currently displayed document
- **Selected documents:** Segments in multiple pre-selected documents (requires selection in Translations view)
- **From cursor:** Segments below the current position in the active document
- **Open documents:** All segments in every document currently open in editor tabs
- **Selection:** Only highlighted segments in the active document
- **Work on views:** Applies changes to project views (when available)

### Filtering by Current Status
Rather than changing all segments, users can target specific statuses:

- Translator confirmed
- Reviewer 1 confirmed
- Reviewer 2 confirmed
- Edited
- Pre-translated

Alternatively, select "All rows in scope" to affect every segment without filtering.

### Workflow Rules

**Pre-translation interaction:** Pre-translation won't touch Edited segments. Changing Edited segments back to Not started allows subsequent pre-translation processing.

**Accidental confirmation recovery:** For segments confirmed after pre-translation, first revert to Pre-translated status. The system only changes segments that had a match from pre-translation. Remaining confirmed segments should then be changed to Edited status.

**Pre-translated constraints:** memoQ validates using percentage values - segments must have a match percentage greater than 0% to return to Pre-translated status.
