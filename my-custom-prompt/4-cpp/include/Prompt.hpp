#ifndef PROMPT_HPP
#define PROMPT_HPP

#include <string>
#include <vector>

class Prompt {
public:
    // Starts the main shell execution loop
    void run();

private:
    // Split input string by spaces into structural segments
    std::vector<std::string> tokenize(const std::string& input);
    
    // Normalize text input strings to lowercase letters
    std::string toLowerCase(std::string str);
    
    // Delegate unhandled processes to native host console infrastructure
    void executeNativeCommand(const std::string& fullCommand);
};

#endif // PROMPT_HPP
