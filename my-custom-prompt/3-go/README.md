# 🐹 3. Go Custom Prompt

A high-performance custom command shell environment written in Go designed to run efficiently on Windows.

## Features
- Standard prompt layout formatting: `C:\path\to\dir> `
- Direct system state directory modifications (`cd`)
- Blazing fast file buffer streams (`cat`, `type`)
- Process isolation architecture via native execution channels (`cmd.exe`)

## How to Run

1. Make sure you have [Go](https://go.dev) installed.
2. Open your terminal or Command Prompt.
3. Navigate to the project root directory:
   ```bash
   cd 3-go
   ```
4. Run the code directly:
   ```bash
   go run main.go
   ```
5. Alternatively, compile it to a standalone executable binary:
   ```bash
   go build -o myprompt.exe main.go
   ```
