# Project Home - Translations Pane (memoQ Translator Pro)

## Overview

The Translations pane serves as the central workspace where translators manage documents, track progress, and oversee translation workflow.

## Accessing the Translations Pane

Navigate to Project Home and select the Translations tab. Documents typically appear automatically if the project was created from a template or imported from the Dashboard.

## Document List Display Modes

### Standard List View
The default presentation shows all documents in a flat list format with relevant columns and progress indicators.

### Structure View
Activating Structure mode organizes documents hierarchically by target language and folder structure. Each grouping can be expanded or collapsed using arrow icons. Embedded objects appear as expandable sub-items beneath parent documents.

### Path View
When multiple documents share identical names from different source folders, activating Path view displays relative folder paths to differentiate them.

## Document List Columns and Information

**Name Column**
Contains document titles. In Structure mode, expandable groups show language and folder organization.

**Document Status Icon**
Indicates translation workflow state (in progress, complete, Review 1 complete, Review 2 complete). Hovering reveals the specific status message.

**Version Column (V)**
Displays two numbers: source text version (first) and translation version (second).

**Segment/Word/Count Column (#)**
Shows document size measurable in segments, words, or characters. Right-clicking the document list allows users to select the preferred unit via "Base progress on" option.

**Progress Indicator**
Visual representation showing completion percentage based on the selected unit.

## Details Pane

Clicking the Details button reveals an extensive information panel displaying:

- Document type and format
- Import path source location
- Export path destination folder and filename
- Filter configuration used during import
- Size in segments, words, and characters
- Embedded objects count
- Target language assignment
- Workflow phase status
- Assignment table showing user roles with progress percentages
- Translate action icon for opening documents

## Document Management Actions

### Import Operations

**Standard Import** - Opens a file browser to select documents with default filters applied automatically.

**Import with Options** - Provides filter customization and format selection before import. Recommended for Excel, XML, plain-text, and bilingual Word documents.

**Import Folder Structure** - Imports entire directories with subdirectories intact.

**Import Package** - Accepts memoQ (.mqout) or SDL Studio (.sdlppx) package files.

### Remove Documents
Deletes selected documents from the project database without affecting original source files.

### Reimport Documents
Reloads documents from original source location, incrementing the major version number.

## Sorting, Searching, and Filtering

**Sort Options:** Sort by document name, status, workflow status, version, size, language, progress metrics, user role assignment, deadline dates, embedded object presence.

**Search Function:** Enter keywords to filter documents by name.

**Advanced Filtering:** Click Edit icon for complex filter conditions.

## Translation and Review Workflow

### Opening Documents for Translation
Double-click a document name, right-click and select "Open For Translation," or select a document and click Translate on the Documents ribbon.

## Export Operations

**Export Bilingual** - Creates bilingual documents in RTF, Trados DOC/RTF, or XLIFF format.

**Export (Choose Path)** - Manual path selection for export destinations. Warnings appear if documents contain errors.

**Export (Stored Path)** - Exports to pre-configured locations.

**Change Export Path** - Modifies destination paths.

## Analysis and Preparation Operations

**Statistics** - Counts segments, words, characters; performs analysis against TMs and LiveDocs.

**LQA Reports** - Compiles Linguistic Quality Assurance feedback.

**Pre-translate** - Populates documents from TMs and LiveDocs.

**X-translate** - Retrieves matching translations from previous document versions after reimport.

## View Creation and Management

Views consolidate multiple documents or segments into single working units without modifying original documents.

### Creating Views

**Glue Documents** - Combines multiple documents into one view.

**Split Document** - Extracts specific row ranges from longer documents.

**Segment Filtering** - Filter by conditions, repetitions, or advanced filtering/sorting parameters.

### View Characteristics
- Views maintain direct links to original documents
- Editing view segments updates corresponding original segments
- Views support pre-translation, X-translation, statistics, and reporting
- Views cannot be exported as translated documents
- Views can be exported as bilingual formats

### View Management
- Views Tab lists all created views
- Double-click to open in translation editor
- Cannot edit views while source documents are open
