package main

import (
	"bufio"
	"fmt"
	"os"
	"os/exec"
	"strings"
)

func main() {
	fmt.Println("=== Custom Go Prompt for Windows ===")
	fmt.Println("Type 'exit' to close the prompt.\n")

	reader := bufio.NewReader(os.Stdin)

	for {
		// Get current working directory and display the prompt layout
		currentDir, err := os.Getwd()
		if err != nil {
			fmt.Printf("Error retrieving directory: %v\n", err)
			currentDir = "Unknown"
		}
		fmt.Printf("%s> ", currentDir)

		// Read user input until line break
		input, err := reader.ReadString('\n')
		if err != nil {
			fmt.Printf("Error reading input: %v\n", err)
			break
		}

		// Clean up carriage return and newline values for Windows environment
		input = strings.TrimSpace(input)
		if input == "" {
			continue
		}

		// Split input into command and raw arguments
		args := strings.Fields(input)
		command := strings.ToLower(args[0])

		// [exit] Close the prompt
		if command == "exit" {
			fmt.Println("Exiting prompt.")
			break
		}

		// [cd] Change directory
		if command == "cd" {
			if len(args) < 2 {
				// Print current path if no args provided
				fmt.Println(currentDir)
			} else {
				// Reconstruct string to seamlessly allow folder paths with spaces
				targetDir := strings.Join(args[1:], " ")
				err := os.Chdir(targetDir)
				if err != nil {
					fmt.Printf("Error: The system cannot find the path specified: %s\n", targetDir)
				}
			}
			continue
		}

		// [cat / type] Open and display file content
		if command == "cat" || command == "type" {
			if len(args) < 2 {
				fmt.Println("Error: Please specify a file. Example: cat sample.txt")
			} else {
				targetFile := strings.Join(args[1:], " ")
				content, err := os.ReadFile(targetFile)
				if err != nil {
					fmt.Printf("Error: File not found or unreadable: %s\n", targetFile)
				} else {
					fmt.Print(string(content))
					// Ensure a fresh line block trailing the file prints
					fmt.Println()
				}
			}
			continue
		}

		// [Other commands] Delegate directly to Windows Command Prompt environment
		executeNativeCommand(input)
	}
}

func executeNativeCommand(fullCommand string) {
	// Execute via Windows cmd.exe context loop integration
	cmd := exec.Command("cmd.exe", "/c", fullCommand)
	cmd.Stdout = os.Stdout
	cmd.Stderr = os.Stderr
	cmd.Stdin = os.Stdin

	_ = cmd.Run()
}
