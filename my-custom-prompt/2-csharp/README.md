# 🔷 2. C# Custom Prompt

A robust custom command line interface written in C# designed to run natively on the Windows ecosystem.

## Features
- Standard prompt layout formatting: `C:\path\to\dir> `
- Native context tracking for internal path routing (`cd`)
- Quick file readers supporting native exceptions (`cat`, `type`)
- Out-of-process shell delegation to native `cmd.exe` for external programs

## How to Run

1. Make sure you have the [.NET SDK](https://microsoft.com) installed.
2. Open your terminal or Command Prompt.
3. Navigate to the project root directory:
   ```bash
   cd 2-csharp
   ```
4. Build and run the project instantly using the .NET CLI:
   ```bash
   dotnet run --project src/MyCustomPrompt.csproj
   ```
