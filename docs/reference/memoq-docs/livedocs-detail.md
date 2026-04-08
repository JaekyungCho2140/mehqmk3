# LiveDocs in memoQ — Detailed Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-livedocs.html + concepts-livedocs-settings.html (memoQ 12.2)

## Overview

LiveDocs is a resource type in memoQ that supports multiple document formats through distinct technologies, enabling reuse of existing translations without traditional TM import.

## Document Types / Technologies

### Library Technology
- Stores **monolingual documents** in target languages
- Users access via Concordance to check solutions

### ActiveTM Technology
- Handles **bilingual documents** translated within memoQ
- Provides matching results during translation work
- Functions similarly to translation memories

### LiveAlign Technology
- Processes original documents and translations through **automatic alignment**
- Users can edit segment links, and the system realigns accordingly
- Revolutionary: shifts the alignment process into the translation process
- Enables on-the-fly corrections without pre-alignment

### EZAttach Technology
- Manages **binary reference materials** (PDFs, drawings, software)
- Double-clicking opens files in appropriate viewers

## Core Features

- Setup and access for local and online corpora
- Customizable settings per corpus
- Direct word/phrase lookup via Concordance tool
- Document review and editing through LiveDocs editor
- Standard resource handling capabilities

## Access Types

### Local LiveDocs
- Physically present on user's computer
- Registered via Resource console or "Use In Project" button

### Online LiveDocs
- Remote access via Internet or local network
- Included automatically with online projects
- Supports team collaboration for document additions and segment realignment

## Import Methods

Users access import functions through Project home's LiveDocs ribbon tab using:
- **Import Documents**
- **Import with Options**
- **Import Folder Structure**

## LiveDocs Settings

### Thresholds & Penalties
- Thresholds establish limits for what qualifies as a match or good match
- Penalties are percentages automatically subtracted from match rates
- Default threshold values are pre-configured
- Default penalty applies to matches from LiveAlign

### Customizable Penalty Categories
- User-specific penalties
- Penalties for specific LiveDocs corpora
- Penalties for documents containing specific keywords
- Penalties for deprecated documents
- Penalties for documents with different sublanguages
- Penalties for segments with different segment types (in ActiveTM)

### Configuration
- Multiple LiveDocs settings sets can be created
- Only one settings set can be active per LiveDocs corpus
- Default global and project-level settings available
- Individual corpus settings adjustable via LiveDocs ribbon > Settings

## Alignment Details

### Workflow
1. Create or select a LiveDocs corpus
2. Add alignment pairs or import monolingual documents and link them
3. Choose:
   - **Align on the fly**: Proceed to translation immediately; fix alignment errors via right-click > "Show document"
   - **Review first**: Click "View/Edit" to access the alignment editor

### Alignment Editor
- Dedicated tab in the memoQ main window
- Users revise alignment results and correct inaccuracies
- Uses statistical and linguistic algorithms
- Processing may take several minutes based on document length
- memoQ's automatic alignment is quite accurate, though human revision is necessary

### Output Options
Users can create translation memories from aligned documents if desired.
