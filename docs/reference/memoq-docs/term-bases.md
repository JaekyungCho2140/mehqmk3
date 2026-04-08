# Term Bases Concepts in memoQ

## Definition and Purpose

A term base functions as a database containing word and expression pairs across multiple languages -- used like a glossary during translation work.

The primary objectives include:
- **Translation Consistency**: Maintaining uniform terminology across projects
- **Project Simplification**: Reducing complexity in demanding projects with specialized vocabulary
- **Translation Instructions**: Functioning as mandatory guidance, particularly in multi-translator environments where specific term base expressions must be used as specified

## Term Base Types by Location

memoQ recognizes three distinct configurations:
1. **Local**: Physically stored on the user's computer
2. **Online**: Stored on a remote server, accessible via Internet or local network
3. **Synchronized Online**: Hybrid approach with a primary remote copy and a local cache, enabling offline work with automatic synchronization upon reconnection

## Multilingual Structure

Term bases support multiple languages within single entries. Rather than restricting entries to source-target pairs, a term can occur in any number of languages within an entry. Language selection occurs during creation, with options to add additional languages later through three methods:
- Resource console modifications
- Term base editor properties dialog
- Project assignment with missing target languages

## Language Designation and Lookup

**Without Project Context**: All included languages maintain equal status with no designated source or target designations.

**Within Projects**: memoQ designates the project's source language for lookups and returns results in project target languages.

### Availability Criteria

A term base becomes available for a project when it contains:
- The project's source language
- At least one target language

The system accepts locale-specific variants as equivalents to neutral languages. For instance, "English (United Kingdom)" satisfies requirements for "English (neutral)" during lookups.

## Lookup and Term Addition Behavior

**Lookup Treatment**: memoQ will consider the neutral language and any locale- or region-specific language the same during term searches, accepting regional variants interchangeably.

**Term Addition**: When users create new terms, memoQ applies stricter matching, treating neutral and region-specific variants as distinct. The system prompts language addition if the exact variant is absent.

## Moderated Term Bases

Remote and synchronized online term bases support two governance models:
- **Unmoderated**: All users possess direct term addition capabilities
- **Moderated**: Users submit suggestions requiring terminologist approval before publication to other users. A term suggestion posted by a user appears to the user who posted it right from the moment of posting -- as if it were added to a local term base.

Moderated term bases cannot be converted to Qterm format.

## Feature Summary

memoQ's term base capabilities include:
- Multiple access configurations (local, online, synchronized)
- Rich entry information storage
- Multiple concurrent term bases per project
- Automatic segment lookup during translation
- Inline term creation without editor exit
- Moderation workflows for collaborative environments
- Dedicated term base editor for comprehensive management
- Export/import compatibility with tabular formats (CSV)
