# Translation Results Pane - Complete Documentation

## Overview
The Translation results pane displays suggestions from multiple sources while translating in memoQ. It pulls from translation memories, LiveDocs corpora, term bases, fragment matches, and auto-translation rules.

## Three Main Parts

### Part 1: Results List (Top)

**Layout:**
- Left column: source-language entry
- Middle column: identifier number
- Right column: target-language equivalent

**Navigation:**
- Ctrl+Up/Ctrl+Down to move highlight through results
- NumLock must be OFF for Page Up, Page Down, Home, End, Up, Down shortcuts

#### Result Types by Color

**Red: Translation Memories & LiveDocs**
- Three icon types:
  - Bilingual document in LiveDocs corpus
  - Alignment pair in LiveDocs corpus
  - Translation memory (TM) entry
- Editable via right-click > View/edit
- Shows match rate percentage; patched matches marked with "!" (e.g., !92%)

**Match Rate Categories:**

1. **Context Match (101-102%)**
   - Simple context: 101%
   - Double-context: 102%
   - Previous/next segments identical; or context identifier matches in structured docs

2. **Exact Match (100%)**
   - Source segment identical but different context

3. **TC (Track Changes) Match**
   - Special exact/context match for documents with tracked changes
   - Looks up unedited text versions

4. **High Fuzzy Match (95-99%)**
   - Differences in numbers, punctuation, tags, spaces only

5. **Medium Fuzzy Match 1 (85-94%)**
   - Average 10-word segments differ by approximately one word

6. **Medium Fuzzy Match 2 (75-84%)**
   - Average 10-word segments differ by approximately two words

7. **Low Fuzzy Match (50-74%)**
   - Generally too different; useful only for segments under 6 words

**Ranking Order (Same Match Rate):**
1. Stored match rate (XLIFF:doc files only)
2. Master translation memory results
3. LiveDocs corpora results
4. Working translation memory results
5. Reference translation memories
- Within categories: newest (latest Modified date) appears first

**Blue: Term Base Entries**
- Three icon types:
  - Regular term base
  - Accepted term extraction session entry
  - External terminology service

**Display Details:**
- Selected entries show formatted layout below list
- Only project-language terms displayed
- Source term on top, followed by target term(s)
- Only selected term expands; others collapsed

**Expandable Information:**
- Click triangle icon (right side of term) to expand/collapse details

**Editing & Updates:**
- Click "Edit entry" icon to modify term base entries
- "Update from active segment" adds current segment as example
- Ctrl+K + segment selection to add concordance hits as examples
- Copy metadata: Ctrl+C or right-click > Copy selection/Copy term pair info/Copy entry info

**Qterm Term Base Features:**
- Add/edit entries (with proper permissions)
- Start discussions via "Discussion" icon
- View related discussions below terms
- Cannot participate if discussions disabled server-wide, in Qterm, or user group excluded

**Filtering Multiple Hits:**
- Default: memoQ hides some hits for relevance
- Longer matches hide shorter ones
- Same expression ranked by term base priority and project alignment
- Click eye icon to show all results (Ctrl+Shift+D)

**Black: Forbidden Terms**
- Show how NOT to translate phrases
- Cannot insert into translation
- Display as QA warning if used
- Source from term bases

**Purple: Fragment-Assembled Matches**
- memoQ assembles translation from smaller parts in TMs/term bases
- Disabled/enabled via Options > Advanced lookup settings > Fragment assembly settings tab

**Light Orange: Automated Concordance (LSC)**
- Retrieves longest substring expressions
- Double-click without translation opens Concordance window
- Enabled/disabled via Options > Advanced lookup settings

**Deep Orange: Machine Translation**
- Requires MT plugin setup and enabled Translation results setting
- Insertable like TM matches
- Configure via Edit machine translation settings window

