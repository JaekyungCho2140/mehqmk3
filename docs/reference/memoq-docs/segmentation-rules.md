# Segmentation Rules in memoQ

## Core Concept

Segmentation is the process of splitting text in translation documents into discrete units called segments or translation units. Each segment becomes a translatable element that pairs source text with target translation for storage in translation memory.

## Default Segmentation Behavior

By default, the segment boundaries are punctuation marks. Typically, a period indicates sentence completion and represents a meaningful translation unit. However, exceptions exist -- for instance, a full stop is not followed by a new sentence, e.g. in the case of an ordinal number in some languages.

## Rule Structure and Language Specificity

Segmentation rules are language-dependent resources within memoQ. The system provides pre-configured rules suitable for most use cases, though these can be modified as needed.

## Technical Foundation

memoQ's segmentation is based on regular expressions -- an extremely powerful tool for working with text. This technical approach enables flexible customization of segmentation behavior.

## Customization and Sharing

Users can edit and share segmentation rules, allowing teams to tailor segmentation to specific needs and increase accuracy for particular content types or language pairs.

## Standards Compatibility

memoQ supports the SRX (Segmentation Rule eXchange) 1.0 standard for migrating from other translation tools. This compatibility ensures translation memories can transfer without loss of data. Users import SRX files through the resource editing interface.
