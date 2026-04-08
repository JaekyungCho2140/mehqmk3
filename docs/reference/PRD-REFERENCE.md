# mehQ PRD Reference -- memoQ Documentation Mapping

## How to Use This Document

Each epic links to specific memoQ documentation files and screenshots. **When implementing a feature, read the linked docs and examine the linked images BEFORE writing code.** This document extracts concrete UI/UX requirements from the scraped memoQ 12.2 documentation.

- Doc paths are relative to `docs/reference/memoq-docs/`
- Image paths are relative to `docs/reference/memoq-images/`
- Epics map to Jira issues MEHQ-11 through MEHQ-20

---

## E1: Project Infrastructure (MEHQ-11) -- COMPLETED

- **Docs:** None needed (solution scaffolding, CI/CD, installer skeleton)
- **Status:** Done

---

## E2: Translation Editor (MEHQ-12)

### Documentation

| File | Key Sections |
|------|-------------|
| `translation-editor.md` | Full editor layout (Grid + View Pane + Results Pane), status bar fields, insertion methods, layout management |
| `translation-grid.md` | Grid filtering (Common/Status/Conflicts/Tags tabs), sorting options (9 criteria), segment range extraction |
| `keyboard-shortcuts.md` | Complete shortcut reference for editor, formatting, concordance, find/replace |
| `segment-statuses.md` | All status types, advanced filters, Change Segment Status tool, workflow rules |
| `view-pane.md` | Three modes (Preview, Review/QA, Active Comments), detaching/docking behavior |
| `views.md` | Static views, persistence, use scenarios (consolidation, splitting, review) |
| `tags.md` | Uninterpreted formatting tags ({1}, {2}), inline tags (open/close/empty), special tags |
| `translation-results.md` | Results list color coding, compare boxes, meta-information, fragment assembly, MatchPatch |
| `translation-results-settings.md` | TM/LiveDocs filtering, MatchPatch config, TB suggestion ordering, delay settings |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `editor/translation-editor.png` | **PRIMARY REF** -- Full desktop editor with all 3 panels (Grid left, Results right, View bottom) |
| `editor/translation-editor-segment.png` | Single segment row close-up showing source/target cells |
| `editor/translation-editor-grid.png` | Translation grid with source/target columns |
| `editor/translation-editor-view-pane.png` | Editor with view pane open at bottom |
| `editor/translation-editor-status-bar.png` | Status bar at bottom with progress indicators |
| `editor/translation-editor-redock.png` | Panel redocking behavior with docking icons |
| `editor/translation-editor-sort-dropdown.png` | Sort options dropdown menu |
| `editor/translation-editor-tracked-source.png` | Tracked changes display in source text |
| `editor/translation-results.png` | Translation results pane showing TM/TB matches |
| `editor/translation-results-settings.png` | Translation results settings dialog |
| `editor/view-pane-modes.png` | View pane mode selector (Preview / Review / Comments) |
| `editor/mqw-tr-editor-row.png` | Single row structure in editor |
| `editor/mqw-tr-editor-tags.png` | Tags displayed in translation cells |
| `editor/mqw-tr-editor-toolbar.png` | Editor toolbar buttons |
| `editor/mqw-tr-editor-joined.png` | Joined segments display |
| `editor/mqw-tr-editor-warning.png` | Warning indicator in editor row |
| `editor/mqw-tr-editor-error.png` | Error display in editor |
| `editor/mqw-tr-results-pane.png` | Results pane layout (web variant for reference) |
| `editor/mqw-tr-results-compareboxes.png` | Compare boxes showing diff between suggestion and source |
| `editor/mqw-tr-view-pane-comments.png` | View pane in Active Comments mode |
| `editor/mqw-tr-view-pane-history.png` | View pane showing segment history |
| `editor/mqw-tr-view-pane-qa-lqa.png` | View pane showing QA/LQA warnings |
| `editor/mqw-tr-view-pane-trans.png` | View pane showing translation details |
| `editor/mqw-te-advanced-filters.png` | Advanced filtering options dialog |
| `editor/inline-tags.png` | Inline tags visual example |
| `editor/find-in-preview.png` | Find-in-preview functionality |
| `editor/mqw-tr-status-confirmed.png` | Confirmed status icon |
| `editor/mqw-tr-status-edited.png` | Edited status icon |
| `editor/mqw-tr-status-notstarted.png` | Not Started status icon |
| `editor/mqw-tr-status-pretranslated.png` | Pre-translated status icon |
| `editor/mqw-tr-status-rejected.png` | Rejected status icon |
| `editor/mqw-tr-spelling.png` | Spelling check display in editor |
| `editor/mqw-edit-inline-tag.png` | Inline tag editing interface |

### Key UI/UX Requirements

#### Editor Layout (3-Panel Design)
- **Grid** (center/left): Source column on left, target column on right, row numbers
- **Translation Results Pane** (right side): Suggestions from TM, TB, fragments, concordance
- **View Pane** (bottom): HTML preview of translated document, or QA warnings, or comments
- **Status Bar** (very bottom): Progress indicators (see fields below)
- Two preset layouts: **Default** (results right) and **Results on Top** (Trados-style); toggle with **F11**
- Layout reset via View ribbon > Layout dropdown > "Default"
- Panels are detachable/dockable (drag title bar to detach, dock icons appear on re-attach)

