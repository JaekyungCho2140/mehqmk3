# QA Warnings in memoQ — Complete Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-quality-assurance-qa-warnings.html (memoQ 12.2)

## Overview

memoQ's automated QA module performs over a hundred different types of checks — about numbers, spaces, punctuation marks, the consistency of terms, the length of segments, and many more.

## QA vs LQA

- **QA (Quality Assurance)**: Automated checks on translations
- **LQA (Linguistic Quality Assurance)**: Human feedback structured through LQA models (J2450, LISA, TAUS, memoQ proprietary)

## Configuration

Access QA settings through Project home or memoQ online project Settings pane. Changes require right-clicking the QA settings resource and selecting Edit.

## Complete QA Warning Categories

### Tag-Related (1000s-2000s)

| Code | Description |
|------|-------------|
| 1001-1002 | Missing or extra tags affecting formatting |
| 2001-2017 | Attribute validation, tag structure, ordering, and translatable attribute issues |

### Content Issues (3000s)

| Code | Description |
|------|-------------|
| 3010 | Empty target segments |
| 3020-3030 | Punctuation and capitalization consistency |
| 3040 | Identical source/target detection |
| 3050 | Multiple consecutive whitespaces |

### Number Handling (3061-3069)

Format validation, matching verification, and language-specific grouping rules.

### Spacing & Punctuation (3071-3089)

Non-breaking spaces, quote/bracket pairing, and language-specific punctuation.

### Term & Content Consistency (3091-3101)

Missing/extra terms, forbidden terminology, and inconsistent translations.

### Formatting (3131-3134)

Bold, italic, underline consistency between source and translation.

### Advanced Checks (3151-3309)

| Code Range | Description |
|------------|-------------|
| 3151-3153 | Translation memory match verification |
| 3161-3162 | Spelling and grammar detection |
| 3180-3197 | Length limits and tag spacing |
| 3200-3206 | Regular expression pattern matching |
| 3301-3309 | Measurement, entity, and date consistency |

## Key Implementation Notes for mehQ

Essential QA checks to implement first:
1. Missing/extra tags (1001-1002)
2. Empty target segments (3010)
3. Punctuation/capitalization consistency (3020-3030)
4. Number matching (3061-3069)
5. Term consistency (3091-3101)
6. Spelling (3161)
