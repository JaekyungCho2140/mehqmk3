# Task Completion Checklist

When completing a task or before ending a session, verify:

1. **Build**: `dotnet build mehQ.sln` — 0 errors, 0 warnings
2. **Tests**: `dotnet test mehQ.sln` — all tests passing
3. **Git**: No uncommitted changes (`git status` clean)
4. **Jira**: Update relevant issue status via MCP (transition ID 41 for 완료)
5. **CI**: Push to remote, verify GitHub Actions passes
6. **Merge**: If feature branch work is complete, merge to main

## Hookify Rules (Active)
- `enforce-conventional-commits` — BLOCK: commit without feat:/fix:/docs: prefix
- `protect-clean-architecture` — BLOCK: Core importing Infrastructure/Application/UI
- `protect-application-layer` — BLOCK: Application importing Infrastructure/UI  
- `session-completion-checklist` — BLOCK: stop without verifying build/test/jira
