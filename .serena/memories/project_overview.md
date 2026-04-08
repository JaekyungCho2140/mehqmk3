# mehQ - memoQ Desktop Clone

## Purpose
Windows-only CAT (Computer-Assisted Translation) tool that clones memoQ's local desktop features. Server/TMS/MT/Cloud features are explicitly out of scope.

## Tech Stack
- .NET 8 LTS, C# 12, WPF (Windows Presentation Foundation)
- MVVM pattern via CommunityToolkit.Mvvm
- Clean Architecture (Core → Application → Infrastructure → UI)
- SQLite via EF Core 8 for TM/TB storage
- Fluent.Ribbon v11 for ribbon menus
- Dirkster.AvalonDock v4.72 for docking panel layout
- Velopack for auto-update, WiX Toolset v5 for installer
- xUnit + Moq + FluentAssertions for testing, FlaUI for UI automation
- GitHub Actions (windows-latest) for CI/CD

## Project Structure
```
src/
  MehQ.Core/           - Domain models, interfaces (NO dependencies)
  MehQ.Application/    - Use cases, services (depends on Core only)
  MehQ.Infrastructure/ - SQLite, file parsers (implements Core interfaces)
  MehQ.UI/             - WPF app, ViewModels, Views
tests/
  MehQ.Core.Tests/
  MehQ.Application.Tests/
  MehQ.Infrastructure.Tests/
docs/
  reference/memoq-docs/    - Scraped memoQ documentation (28 files)
  reference/memoq-images/  - Scraped memoQ UI screenshots (114 images)
```

## Architecture Rules
- Core has ZERO dependencies on other layers
- Application depends only on Core
- Infrastructure implements Core interfaces, depends on Core + Application
- UI depends on Application + Infrastructure

## Naming
- Display name: mehQ (lowercase meh, uppercase Q)
- Code namespace: MehQ (PascalCase)
- Jira project key: MEHQ (all caps, only in Jira context)
