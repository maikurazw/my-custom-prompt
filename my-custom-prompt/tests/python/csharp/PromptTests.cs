using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace MyCustomPrompt.Tests
{
    [TestClass]
    public class PromptTests
    {
        [TestMethod]
        public void TestInitializationAndExit()
        {
            // Simulate user typing 'exit'
            var input = new StringReader("exit" + Environment.NewLine);
            var output = new StringBuilder();
            var writer = new StringWriter(output);

            Console.SetIn(input);
            Console.SetOut(writer);

            // Run the main program entry point
            Program.Main(new string[] { });

            string result = output.ToString();

            // Verify the console printed the correct startup and exit sequences
            Assert.IsTrue(result.Contains("=== Custom C# Prompt for Windows ==="));
            Assert.IsTrue(result.Contains("Exiting prompt."));
        }
    }
}
