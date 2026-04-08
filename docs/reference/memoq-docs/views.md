# Views in memoQ

## Overview

Views represent a specialized feature in memoQ's translation grid that allows translators to work with filtered or sorted segment collections from translation documents.

### Definition and Core Characteristics

You can make your job easier by creating views of filtered or sorted segments from the selected translation documents. These views function as persistent, reusable entities distinct from temporary filtering operations.

**Key Properties:**
- Static in nature with assigned names
- Can be reopened at any time
- Exportable and importable as separate files
- Assignable to specific translators
- Retain persistence across project sessions

### Views vs. On-the-Fly Filtering

Using views is different from the on-the-fly filtering and sorting that is done with a document in the main translation grid. The core difference is that the results list of on-the-fly filtering are not a separate entity, and so are available to you only temporarily.

Temporary filtered results disappear when you close the project, requiring users to reapply filters if needed again.

## Primary Use Scenarios

### Scenario 1: Consolidating Multiple Small Documents

When translating websites with hundreds or thousands of small files, views enable document consolidation by "gluing" small files together. Views present consolidated content in the order they appear in the Translations list and can be saved in a bilingual file, and transferred to another computer.

### Scenario 2: Segmenting Large Documents

For lengthy documents, views enable document splitting through segment range specification. Users can specify a starting and an ending segment number. For example, you can create a view from segment 1,500 to 3,000 from a document of 4,500 segments.

**Limitation:** With a single Create view operation, you can extract one portion from the document. Repeat the Create view command for multiple views from a single document.

### Scenario 3: Review and Preparation Tasks

Views support multiple review-focused filtering approaches:

**Match-based filtering:** Reviewers can isolate segments with specific match percentages, such as segments that received a fuzzy match.

**Error-based filtering:** Users can create a view to include all segments that have a formatting tag error.

**Content-based filtering:** Two strategies:
1. List phrases to filter for in both source and target cells
2. Use Find and Replace to mark segments, then create view including marked segments

## Access and Management

Views are managed through the Views tab located in the Translations pane within Project home.
