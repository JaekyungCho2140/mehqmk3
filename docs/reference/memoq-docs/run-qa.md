# Running QA Checks in memoQ

## Overview

memoQ provides automated quality assurance capabilities. While the system runs checks during translation work, the Run QA command allows users to execute custom checks or perform consistency validation at the segment level.

## Accessing Run QA

1. Open a project (documents may be open but are not required)
2. On the Review ribbon, select the Quality Assurance button
3. The Run QA window opens

**Note:** Before running QA with custom settings, ensure proper QA settings resources are configured in Project home.

## Primary QA Options

### Option 1: Check Documents

Select "Check documents" to validate project content.

#### Scope Selection

- **Project**: All segments across all documents and target languages
- **Active document**: Currently displayed translation editor document
- **Selected documents**: Multiple documents chosen from Translations pane
- **From cursor**: Segments below current position in active document
- **Open documents**: All documents with open translation editor tabs
- **Selection**: Only selected segments in active document
- **Work on views**: Processes segments through project views

**Single Language Option:** Select language in Translations pane, select all documents, choose "Selected documents."

### Option 2: Check Translation Memory

Select "Check translation memory" to validate a single TM from the project.

**Important:** This action erases previous warnings and errors from checked segments.

## Post-QA Actions

- **Proceed to resolve warnings after QA**: Opens Resolve errors and warnings tab immediately
- **Create view of inconsistent translations**: Displays inconsistent translations in the editor

## QA Report Generation

### Enable Report Export
Check "Export QA report to this location" for detailed HTML report.

- Default location: Documents folder with project name and QA date
- Custom location via Browse button

### Separate Translator Reports
Project managers can create individual HTML files per translator.

### Report Contents

**Project Details Section:** Information about project, documents, and settings used.

**Number of Errors and Warnings by Type Section:** Issues grouped by category with expandable sections.

**Filters Section:** Customize the issue list by clicking fields and selecting options.

**List of Errors and Warnings Section:** All detected issues with filter results.

## QA Results Display

In the translation editor, a lightning symbol appears in segments where QA detected at least one issue.

## Important Behavior Notes

When segments are confirmed, QA re-checks them but only executes "quick" checks -- not consistency checks. Warning indicators may disappear even without segment changes or QA settings modifications.
