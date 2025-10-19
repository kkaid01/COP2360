```markdown
# COP2360 — Module 7 Dictionary Assignment

This branch adds a console program implementing the Module 7 dictionary assignment.

How to build and run
- Ensure you have .NET SDK 6.0+ installed.
- From the repository root (where the .csproj lives), run:
  - dotnet build
  - dotnet run

Program features
- Interactive switch-driven menu with options:
  1) Populate the dictionary (key:value1,value2)
  2) Display dictionary contents (three enumeration methods)
  3) Remove a key
  4) Add a new key and values
  5) Append values to an existing key
  6) Sort keys and display
  7) Show enumeration methods info
  8) Exit

Testing
- A small xUnit test project can be used. To create and run tests:
  - dotnet new xunit -o Tests
  - dotnet add Tests reference <path-to-your-main-project-csproj>
  - dotnet test

Notes
- The program uses Dictionary<string, List<string>> so each key can hold multiple values.
- Keys are compared case-insensitively (StringComparer.OrdinalIgnoreCase).
```
