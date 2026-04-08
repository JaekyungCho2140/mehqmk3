# Pre-translate and Statistics in memoQ

## Overview

The Pre-translate and statistics window enables users to configure and execute pre-translation operations. This function searches translation memories and LiveDocs corpora to insert optimal matches for each segment.

## Core Functionality

When pre-translating documents, memoQ can:
- Assemble segments from smaller fragments when no exact match exists
- Apply machine translation for unmatched segments
- Join or split segments to improve matching quality

## Access Methods

### Local Projects
Project home > Preparation ribbon > Pre-translate button

### Online Projects
Translations section > Statistics/Preparation ribbon > Pre-translate

## Configuration Sections

### Scope and Lookup Tab

**Scope Options:**
- **Project**: All segments across all documents for all target languages
- **Active document**: Currently open document only
- **Selected documents**: Multiple documents chosen from Translations pane
- **From cursor**: From current position downward
- **Open documents**: All documents with active editor tabs
- **Selection**: User-highlighted segments only
- **Work on views**: View-based segments when available

### Match Quality Thresholds

- **Exact TM or corpus match with context**: Only 101% or 102% matches
- **Exact TM or corpus match**: 100% or better matches
- **Good TM or corpus match**: Threshold defined in active TM settings
- **Any TM or corpus match**: Any match exceeding 60% minimum

**Specialized Option**: "Use only if there's a single TM or corpus match" -- restricts to segments with exactly one 100%+ match.

### Fragment Assembly

**Enabling**: Check "Perform fragment assembling"

**Matches to Include:**
- Terms
- Non-translatable items
- Numbers
- Auto-translation rule results
- TM and LiveDocs corpus fragments

**Coverage Requirements:**
- Full matches covered by one single hit
- Full matches covered by several hits
- Matches with coverage of at least [customizable percentage] (default 50%)

**Advanced Options:**
- "Delete source text without any match": Removes untranslated source portions
- "Do not change the case of terms": Preserves term capitalization as stored

### Machine Translation

**Basic MT**: Enable "Use machine translation if there's no TM match"

**AI-Based Quality Estimation (AIQE)**: Enable for multiple MT services; AIQE selects optimal service per segment.

### TM-Driven Segmentation

**Feature**: "Automatically join and split segments for best match"

When exact match unavailable, memoQ combines segments with following ones. If joining fails but segment beginning has exact match, splits at that point and continues checking remainder.

## Confirm/Lock Tab

**Match Rate Conditions:**
- Do not confirm or lock segments
- Exact match (100% or better)
- Exact match with context (101% or better)
- Exact match with double context (102% only)
- Only if match is unambiguous

**Status Change Options:**
- New status: Pre-translated (no modification)
- New status: Translator confirmed
- New status: Reviewer 1 confirmed
- New status: Reviewer 2 confirmed
- Make rows locked

## Versioning Tab

- Create minor version snapshot before pre-translation
- Create minor version snapshot after pre-translation

## Statistics Tab

- Check "Perform statistics" to combine with analysis
- Reports appear on Project home Overview page

## Segment Behavior During Pre-translation

**Empty segments**: Always filled when matches exist
**Previously pre-translated segments**: Overwritten only if newer match rates exceed prior
**Edited or confirmed segments**: Remain unchanged; use Clear translations to modify
