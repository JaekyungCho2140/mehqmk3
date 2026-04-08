# Views in memoQ — Detailed Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-views.html (memoQ 12.2)

## Core Definition

Views are static, named filters of translation document segments that can be saved, reopened, exported, imported, and assigned to translators. They are distinct from temporary on-the-fly filtering.

## Views vs On-the-Fly Filtering

| Feature | Views | On-the-Fly Filtering |
|---------|-------|---------------------|
| Persistence | Named, saved entities | Temporary, lost on close |
| Lifecycle | Independent, reusable | Tied to current session |
| Assignment | Can be assigned to translators | N/A |

## Primary Use Cases

### 1. Consolidating Multiple Documents
For website translation projects with hundreds or thousands of small files, views allow combining multiple documents into a single interface, eliminating repetitive file opening/closing.

### 2. Segmenting Long Documents
Extract specific portions by defining start and end segment numbers. Example: creating a segment range from 1,500-3,000 within a 4,500-segment document.

### 3. Review and Preparation Scenarios
- Filter segments with fuzzy matches across all project documents
- Identify segments containing formatting tag errors
- Locate specific phrases in source and target cells
- Include segments previously marked by Find and Replace functionality

## UI Navigation

Views are accessed through the **Views tab in the Translations pane of Project home**.

## Access Points

- Create view dialog offers filtering and sorting options
- Views persist in the Translations list for future access
