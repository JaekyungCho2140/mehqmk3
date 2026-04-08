# Auto-Translation Rules in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-auto-translation-rules.html (memoQ 12.2)

## Definition

Auto-translation rules control how a portion of the source text is converted to its equivalent in the target text. Designed for specific translation challenges like dates, numbers, legislative references, and unit conversions.

## Technical Foundation

The feature relies on regular expressions (.NET regex engine). Users must define two components:
1. A **search pattern** (regex)
2. A **replacement pattern**

## How It Works

The system operates automatically without requiring additional setup beyond rule creation.

### Processing Order
When you open an untouched segment, memoQ follows this sequence:
1. Scan translation memories
2. Scan term bases
3. Scan auto-translation rule sets

### Visual Feedback
- memoQ automatically highlights matches in the source cell
- Matches appear as a **green hit** by default
- Translators can double-click highlights or select results from the Translation results pane

## Capabilities

- Pattern matching and replacement via regex
- Auto-translation rules combined with the **fragment assembly** feature can also act as simple machine translation, particularly for basic catalog translations

## Pre-installed Rules

memoQ includes pre-installed auto-translation rules available immediately for common patterns (dates, numbers, etc.).

## Key Points

- Light resource type
- Can be shared, imported, exported
- Regular expression based
- Supports lists within patterns (using `#listname#` syntax)
- Supports translation pairs for dictionary-like lookups
