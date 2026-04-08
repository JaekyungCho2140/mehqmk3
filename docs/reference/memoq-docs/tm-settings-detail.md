# TM Settings in memoQ — Detailed Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-tm-settings.html (memoQ 12.2)

## Definition

TM (Translation Memory) settings define rules governing translation memory parameters including match thresholds and penalties.

## Key Components

### Thresholds
Thresholds are the limits that a match must pass so that it is considered as a match or a good match. Default threshold values are pre-configured.

### Penalties
Penalties are percentages automatically deducted from match rates for segments created through alignment rather than manual creation.

### Adjust Fuzzy Hits
"Adjust fuzzy hits" is enabled by default, allowing automatic adjustment of numbers, punctuation, cases, and inline tags in matches below 100%. Users may disable this feature for manual adjustment.

## Configuration

- Multiple TM setting sets can be created
- Only one applies per project
- Located in Project home or Resource console
- Operations supported: create new sets, import/export existing sets, clone online sets for local use, edit selected set properties

## TM Settings is a Light Resource

- Can be saved, shared, imported, exported
- XML-based exchange format
