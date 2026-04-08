# Segmentation Rules in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-segmentation-rules.html (memoQ 12.2)

## Overview

Segmentation is the process of splitting the text in a translation document into segments (translation units). Translators then create translation pairs consisting of source and target segments for storage in translation memory.

## Default Behavior

- Punctuation marks define segment boundaries by default
- Full stops typically mark sentence endings
- Exceptions exist: e.g., ordinal numbers in certain languages where a period doesn't indicate a new sentence

## Customization

- Segmentation rules are **language-specific resources** that can be edited
- memoQ includes pre-defined rules for most cases
- Users can modify and share custom rules to improve accuracy and flexibility

## Standards Support

memoQ offers support for the **SRX (Segmentation Rule eXchange) 1.0 standard** to provide 100% compatibility when migrating from other tools and recycling translation memories. Users can import SRX files through the Edit function.

## Technical Implementation

- memoQ's segmentation is based on **regular expressions**
- Regular expressions enable users to customize segmentation rules effectively
- Rules use lists (delimited by hash marks, e.g., `#listname#`) for abbreviations and punctuation
- Special break marker `#!#` creates segment breaks

## Key Points

- Segmentation rules are a **light resource** type
- They are applied at document import time
- Different languages may require different segmentation rules
- Rules can be imported/exported in SRX format
- Custom rules can override default behavior for specific patterns