#### Status Bar Fields (left to right)
| Field | Description |
|-------|------------|
| Server Icon | Connection status (N/A for mehQ local-only) |
| Proj (lang) | Project completion % (right-click to toggle words/segments/characters) |
| Doc | Current document completion % |
| TR | Translator-confirmed segment count |
| R1 / R2 | Reviewer 1 / Reviewer 2 confirmed counts |
| Ed | Edited but unconfirmed count |
| Rej | Rejected segment count |
| Empty | Untouched segment count |
| Pre | Pre-translated, unedited count |
| Frag | Fragment-assembled pre-translations |
| MT | Machine translation pre-translations (N/A for mehQ) |
| QA errors | QA error count |
| Ins | Insert/Overwrite mode indicator |
| Pos | Cursor position in current segment |
| Length | Source and target character counts |

#### Segment Statuses
| Status | Description |
|--------|------------|
| Not Started | Empty, untouched segment |
| Edited | User typed in target but not confirmed |
| Pre-translated | Filled by pre-translation, unedited |
| Assembled from fragments | Built from fragment assembly |
| Machine translated | Filled by MT (out of scope for mehQ) |
| X-translated | From version update matching |
| Translator confirmed | Confirmed by translator |
| Reviewer 1 confirmed | Confirmed by Reviewer 1 |
| Reviewer 2 confirmed | Confirmed by Reviewer 2 |
| Rejected | Rejected by reviewer |

#### Segment Status Sort Order
Not started > Pre-translated > Edited > Translator confirmed > R1 confirmed > R2 confirmed

#### Core Keyboard Shortcuts (Translation Editor)
| Shortcut | Action |
|----------|--------|
| **Ctrl+Enter** | Confirm segment (save to TM, advance to next) |
| **Shift+Enter** | Reject segment |
| **Ctrl+Space** | Insert first/current suggestion from results |
| **Ctrl+1 through Ctrl+9** | Insert numbered suggestion |
| **Ctrl+Down / Ctrl+Up** | Navigate through results list |
| **Ctrl+Shift+S** | Copy source to target |
| **Ctrl+Shift+T** | Copy selection to target |
| **F9** | Copy next tag sequence |
| **Ctrl+F** | Find |
| **Ctrl+H** | Replace |
| **Ctrl+F, Ctrl+F** | Advanced find and replace |
| **F11** | Switch layout |
| **Ctrl+F4** | Close active document |
| **Ctrl+J** | Join segments |
| **Ctrl+T** | Split segment |
| **Ctrl+M** | Add comment |
| **Ctrl+K** | Open concordance |
| **F2** | Edit source |
| **F3** | Scan segment (re-lookup) |
| **F7** | Spelling check |
| **Tab** | Switch source/target sides |
| **Ctrl+G** | Go to next |
| **Ctrl+Shift+G** | Go to next settings |
| **Ctrl+Shift+L** | Lock/Unlock segments |
| **Ctrl+L** | Lock/Unlock several segments at once |
| **Ctrl+Shift+F** | Filter for selected text / Clear text filter |
| **Ctrl+Shift+A** | Select all segments |
| **Ctrl+Shift+D** | Toggle display all hits / filtered hits |
| **Ctrl+Alt+Enter** | Edit resource entry in results pane |
| **Ctrl+Shift+U** | Confirm and update rows |
| **Ctrl+Shift+R** | Confirm without update |
| **Ctrl+W** | Edit warnings |

#### Formatting Shortcuts
| Shortcut | Action |
|----------|--------|
| **Ctrl+B** | Bold |
| **Ctrl+I** | Italic |
| **Ctrl+U** | Underline |
| **Shift+F3** | Toggle case |
| **Alt+F8** | Insert all tags |
| **Ctrl+F8** | Remove all tags |
| **Alt+F6** | Arrange tags |
| **Ctrl+F9** | Edit inline tag |

#### Translation Results Pane -- Color Coding
| Color | Source Type | Details |
|-------|-----------|---------|
| **Red** | TM & LiveDocs matches | Shows match rate %; patched matches prefixed with "!" |
| **Blue** | Term base entries | Source term on top, target term(s) below |
| **Black** | Forbidden terms | Cannot be inserted; triggers QA warning if used |
| **Purple** | Fragment-assembled matches | Assembled from smaller TM/TB parts |
| **Light Orange** | Automated concordance (LSC) | Longest substring expressions |
| **Deep Orange** | Machine translation | N/A for mehQ |
| **Yellow** | MT concordance | N/A for mehQ |
| **Gray** | Non-translatable items | Must remain unchanged |
| **Green** | Auto-translated items | From auto-translation rules |

#### Match Rate Categories
| Rate | Name | Description |
|------|------|-------------|
| **102%** | Double context match | Both text flow context AND ID context match |
| **101%** | Context match (ContexTM) | Source + previous/next segments identical |
| **100%** | Exact match | Source identical, context different or unknown |
| **95-99%** | High fuzzy | Differences only in numbers, punctuation, tags, spaces |
| **85-94%** | Medium fuzzy 1 | ~1 word different in 10-word segment |
| **75-84%** | Medium fuzzy 2 | ~2 words different in 10-word segment |
| **50-74%** | Low fuzzy | Generally too different; useful only for short segments |

#### Match Ranking (Same Match Rate)
1. Stored match rate (XLIFF:doc only)
2. Master TM results
3. LiveDocs corpora results
4. Working TM results
5. Reference TMs
6. Within categories: newest (latest Modified date) first

