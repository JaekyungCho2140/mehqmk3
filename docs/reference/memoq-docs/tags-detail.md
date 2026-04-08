# Tags in memoQ — Detailed Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-tags.html (memoQ 12.2)

## Uninterpreted Formatting Tags

### Definition & Purpose
memoQ uses placeholder tags ({1}, {2}, {3}, etc.) to represent formatting that differs from basic bold, italics, and underline. These tags also represent inline images, or certain types of whitespace (line breaks and tabulators).

### Key Characteristics
- Tags are "uninterpreted" until document export
- Display in the translation grid
- Cannot be reordered; F9 always inserts the next sequential tag
- Moving the insertion point backward causes memoQ to renumber tags

### Insertion Method
- Press **F9** at cursor position in target cell
- Can press F9 while actively typing

### Quality Assurance
- Segments with missing formatting tags display warning (lightning bolt) or error (!) icons
- Double-clicking opens the Errors window showing missing tag codes and descriptions
- All source tags must be inserted before export

### Invisible Tags
Segments with uniform formatting different from adjacent segments have invisible tag boundaries. Joining differently-formatted segments makes these tags visible.

## XML/XML-Like Documents

memoQ distinguishes two tag types:
- **Structural tags**: determine which XML sections contain translatable content
- **Inline tags**: additional markup within segments (XML, HTML, INX, MIF, XLIFF, TTX)

## Inline Tags

### Visual Indicators
- Opening tag: specific icon
- Closing tag: specific icon
- Empty tag: specific icon
- Default color: gray

### Manipulation Capabilities
Users can rearrange, add, or drop inline tags. Non-translated inline tags in XML documents are replaced with single tags for single-keystroke insertion.

### Verification
Inline tags are validated against the document's XML format; only specified tags and attributes are permitted.

### XML Quality Assurance
Despite free manipulation capability, memoQ performs validation checks producing warnings and errors. Results display on the "Resolve errors and warnings" tab.

## Special Inline Tags

Special tags have darker red backgrounds (customizable in Options > Appearance).

### Complete Tag Type Reference

| Tag | Source/Purpose |
|-----|---|
| `tw:it` | TTX and Trados bilingual RTF files |
| `st:it` | Star Transit (without "Treat markup as XML") |
| `mq:nt` | Non-translatable text placeholders in RTF/DOCX |
| `mq:it` | memoQ table RTF files or HTML tags (Java properties) |
| `mq:ch` | Special characters (tabs, Symbol/WingDings fonts in DOCX) |
| `mq:gap` | Legacy chained filter import tag (no longer used) |
| `mq:rxt-req` | Required Regex Tagger tags |
| `mq:rxt` | Normal Regex Tagger tags |
| `mq:txml-ut` | TXML tags (Wordfast imports) |
| `mq:pi` | HTML/XML processing information |
| `bpt, ept, ph, it` | XLIFF filter tags (when "Mask with bpt, ept, ph or it inline tags" selected) |

### Tag Behavior
- Special inline tags are unpaired and receive new numbers
- Exception: when two or more share identical type, name, and attributes
- Users can filter for specific tags (e.g., "mq:rxt") to locate edited or converted text

## Tag Strictness and Match Rates

### Strict Mode
Only segments with identical tag properties get a 100% score. Properties evaluated: position, type (opening/closing/empty/memoQ), name, and attribute names/values.

### Medium Mode
memoQ reports an exact (100%) match if the tags are the same type and occur in the same position as in the source text. Attribute differences don't lower match rates.

### Permissive Mode
memoQ returns an exact match if it finds a hit that has a tag or tag sequence everywhere where there is a tag or tag sequence in the source segment. Tag types and attributes become irrelevant.

### Common Behavior Across All Modes
All three settings permit TM/LiveDocs matches containing extra tags not present in the current source segment.

### Tag Adjustment Upon Insertion
When inserting TM hits, memoQ automatically adjusts target tags by:
- Mapping corresponding tag pairs between lookup and TM source segments
- Replacing TM target tags with lookup source tags
- Preserving unmatched extra tags from the TM target

### Configuration
Users modify tag strictness through the **Edit TM Settings** or **Edit LiveDocs Settings** dialogs.
