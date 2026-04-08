# Translation Memories in memoQ — Detailed Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-translation-memories.html (memoQ 12.2)

## Core Functionality

Translation memories are databases storing source-target segment pairs that accelerate translation work by enabling automatic lookup and reuse of previously translated content.

## Key Features

### Basic Operations
- Local, online, and offline translation memory access
- Automatic segment lookup during translation
- Concordance search for specific words/expressions
- Translation memory editor for review and modification
- Working (primary) and master TM designation per project

### Context Management (ContexTM)
memoQ looks at each segment together with its context (the segments before and after) and stores context automatically when enabled.

**Context options:**
- Simple context (default) — checks previous segment
- Double context — checks both previous and following segments
- No context

Multiple identical segments with different contexts count as separate entries, potentially creating multiple 100%/101% matches.

### Multiple Translations
During creation, users specify whether identical segments allow one or multiple target translations. If you decide that memoQ should allow only one translation and then you translate an already translated segment differently, the new translation replaces the older one.

## Translation Memory Properties

Modifiable metadata includes: subject, domain, path, description, client, author, entry count, and read-only status. Properties set at creation (context handling, multiple translations allowance) cannot be altered afterward.

## Match Types

| Match % | Description |
|---------|-------------|
| 102% (XLT) | Double context match — both text flow and ID context match |
| 101% | Identical segment with identical surrounding context (single) |
| 100% | Same text, different context or no context |
| 95-99% | Nearly exact — minor variations in numbers, tags, punctuation |
| 50-94% | Fuzzy matches — textual differences |

### Special Indicators
- **Asterisk prefix** (*100%, *101%, *102%): Multiple identical matches existed; insertion doesn't guarantee best match
- **Exclamation mark prefix** (!): Match rate boosted due to automatic tag/text patching

## Roles in Translation Memories

Available since memoQ 2013 R2. Stores user role data (Translator, Reviewer 1, Reviewer 2) with each segment, enabling role-based filtering and penalty application.

### Role Hierarchy
Reviewer 2 overwrites Reviewer 1, which overwrites the Translator role.

## Project TM Strategy

- **Working TM**: Receives confirmed segments during translation/review phases
- **Master TM**: Stores final approved translations after project completion

## TM+ (Next Generation)

- Performs much better on CPUs with higher core count, especially in server environments
- TMX import operates twice as fast as classic version
- Handles over 10 million segments effectively
- Support for roles and concordance search guess translation
- Since memoQ 12.0: Classic TM creation disabled; TM+ only

## Offline Synchronization

Synchronized online TMs maintain local copies synchronized with remote versions, enabling offline work with automatic updates upon reconnection.

## TM Match Scoring Details

- Matching scores reflect word-length weighting: short words weigh less and long words weigh more
- For very short segments (5 or fewer words, under 128 characters), the Levenshtein algorithm applies
- Automatic number substitution: segments differing only in numbers can return as 100% matches if correction succeeds
- Supports Latin numerals in CJK texts

## Weighted Word Counts

| Match Category | Weight Coefficient |
|---------------|-------------------|
| 100% and above | 0.3 |
| 95-99% | 0.5 |
| 75-94% | 0.8 |
| Below 75% | 1.0 |
| Locked segments | excluded |