#### Compare Boxes (Middle Section of Results Pane)
Two view options:
- **Track Changes View**: Insertions/deletions shown as tracked changes
- **Traditional Compare View**: Black = identical, Red = differences, Blue = missing words

#### View Pane Modes
1. **Translation Preview**: Formatted document preview; current segment has **red border**; click to navigate
2. **Review (QA/LQA)**: QA warnings for current segment; checkboxes to ignore; refresh icon
3. **Active Comments**: Comment viewing/editing with pencil (reply) and trash (delete) icons

#### Insertion Methods for Suggestions
1. **Predictive typing**: Auto-suggests TB and rule matches while typing
2. **Placeholder menu**: Press and release **Ctrl** while typing for numbers, tags, terms
3. **Full-segment insertion**: **Ctrl+Space** (first), **Ctrl+number** (specific), **Ctrl+Down/Up** + **Ctrl+Enter** (navigate+insert), or double-click

#### Grid Sorting Options (9 criteria)
1. No sorting (document order)
2. Alphabetical by source
3. Alphabetical by target
4. Source text length
5. Target text length
6. Match rate
7. Frequency (repetition count)
8. Last changed
9. Segment status

#### Tag Types
- **Uninterpreted formatting tags**: Displayed as {1}, {2}, {3}; inserted with F9; sequential order enforced
- **Inline tags**: Three types -- opening, closing, empty; **default color is gray**; freely rearrangeable
- **Special inline tags**: **Darker red background** (configurable in Options > Appearance)
- QA indicators: Lightning bolt (warning) and exclamation mark (error) for missing tags

### Implementation Fidelity: 90%

Excellent coverage. The documentation provides complete layout specs, all keyboard shortcuts, color codes for results, status definitions, and grid behavior. Minor gaps: exact pixel dimensions not documented (must derive from screenshots), ribbon UI details require additional scraping.

---

## E3: Translation Memory (MEHQ-13)

### Documentation

| File | Key Sections |
|------|-------------|
| `translation-memories.md` | TM concepts, match rates (50-102%), context matching, multiple translations, roles, working vs master TM |
| `new-translation-memory.md` | TM creation wizard: name, languages, TM+ options, context config, reversible TM, custom fields |
| `tm-settings.md` | Thresholds, penalties, Adjust Fuzzy Hits feature, management capabilities |
| `concordance.md` | Concordance window: 3-column KWIC view, search options, wildcards, Guess Translation, insertion |
| `translation-results.md` | Match display in results pane, fragment assembly mechanism, MatchPatch feature |
| `pre-translate.md` | Pre-translation thresholds, fragment assembly options, confirm/lock tab |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `tm/new-translation-memory-choose.png` | New TM creation wizard dialog |
| `tm/select-tm-settings.png` | TM settings selector dialog |
| `tm/ribbon_tm.png` | TM ribbon tab with all TM actions |
| `tm/ribbon_tmeditor.png` | TM editor ribbon with edit/merge/delete actions |
| `tm/mt-concordance.png` | Concordance search results display |
| `dashboard/project-home-translation-memories.png` | TM list in Project Home |
| `dashboard/project-home-settings-tm.png` | TM settings in Project Home settings pane |
| `dialogs/concordance-3column.png` | **PRIMARY REF** -- Concordance 3-column KWIC layout (desktop) |
| `dialogs/dialog_concordance.png` | Concordance dialog (web variant) |

### Key UI/UX Requirements

#### TM Creation Dialog Fields
- **Name**: Text field (unique name)
- **Source Language**: Dropdown
- **Target Language**: Dropdown (inherited from project)
- **Path**: Auto-populated (read-only, storage folder)
- **TM+ checkbox**: Default ON (new format); uncheck for classic TM
- **Store Context radio**: Recommended default; enables 101% matches
- **Allow Multiple Translations radio**: Not recommended as default
- **No Context radio**: Not recommended
- **Reversible checkbox**: Default ON (lookup in both directions); immutable after creation
- **Store document names checkbox**: Default ON
- **Store full path checkbox**: Sub-option of document names
- **Custom Fields tab**: Up to 20 fields; types: text, picklist single, picklist multiple; export/import scheme to XML

#### TM Properties (Editable)
Subject, domain, path, description, client, author, read-only status, entry count visibility, context usage, multiple translation allowance

#### TM Properties (Fixed After Creation)
Context type, reversible flag, custom field schema

#### Match Rate Definitions (Repeated from E2 for completeness)
- 102% = Double context (text flow + ID)
- 101% = Simple context match
- 100% = Exact match (no context)
- 95-99% = High fuzzy (numbers, punctuation, tags, spaces differ)
- 85-94% = Medium fuzzy (~1 word diff per 10 words)
- 75-84% = Medium fuzzy 2 (~2 words diff)
- 50-74% = Low fuzzy
- Asterisk notation: *100%, *101%, *102% = uncertain among multiple matches

#### Penalties
- Applied to: unreliable TMs, untrustworthy translators, unreviewed alignments, unreviewed LiveDocs
- Calculation: penalty percentage subtracted from match rate

#### Concordance Window
- **Access**: Ctrl+K (after selecting text) or Translation ribbon button
- **Layout**: 3-column KWIC (Keyword In Context) format
- **Search options**:
  - Put selected text in quotes (exact expression)
  - Add wildcards to selected text
  - Case sensitive
  - Find different numbers too
  - Limit spin box (max results)
