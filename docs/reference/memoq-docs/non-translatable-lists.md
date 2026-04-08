# Non-Translatable Lists in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-non-translatable-lists.html (memoQ 12.2)

## Purpose

Non-translatable lists designate text that should remain untranslated and be copied directly to the target cell.

## How It Works

- No special configuration needed beyond setting up the non-translatable list
- When editing untouched segments, memoQ scans in sequence:
  1. Translation memories
  2. Term bases
  3. Non-translatable phrase lists
- Matching phrases are automatically highlighted in **gray** within the source cell
- Matches appear as **gray hits** in the Translation results pane

## Functionality

- Gray highlighting indicates identified non-translatable content
- Users can manually insert desired target versions
- Projects support **multiple non-translatable lists**
- One list serves as the **primary list** where new non-translatable expressions can be added during translation work

## Access

Features are available within the translation editor while working on projects.
