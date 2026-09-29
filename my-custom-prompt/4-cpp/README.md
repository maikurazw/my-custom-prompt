# 🧱 4. C++ Custom Prompt

A native performance custom command prompt compiled with C++17, working seamlessly on Windows environments.

## Features
- Displays native OS workspace tracks: `C:\path\to\dir> `
- Robust path movement relying on standard filesystem libraries (`cd`)
- Buffered output streaming for fast performance file logs (`cat`, `type`)
- Low-level shell bridge communication via native `std::system`

## Prerequisites

To compile and run this C++ version, you need to have the following tools installed on your Windows PC:
- A C++ compiler that supports C++17 (e.g., **MinGW**, **MSVC / Visual Studio**, or **Clang**)
- **CMake** (version 3.15 or higher)

## How to Build and Run

1. Open your terminal or Command Prompt.
2. Navigate to this directory:
   ```bash
   cd 4-cpp
   ```
3. Create a fresh build directory and navigate into it:
   ```bash
   mkdir build
   cd build
   ```
4. Generate the build configuration files using CMake:
   ```bash
   cmake ..
   ```
5. Compile the executable program:
   ```bash
   cmake --build . --config Release
   ```
6. Run your newly created standalone custom shell:
   ```bash
   # For MinGW / Makefiles:
   ./custom_prompt.exe
   
   # For Visual Studio (MSVC), it might be inside the Release folder:
   ./Release/custom_prompt.exe
   ```