- **Wildcards**: `*` (optional ending), `+` (required ending), prefix variants
- **Insertion**: "Insert" (full), "Insert selected" (partial)
- **Source+Target view**: Parallel text with metadata
- **Guess Translation**: Color-coded confidence (darker green = higher confidence)
- **Filter boxes**: Filter source, Filter target

#### TM Settings
- Match thresholds (configurable minimums)
- Penalties (percentage deductions per TM)
- Adjust Fuzzy Hits: auto-adjusts numbers, punctuation, case, inline tags in <100% matches (default ON)

#### Fragment Assembly Mechanism
1. Search longest fragment from segment beginning
2. Move word-by-word through segment
3. Use exact TM matches only (no fuzzy)
4. No prefix matching in term bases
5. Must cover entire source segment
6. Unfound words inserted in source language

#### MatchPatch
- Combines TM fuzzy match + TB hit to improve match rate
- Indicator: exclamation mark prefix (!93%)
- Shows two rates: original > improved (e.g., 73% > 93%)
- Light blue highlighting in grid (different from normal pre-translated)
- Capped at 94% (penalty applied)
- Ignores words <= 3 letters
- Does NOT patch numbers or tags

#### TM Editor Shortcuts
| Shortcut | Action |
|----------|--------|
| Ctrl+N | New TM entry |
| Ctrl+D | Delete selected entries |
| Ctrl+Shift+F | Filter for selected text |
| Ctrl+M | Flag TM entry |
| Ctrl+G | Jump to next flagged |
| Ctrl+Enter | Merge current |
| Ctrl+S | Save changes |

### Implementation Fidelity: 85%

Strong coverage of TM concepts, match rates, and concordance. Missing: TM editor UI details (not scraped), exact fuzzy matching algorithm parameters, TMX import/export dialogs.

---

## E4: Term Base (MEHQ-14)

### Documentation

| File | Key Sections |
|------|-------------|
| `term-bases.md` | TB concepts, types (local/online/synchronized), multilingual structure, moderated TBs |
| `term-base-entries.md` | 3-level hierarchy (Entry > Language > Term), all properties at each level, matching options |
| `translation-results.md` | TB display in results pane (blue), forbidden terms (black), filtering, ranking |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `tb/term-base-entry-new.png` | **PRIMARY REF** -- New term base entry dialog (desktop) |
| `tb/term-base-entry-qterm.png` | QTerm entry view |
| `tb/term-base-export-settings.png` | TB export settings dialog |
| `tb/ribbon_tb.png` | Term base ribbon tab |
| `tb/ribbon_tbeditor.png` | Term base editor ribbon |
| `tb/mqw-new-term-base-window.png` | New TB creation window (web) |
| `tb/mqw_edit_tb_entry.png` | Edit TB entry (web) |
| `dashboard/project-home-term-bases.png` | TB list in Project Home |
| `editor/mqw-tr-editor-tb-format.png` | TB formatting in editor |
| `editor/mqw-tr-results-tb-entry.png` | TB entry in results pane |
| `editor/mqw-tr-results-qterm-hit.png` | QTerm hit in results pane |

### Key UI/UX Requirements

#### Term Base Entry -- 3-Level Hierarchy

**Level 1: Entry (Concept)**
| Property | Type | Notes |
|----------|------|-------|
| ID | Auto-generated | Non-editable |
| Note | Text | Comments/references |
| Project | Text | Auto-populated from project |
| Domain | Text | Broader category; auto-populated |
| Client | Text | Auto-populated from project |
| Subject | Text | Specific sub-topic; auto-populated |
| Created by / Modified by | Username | System-managed |
| Created at / Modified at | Timestamp | System-managed |
| Image | Binary | Optional visual illustration |

**Level 2: Language**
| Property | Type | Notes |
|----------|------|-------|
| Definition | Text | One description per language |

**Level 3: Term**
| Property | Type | Notes |
|----------|------|-------|
| Term text | Text | The actual word/expression |
| Matching | Enum | Fuzzy / 50% prefix (default) / Exact / Custom |
| Case sensitivity | Enum | Yes / Permissive / No |
| Forbidden | Boolean | If true: source forbidden terms hidden from results; target forbidden shown in black |
| Example | Text | Sample phrase demonstrating usage |
| Part of speech | Enum | Noun, adjective, adverb, verb, etc. |
| Gender | Enum | Masculine, feminine, neutral |
| Number | Enum | Singular, plural |

#### Matching Options Detail
- **Fuzzy**: Matches word forms and variations (useful for compound words like German)
- **50% prefix** (default): "project" matches "projects" but NOT "project-specific"
- **Exact**: Only precise form matches
- **Custom**: Wildcards (e.g., "Wassert|urm" matches "Wasserturm" and "Wasserturme")
- Constraint: matches only at start of expressions (prefix matching)

#### Case Sensitivity Detail
- **Yes**: Exact capitalization required (proper names, abbreviations like TBD, XML)
- **Permissive**: Uppercase must match exactly; lowercase is flexible
- **No**: Case-insensitive matching

#### Forbidden Terms Behavior
- Source forbidden terms: NOT shown in translation results
- Target forbidden terms: Shown in **black text** without highlighting
- QA warning triggered if forbidden term used in translation

#### TB in Results Pane
- Color: **Blue**
- Triangle icon on right to expand/collapse entry details
- "Edit entry" icon to modify
- "Update from active segment" adds current segment as example
- Copy metadata: Ctrl+C or right-click menu

#### TB Suggestion Ordering (Configurable)
- Order of appearance in text
- Alphabetical arrangement
- Rank-based ordering: TB ranking + descriptive details (client, domain, subject)

