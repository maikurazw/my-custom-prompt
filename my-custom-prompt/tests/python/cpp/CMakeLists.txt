cmake_minimum_required(VERSION 3.15)
project(CustomCppTests LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

include_directories(../../4-cpp/include)

# Compile the testing runner alongside core implementation modules
add_executable(run_tests 
    test_main.cpp 
    ../../4-cpp/src/Prompt.cpp
)
