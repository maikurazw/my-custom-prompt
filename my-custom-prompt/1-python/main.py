import os
import sys

def main():
    print("=== Custom Python Prompt for Windows ===")
    print("Type 'exit' to close the prompt.\n")

    while True:
        # Get current working directory and display the prompt
        current_dir = os.getcwd()
        print(f"{current_dir}> ", end="")
        
        # Read user input
        try:
            user_input = input().strip()
        except KeyboardInterrupt:
            print("\nExiting prompt.")
            break

        # If input is empty, skip to the next loop
        if not user_input:
            continue

        # Split input into command and arguments
        args = user_input.split()
        command = args[0].lower()

        # [exit] Close the prompt
        if command == "exit":
            print("Exiting prompt.")
            break

        # [cd] Change directory
        elif command == "cd":
            if len(args) < 2:
                # If no argument, print the current directory
                print(os.getcwd())
            else:
                # Combine remaining args to handle paths with spaces
                target_dir = " ".join(args[1:])
                try:
                    os.chdir(target_dir)
                except FileNotFoundError:
                    print(f"Error: The system cannot find the path specified: {target_dir}")
                except Exception as e:
                    print(f"Error: {e}")

        # [cat / type] Open and display file content
        elif command in ["cat", "type"]:
            if len(args) < 2:
                print("Error: Please specify a file. Example: cat sample.txt")
            else:
                # Combine remaining args to handle filenames with spaces
                target_file = " ".join(args[1:])
                try:
                    with open(target_file, "r", encoding="utf-8") as f:
                        print(f.read())
                except FileNotFoundError:
                    print(f"Error: File not found: {target_file}")
                except UnicodeDecodeError:
                    # Fallback to Windows default encoding (cp932/Shift-JIS) if UTF-8 fails
                    try:
                        with open(target_file, "r", encoding="cp932") as f:
                            print(f.read())
                    except Exception as e:
                        print(f"Error: Could not read file: {e}")
                except Exception as e:
                    print(f"Error: {e}")

        # [Other commands] Pass directly to Windows Command Prompt
        else:
            exit_code = os.system(user_input)

if __name__ == "__main__":
    main()