#### TB Editor Shortcuts
| Shortcut | Action |
|----------|--------|
| Ctrl+A | Add term |
| Ctrl+E | Create TB entry |
| Ctrl+Q | Quick create TB entry |
| Ctrl+D | Delete selected entries |
| Ctrl+N | New TB entry |
| Ctrl+Enter | Merge/Commit current |

### Implementation Fidelity: 80%

Good coverage of entry structure and matching logic. Missing: TB editor full UI layout (not scraped), TB import/export format details, TB creation wizard specifics.

---

## E5: Project Management (MEHQ-15)

### Documentation

| File | Key Sections |
|------|-------------|
| `project-home.md` | Project Home tab, all 8 panes, opening/closing projects |
| `translations-pane.md` | Document list (3 view modes), columns, details pane, import/export, view creation |
| `project-settings.md` | All settings tabs (General, Segmentation, QA, TM, LiveDocs, Auto-translation, etc.) |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `dashboard/project_home_translations.png` | **PRIMARY REF** -- Project Home translations tab |
| `dashboard/project_home_settings.png` | Project Home settings tab |
| `dashboard/project-home-overview-tpro.png` | Project Home overview for translator |
| `dashboard/project-home-translations-pm-documents-details.png` | Document details panel |
| `dashboard/project-home-translations-pm-documents-structure.png` | Document folder structure view |
| `dashboard/project-home-settings-general-languages.png` | Language pair settings dialog |
| `dashboard/project-home-settings-tm.png` | TM settings in project settings |
| `dashboard/project-home-settings-qa.png` | QA settings in project settings |
| `dashboard/project-home-term-bases.png` | TB list in Project Home |
| `dashboard/project-home-translation-memories.png` | TM list in Project Home |
| `dashboard/project-home-livedocs.png` | LiveDocs tab |
| `dashboard/project-home-people.png` | People/users tab |
| `ribbon/ribbon-tabs.png` | All ribbon tabs overview |
| `ribbon/ribbon-applicationmenu.png` | Application/File menu |
| `ribbon/ribbon_quickaccess.png` | Quick Access Toolbar |
| `ribbon/ribbon-project-local-left.png` | Local project ribbon (left) |
| `ribbon/ribbon-project-local-right.png` | Local project ribbon (right) |
| `ribbon/ribbon_documents.png` | Documents ribbon tab |
| `ribbon/ribbon_preparation.png` | Preparation ribbon tab |
| `ribbon/ribbon_view.png` | View ribbon tab |
| `ribbon/ribbon_edit.png` | Edit ribbon tab |
| `ribbon/ribbon-translation.png` | Translation ribbon tab |
| `ribbon/minimize-the-ribbon.png` | Minimized ribbon state |
| `ribbon/smaller-ribbon.png` | Compact ribbon view |

### Key UI/UX Requirements

#### Project Home Panes (8 total)
| Pane | Purpose | mehQ Scope |
|------|---------|-----------|
| Translations | Document management, workflow | YES |
| LiveDocs | Earlier translation suggestions | YES (E8) |
| Translation Memories | TM resources | YES (E3) |
| Term Bases | Terminology databases | YES (E4) |
| Muses | Predictive typing resources | YES (E9) |
| Settings | Segmentation, QA, TM settings | YES |
| Overview | Project reports | YES |
| People | Work assignment (PM only) | SIMPLIFIED (local only) |

#### Translations Pane -- Document List

**Three View Modes:**
1. **Standard List**: Flat list with columns
2. **Structure View**: Hierarchical by target language and folder; expandable/collapsible
3. **Path View**: Shows relative folder paths for identically-named documents

**Columns:**
| Column | Description |
|--------|------------|
| Name | Document title |
| Status icon | Workflow state (in progress, complete, R1/R2 complete); hover for tooltip |
| V (Version) | Source version / Translation version |
| # (Count) | Segments, words, or characters (right-click to change unit) |
| Progress | Visual bar showing completion % |

**Details Pane (expandable):**
- Document type/format
- Import path, export path
- Filter configuration used
- Size (segments, words, characters)
- Embedded objects count
- Target language
- Workflow phase status
- Assignment table with user roles + progress %

#### Document Operations
- **Import**: Standard, Import with Options, Import Folder Structure, Import Package
- **Remove**: Deletes from project DB (not source files)
- **Reimport**: Reloads from source, increments major version
- **Export**: Bilingual (RTF/DOC/XLIFF), Choose Path, Stored Path
- **Change Export Path**: Modify destination

#### Project Settings Tabs
1. General (languages, main details)
2. Segmentation Rules
3. QA Settings
4. TM Settings
5. LiveDocs Settings
6. Auto-translation Rules (per target language)
7. Non-translatable Lists
8. Export Path Rules
9. LQA Models
10. Font Substitution
11. MT Settings (out of scope for mehQ)

#### General Shortcuts
| Shortcut | Action |
|----------|--------|
| Ctrl+S | Save All |
| F1 | Help |
| Ctrl+F1 | Hide/expand ribbons |
| Ctrl+Tab | Navigate through open tabs |

### Implementation Fidelity: 75%

Good project structure documentation. Missing: Dashboard/main window layout (not scraped), project creation wizard, project template system, ribbon detail per tab. The ribbon screenshots fill many gaps but exact button labels need to be read from images.

---

## E6: File Format Support (MEHQ-16)

