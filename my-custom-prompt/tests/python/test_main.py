import os
import sys
import unittest
from unittest.mock import patch
from io import StringIO

# Add the 1-python directory to the system path to import main.py
sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), '../../1-python')))
import main

class TestPythonPrompt(unittest.TestCase):

    @patch('builtins.input', side_effect=['exit'])
    @patch('sys.stdout', new_callable=StringIO)
    def test_exit_command(self, mock_stdout, mock_input):
        """Test if the 'exit' command successfully terminates the prompt loop."""
        try:
            main.main()
        except SystemExit:
            pass
        
        output = mock_stdout.getvalue()
        self.assertIn("=== Custom Python Prompt for Windows ===", output)
        self.assertIn("Exiting prompt.", output)

    @patch('builtins.input', side_effect=['', 'exit'])
    @patch('sys.stdout', new_callable=StringIO)
    def test_empty_input(self, mock_stdout, mock_input):
        """Test if empty inputs are safely skipped without throwing errors."""
        try:
            main.main()
        except SystemExit:
            pass
        
        output = mock_stdout.getvalue()
        # Verify that it prints the welcome message and exits properly
        self.assertIn("=== Custom Python Prompt for Windows ===", output)
        self.assertIn("Exiting prompt.", output)

if __name__ == '__main__':
    unittest.main()
