using System;
using System.Collections.Generic;
using Session;

namespace UserInterface
{
    public class StartScreen : Screen
    {
        private const int OPTIONS_X = 0;
        private const int OPTIONS_Y = HEADER_HEIGHT + BORDER_SIZE;
        private const int OPTIONS_WIDTH = SCREEN_WIDTH - BORDER_SIZE;

        private const int INPUT_X = 0;
        private const int INPUT_Y = HEADER_HEIGHT + BORDER_SIZE * 2;
        
        private List<string> _options = new()
        {
            "Host a new session", 
            "Join a session", 
            "Load a session", 
            "Agent editor", 
            "Leave game"
        };

        private const string HEADER_TEXT = "Welcome to The Apocalypse We Wanted! Pick an option to continue...";
        private const string INPUT_MESSAGE = "Insert an option";

        public override void DrawScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            DrawHeader(HEADER_TEXT);
            DrawOptionBox();
            DrawInputBox(INPUT_X, INPUT_Y + _options.Count, INPUT_MESSAGE);
        }
        private void DrawOptionBox()
        {
            DrawBox(OPTIONS_X, OPTIONS_Y, OPTIONS_WIDTH, _options.Count);

            foreach (var option in _options)
            {
                int optionNumber = _options.IndexOf(option) + 1;
                Console.SetCursorPosition(OFFSET_LEFT, OPTIONS_Y + optionNumber);
                Console.Write(optionNumber + ": " + option);
            }
        }

        public void UpdateInputMessage(string message)
        {
            DrawInputBox(INPUT_X, INPUT_Y + _options.Count, message);
        }
    }
}