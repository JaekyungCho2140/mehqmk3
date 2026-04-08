# Tags in memoQ

## Uninterpreted Formatting Tags

### Definition and Purpose

Uninterpreted formatting tags are placeholders representing formatting other than the three basic types which are bold, italics and underlined. Rather than displaying complex formatting directly, memoQ converts these into numbered tags like {1}, {2}, {3}.

### When Tags Appear

Tags display to represent:
- Uniform formatting changes throughout a document
- Inline images
- Types of whitespace (line breaks and tabulators)

The term "uninterpreted" indicates that the actual meaning of the tags (what type of formatting change they stand for) is ignored until the document is exported.

### Tag Insertion Process

**Methods to insert tags:**
- Place cursor in target cell and press F9
- Press F9 while actively typing the translation

**Key behaviors:**
- Cannot manually change tag order; F9 always inserts the next sequential tag
- Moving insertion point backward and pressing F9 causes memoQ to renumber tags
- Meaning of tags is restored only during document export

### Quality Assurance for Formatting Tags

memoQ marks target segments containing formatting tags with warning symbols:
- Lightning bolt icon (warning level)
- Exclamation mark icon (error level, depending on QA settings)

These indicators persist until all formatting tags from the source are inserted into the target cell. Double-clicking these symbols opens the Errors window displaying missing tag codes and descriptions.

**Invisible tags:** Segments with uniform formatting different from adjacent segments create invisible tags at boundaries. These become visible only when joining segments with different formatting.

---

## Inline Tags

### Visual Representation

Inline tags display distinctly from uninterpreted formatting tags using three icon types:
- **Opening tag**: Visually distinct opening marker
- **Closing tag**: Visually distinct closing marker
- **Empty tag**: Self-closing tag marker

Default color is gray.

### Key Characteristics

Unlike uninterpreted tags, translators can:
- View tag type, name, and attributes
- Freely rearrange inline tags
- Add or drop tags as needed
- Manipulate tag information using commands on the Edit ribbon

### XML and XML-Like Documents

memoQ distinguishes two tag categories in structured documents:

1. **Structural tags** - determine which XML sections contain translatable content
2. **Inline tags** - represent additional markup appearing inside segments

Inline tags appear in: XML, HTML, INX, MIF, XLIFF and TTX documents.

### Non-Translated Content

In XML documents, inline tags can be marked as non-translated (indicating text within tags shouldn't be translated). memoQ replaces these inline tags and their contents with a single tag, so the translator can insert them by a single key shortcut.

### Validation and Constraints

- Inline tags are verified against the XML format used to import the document
- Only tags and attributes listed in the format specification can be used
- Predefined XML format settings exist for specific formats (INX, MIF)
- memoQ automatically converts special character sequences into tags

---

## XML Quality Assurance

Because inline tags can be manipulated freely, you can accidentally produce invalid documents. However, memoQ performs automated checks generating warnings if resulting documents might be invalid.

---

## Special Inline Tags

### Definition

Special inline tags (like mq:ch for characters) use a darker red background color that can be changed in Options, under Appearance.

### Complete Tag Reference

**From TTX and bilingual RTF files:**
- tw:it - TTX and Trados bilingual RTF inline tags
- st:it - Star Transit tags

**From RTF/DOCX files:**
- mq:nt - placeholder for non-translatable inline text
- mq:ch - general placeholder for special characters (tabs, Symbol/WingDings fonts)

**From memoQ and HTML:**
- mq:it - memoQ table RTF tags; HTML tags from Java properties filter

**From advanced features:**
- mq:gap - formerly used in chained filter import
- mq:rxt-req - required tags from Regex Tagger
- mq:rxt - normal Regex Tagger tags
- mq:txml-ut - TXML tags in Wordfast file imports
- mq:pi - HTML and XML processing information tags

**From XLIFF generic filter:**
- bpt (with "val" attribute only)
- ept (with "val" attribute only)
- ph (with "val" attribute only)
- it (with "val" attribute only)

### Tag Numbering

Special inline tags are not paired and will always receive a new number. Exception: when two or more tags in a segment share identical type, name, and attributes, they may receive the same number.
