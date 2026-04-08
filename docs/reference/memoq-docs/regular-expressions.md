# Regular Expressions in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-regular-expressions.html (memoQ 12.2)

## Core Engine & Syntax

memoQ uses the **.NET regex engine** and .NET flavor syntax.

## Standard .NET Regex Features

### Meta Characters

| Element | Function |
|---------|----------|
| `.` | Matches any single character |
| `\|` | Alternation (OR operator) |
| `[]` | Character class — matches any enclosed character |
| `[^]` | Negated character class |
| `*` | Zero or more repetitions |
| `+` | One or more repetitions |
| `?` | Zero or one occurrence |
| `{num}` | Exact, range, or minimum/maximum quantifiers |
| `()` | Grouping and capture |
| `\\` | Escape character |

### Character Classes & Shorthands

- `[a-z]`, `[0-9]` — ranges supported
- `\s` — whitespace; `\S` — non-whitespace
- `\d` — digits (Unicode); `\D` — non-digits
- `\w` — alphanumeric + underscore; `\W` — opposite
- Unicode support for international alphabets

### Quantifiers

- `{3,5}` — 3 to 5 times
- `{3,}` — 3 or more times
- `{0,5}` — 0 to 5 times

### Groups & Alternatives

Parentheses group alternatives: `(EUR|USD|GBP)` matches any listed currency.

## Find & Replace Functionality

Replacement expressions use **backreferences**: `$1`, `$2`, etc. reference captured groups.

**Example**: Pattern `(EUR|USD|GBP) (\d+) million` with replacement `$2 Millionen $1` reorders currency and amount for German format conversion.

## memoQ-Specific Extensions

### Tag Matching
- `\tag` — any tag
- `\itag` — inline tags
- `\mtag` — memoQ tags (curly brackets)

### Custom Lists
Lists start/end with hash marks (`#listname#`). Used in:
- **Segmentation rules** — define abbreviations, punctuation
- **Auto-translation rules** — words with identical source/target forms
- **Translation pairs** — custom dictionaries (e.g., "EUR" -> "Euro")

Special feature: `#!#` creates segment breaks.

## Usage Contexts

Regexes apply to:
- Segmentation rules
- Auto-translation rules
- Regex tagger
- Find and replace operations
- Translation editor filter fields

## Testing Tool

The **Regex Assistant** provides a testing ground with live highlighting of matches.
