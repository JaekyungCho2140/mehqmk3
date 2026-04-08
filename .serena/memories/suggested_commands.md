# Suggested Commands

## Build & Test
```bash
dotnet build mehQ.sln                          # Build all projects
dotnet build mehQ.sln --configuration Release  # Release build
dotnet test mehQ.sln                           # Run all tests
dotnet test mehQ.sln --verbosity normal        # Verbose test output
dotnet run --project src/MehQ.UI/MehQ.UI.csproj # Run the WPF app
```

## Git
```bash
git checkout -b feature/MEHQ-<number>-<description>  # New feature branch
git add <files>                                       # Stage specific files
git commit -m "feat: description"                     # Conventional commit
git push origin <branch>                              # Push branch
git checkout main && git merge <branch> --no-ff       # Merge to main
```

## NuGet
```bash
dotnet add <project> package <PackageName>     # Add NuGet package
dotnet restore mehQ.sln                        # Restore all packages
dotnet package search <query>                  # Search for packages
```

## System Utils (Windows/Git Bash)
```bash
ls -la                    # List files
find . -name "*.cs"       # Find files
grep -r "pattern" src/    # Search in code
pwd                       # Current directory
```

## CI/CD
- CI triggers on push to main and feature/** branches
- Release triggers on v* tags
- Both run on windows-latest