**Yellow: MT Concordance**
- Machine-translated phrases you selected
- Insert like term base matches (doesn't overwrite existing content)

**Gray: Non-Translatable Items**
- Must not be translated
- From project non-translatable settings
- Insert exact same word/expression to target cell

**Green: Auto-Translated Items**
- From auto-translation rules
- Handle dates, measures, currency conversion, etc.
- Configure via project settings

### Part 2: Compare Boxes (Middle)

**Displays when TM/LiveDocs match selected:**
- Current source segment
- Source text from selected suggestion
- Target text from selected suggestion

**Two View Options:**

**Track Changes View:**
- Differences appear as tracked changes
- Shows insertions/deletions
- Highlights second box only

**Traditional Compare View:**
- Black: identical parts
- Red: differences between boxes
- Blue: missing words from suggestion

**Switching Views:**
- Double-click eye icon above list > Translation results settings > Compare boxes tab
- OR Options > Miscellaneous > Lookup results tab > Compare boxes

**Customization:**
- Colors: Options > Appearance > Compare boxes tab
- Fonts/colors: Options > Appearance > Translation grid tab

### Part 3: Meta-Information & Indicators (Bottom)

**TM Entry Fields:**
- Subject (Sub)
- Domain (Dom)
- Project identifier (Pro)
- Client (Cli)
- TM/LiveDocs corpus name
- Username (creator/last modifier)
- Creation/modification date and time
- Match rate
- User role (translator/reviewer 1/reviewer 2 confirmation status)

**Indicator Lamps (Two Sets):**

**Left Lamps (Two Icons):**
- Automatic alignment result indicator
- Source text edited and re-sent to TM indicator

**Right Lamps (Six Icons, 95-101% matches only):**
- Space character differences
- Punctuation differences
- Uppercase/lowercase differences
- Bold/italics/underline formatting differences
- Tag differences
- Numbers and entity differences

**Lamp States:**
- Color-lit: manual fixing required
- Gray-lit: memoQ auto-fixed the difference

**Terms Display:**
- Same meta-information except Aligned label and match rate

## Advanced Features

### Fragment Assembly

**Purpose:** Assembles translation from smaller parts when no TM match exists

**Example Scenario:**
- Previous TM entries: "Hello there" > target translation + term base entry "world" > target
- New segment: "Hello world"
- Result: assembled translation from fragments

**Insertion Methods:**
- Ctrl+3 (if third item)
- Ctrl+arrow keys + Ctrl+Space

**Mechanism:**
- Searches longest possible fragment from beginning
- Moves word-by-word through segment
- Uses exact TM matches only (no fuzzy for fragments)
- No prefix matching in term bases
- Covers entire source segment
- Unfound words inserted in source language

**Choosing Multiple Term Base Hits:**

**Ranking Enabled:** Order term base hits primarily by rank and metadata (Translation results settings)

**Scoring Factors:**
1. Longer hit always stronger
2. Term base priority (if different TBs)
3. Project detail matches (if same TB):
   - Project name (most important)
   - Client name
   - Subject
   - Domain (least important)

### MatchPatch

**Function:** Combines TM matches with term base hits for improved suggestions

**Example:**
- TM match: "The next stop is Tower Bridge"
- Segment text: "The next stop is Highgate"
- Term base: contains both "Tower Bridge" and "Highgate" translations
- Result: "The next stop is Highgate" with proper target translation

**Enabling:**
- Options > Miscellaneous > Lookup results tab > "Patch fuzzy TM matches" checkbox

**Patched Match Indicators:**
- Exclamation mark prefix (!93%)
- Two match rates shown: original > improved (e.g., 73% > 93%)
- Light blue highlighting in grid (different from normal pre-translated)

**Formatting:**
- Uses source cell formatting (bold, italic, etc.) applied to target

**Limitations:**
- Works on 1-2 differences typically
- Requires high match scores
- Ignores words with 3 or fewer letters
- Does NOT patch numbers or tags
- Does NOT work during pre-translation
- Patched matches capped at 94% (penalty applied)
- MT patching limited to one service, one lookup, first result only

### MatchPatch with MT
1. Edit machine translation settings window
2. Configure MT service if needed
3. Settings tab > MatchPatch dropdown > select service
4. OK

Usage: Falls back to MT when term base/TM cannot patch

## Filtering & Display

**Hidden Suggestions Indicator:**
- Closed eye icon = some suggestions hidden
- Open eye icon = all suggestions visible
- Ctrl+Shift+D toggles

**Configuration:**
- Translation results settings window controls which suggestions hidden
- Controls filtering by resource type

## Keyboard Shortcuts Summary

- Ctrl+Up/Down: navigate results list
- Ctrl+Shift+D: show all/hide suggestions
- Ctrl+K: add concordance hit as example
- Ctrl+C: copy metadata
- Ctrl+Space: insert suggestion
- Ctrl+1-9: insert numbered suggestions (first 9 hits)
- Ctrl+Down: navigate to purple fragment matches

## Settings Access

**Translation Results Settings:**
- Double-click eye icon above results list
- Controls filtering, sorting, display options
- Compare boxes view selection
- Term base hit ranking configuration

**Machine Translation Settings:**
- Edit machine translation settings window
- MatchPatch configuration
- Plugin setup and configuration

**Advanced Lookup Settings:**
- Options > Advanced lookup settings
- Fragment assembly settings tab
- Automated concordance on/off
