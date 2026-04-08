# Ignore Lists in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-ignore-lists.html (memoQ 12.2)

## Purpose

Ignore lists contain words and expressions that should be skipped during spell checking operations.

## How They Work

memoQ defines words as a sequence of non-whitespace characters, surrounded by whitespace or a segment boundary. Before invoking the spell checker, the system searches the active ignore lists for each word. If found, the word is marked correct without further verification.

## Smart Lookup Features

### Case Flexibility
Words in uppercase or mixed case match lowercase entries in the list.

### Trailing Periods
Words with periods match list entries without them.

### One-Way Matching
The reverse doesn't apply: "etc." in the list won't validate "etc" without the period in text.

## Access and Management

Ignore lists cannot be edited through the Settings pane in Project home. Instead:
1. Navigate to the **Translation ribbon**
2. Click **Spelling**
3. Select **"Ignore these"** to manage active ignore lists
