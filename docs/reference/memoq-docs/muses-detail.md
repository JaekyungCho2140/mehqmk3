# Muses in memoQ — Predictive Typing

> Source: https://docs.memoq.com/current/en/Concepts/concepts-muses.html (memoQ 12.2)

## Core Definition

Muses are heavy resources that provide subsegment suggestions to users as they type in the translation editor. They analyze expression patterns and correlations to offer predictive typing assistance.

## How It Works

1. System collects single and multiword expressions from source and target content
2. Identifies correlations between source and target expressions
3. During translation, compares incoming source segments against trained patterns
4. Suggests corresponding target expressions through predictive typing

## Example

If a training corpus contains "term base" in the source and "Termdatenbank" in the target without explicit alignment, the Muse independently detects this correlation. During subsequent translation, it recognizes similar source expressions and recommends the matching target term.

## Limitations & Capabilities

- **Scope**: Available for local projects only, including offline copies of online projects with local translation memories
- **Maintenance**: Users can retrain Muses as their translation memory grows or content evolves
- **Scale**: Effective with a corpus of a few thousand segments or more
- **Learning**: Automates terminology suggestion by learning translation patterns rather than relying on manual entries
