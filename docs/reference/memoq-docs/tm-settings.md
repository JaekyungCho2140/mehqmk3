# TM Settings in memoQ

## Overview

Translation memory settings establish rules governing translation memory parameters, including match thresholds and penalties. These configurations determine whether segments qualify as matches or good matches.

## Core Components

### Thresholds
- Define limits that matches must surpass for qualification
- Contain default values upon initialization
- Represent the matching criteria applied to translation memory queries

### Penalties
- Calculated as percentages automatically deducted from match rates
- Applied specifically to segments created through alignment rather than manual creation
- Can be assigned to different users within a project

### Adjust Fuzzy Hits Feature
- Allows the automatic adjustment of numbers, ending punctuation marks, cases and inline tags within translation memory hits with less than 100% match rate
- Enabled by default
- Users may disable this feature to perform adjustments manually instead

## Management Capabilities

Users can:
- Create multiple TM settings sets
- Apply only one set per project at any given time
- Access settings through Project home or Resource console
- Generate new TM settings sets
- Import and export existing configurations
- Clone online sets for local computer use
- Edit properties of selected sets

## Access Locations

Configuration management occurs through:
- Project home TM settings pane
- Resource console interface
- Both local and remote server environments
