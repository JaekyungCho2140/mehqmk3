# Linguistic Quality Assurance (LQA) Models in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-linguistic-quality-assurance.html (memoQ 12.2)

## Definition

LQA is a systematic approach for incorporating human feedback into document translation. It allows reviewers to structure and formalize their feedback, and grade the translations if necessary.

## Key Components

LQA models define error categories used to score translation errors and assign grades. Some models can fail translations entirely.

## Supported Standards

memoQ implements four LQA frameworks:
1. **J2450** — automotive industry standard
2. **LISA** — localization industry standard
3. **TAUS** — translation automation standard
4. **memoQ proprietary** — memoQ's own model

## LQA vs. QA

| Aspect | LQA | QA |
|--------|-----|------|
| Type | Human evaluation | Automated checks |
| Focus | Structured feedback | Consistency, tags, length |
| Method | Reviewer-driven | Software-driven |

## Project Implementation

1. Access Project Home
2. Navigate to Settings
3. Click the LQA settings icon
4. Select preferred model checkbox
