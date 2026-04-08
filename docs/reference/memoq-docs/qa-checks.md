# Quality Assurance (QA) Warnings in memoQ

## Overview

memoQ's automated QA module performs over a hundred different types of checks - about numbers, spaces, punctuation marks, the consistency of terms, the length of segments, and many more. Regular expression checks enable practically unlimited automated validation possibilities.

## QA vs. LQA Distinction

QA differs from Linguistic Quality Assurance (LQA). While QA is automated, LQA is a way of adding human feedback to documents where reviewers structure feedback and grade translations.

## Configuration

**QA Settings Resources:**
- Exactly one QA settings resource must be selected per project
- Settings are configured through QA settings resources
- Access points: Project home Settings pane or memoQ online project window
- Modifications: Right-click QA settings and select Edit

## Complete QA Warning Categories

### Tag Issues (Codes 1001-2017)

| Code | Warning | Details |
|------|---------|---------|
| 1001 | memoQ {tags} tags do not match | Remove unnecessary ones for extra tags |
| 1002 | memoQ {tags} tags do not match | Add them to maintain formatting for missing tags |
| 2001 | missing required attribute | Required attribute {1} absent in tag {0} |
| 2003 | overlapping tag pairs | May cause formatting issues |
| 2004 | missing required tag | Copy missing tags from source |
| 2007 | undefined tag | Tag {0} not defined in document settings |
| 2008 | undefined attribute | Attribute {0} unrecognized for tag {1} |
| 2009 | incorrect value in translatable attribute | Direct text in attribute may cause issues |
| 2010 | inline tags in target not well-formed against source | Compare formatting with source |
| 2011 | missing inline tag | Add missing inline tag {0} |
| 2012 | no tag in source for tag with translatable attribute | Missing tags with translatable attributes {0} |
| 2013 | translatable attribute points to wrong segment | Correct pointing attribute {0} in tag {1} |
| 2014 | missing or not properly located translatable attribute | Misplaced or missing in tag {0} |
| 2015 | extra inline tag | Remove unnecessary inline tag {0} |
| 2016 | changed tag order | Tag ordering differs from source |
| 2017 | non-translatable tag sequence changed | Structure inconsistency with source |

### Segment Content Issues (Codes 3010-3040)

| Code | Warning | Details |
|------|---------|---------|
| 3010 | empty target segment | The translation text is missing |
| 3020 | ending punctuation different | Source and translation end differently |
| 3030 | first letter's capitalization | Capitalization differs from source |
| 3040 | target segment equals source | Identical translation to source |

### Whitespace Issues (Codes 3050, 3110)

| Code | Warning | Details |
|------|---------|---------|
| 3050 | multiple consecutive whitespaces | Multiple consecutive spaces detected |
| 3110 | space at end of segment | Consider removing it |

### Number Format Issues (Codes 3061-3069)

| Code | Warning | Details |
|------|---------|---------|
| 3061 | non-standard number format in the target | Invalid format based on language settings {0} |
| 3062 | numbers do not match | Numbers {0} and {1} inconsistent |
| 3063 | missing number from the target | Number {0} absent in translation |
| 3064 | extra number in the target | Unnecessary number {0} present |
| 3065 | full-width digits in the target | Non-standard full-width digits {0} |
| 3067 | strict formats do not match | Values {0} and {1} inconsistent |
| 3068 | numbers with different format | Formatting differs between source {0} and translation {1} |
| 3069 | target number should be grouped | Number {0} requires language-appropriate grouping |

### Spacing Around Signs (Codes 3071-3076)

| Code | Warning | Details |
|------|---------|---------|
| 3071 | space missing before sign | Space required before {0} |
| 3072 | extra space before sign | Unnecessary space before {0} |
| 3073 | space missing after sign | Space required after {0} |
| 3074 | extra space after sign | Unnecessary space after {0} |
| 3075 | non-breaking space missing before sign | Non-breaking space needed before {0} |
| 3076 | non-breaking space missing after sign | Non-breaking space needed after {0} |

### Punctuation Issues (Codes 3077-3089)

| Code | Warning | Details |
|------|---------|---------|
| 3077 | different number of quotes/brackets | Quotation marks or brackets differ |
| 3078 | non language-specific punctuation mark | Punctuation {0} incorrect for this language |
| 3079 | incorrect sequence of punctuation marks | Sequence {0} appears incorrect |
| 3080 | missing language-specific punctuation marks | No punctuation defined for {0} |
| 3086 | extra quote/bracket | Extra punctuation mark {0} detected |
| 3087 | missing quote/bracket | {0} is missing |
| 3088 | quote/bracket without a pair | {0} lacks matching pair |
| 3089 | source and target quotes/brackets do not match | {0} in translation vs {1} in source |

### Length Issues (Codes 3081-3084)

| Code | Warning | Details |
|------|---------|---------|
| 3081 | translation too short | Translation shorter than source |
| 3082 | translation too long | Translation significantly longer than source |
| 3083 | translation longer than limit | Length {0} exceeds limit {1} characters |
| 3084 | translation longer than configuration limit | Length {0} exceeds configured limit {1} |

### Terminology Issues (Codes 3085, 3091-3101)

