# mehQ - memoQ Clone Brainstorming Result

**Date:** 2026-04-08
**Project:** mehQ (memoQ Desktop Clone)
**Repo:** https://github.com/JaekyungCho2140/mehqmk3
**Jira:** https://hotelafrica.atlassian.net/jira/software/projects/MEHQ/

---

## 1. Project Overview

memoQ(CAT - Computer-Assisted Translation 도구)의 로컬 데스크톱 기능을 클론하는 Windows 전용 애플리케이션.
네트워크(서버, TMS)와 MT(Machine Translation) 기능은 제외.

## 2. Scope

### In-Scope

#### Core Features
- **번역 편집기**: 세그먼트 기반 에디터, 소스/타겟 양분할 뷰, 인라인 태그 처리
- **번역 메모리 (TM)**: 로컬 DB 기반, fuzzy matching (0-100%), concordance 검색, TM 편집기
- **용어집 (Term Base)**: 용어 관리, 자동 하이라이팅, 미번역 용어 경고, 일괄 치환
- **로컬 프로젝트 관리**: 프로젝트 생성/열기/삭제, 문서 추가/제거, 프로젝트 대시보드
- **QA 검사**: 태그 누락, 포맷팅, 구두점, 숫자, 용어 일관성 검증
- **LiveDocs**: 참조 문서 관리, 이중언어 문서 정렬(alignment)
- **The Muse (예측 입력)**: TM/LiveDocs 기반 예측 타이핑

#### File Format Support
- XLIFF (.xlf, .xliff)
- Microsoft Office (DOCX, XLSX, PPTX) via Open XML
- HTML
- Plain Text (.txt)
- CSV/TSV (TM/TB import/export)

#### Infrastructure
- Windows Installer (MSI via WiX Toolset)
- Auto-update mechanism
- CI/CD via GitHub Actions

### Out-of-Scope
- Server/TMS/Network features
- Machine Translation (MT) integration
- Cloud collaboration
- Web-based access
- Mobile support

## 3. Technology Stack

| Area | Technology | Rationale |
|------|-----------|-----------|
| Runtime | .NET 8 (LTS) | Modern, cross-compile capable, long-term support |
| UI Framework | WPF | Windows-native, rich UI controls, MVVM pattern |
| Architecture | MVVM + Clean Architecture | Testability, separation of concerns |
| Database | SQLite (via EF Core) | Lightweight, file-based, ideal for local TM/TB |
| DOCX/XLSX/PPTX | Open XML SDK | Official Microsoft library |
| HTML | HtmlAgilityPack | Robust HTML parsing |
| XLIFF | System.Xml.Linq | Standard XML processing |
| Fuzzy Matching | Custom (Levenshtein + weighted) | TM matching algorithm |
| Installer | WiX Toolset v4 | MSI creation, industry standard |
| Auto-Update | Squirrel.Windows or AutoUpdater.NET | Proven update libraries |
| CI/CD | GitHub Actions | Build, test, release automation |
| Testing | xUnit + Moq + FluentAssertions | .NET testing standard |

## 4. High-Level Architecture

```
mehQ/
├── src/
│   ├── MehQ.Core/              # Domain models, interfaces
│   ├── MehQ.Application/       # Use cases, services
│   ├── MehQ.Infrastructure/    # SQLite, file parsers, auto-update
│   ├── MehQ.UI/                # WPF app, ViewModels, Views
│   └── MehQ.Installer/         # WiX installer project
├── tests/
│   ├── MehQ.Core.Tests/
│   ├── MehQ.Application.Tests/
│   └── MehQ.Infrastructure.Tests/
├── docs/
└── .github/workflows/
```

## 5. Key Design Decisions

1. **WPF over WinUI 3**: WPF is more mature, better tooling, larger ecosystem for complex desktop apps
2. **SQLite over LiteDB**: SQL-based querying is better for TM fuzzy search and complex queries
3. **Clean Architecture**: Enables testability and future extensibility
4. **MVVM**: WPF best practice, clean separation of UI and logic
5. **Segment-based editing**: Core UX pattern - each translation unit is a segment pair

## 6. Epic Structure (for Jira)

1. **E1: Project Infrastructure** - Solution setup, CI/CD, installer skeleton
2. **E2: Translation Editor** - Segment editor, source/target view, navigation
3. **E3: Translation Memory** - TM creation, fuzzy matching, concordance, TM editor
4. **E4: Term Base** - TB creation, term highlighting, warnings, TB editor
5. **E5: Project Management** - Project creation, document import, dashboard
6. **E6: File Format Support** - XLIFF, DOCX, HTML, TXT parsers
7. **E7: QA System** - QA checks, error reporting, batch QA
8. **E8: LiveDocs & Alignment** - Reference docs, bilingual alignment
9. **E9: The Muse (Predictive Typing)** - Auto-completion from TM/LiveDocs
10. **E10: Installer & Auto-Update** - WiX installer, update mechanism, release pipeline
