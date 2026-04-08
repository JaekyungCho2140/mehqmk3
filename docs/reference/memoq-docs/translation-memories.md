# memoQ Translation Memories: Complete Documentation

## Overview

memoQ projects integrate translation documents with resources, with translation memory (TM) being a primary resource type. A TM functions as a database containing pairs of translation units of the original text (source segments) and their translations (target segments).

## Core TM Features

### Fundamental Capabilities
- Local, online, and offline translation memory access and setup
- Automatic word and expression lookup within TM segments
- Multiple translation storage options for identical segments
- Customizable TM settings per memory
- Concordance search functionality for direct word/sequence lookup
- Translation memory editor for comprehensive review and modification
- Working (primary) and master TM designation per project

### Translation Memory Properties

Each TM contains modifiable and fixed properties:

**Editable Properties:**
- Subject, domain, path, description
- Client and author information
- Read-only status designation
- Entry count visibility
- Context usage parameters
- Multiple translation allowance settings

**Fixed Properties:**
Properties established during TM creation cannot be modified afterward.

## Context in Translation Memories

### Simple Context Operation

memoQ analyzes each segment alongside surrounding segments. During translation, confirmed segments and contextual segments automatically store in the TM. Identical segments with identical surrounding segments generate "ContexTM match with a 101% match rate."

### Context Definition

Context varies by document format:

**Running Text Formats:**
- Microsoft Word documents
- HTML files
- Plain text documents
- FrameMaker
- InDesign

Context uses the source text from the previous and the next segments.

**Structured Formats:**
- Excel workbooks use column or cell-based context
- XML files employ neighboring elements or attributes
- ID-based context methods apply to tables and data structures

### Context Configuration

Simple context radio button is turned on by default when creating new TMs. Context settings cannot be changed after TM creation -- users must select "No context" before creation completion to prevent context storage.

### Document Update Applications

Context TM matches enable document updates without requiring original source documents. Reused text blocks generate substantial 101% matches from stored context. The system represents reused sequences as: initial 100% match, middle 101% matches, final 100% match.

**Double Context Matches:**
When context ID and text flow matches, systems generate 102% (double context) matches displayed in Statistics with x-translated counts.

### Context as Translation Backup

Pre-translation can correctly re-populate segments in corrupted documents through context TM matches, ensuring retrieval of all segments functioning as context for each other, appearing as 101% matches.

## Multiple Translations

### Allowance Configuration

Creation dialog enables selection of single or multiple translation allowance per identical segment. Single-translation mode causes new translation replaces the older one in the memory.

### Context Interaction with Multiple Translations

Two segments with the same source text but different context count as two different segments, permitting identical source segments in TMs disallowing multiple translations. One 101% match coexists with multiple 100% matches when same source segment appears in the TM in different contexts.

### Usage Recommendations

TMX import from non-context-supporting tools benefits from multiple translation allowance. Recommendation: use such translation memories for reference only, and use a context-enabled translation memory without allowing multiple translations as the primary translation memory.

## Multiple Match Scenarios

### Occurrence Conditions

- Single TM: one 101% match maximum
- Multiple TMs: each may produce 101% matches
- Context-enabled single TM: one 101% plus multiple 100% matches possible
- Role penalties: suppress hits by specified roles
- Unambiguous matches: pre-translate with "Exact match, Only unambiguous matches" settings

### Locked Row Handling

Run Statistics with locked rows to exclude 100%/101% ambiguous matches. Clear "Include locked rows checkbox" to analyze only ambiguous matches.

## Translation Memory Types

### Local Translation Memories
Physically resident on user's computer, registered via "Register local" or "Use in project" commands on Translation memories ribbon or Resource console.

### Online Translation Memories
On a remote computer and can be accessed through the Internet or the local network. Availability depends on internet connectivity. Multiple team members contribute to shared memory simultaneously. New segment handling depends on project manager configuration.

### Synchronized Offline Translation Memories
Hybrid of the above two with primary remote copy and local computer copy. Users work offline; synchronization occurs upon reconnection, updating both copies. Create through "Synchronize offline" selection of online TM in Translation memories pane.

## Roles in Translation Memories

### Role Storage and Function

memoQ records user roles (Translator, Reviewer 1, Reviewer 2) for committed segments. All translation memories created from memoQ 2013 R2 and higher include the Role field, though older TMs receive role updates only for newly added segments.

### Role Behavior

- Role information functions as part of the context for the affected segment
- Same source with identical context can have three different translations by the 3 user roles
- Roles don't affect 101% matches absent penalties
- Penalties function as other TM penalties (the given penalty is subtracted from the match rate)
- TM editor displays "Last modified role field" (non-editable)
- Checkboxes in "Showing TM entries section exclude TM entries from certain roles" in Translation results pane

### Configuration

Role storage defaults to enabled; disable in TM settings disables role recording.

## Working and Master Translation Memories

### Primary (Working) TM
Most likely your working TM where memoQ stores all confirmed segments during translation and review phases.

### Master TM
All translations once the project is finished and delivered containing final and approved translations.

### Online Project Modifications

Translators checking out online projects can modify local working TM designation if project manager set master TM as working TM. Local changes don't affect online projects; PM updates override local choices during synchronization.

### Permission Constraints

Translators typically lack write permissions for master TMs: implicit project permissions gives the PMs admin rights to the master TM, but only lookup rights to everyone else. Subvendor PMs receive identical permissions, preventing master TM updates in online projects.

### Automated TM Management

Project templates enable automated steps to delete your working TM and automatically confirm and update your master TM.

## Match Rates from Translation Memories

### Exact Match (100%)
The source text in the segment text is exactly the same as the match from the translation memory. Context information either doesn't match or remains unknown.

### Nearly Exact Match (95%-99%)
Source text matches precisely, though minor variations exist. Numbers, tags, punctuation marks and spaces might be different. This represents optimal pre-translation matching under default configurations.

### Fuzzy Match (50%-94%)
Source text demonstrates similarity with textual differences present. memoQ categorizes fuzzy matches into three classes:
- **High Fuzzy (85-95%)**: In segments averaging 8-10+ words, typically one-word differences appear
- **Medium Fuzzy (75-84%)**: Similar-length segments show approximately two-word variations
- **Low Fuzzy (50%-74%)**: Segments contain differences exceeding two words

Note: If the segment text is shorter than average, the match rate number and the actual difference in the text may not correspond so clearly.

### Exact Match with Context (101%)
Identical source text plus matching context. In running text, the context is the source text of the previous and the next segment. For structured/tabular documents, context includes identifier labels (IDs).

### Double Context Match (102% or XLT)
The source text in the segment text is exactly the same as the match from the translation memory. Both surrounding segments and ID context match identically, enabling document reconstruction.

### Asterisk Notation (*100%, *101%, *102%)
When multiple exact or context matches exist for one segment, the asterisk indicates uncertainty regarding match quality. There is no guarantee that the one that was inserted was the best.

### Penalties
memoQ applies rate reductions for:
- Matches from unreliable translation memories
- Matches from untrustworthy translators
- Matches from unreviewed document alignments
- Matches from unreviewed LiveDocs corpora
- Matches from document pairs lacking confirmed alignment review

### Automatic Adjustments
memoQ will substitute numbers if it can, enabling matches where numerical differences were corrected automatically.

### Patching
When memoQ adjusts tags and text from term base matches, it boosts the resulting rate, typically aligning with fuzzy match categories. The percent value will be preceded by an exclamation mark (!).