| Code | Warning | Details |
|------|---------|---------|
| 3085 | Duplicate words | Repeated words {0} detected |
| 3091 | missing term | Term {0} missing; consider using {1} |
| 3092 | extra term | Extra term {0} detected |
| 3093 | forbidden term | Term {1} should not translate as {0} |
| 3097 | forbidden term without a source equivalent | Term {0} disallowed; use {1} instead |
| 3098 | forbidden term in the source | Term {0} forbidden in source text |
| 3100 | inconsistent translation | Same source with different translations {1} |
| 3101 | inconsistent translation | Different sources with same translation {1} |

### Non-translatable Elements (Codes 3094-3096)

| Code | Warning | Details |
|------|---------|---------|
| 3094 | missing non-translatable | Non-translatable element {0} missing |
| 3095 | extra non-translatable in target | Extra non-translatable element {0} found |
| 3096 | missing or extra non-translatable | Element {0} count differs: {1} source vs {2} translation |

### Forbidden Characters (Code 3120)

| Code | Warning | Details |
|------|---------|---------|
| 3120 | forbidden character | Character {0} (code {1}) forbidden |

### Formatting Issues (Codes 3131-3134)

| Code | Warning | Details |
|------|---------|---------|
| 3131 | missing bold/italic/underline | Formatting {0} missing in translation |
| 3132 | extra bold/italic/underline | Extra formatting {0} detected |
| 3133 | bold/italic/underline mismatch | Formatting of {0} differs from source |
| 3134 | bold/italic/underline mismatch | Formatting of {0} in source differs from translation |

### Auto-translatable Elements (Code 3140)

| Code | Warning | Details |
|------|---------|---------|
| 3140 | missing auto-translatable | Auto-translatable element {0} missing; consider {1} |

### Translation Memory Matches (Codes 3151-3153)

| Code | Warning | Details |
|------|---------|---------|
| 3151 | best exact/context match is different from translation | Best match differs; segment info: [{0}% {1} {2} {3}] {4} |
| 3152 | most recent exact/context match is different from translation | Latest match differs; segment info: [{0}% {1} {2} {3}] {4} |
| 3153 | there are multiple exact/context matches | Multiple matches in segments {0} |

### Spelling & Grammar (Codes 3161-3162)

| Code | Warning | Details |
|------|---------|---------|
| 3161 | spelling error | {0} is misspelled with suggestions {1} |
| 3162 | grammar error | Possible grammatical error: {0} |

### Pixel-based Length Checks (Codes 3180-3182)

| Code | Warning | Details |
|------|---------|---------|
| 3180 | translation longer than limit | Length {0} surpasses limit {1} |
| 3181 | no rule matches the pixel-based length check | No applicable rule in QA settings |
| 3182 | failed to measure string length | Measurement unavailable |

### Spacing Around Tags (Codes 3190-3197)

| Code | Warning | Details |
|------|---------|---------|
| 3190 | missing space before tag | Space missing before tag {0} |
| 3191 | missing space after tag | Space missing after tag {0} |
| 3192 | extra space before tag | Extra space before tag {0} |
| 3193 | extra space after tag | Extra space after tag {0} |
| 3194 | space before tag should be non-breaking | Adjust space before tag {0} |
| 3195 | space after tag should be non-breaking | Adjust space after tag {0} |
| 3196 | missing non-breaking space before tag | Non-breaking space needed before tag {0} |
| 3197 | missing non-breaking space after tag | Non-breaking space needed after tag {0} |

### Regular Expression Checks (Codes 3200-3206)

| Code | Warning | Details |
|------|---------|---------|
| 3200 | forbidden regex match in target for source | Forbidden match for regex '{0}': {1} |
| 3201 | missing regex match in target | Match missing for regex '{0}': {1} |
| 3202 | counts of regex matches differ | Match count differs for regex '{0}' |
| 3203 | missing regex replacement in target | Replacement missing for regex '{0}': {1} |
| 3204 | forbidden regex replacement in target | Forbidden replacement for regex '{0}': {1} |
| 3205 | counts of regex matches/replacements differ | Count differs for regex '{0}' |
| 3206 | forbidden regex match in target | Forbidden match for regex '{0}': {1} |

### Deletion/Insertion Tracking (Codes 3220-3221)

| Code | Warning | Details |
|------|---------|---------|
| 3220 | Deletion missing from translation | Tracked deletion not reflected |
| 3221 | Insertion missing from translation | Tracked insertion not reflected |

### Measurements & Entities (Codes 3301-3309)

| Code | Warning | Details |
|------|---------|---------|
| 3301 | measurement added to target | Unit {0}, {1} added to translation |
| 3302 | measurement removed from source | Unit {0}, {1} removed in translation |
| 3303 | measurement changed | Unit changed from {0} to {1} |
| 3304 | entity added to target | Alphanumeric code {0} added |
| 3305 | entity removed from source | Alphanumeric code {0} removed |
| 3306 | entities not matching | Codes {0} and {1} inconsistent |
| 3307 | date added to target | Date {0} added to translation |
| 3308 | date removed from source | Date {0} removed in translation |
| 3309 | date not matching | Dates inconsistent: {0} and {1} |

## Access to Warning Information

Warnings appear on the "Resolve errors and warnings" document tab where users can filter by warning type using these codes and descriptions.
