# Translation Results Settings

## Access Method

Open the Translation results settings window by:
1. Launch a document for translation
2. In the Translation results pane, double-click the eye icon

## Settings Categories

### Translation Memory and LiveDocs Corpus Filtering

**Filter and limit translation memory and corpus hits**
- Checkbox: Display only one hit per identical target segment

**Maximum number of translation memory and corpus hits shown**
- Configurable field to specify desired suggestion count

**Show corpus hits without translation**
- Checkbox to display suggestions from monolingual LiveDocs documents

### MatchPatch Configuration

**Patch fuzzy TM matches**
- Primary checkbox for automatic matching improvement
- "Include TM fragments (LSC hits)": Enables TM fragment usage
- "Store patched match rate instead of original match rate": Saves improved metrics

### Term Base Suggestion Management

**Longest source term hides shorter matches**
- When active, conceals shorter terms contained within longer matching terms

**Source term translation limitation**
- Single translation display per identical source term during filtering

**Suggestion ordering options** (radio buttons):
- Order of appearance in text
- Alphabetical arrangement

**Order term base hits primarily by rank**
- When enabled: sorts by term base ranking plus descriptive details (client, domain, subject)
- When disabled: prioritizes source position or alphabetical order

**Show term base hits with empty target**
- Checkbox to display suggestions lacking target language translation

### Performance Adjustment

**Delay before showing translation results**
- Millisecond-based input field for list display postponement
- Default: half-second delay to optimize typing speed

## Completion Actions

- **OK**: Saves configuration changes
- **Cancel**: Discards modifications
