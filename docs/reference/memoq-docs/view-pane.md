# View Pane Documentation

## Overview

The View pane is located at the bottom of the translation editor, typically below the Grid. It displays one of three modes: HTML Preview, Review (QA/LQA warnings), or Active comments.

## Switching Modes

Three buttons appear at the top right of the View pane when you point at it. Click any button to switch between the three display modes.

## Toggling the View Pane

Access the View ribbon and click "View pane" to turn the pane on or off.

---

## Translation Preview Mode

### Default Display
The pane initially shows a formatted preview of the translation. When you translate a segment in the Grid, the translated text replaces the source text in this preview.

### Current Segment Highlighting
In the preview, the current segment is highlighted with a red border.

### Navigation Within Preview
Click anywhere in the preview to jump the Grid to that location. This enables direct navigation through clicking.

### Finding Text in Preview
1. Click within the View pane
2. Press Ctrl+F
3. Enter search terms in the Find box
4. memoQ highlights matches and jumps to the first occurrence
5. Click "Next" to navigate through additional matches
6. The Find window remains open for continuous searching

### Preview Limitations

**Similarity to Original Document:**
memoQ uses various applications to turn every document into a web page. Sometimes a web page cannot look the same as the finished document. The formatting may be similar, but never identical.

**No Guaranteed Preview:**
memoQ does everything to produce a preview for every document. But there are document formats where it's impossible to get a preview.

**XML Document Structure:**
Preview of XML documents, XML-based documents, and multilingual tables shows the structure of the document, not the formatting. This is normal.

### Supported Formats
Microsoft Word, Excel, PowerPoint, HTML, XML (including XSLT style sheets), multilingual Excel, text, WPML XLIFF, and XML.

---

## Review Mode

The Review mode displays QA and LQA (Linguistic Quality Assurance) warnings for the current segment.

### Ignoring Warnings
Select the checkbox next to individual warnings to ignore them.

### Refreshing Warnings
Click the Refresh icon adjacent to the Ignore checkbox to update the QA warnings list.

### Ignoring Warning Types Project-Wide
Point at a warning row to reveal an icon that allows ignoring all warnings of that type throughout the entire project.

### Converting QA to LQA Warnings
If an LQA model exists in the project, click the error-change icon to convert a QA warning into an LQA warning.

---

## Active Comments Mode

Switch the View pane to Active comments mode to view and manage comments for the current segment.

### Advantages Over Notes Window
This is useful because the Notes window is limited in size. The View pane can hold more text.

### Comment Management
- Click the pencil icon to respond to comments
- Click the trash can icon to delete comments

---

## Detaching to Secondary Screen

### Prerequisites
Connect a second monitor and configure Windows to extend the display (Windows+P).

### Detaching Process
1. Click and hold the View pane title bar
2. Drag to initiate detachment
3. Drag the detached pane to the second screen
4. Maximize as needed

### Redocking to Main Window
1. Click and drag the View pane title bar over the memoQ window
2. Docking icons appear showing available attachment points
3. Move the pointer to the desired icon while dragging
4. Release the mouse button to dock

### Returning to Default Position
Drag the View pane to the center docking icon labeled "normal place."
