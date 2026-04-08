# Supported Source Document Formats in memoQ

> Source: https://docs.memoq.com/current/en/Concepts/concepts-supported-source-document-form.html (memoQ 12.2)

## Overview

memoQ uses **import filters** as software components enabling support for numerous file formats. Users configure filters via Documents ribbon > Import > Import with options > Change filter and configuration.

## Monolingual Formats

### Adobe Products
- InDesign Exchange (.inx)
- InDesign Markup Language (.idml)
- InCopy (.icml)
- FrameMaker (.mif, .mi2)
- Photoshop (.psd)

### Web & Code
- HTML (.html, .htm)
- Server Side Includes (.shtml)
- ASP.NET (.aspx)
- JSP (.jsp)
- PHP (.php)
- Include files (.inc)

### Data & Configuration
- JSON (.json)
- YAML (.yaml, .yml)
- Java properties (.properties)
- XML variants (.xml, .sgm, .sgml, .ttml)
- Plain text (.txt, .inf, .ini, .reg)

### Office & Spreadsheets
- Excel 2003+ (.xls, .xlsx, .xlsm, .xlsb, .xltx)
- PowerPoint 2003+ (.ppt, .pptx, .ppsx, .potx, .pptm)
- Word 2003+ (.doc, .docx, .dot, .dotx, .docm, .dotm, .rtf)
- Outlook (.msg)

### Other Formats
- PDF (.pdf)
- Visio (.vsd, .vsdx, .vdx)
- Markdown (.md)
- Image files (.bmp, .jpg, .png, .tif) — OCR-based
- OpenDocument (.odt, .odp, .ods)
- DITA (.dita, .ditamap, .bookmap)
- ZIP (.zip)
- COTI packages (.coti)
- SVG
- FreeMind (.mm)
- Typo3 (.xml)

## Bilingual Formats
- XLIFF variants (.xlf, .xlif, .xliff, .mxliff, .xliffdoc)
- SDL Trados (.sdlxliff, .ttx)
- TMX (.tmx)
- PO Gettext (.po)
- TXML (.txml)
- Bilingual DOC/RTF (.doc, .rtf)

## memoQ Bilingual
- memoQ XLIFF (.mqxliff, .mqxlz)
- Table RTF (.rtf)

## Package Formats
- SDL Trados Studio (.sdlppx)
- STAR Transit (.pxf, .ppf)
- TIPP packages
- memoQ handoff (.mqout)
- SDL World Server (.xlz, .wsxz)

## Advanced Capabilities

Users can work on or modify every file from the above list by using **Regex tagger** or a **cascading filter**.

## Key Points for mehQ Implementation

Priority formats to support (based on frequency of use):
1. **XLIFF** (.xlf, .xliff, .mqxliff) — most common CAT exchange format
2. **DOCX** (.docx) — most common office format
3. **HTML** (.html, .htm) — web content
4. **TMX** (.tmx) — TM exchange
5. **TBX** — term base exchange (implied by term base import/export)
6. **Plain text** (.txt) — simple format
7. **PDF** (.pdf) — reference material
