# Creating a New Translation Memory in memoQ

## Overview

A translation memory (TM) is a database containing source and target language segment pairs. The system enables memoQ to offer matches when translating, allowing reuse of existing translations.

## Accessing the New Translation Memory Window

### From Resource Console
1. Open the Resource console
2. Select Translation memories
3. Click "Create new" beneath the list

### From Local Project
1. Open a project
2. Navigate to Project home > Translation memories
3. Click "Create/Use New" on the Translation memories ribbon
4. For multi-target projects: Choose target language from dropdown first

### From Online Project
1. Open a project > Project home > Translation memories
2. Click "Create/Use New"
3. Select specific target language from dropdown

## Core Configuration Options

### Location Selection (Resource Console Only)
- Choose between "My computer" or "Remote" radio buttons

### Translation Memory Properties

**Name**: Enter unique name for the TM

**Source Language**: Select from dropdown menu

**Target Language**: Select from dropdown menu (inherited from project when created in project context)

**Path**: Auto-populated showing storage folder location (should not be changed)

### TM Type Selection

#### TM+ (Default in memoQ 10.5+)
- New TMs are TM+ format by default
- Clear "TM+" checkbox to create classic TM instead

**Storage Options for TM+:**

**Option 1: Store Context** (Recommended)
- Returns "context match" when both segment and context match
- Enables reconstruction of document translations
- Useful for updating translations in new source versions

**Option 2: Allow Multiple Translations** (Not recommended)
- Only recommended when importing from different tools with multiple translations
- Typically redundant when context storage is enabled

### Context Handling

#### Simple-Context Match (101% Match Rate)
- **Text Flow Context**: Previous and next segments in running text
- **ID-Based Context**: Identifier matching in tables or structured documents

#### Double-Context Match (102% Match Rate)
- Documents with both running text and identifiers
- memoQ checks both context types simultaneously

#### No Context Option (Not Recommended)
- Creates TM without context storage
- Should never be designated as working or master TM
- Cannot be modified after creation

### Reversible Translation Memory

**Default**: TMs are reversible by default
- Enables lookup in both source and target languages
- Cannot be modified after creation

### Document Name Storage

**Default**: Document names stored with segments
- "Store full path" checkbox for disambiguating identically-named documents

## Custom Fields Tab

### Overview
Each translation unit can contain metadata in custom fields. Maximum 20 custom fields per TM.

### Available Actions

**Add**: Create new custom field (name, type: text/picklist single/picklist multiple)

**Edit**: Modify selected custom field (name unchangeable after creation)

**Remove**: Delete custom field (only before clicking OK)

**Export Scheme to XML**: Save configuration for reuse

**Import Scheme from XML**: Load previously saved configuration

### Post-Creation Constraints
- Cannot change or remove custom fields after TM saved
- Only picklist values remain modifiable after creation
- Workaround: Export to TMX, create new TM, import TMX

## Completion Actions

**OK**: Creates TM with all configured settings
**Cancel**: Returns without creating TM
