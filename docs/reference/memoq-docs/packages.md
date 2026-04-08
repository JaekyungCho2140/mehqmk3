# Packages in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-packages.html (memoQ 12.2)

## Definition

A memoQ handoff package is a compressed file (`.mqout` extension) containing a translation or review job with all necessary resources. The handoff package contains the documents that the linguist needs to work on, plus translation memories, term bases, and all other resources and settings.

## Key Features

### Creation & Distribution
- Project managers with appropriate licensing create packages from online and local projects
- Packages are distributed via email to translators and reviewers
- Translators use memoQ translator pro to access packages (no internet required)

### Project Setup
Upon import, packages automatically establish complete projects for recipients with all embedded resources and configurations.

### Update Capability
When changes occur in the master project, managers can send update packages. The system automatically identifies and updates the translator's corresponding copy without manual intervention.

## Delivery Process

### Final Handoff
1. Translators export completed work as delivery packages (`.mqback` extension)
2. Email delivery packages to project managers
3. Manager opens delivery file
4. memoQ automatically locates the master project and applies all updates

## Package Types

| Extension | Purpose |
|-----------|---------|
| `.mqout` | Handoff package (PM to translator) |
| `.mqback` | Delivery package (translator to PM) |

## Licensing

- Project managers require appropriate licenses
- Translators and reviewers need only memoQ translator pro access

## Note for mehQ

Packages are primarily a PM/server workflow feature. For mehQ (local desktop only), the relevant aspects are:
- Ability to receive and import `.mqout` packages
- Ability to create and send `.mqback` delivery packages
- Automatic project setup from package contents