### Documentation

| File | Key Sections |
|------|-------------|
| `file-formats.md` | Complete list of monolingual, bilingual, memoQ bilingual, and package formats |
| `segmentation-rules.md` | Segmentation concept, regex-based rules, SRX compatibility |
| `tags.md` | How tags from different formats appear in the editor |

### Screenshots

No dedicated file format screenshots in our collection. Relevant related images:
| Image | What It Shows |
|-------|--------------|
| `editor/mqw-tr-editor-tags.png` | Tags from document formats displayed in editor |
| `editor/inline-tags.png` | Inline tags visual representation |
| `dialogs/bad-segmentation.png` | Example of poor segmentation result |

### Key UI/UX Requirements

#### mehQ Supported Formats (In-Scope Subset)
| Format | Extensions | Priority |
|--------|-----------|----------|
| XLIFF | .xlf, .xliff | P0 -- Core |
| Microsoft Word | .docx, .dotx | P1 |
| Microsoft Excel | .xlsx, .xltx | P1 |
| Microsoft PowerPoint | .pptx, .potx | P1 |
| HTML | .html, .htm | P1 |
| Plain Text | .txt | P1 |
| CSV/TSV | .csv, .tsv | P1 (TM/TB import/export) |

#### Segmentation Rules
- Based on regular expressions
- Language-dependent (different rules per language)
- Default: sentence boundaries at punctuation marks
- Exceptions: ordinal numbers, abbreviations, etc.
- SRX 1.0 import compatibility
- Customizable and shareable between projects

#### Tag Handling per Format
- **DOCX/HTML/XML**: Inline tags (opening/closing/empty) -- freely rearrangeable
- **General formatting**: Uninterpreted formatting tags ({1}, {2}) -- sequential order
- **RTF/DOCX specials**: mq:nt (non-translatable), mq:ch (special chars)
- **HTML**: mq:it tags, mq:pi processing instructions

### Implementation Fidelity: 60%

Format list is complete but import filter configuration dialogs are not scraped. Segmentation rules concepts are clear but regex rule editor UI is missing. The actual parsing logic will rely on Open XML SDK / HtmlAgilityPack / System.Xml.Linq as specified in tech stack.

---

## E7: QA System (MEHQ-17)

### Documentation

| File | Key Sections |
|------|-------------|
| `qa-checks.md` | **Complete reference**: 100+ QA warning codes organized by category (tags, segments, numbers, punctuation, etc.) |
| `qa-settings.md` | QA settings editor: all 8 tabs (Segments/Terms, Consistency, Numbers, Punctuation, Spaces/Capitals, Inline Tags, Length, Regex, Severity) |
| `run-qa.md` | Run QA dialog: scope options, check documents/TM, report generation, post-QA actions |
| `segment-statuses.md` | Error status filtering for QA results |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `qa/edit-qa-settings-consistency.png` | QA settings: Consistency tab |
| `qa/edit-qa-settings-inline-tags.png` | QA settings: Inline Tags tab |
| `qa/edit-qa-settings-numbers.png` | QA settings: Numbers tab |
| `qa/edit-qa-settings-segments-terms.png` | QA settings: Segments & Terms tab |
| `qa/errors-window-qa-notifications.png` | QA errors/notifications window |
| `qa/qa_warning.png` | QA warning display in editor segment |
| `qa/ribbon-qa-menu.png` | QA menu in ribbon |
| `qa/run-qa-report-list-errors-warnings.png` | QA report with categorized errors/warnings list |
| `qa/specify-segment-status.png` | Segment status specification dialog |
| `editor/mqw-tr-editor-warning.png` | Warning indicator in editor row |
| `editor/mqw-tr-editor-error.png` | Error display in editor |
| `editor/mqw-tr-view-pane-qa-lqa.png` | View pane QA/LQA mode |

### Key UI/UX Requirements

#### QA Warning Categories (by Code Range)
| Code Range | Category | Count |
|------------|----------|-------|
| 1001-2017 | Tag Issues | 15 warnings |
| 3010-3040 | Segment Content | 4 warnings |
| 3050-3110 | Whitespace | 2 warnings |
| 3061-3069 | Number Formats | 8 warnings |
| 3071-3076 | Spacing Around Signs | 6 warnings |
| 3077-3089 | Punctuation | 7 warnings |
| 3081-3084 | Length | 4 warnings |
| 3085-3101 | Terminology | 8 warnings |
| 3094-3096 | Non-translatable Elements | 3 warnings |
| 3120 | Forbidden Characters | 1 warning |
| 3131-3134 | Formatting (B/I/U) | 4 warnings |
| 3140 | Auto-translatables | 1 warning |
| 3151-3153 | TM Matches | 3 warnings |
| 3161-3162 | Spelling & Grammar | 2 warnings |
| 3180-3182 | Pixel-based Length | 3 warnings |
| 3190-3197 | Spacing Around Tags | 8 warnings |
| 3200-3206 | Regex Checks | 7 warnings |
| 3220-3221 | Deletion/Insertion | 2 warnings |
| 3301-3309 | Measurements & Entities | 9 warnings |

#### QA Settings Editor -- 8 Tabs

**Tab 1: Segments and Terms**
- Check consistent terminology (source-to-target / target-to-source / both)
- Warn if forbidden term used (+ sub-options)
- Check length ratio (characters, words, or both; configurable ratio + deviation)
- Warn if translation > N characters
- Warn if target = source
- Warn if target empty
- Check bold/italic/underline consistency
- Check auto-translatables
- Check non-translatables (with exact matching option)

