# 💻 Polyglot Custom Prompt for Windows

A compilation of custom-built command-line shells implemented across 4 major programming languages: **Python**, **C#**, **Go**, and **C++**. This project showcases identical basic shell features implemented across different runtime paradigms.

## 🚀 Supported Environments & Features

- **Target OS:** Windows
- **Built-in Commands:**
  - `cd` - Change directory (seamlessly supports folder paths with spaces).
  - `cat` / `type` - Read and print file contents directly to the console.
  - `exit` - Terminate the custom shell program.
- **Fallback Integration:** Automatically passes any unhandled native commands (e.g., `dir`, `ipconfig`, `ping`) down to the core Windows shell environment.

## 📁 Repository Structure

```text
my-custom-prompt/
├── .github/workflows/    # Automated CI/CD compilation actions
├── 1-python/             # Python Implementation (Scripting paradigm)
├── 2-csharp/             # C# Implementation (.NET / Enterprise ecosystem)
├── 3-go/                 # Go Implementation (Single binary compilation)
├── 4-cpp/                # C++ Implementation (Native C++17 performance)
└── tests/                # Unit test suites across language layers
```

## 🛠️ Getting Started

Every implementation lives inside its own dedicated subdirectory. To build or run a specific language shell, navigate into the respective folder and follow the instructions in its local documentation:

* [Python Setup Guide](./1-python/README.md)
* [C# Build Guide](./2-csharp/README.md)
* [Go Compilation Guide](./3-go/README.md)
* [C++ Compilation Guide](./4-cpp/README.md)

## 📄 License

This repository is distributed under the MIT License. See the [LICENSE](./LICENSE) file for more information.
