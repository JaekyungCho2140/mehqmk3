# Code Style & Conventions

## C# Style
- Language: C# 12, nullable reference types enabled, implicit usings enabled
- PascalCase for public members, _camelCase for private fields
- TreatWarningsAsErrors enabled in Directory.Build.props
- File-scoped namespaces preferred

## Git Conventions
- Conventional commits: feat:, fix:, refactor:, docs:, test:, chore:
- Scoped format allowed: feat(core):, fix(ui):
- Branch naming: feature/MEHQ-<number>-<description>
- No PRs — direct merge to main after CI passes (solo Claude development)
- Co-Authored-By trailer required on commits

## Architecture
- Clean Architecture with strict layer boundaries
- Core: pure domain models and interfaces only
- Application: use cases and service implementations
- Infrastructure: external dependencies (DB, file I/O, parsers)
- UI: WPF views, ViewModels (CommunityToolkit.Mvvm), DI wiring

## Testing
- xUnit + FluentAssertions + Moq
- Test project per layer: MehQ.Core.Tests, MehQ.Application.Tests, MehQ.Infrastructure.Tests
- FluentAssertions syntax: `result.Should().Be(expected);`

## Jira Integration
- Project: MEHQ at hotelafrica.atlassian.net
- Cloud ID: 8d101c74-7bfe-49c4-bed5-99dc3fbdca1b
- Issue types: 에픽, 스토리, 작업, 버그, Feature, Subtask
- Transition IDs: 해야 할 일(11), 진행 중(21), 검토 중(31), 완료(41)