**Tab 2: Consistency**
- Check duplicate words in target
- Verify identical segments translated consistently (with formatting, case-sensitive options)
- Direction: source-to-target / target-to-source / bidirectional
- Check against TMs: best match, most recent match, multiple matches
- Check insertion/deletion consistency (track changes)

**Tab 3: Numbers**
- Verify number formats
- Verify numbers matched on target side
- Check alphanumeric codes
- Include measurement units
- Custom number formats per language
- Editable measurement unit list

**Tab 4: Punctuation**
- Accept language-specific punctuation only
- Warn for missing brackets/quotes
- Verify spaces before/after punctuation
- Check punctuation sequences (ignore ellipsis option)
- Verify ending punctuation matches
- Custom punctuation marks per language

**Tab 5: Spaces, Capitals, Characters**
- Warn for double whitespace
- Detect extra trailing spaces
- Verify initial capitalization consistency
- Forbidden characters list (Unicode U+ prefix supported)
- Spelling error warnings (+ ignore non-translatables, skip suggestions)
- Grammar error warnings
- Tags-as-spaces designation

**Tab 6: Inline Tags**
- Verify well-formedness against source
- Check overlapping paired tags
- Warn for undefined Unicode entities
- Warn for missing/extra tags
- Warn for changed tag order
- Check spaces before/after tags match source

**Tab 7: Length**
- Character-based length checks (from structured files)
- Pixel-based length checks (font specifications: `120px;Arial;10pt;BI`)

**Tab 8: Regex**
- 7 warning types (forbidden match, missing match, count mismatch, etc.)
- Source regex, Target regex, Correction, Description fields
- "Expand tags to text before processing" option

**Severity Tab (Global)**
- Each QA code can be set to Warning or Error
- Errors prevent document delivery
- Searchable by name/code

#### Run QA Dialog
**Scope Options** (same as pre-translate):
Project, Active document, Selected documents, From cursor, Open documents, Selection, Work on views

**Check Types:**
- Check documents
- Check translation memory (single TM)

**Post-QA Options:**
- Proceed to resolve warnings (opens Resolve tab)
- Create view of inconsistent translations
- Export QA report to HTML (per-translator reports optional)

#### QA Display in Editor
- Lightning symbol in segments with QA issues
- Warning icons: lightning bolt (warning level), exclamation mark (error level)
- View pane Review mode shows QA/LQA warnings per segment
- "Resolve errors and warnings" tab for batch review

#### Error Resolution Shortcuts
| Shortcut | Action |
|----------|--------|
| Ctrl+Up | Move to previous item |
| Ctrl+Down | Move to next item |
| Ctrl+Space | Ignore and move to next |
| Ctrl+Shift+E | Apply automatic corrections |
| Ctrl+Shift+I | Ignore all warnings of this kind |
| Ctrl+Shift+R | Refresh data |

### Implementation Fidelity: 90%

Excellent coverage. All 100+ QA codes documented with descriptions. All 8 settings tabs detailed. Run QA dialog fully specified. Minor gap: Severity tab UI layout not in screenshots, regex tab editor exact layout.

---

## E8: LiveDocs & Alignment (MEHQ-18)

### Documentation

| File | Key Sections |
|------|-------------|
| `livedocs.md` | 4 technologies (Library, ActiveTM, LiveAlign, EZAttach), access models, management |
| `concordance.md` | Concordance search includes LiveDocs corpora results |
| `translation-results.md` | LiveDocs matches shown as red entries (same as TM) with different icons |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `livedocs/resource-console-livedocs.png` | LiveDocs in resource console |
| `livedocs/livedocs_settings_dialog.png` | LiveDocs settings dialog |
| `livedocs/livedocs-filter-types.png` | LiveDocs filter type options |
| `livedocs/ribbon-livedocs.png` | LiveDocs ribbon section |
| `dashboard/project-home-livedocs.png` | LiveDocs tab in Project Home |

### Key UI/UX Requirements

#### Four LiveDocs Technologies
| Technology | Purpose | mehQ Relevance |
|------------|---------|---------------|
| **Library** | Monolingual reference docs; accessed via Concordance | YES |
| **ActiveTM** | Bilingual docs treated as TM; prevents TM pollution | YES |
| **LiveAlign** | Real-time alignment during translation; fix on the fly | YES -- key differentiator |
| **EZAttach** | Binary reference files (PDF, etc.); opens in external viewer | SIMPLIFIED |

#### Corpus Access Models (mehQ: Local Only)
- Local: Stored on user's computer
- Online: Remote server (out of scope)
- Synchronized: Hybrid (out of scope)

#### ActiveTM Behavior
- Imported documents immediately available for matching
- Editable via View/Edit ribbon or right-click on matches
- "Add to LiveDocs" feature for finished project documents

#### LiveAlign Behavior
- Alignment integrated into translation workflow (not preliminary step)
- Segments reusable immediately
- Corrections happen on the fly
- Import via "Add alignment pairs" and "Link documents" buttons

#### Result Display
- LiveDocs matches appear in **Red** (same as TM) with distinct icons:
  - Bilingual document icon
  - Alignment pair icon
  - (vs. TM entry icon)

### Implementation Fidelity: 70%

Concepts well-documented but LiveDocs editor UI, alignment editor detail, and LiveDocs settings specifics are not fully scraped. The alignment editor keyboard shortcuts are documented (in keyboard-shortcuts.md) but the visual layout is missing.

