#include "Prompt.hpp"
#include <iostream>
#include <fstream>
#include <filesystem>
#include <algorithm>
#include <cctype>
#include <cstdlib>

namespace fs = std::filesystem;

void Prompt::run() {
    std::cout << "=== Custom C++ Prompt for Windows ===" << std::endl;
    std::cout << "Type 'exit' to close the prompt.\n" << std::endl;

    std::string input;
    while (true) {
        // Retrieve current active directory workspace tracking
        try {
            std::cout << fs::current_path().string() << "> ";
        } catch (const std::exception&) {
            std::cout << "Unknown> ";
        }

        // Catch full string sequence lines from input buffer
        if (!std::getline(std::cin, input)) {
            break;
        }

        // Clean up empty lines immediately
        if (input.empty()) {
            continue;
        }

        // Parse explicit string parameters
        std::vector<std::string> args = tokenize(input);
        if (args.empty()) continue;

        std::string command = toLowerCase(args[0]);

        // [exit] Close the prompt application
        if (command == "exit") {
            std::cout << "Exiting prompt." << std::endl;
            break;
        }
        // [cd] Change directory
        else if (command == "cd") {
            if (args.size() < 2) {
                std::cout << fs::current_path().string() << std::endl;
            } else {
                // Recombine trailing parts to support paths containing spaces
                std::string targetDir = "";
                for (size_t i = 1; i < args.size(); ++i) {
                    targetDir += args[i] + (i == args.size() - 1 ? "" : " ");
                }

                try {
                    fs::current_path(targetDir);
                } catch (const fs::filesystem_error&) {
                    std::cout << "Error: The system cannot find the path specified: " << targetDir << std::endl;
                }
            }
        }
        // [cat / type] Open and display file content logs
        else if (command == "cat" || command == "type") {
            if (args.size() < 2) {
                std::cout << "Error: Please specify a file. Example: cat sample.txt" << std::endl;
            } else {
                std::string targetFile = "";
                for (size_t i = 1; i < args.size(); ++i) {
                    targetFile += args[i] + (i == args.size() - 1 ? "" : " ");
                }

                std::ifstream file(targetFile);
                if (file.is_open()) {
                    std::cout << file.rdbuf() << std::endl;
                    file.close();
                } else {
                    std::cout << "Error: File not found or unreadable: " << targetFile << std::endl;
                }
            }
        }
        // [Other commands] Delegate execution downstream directly to cmd.exe
        else {
            executeNativeCommand(input);
        }
    }
}

std::vector<std::string> Prompt::tokenize(const std::string& input) {
    std::vector<std::string> tokens;
    std::string current = "";
    for (char c : input) {
        if (std::isspace(c)) {
            if (!current.empty()) {
                tokens.push_back(current);
                current = "";
            }
        } else {
            current += c;
        }
    }
    if (!current.empty()) {
        tokens.push_back(current);
    }
    return tokens;
}

std::string Prompt::toLowerCase(std::string str) {
    std::transform(str.begin(), str.end(), str.begin(), [](unsigned char c) {
        return std::tolower(c);
    });
    return str;
}

void Prompt::executeNativeCommand(const std::string& fullCommand) {
    // Run unhandled inputs straight through the standard runtime platform call
    std::system(fullCommand.c_str());
}
