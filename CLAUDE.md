# mehQ - memoQ Desktop Clone

## Project Overview
Windows 전용 CAT(Computer-Assisted Translation) 도구. memoQ의 로컬 데스크톱 기능 클론.

## Tech Stack
- .NET 8 (LTS), WPF, MVVM (CommunityToolkit.Mvvm) + Clean Architecture
- SQLite (via EF Core 8) for TM/TB storage
- Fluent.Ribbon v11 for ribbon menu
- AvalonDock (Dirkster99) v4.72 for docking panels
- Velopack for auto-update
- WiX Toolset v5 for installer
- FlaUI (UIA3) for UI automation tests
- xUnit + Moq + FluentAssertions for unit tests
- GitHub Actions (windows-latest) for CI/CD

## Project Structure
```
src/
  MehQ.Core/           - Domain models, interfaces
  MehQ.Application/    - Use cases, services
  MehQ.Infrastructure/ - SQLite, file parsers, auto-update
  MehQ.UI/             - WPF app, ViewModels, Views
  MehQ.Installer/      - WiX installer project
tests/
  MehQ.Core.Tests/
  MehQ.Application.Tests/
  MehQ.Infrastructure.Tests/
```

## Conventions
- Language: C# 12, nullable reference types enabled
- Naming: PascalCase for public members, _camelCase for private fields
- Architecture: Clean Architecture layers - Core has no dependencies, Application depends on Core, Infrastructure implements Core interfaces, UI depends on Application
- Testing: xUnit + Moq + FluentAssertions
- Git: Conventional commits (feat:, fix:, refactor:, docs:, test:, chore:)
- Branch: feature/<jira-key>-<description> (e.g., feature/MEHQ-1-project-setup)

## Jira
- Project: MEHQ at https://hotelafrica.atlassian.net/jira/software/projects/MEHQ/
- Issue types: 에픽, 스토리, 작업, 버그, Feature, Subtask

## Out of Scope
- Server/TMS/Network features
- Machine Translation (MT)
- Cloud/Web access