---

## E9: The Muse -- Predictive Typing (MEHQ-19)

### Documentation

| File | Key Sections |
|------|-------------|
| `muse.md` | Muse concept, training, availability (local projects only), practical example |
| `translation-editor.md` | Predictive typing as an insertion method |

### Screenshots

| Image | What It Shows |
|-------|--------------|
| `muse/resource-console-muses.png` | Muses in resource console |
| `muse/muse-properties.png` | Muse properties dialog |
| `muse/train_muse.png` | Train Muse dialog |
| `muse/ribbon_muses.png` | Muse ribbon section |
| `muse/projecthome_muses.png` | Muses tab in Project Home |

### Key UI/UX Requirements

#### Muse Functionality
- Provides **subsegment suggestions** while typing in the editor
- Collects single and multiword expressions from source AND target content
- Identifies correlations between source and target expressions
- Suggests target expressions via **predictive typing** overlay

#### Training
- Requires a trained model from TM data (several thousand segments recommended)
- **Retrainable** when TM grows
- Training dialog (see `muse/train_muse.png`)

#### Availability
- **Local projects only** (also works in local copies of online projects with offline TMs)
- Managed via Muses tab in Project Home or Resource Console

#### Practical Behavior
1. Source text contains "term base"
2. TM training found correlation: "term base" <-> "Termdatenbank"
3. During typing, Muse compares source segment with extracted expressions
4. Suggests "Termdatenbank" in predictive typing popup

#### Integration with Editor
- Predictive typing auto-suggests TB and rule matches while typing
- Placeholder menu: press/release Ctrl for numbers, tags, term matches

### Implementation Fidelity: 55%

Concept documented but implementation details sparse. The actual predictive typing UI behavior (popup appearance, acceptance keys, dismissal) is not detailed in documentation. Training algorithm is not documented. Screenshots of properties/training dialogs exist but the in-editor predictive typing overlay is not captured.

---

## E10: Installer & Auto-Update (MEHQ-20)

### Documentation

- No memoQ documentation is relevant (this is mehQ-specific infrastructure)
- Technology decisions from brainstorming spec: WiX Toolset v4 for MSI, Squirrel.Windows or AutoUpdater.NET for updates

### Screenshots

- None applicable from memoQ docs

### Key UI/UX Requirements

#### Installer
- MSI-based installer (WiX Toolset v4)
- Standard Windows installation wizard
- Start menu shortcut, desktop shortcut option
- Uninstaller registration

#### Auto-Update
- Background check for updates on application launch
- User notification of available updates
- Download and install with user confirmation
- Release pipeline via GitHub Actions + GitHub Releases

### Implementation Fidelity: N/A

Not based on memoQ documentation. Implementation driven by .NET/WiX/GitHub best practices.

---

## Overall Fidelity Assessment

| Epic | MEHQ ID | Fidelity | Notes |
|------|---------|----------|-------|
| E1: Infrastructure | MEHQ-11 | DONE | Completed |
| E2: Translation Editor | MEHQ-12 | **90%** | Excellent: full layout, shortcuts, colors, statuses, results pane |
| E3: Translation Memory | MEHQ-13 | **85%** | Strong: match rates, concordance, TM creation. Gap: TM editor UI |
| E4: Term Base | MEHQ-14 | **80%** | Good: 3-level hierarchy, matching options. Gap: TB editor UI, creation wizard |
| E5: Project Management | MEHQ-15 | **75%** | Good: Project Home structure, translations pane. Gap: Dashboard, project wizard |
| E6: File Format Support | MEHQ-16 | **60%** | Format list complete. Gap: import filter UIs, parser-specific config dialogs |
| E7: QA System | MEHQ-17 | **90%** | Excellent: all 100+ QA codes, 8 settings tabs, run QA dialog |
| E8: LiveDocs & Alignment | MEHQ-18 | **70%** | Concepts clear. Gap: alignment editor UI, LiveDocs editor |
| E9: The Muse | MEHQ-19 | **55%** | Concept only. Gap: predictive typing UI behavior, training algorithm |
| E10: Installer & Update | MEHQ-20 | **N/A** | Not memoQ-dependent |

### Weighted Average Fidelity: ~78%

### Critical Gaps to Address
1. **Dashboard / Main Window** -- Not scraped; consider fetching `Workspace/dashboard.html`
2. **TM Editor UI** -- Not scraped; consider fetching `Workspace/edit-translation-memory.html`
3. **TB Editor UI** -- Not scraped; consider fetching `Workspace/edit-term-base.html`
4. **Document Import Settings** -- Not scraped; consider fetching `Workspace/document-import-settings.html`
5. **Alignment Editor** -- Not scraped; limited to keyboard shortcuts only
6. **Predictive Typing Overlay** -- Not documented in available sources; may need manual memoQ observation

### Recommended Additional Scraping (Priority Order)
1. `Workspace/dashboard.html` -- Main window layout (E5)
2. `Workspace/edit-translation-memory.html` -- TM editor (E3)
3. `Workspace/edit-term-base.html` -- TB editor (E4)
4. `Workspace/document-import-settings.html` -- Import filters (E6)
5. `Concepts/concepts-filter-configurations.html` -- Filter configs (E6)
6. `Workspace/ribbons-*.html` -- Ribbon detail per tab (E5)
7. `Concepts/concepts-auto-translation-rules.html` -- Auto-translation (E7)
