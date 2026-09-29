cmake_minimum_required(VERSION 3.15)
project(CustomCppPrompt LANGUAGES CXX)

# Require C++17 Standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Configure Include Directories
include_directories(include)

# Map Source Paths
set(SOURCES
    src/main.cpp
    src/Prompt.cpp
)

# Build Standalone Binary Executable
add_executable(custom_prompt ${SOURCES})
