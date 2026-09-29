using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MyCustomPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Support Japanese characters in console if needed
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("=== Custom C# Prompt for Windows ===");
            Console.WriteLine("Type 'exit' to close the prompt.\n");

            while (true)
            {
                // Get current working directory and display prompt
                string currentDir = Directory.GetCurrentDirectory();
                Console.Write($"{currentDir}> ");

                // Read user input
                string? userInput = Console.ReadLine();
                if (userInput == null) break;

                userInput = userInput.Trim();
                if (string.IsNullOrEmpty(userInput)) continue;

                // Split input into command and arguments
                string[] inputParts = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputParts[0].ToLower();

                // [exit] Close the prompt
                if (command == "exit")
                {
                    Console.WriteLine("Exiting prompt.");
                    break;
                }
                // [cd] Change directory
                else if (command == "cd")
                {
                    if (inputParts.Length < 2)
                    {
                        Console.WriteLine(Directory.GetCurrentDirectory());
                    }
                    else
                    {
                        // Recombine arguments to handle folder paths with spaces
                        string targetDir = string.Join(" ", inputParts.Skip(1));
                        try
                        {
                            Directory.SetCurrentDirectory(targetDir);
                        }
                        catch (DirectoryNotFoundException)
                        {
                            Console.WriteLine($"Error: The system cannot find the path specified: {targetDir}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }
                }
                // [cat / type] Open and display file content
                else if (command == "cat" || command == "type")
                {
                    if (inputParts.Length < 2)
                    {
                        Console.WriteLine("Error: Please specify a file. Example: cat sample.txt");
                    }
                    else
                    {
                        string targetFile = string.Join(" ", inputParts.Skip(1));
                        try
                        {
                            // Reads all text assuming UTF-8 fallback
                            string content = File.ReadAllText(targetFile);
                            Console.WriteLine(content);
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine($"Error: File not found: {targetFile}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }
                }
                // [Other commands] Pass directly to Windows native cmd.exe
                else
                {
                    ExecuteNativeCommand(userInput);
                }
            }
        }

        static void ExecuteNativeCommand(string fullCommand)
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c {fullCommand}",
                    RedirectStandardInput = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (Process? process = Process.Start(processInfo))
                {
                    process?.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error executing command: {e.Message}");
            }
        }
    }
}
