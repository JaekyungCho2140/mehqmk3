# Term Base Entry Structure in memoQ

## Three-Level Hierarchy

A term base entry operates on three distinct levels:

1. **Entry** - The concept or object as a whole
2. **Language** - The language version of that concept
3. **Term** - Individual names or expressions within each language version

Example: An entry representing "term base" contains English variants ("term base," "termbase"), German ("Terminologiedatenbank"), and Hungarian ("terminologiai adatbazis," "terminus-adatbazis").

---

## Entry-Level Properties

These describe the concept across all languages:

- **ID**: Auto-generated unique identifier (non-editable)
- **Note**: Text field for comments or references related to the entry
- **Project**: Translation project identifier where entry was created
- **Domain**: Broader category or subject area (inherited from project by default)
- **Client**: The client for whom the entry was created
- **Subject**: More specific description or sub-topic within the domain
- **Created by**: Username of entry creator
- **Modified by**: Username of last editor
- **Created at**: Timestamp of entry creation
- **Modified at**: Timestamp of last modification
- **Image**: Optional visual illustration of the concept

**Auto-populated fields**: When created within a project, memoQ automatically fills Project, Domain, Client, and Subject from project settings. Users may customize these afterward.

**Editable user fields**: Subject, Domain, and Note can be manually edited.

---

## Language-Level Properties

Each language version of an entry contains:

- **Definition**: A description of the concept in that language. You may add exactly one description per language.

---

## Term-Level Properties

Individual terms within a language version have specific properties controlling matching behavior:

### Matching Options

- **Fuzzy**: Matches word forms and variations (e.g., German "Mutter"/"Mutter"), useful for compound words
- **50% prefix** (default): Allows partial prefix matching (e.g., "project" matches "projects" but not "project-specific")
- **Exact**: Matches only the precise term form
- **Custom**: Uses wildcards for advanced matching (e.g., "Wassert|urm" matches "Wasserturm" and "Wasserturme")

*Constraint*: Matches occur only at the start of expressions -- terms must function as word/phrase prefixes.

### Case Sensitivity Options

- **Yes**: The term will only match if it appears exactly as you typed it including capitalization; useful for proper names, abbreviations (TBD, XML)
- **Permissive**: Uppercase letters must match exactly; lowercase letters are flexible
- **No**: Makes terms case-insensitive, matching regardless of capitalization

### Additional Term Properties

- **Forbidden term**: A word or phrase that shouldn't be used in translation. Source forbidden terms don't appear in translation results; target forbidden terms appear in black text without highlighting
- **Example**: Sample phrase or sentence demonstrating term usage
- **Part of speech (POS)**: Grammatical category (noun, adjective, adverb, verb, etc.)
- **Gender**: Masculine, feminine, or neutral designation
- **Number**: Singular or plural form
