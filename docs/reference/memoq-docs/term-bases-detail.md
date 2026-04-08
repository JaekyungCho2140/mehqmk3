# Term Bases in memoQ — Detailed Reference

> Source: https://docs.memoq.com/current/en/Concepts/concepts-term-bases.html + concepts-term-bases-inside-an-entry.html (memoQ 12.2)

## Core Definition

A term base is a database containing pairs of words or expressions (terms) in multiple languages. Term bases function as glossaries/translation instructions for projects.

## Key Features

- Support for local, online, and offline term bases
- Rich information storage per entry
- Multiple term bases per project
- Multilingual structure with automatic language management
- Real-time lookup during translation work
- Add terms without leaving the editor
- Server-based moderation options
- Dedicated term base editor
- Import/export via CSV and other text formats

## Three Term Base Types (by Location)

| Type | Description |
|------|-------------|
| **Local** | Stored on user's computer |
| **Online** | Remote access via Internet or network |
| **Synchronized Online** | Remote primary + local working copy with sync |

## Language Management

- Term bases contain specific language sets selected at creation
- Languages can be added later through Resource console, term base editor, or project language additions
- Available to project if it includes the project's source language AND at least one target language
- Accepts locale-specific variants when neutral languages are specified

## Moderation

| Mode | Behavior |
|------|----------|
| **Unmoderated** | All users add terms directly |
| **Moderated** | Suggestions require terminologist approval; original poster sees own suggestions immediately |

## Entry Structure (3-Level Hierarchy)

### 1. Entry Level (Concept)
The overarching concept containing one or more terms in multiple languages.

**System-Generated Properties:**
- ID (auto-generated, unchangeable)
- Created by / Modified by (author tracking)
- Created at / Modified at (automatic timestamps)

**User-Editable Properties:**
- Note (comments or source references)
- Project (translation project identifier)
- Domain (broader subject category)
- Client (commissioning party)
- Subject (specific subcategory within domain)
- Image (optional visual representation)

When entries are created within projects, memoQ auto-populates Project, Domain, Client, and Subject from project settings.

### 2. Language Level
Each language version supports a single definition — a description of the concept in that language.

### 3. Term Level
Individual expressions within each language.

**Matching Options:**
| Mode | Description |
|------|-------------|
| Fuzzy | Handles word form variations |
| 50% prefix | Default; partial matching |
| Exact | Precise form only |
| Custom | Wildcard-based matching |

Matching operates at word/phrase starts (prefix-based).

**Case Sensitivity:**
| Mode | Description |
|------|-------------|
| Yes | Exact case required |
| Permissive | Uppercase must match; lowercase flexible |
| No | Case-insensitive |

**Additional Term Controls:**
- Forbidden term designation (prevents usage suggestions)
- Example (usage demonstration)
- Part of speech
- Gender
- Number (grammatical)
