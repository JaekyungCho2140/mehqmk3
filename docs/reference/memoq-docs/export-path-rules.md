# Export Path Rules in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-export-path-rules.html (memoQ 12.2)

## Definition

Export paths define a naming convention for managing file naming and storage locations during translation project exports.

## Use Cases

- Multi-file projects store files in nested folders requiring target language codes in filenames
- Customers request identical names but different storage locations
- Creating new folders with target language codes under original directories

## Functionality

An export path rule defines a conversion between the name and location of an import file (e.g., `C:\memoQ localization\Export_path_rules.xml`) and the desired name and location of the files you export after translation.

## Syntax Components

Example: `<BasePathAbs>\\..\\mqWeb_9_2_translated\\<RelativePath>\\<OrigFileNameExt>`

| Component | Description |
|-----------|-------------|
| `<BasePathAbs>` | Absolute base path with drive letter |
| `<RelativePath>` | Relative path (without drive letter) |
| `<OrigFileNameExt>` | Original filename and extension |

## Key Points

- Export path rules are a **light resource** type
- They can be shared, imported, and exported
- Rules support variable substitution for language codes and paths
- Useful for maintaining parallel directory structures in source/target languages
