# LiveDocs Concepts in memoQ

## Overview

LiveDocs is a resource type in memoQ that enables users to store and retrieve multiple document formats within unified corpora. A single corpus can contain different document types simultaneously.

## Document Types in LiveDocs

### Library Technology
Monolingual documents can be added to LiveDocs corpora in target languages. Users access these through the Concordance feature to verify translation choices. The technology allows translators to locate appropriate terminology without leaving the application to search for external materials.

### ActiveTM Technology
This system treats bilingual documents like translation memories. Documents translated through memoQ become available for matching during active translation work. Key features include:

- Prevents translation memory pollution with questionable content
- Imported via "Import Document or the Import Folder Structure button"
- Documents are available immediately after import for use in matching
- Editable through View/Edit ribbon option or by right-clicking matches

Users can move finished project documents into LiveDocs corpora using the "Add to LiveDocs" feature on Project home.

### LiveAlign Technology
Revolutionary alignment methodology that integrates alignment into the translation workflow rather than treating it as preliminary. Traditional alignment requires:

- Pre-translation alignment completion
- Storage in translation memory (preventing later correction)
- Advance assessment of alignment value

LiveAlign eliminates these constraints by allowing immediate segment reuse with real-time correction capability. Users can fix it on the fly, and LiveAlign document pairs will become better and better.

Import methods include "Add alignment pairs" and "Link documents" buttons.

### EZAttach Technology
Accommodates third-party file formats as reference materials (PDFs, drawings, software, etc.). Files open in appropriate viewers upon double-clicking. Import process:

1. Click Import Documents on LiveDocs ribbon
2. Select binary file (may require "All files" filter selection)
3. Application automatically applies "Import as is (Binary)" filter
4. Confirm with OK button

## Corpus Access Models

### Local LiveDocs
Physically stored on individual computers. Registration occurs through "Register local" in the Resource console, or use "Use In Project" on Project home ribbon.

### Online LiveDocs
Remote corpora accessed via Internet or local networks. Characteristics:

- Included automatically when checking out online projects
- Require active online connection for access
- Support collaborative contribution (document addition, segment realignment, editing)
- Entry handling depends on project manager settings
- Selection via Server URL configuration and checkbox selection at Project home

## LiveDocs Management Features

- Customizable settings for each corpus
- Concordance lookup for specific words or sequences
- Document review and editing through dedicated LiveDocs editor
- Standard resource handling capabilities (shared across resource types)
