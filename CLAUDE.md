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

## Development Process (Jira-Driven)

### Sprint Workflow
1. **스프린트 시작**: Jira에서 에픽 아래 스토리/작업 확인 → feature 브랜치 생성
2. **개발**: 코드 작성 + 테스트 → 커밋 (conventional commits, Jira 키 참조)
3. **CI 검증**: GitHub Actions에서 빌드/테스트 통과 확인 (push 트리거)
4. **머지**: CI 통과 후 main에 직접 머지 → Jira 이슈 상태 업데이트
5. **스프린트 리뷰**: 사용자가 Windows에서 앱 실행 + UI 피드백

> PR은 사용하지 않음 — 작업자가 Claude 단독이므로 셀프 리뷰 불필요. CI push 트리거로 검증 충분.

### Session Handoff Strategy
새 세션 시작 시 현재 상태를 파악하는 순서:
1. `git branch -a && git log --oneline -10` — 현재 브랜치와 최근 커밋 확인
2. `git status` — 미커밋 변경사항 확인
3. Jira MCP로 현재 스프린트의 "진행 중" 이슈 조회 — 작업 중이던 이슈 파악
4. `dotnet build && dotnet test` — 빌드/테스트 상태 확인
5. GitHub Actions 최근 워크플로우 실행 결과 확인 — CI 상태 파악

### Jira Issue State Mapping
| Jira 상태 | 의미 | Claude Code 액션 |
|-----------|------|-----------------|
| 해야 할 일 | 미착수 | feature 브랜치 생성, 개발 시작 |
| 진행 중 | 개발 중 | 기존 브랜치에서 계속 작업 |
| 완료 | PR 머지됨 | 다음 이슈로 이동 |

### Epics (MEHQ-11 ~ MEHQ-20)
| Key | Epic | Sprint |
|-----|------|--------|
| MEHQ-11 | E1: Infrastructure | S1 (W1-2) |
| MEHQ-12 | E2: Translation Editor | S2-3 (W3-6) |
| MEHQ-13 | E3: Translation Memory | S4-5 (W7-10) |
| MEHQ-14 | E4: Term Base | S5-6 (W9-12) |
| MEHQ-15 | E5: Project Management | S6 (W11-12) |
| MEHQ-16 | E6: File Formats | S2-3 (W3-6) |
| MEHQ-17 | E7: QA System | S7 (W13-14) |
| MEHQ-18 | E8: LiveDocs | S8 (W15-16) |
| ~~MEHQ-19~~ | ~~E9: Muse~~ | ~~DROPPED~~ |
| MEHQ-20 | E10: Installer | S9 (W17-18) |

## Out of Scope
- Server/TMS/Network features
- Muse (predictive typing) — dropped from scope
- Machine Translation (MT)
- Cloud/Web access
