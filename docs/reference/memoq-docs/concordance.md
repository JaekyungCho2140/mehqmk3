# Concordance Search Documentation

## Overview
With Concordance, you can look for words and expressions in translation memories and LiveDocs corpora in your project. This feature assists translators when complete segment matches aren't available, providing lists of relevant entries and enabling text insertion into translations.

## Access Methods

Users can launch Concordance through two routes:
1. Press **Ctrl+K** after selecting text in source or target segments
2. Click the Concordance button in the Translation ribbon

If no text is selected, the window opens empty, allowing manual entry in the Search field.

## Core Functionality

### Three-Column View (KWIC Format)
Results display in a "keyword in context" layout showing results from translation memories and LiveDocs corpora. Users must select individual results sequentially to view associated translations and metadata at the window's bottom.

### Search Options and Settings

**Text Matching Controls:**
- **Put selected text in quotes**: When enabled, searches for exact expressions; when disabled, finds words in different orders with intervening text
- **Add wildcards to selected text**: Disabling this finds exact word matches
- **Case sensitive**: Enables proper name searches
- **Find different numbers, too**: When selected, locates variations like "Step 1," "Step 2," and "Step 45"; unchecking requires exact numbers

**Performance Settings:**
- **Limit spin box**: Restricts maximum returned hits, improving response time but potentially missing relevant results

**Wildcard Syntax:**
- `*` at word end: Optional ending variation (e.g., `turn*` finds "turn," "turnover," "turnaround")
- `+` at word end: Required ending variation (excludes exact match)
- `*` before word: Optional beginning variation
- `+` before word: Required beginning variation

### Insertion Options

When suitable translations are found, users can:
- Click **Insert** to add entire translations
- Select specific text and click **Insert selected** for partial insertion
- Enable **Close dialog on insert** checkbox persistence by unchecking it first

## Advanced Features

### Source+Target View
Switching to the "Source+target radio button" displays parallel text with metadata including:
- Source document identification
- Last modification date
- Original document reference (when available)

### Guess Translation Feature
When **Guess translation** checkbox is selected, memoQ analyzes full segment translations to identify likely term equivalents. Results display with color-coding indicating confidence levels (darker green = higher confidence). This setting persists across sessions until manually disabled.

### Target Language Searching
Users can reverse-search by selecting target text and pressing Ctrl+K, then utilizing the **Filter source box** to narrow results by source-language phrases.

### Term Base Integration
Highlighted translations can be added to term bases by:
1. Selecting text
2. Right-clicking and choosing **Add term** or pressing Ctrl+E
3. Completing the Create term base entry window

## Translation Memory Editing

Concordance enables direct TM entry modification:
1. Right-click any result row
2. Select **View/Edit Entry** to access the editing interface
3. Optionally delete entries via the right-click menu

## Filter Functions

- **Filter target box**: Narrows results to entries containing specified target-language words
- **Filter source box**: Limits results to entries with designated source-language words

## Window Persistence

By default, Concordance closes after insertion commands execute. Users desiring persistent window access must uncheck the "Close dialog on insert" option before clicking Insert commands.
