# memoQ Translation Editor Documentation

## Overview
The translation editor is where users compose and modify translations in memoQ. Each document or view operates in its own editor tab.

## Access Instructions
1. Open a project (local or online checkout)
2. Navigate to Project Home > Translations
3. Double-click a document name or right-click and select "Open For Translation"
4. The editor launches in a separate tab

**Alternative:** Access views via the Views tab in the Translations pane.

## Troubleshooting
If opening documents produces errors, missing fonts may be the cause. Users should install language packs in Windows Control Panel for both source and target languages. This issue occurs most frequently in Windows 10, particularly with Korean text.

## Core Functionality

### Translation Writing & Editing
The Grid displays each segment in rows with source text on the left and target cells on the right. Users press **Ctrl+Enter** to confirm translations.

When confirmed, memoQ:
- Saves translations to the document and project working memory
- Changes segment status to "Confirmed"
- Advances to the next segment with pre-translation applied

**Automatic saving occurs continuously**, even for unconfirmed segments.

### Advanced Translation Operations
Users can perform multiple tasks simultaneously:
- Insert suggestions using predictive typing and menus
- Manage multiple segments with batch operations
- Apply document formatting and handle inline tags
- Join, split, or re-segment content
- Filter and sort segments
- Copy source text or clear translations
- Add segment comments
- Adjust segment statuses
- Compare versions
- Lock segments
- Apply pre-translation
- Enable Track Changes (Review ribbon)
- Create inline tags via Regex Tagger (Preparation ribbon)

## Interface Components

### View Pane
Located at the window bottom, this pane displays a formatted preview showing how finished translations appear. The current segment has a red border highlight.

**Navigation:** Users can click within the preview to jump to that location; the Grid synchronizes accordingly.

**Search Function:** Press **Ctrl+F** in the View pane to locate specific text. Matches highlight, and users navigate via "Next" button.

**Limitations:** The preview simulates the original document but may differ in formatting. Some formats prevent preview generation. XML documents and multilingual tables display structure rather than formatting. Supported formats include Word, Excel, PowerPoint, HTML, XML, WPML XLIFF, and text.

### Translation Results Pane
Positioned on the right side, this panel automatically displays suggestions from project resources including translation memories, LiveDocs corpora, term bases, machine translation, auto-translation rules, and non-translatable lists.

**Suggestion Types:**
- Fragment-assembled combinations replacing terms with translations
- Full-segment translations from memories or MT
- Partial-segment translations from term bases or rules
- Concordance suggestions for research purposes

**MatchPatch Feature:** Repairs minor translation memory differences using term bases, TMs, or machine translation when differences involve one or two words.

### Status Bar
The bottom status bar provides project progress overview:

- **Server Icon:** Connection status indicator
- **Proj (language):** Project completion percentage (toggleable between word/segment/character counts via right-click)
- **Doc:** Document completion percentage
- **TR:** Translator-confirmed segments
- **R1/R2:** Reviewer 1 and Reviewer 2 confirmations
- **Ed:** Edited but unconfirmed segments
- **Rej:** Reviewer-rejected segments
- **Empty:** Untouched segments
- **Pre:** Pre-translated, unedited segments
- **Frag:** Fragment-assembled pre-translations
- **MT:** Machine translation pre-translations
- **QA errors:** Quality assurance error count
- **Ins:** Insertion mode indicator
- **Pos:** Current cursor position in segment
- **Length:** Source and target character counts (with tag length noted)

## Layout Management

### Multi-Monitor Setup
To use dual screens:
1. Press **Windows+P** to extend display
2. Drag the View pane title bar to detach
3. Move to second screen and maximize
4. To re-dock: Drag back over memoQ window; docking icons appear
5. Position pointer over desired icon and release

**Recovery:** If View pane detaches unexpectedly, use View ribbon > Navigation box > View Pane icon to restore.

### Preset Layouts
Two default configurations exist: Default and Results on Top (Trados Studio-style). Press **F11** to toggle between them.

To reset to Default layout: View ribbon > Layout icon dropdown > choose "Default"

## Insertion Methods for Suggestions

- **Predictive Typing:** Automatically suggests term base and rule matches
- **Placeholder Menu:** Press and release **Ctrl** while typing for numbers, tags, and term matches
- **Full-Segment Insertion:** Press **Ctrl+Space** for first suggestion; press **Ctrl+number** for others; use **Ctrl+Down/Up** to navigate and **Ctrl+Enter** to insert; or double-click suggestions

## Closing
Translations save automatically without manual intervention. Return to Project Home by closing the editor tab (Close button or **Ctrl+F4**).
