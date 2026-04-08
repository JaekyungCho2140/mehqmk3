# QA Settings Editor in memoQ - Complete Guide

## Overview

Quality Assurance (QA) settings define which automatic checks memoQ runs on translations. These settings allow configuration of terminology checks, formatting validation, consistency verification, and numerous other quality aspects.

**Key constraint:** You cannot edit the default QA settings. Users must either clone the default settings or create new ones before customization.

---

## Accessing QA Settings

### Via Resource Console
1. Click the Resource console icon (top left)
2. Select "QA settings" from the Resources list
3. Click "Create/Use new" or double-click existing settings to edit

### Via Local Project
1. Open a local or checked-out online project
2. Navigate to Project home > Settings
3. Click the QA settings icon
4. Select "Create/Use new" or double-click to edit

### Via Online Project
1. Open an online project for management
2. Go to Settings in the memoQ online project window
3. Click the QA settings icon
4. Select "Create/Use new" or double-click to edit

---

## Segments and Terms Tab

### Terminology Section

**Check for consistent use of terminology**
- Examines consistent term usage across project term bases
- Options:
  - *Source to target:* Verifies all source terms have translations; identifies different translations for identical source terms
  - *Target to source:* Checks identical target terms don't have different source terms
  - *Both ways:* Performs bidirectional consistency checking

**Warn if forbidden term is used**
- Displays warnings when terms marked forbidden appear in translations
- Sub-options:
  - *Even if there is no source equivalent:* Warns about forbidden terms even without source-language equivalents
  - *In the source segment:* Warns if forbidden term or its source equivalent appears in source (may be reported to client)

### Segment Length Section

**Check length of translation in proportion to source**
- Validates target segment length ratios relative to source
- Configuration options:
  - Specify checking by characters, words, or both (characters enabled by default)
  - *Average target/source length ratio:* Enter proportional values (e.g., 1.20 for 20% longer translations)
  - *Allowed deviation:* Define acceptable variance from average (enter for both words and characters)

**Warn if translation is longer than (characters)**
- Triggers warning when translation exceeds specified character limit

### Other Section

**Warn if target segment equals source segment**
- Detects identical source-target segments

**Warn if target segment is empty**
- Identifies empty target segments requiring translation

**Check bold, italic, and underline**
- Verifies same formatting applied consistently across source-target pairs

**Check auto-translatables**
- Confirms auto-translation rule suggestions appear in target text

**Check for consistent use of non-translatables**
- Validates non-translatable phrases maintain consistency
- Options: Source to target / Target to source / Both ways

**Use exact matching for non-translatables**
- Prevents false warnings by requiring exact matches only

---

## Consistency Tab

### Consistent Translation Section

**Check for duplicate words in the target**
- Detects repeated words separated by at least one space (e.g., "and and")

**Verify that identical segments are translated consistently**
- Ensures every identical source segment receives same translation
- Sub-options:
  - *With formatting:* Includes formatting in comparison
  - *Case-sensitive:* Treats uppercase/lowercase as significant

**Translation consistency directions:**
- *Source to target:* Identifies different translations for identical source segments
- *Target to source:* Checks identical target segments don't have different source equivalents
- *Bidirectional:* Performs both checks simultaneously

### Check Against TMs and Corpora Section

**Warn if best exact/context match is different from translation**
- Compares current translation against best TM/corpus match

**Warn if most recent exact/context match is different from translation**
- Uses match with latest modification time

**Warn if there are multiple exact/context matches**
- Alerts when multiple matches exist with different target segments

### Change Tracking Consistency Section

**Check insertion and deletion consistency**
- Warnings for missing tracked deletions/insertions in translation

---

## Numbers Tab

### Check Options Section

**Verify number formats**
- Ensures consistent number format usage
- Detects full-width digits in non-CJK text

**Verify that numbers are matched on the target side**
- Ensures source and target contain identical numbers
- Interprets numbers "linguistically" (format-dependent)

**Check alphanumeric codes**
- Verifies product codes, names, measurements, URLs remain identical

**Include measurement units in number checks**
- When enabled, checks measurement strings following numbers

### Measurements Section
- Editable list of character sequences treated as measurements

### Custom Number Formats for Languages Section
- Per-language format customization

---

## Punctuation Tab

### Check Options Section

**Accept language specific punctuation marks only**
**Warn for missing brackets, quotation marks, and apostrophes**
**Verify the correct use of spaces before and after punctuation marks**
**Check sequences of punctuation marks for correctness**
- Sub-options: Ignore ellipsis, Ignore sequences of periods longer than N

**Verify that source and target segments end with the same punctuation mark**

### Custom Punctuation Marks for Languages Section
- Define punctuation type, spacing rules per language

---

## Spaces, Capitals, Characters Tab

### Whitespace and Capitalization Section

**Warn for double whitespace characters**
**Detect extra spaces at the end of segments**
**Verify that initial capitalization is the same in source and target**

### Forbidden Characters Section
- Enter characters or Unicode numbers (U+ prefix) to flag

### Spelling and Grammar Warnings Section

**Generate warnings for spelling errors**
- Sub-options: Ignore non-translatable items, Skip spelling suggestions

**Generate warnings for grammar errors**

### Tags as Spaces Section
- Designate inline tags as whitespace equivalents (e.g., br, img for HTML)

---

## Inline Tags Tab

### Inline Tag Warnings Section

**Verify well-formedness against source**
**Check for overlapping paired tags**
**Warn for Unicode characters with no defined entity**
**Warn for Unicode characters with more than one defined entity**
**Warn for missing or extra tags on the target side**
**Warn for changed tag order**

### Spaces Before and After Tags

**Check if spaces before and after tags match the source**
**Check if opening and closing tags are in the correct format**

---

## Length Tab

### Character-Based Length Checks
- Imports length restrictions from structured files (XML, Excel, etc.)

### Pixel-Based Length Checks
- Validates translation length in pixels with font specifications
- Format in row comment: `120px;Arial;10pt;BI`
- Uses regex rules to extract parameters

---

## Regex Tab

Custom checks using regular expressions for non-standard validation.

### Warning Type Options

1. **Forbidden regex match in target for source** - Both patterns trigger warning
2. **Missing regex match in target** - Missing target pattern triggers warning
3. **Counts of regex matches differ** - Count mismatch triggers warning
4. **Missing regex replacement in target** - Missing replacement triggers warning
5. **Forbidden regex replacement in target** - Present replacement triggers warning
6. **Counts of regex matches/replacements differ** - Count mismatch triggers warning
7. **Forbidden regex match in target** - Target-only pattern triggers warning

### Configuration
- Source regex box, Target regex box, Correction box, Description box
- Tag content verification: "Expand tags to text before processing"

---

## Severity Tab

Designates QA results as warnings or errors (defaults to warnings for all).

- Search by result name/code
- Change warning to error or vice versa
- "You cannot deliver a document that has errors"

---

## Saving and Applying

- Click OK to save and return
- Apply via project templates or project Settings pane
- Default QA settings cannot be edited directly; clone first
