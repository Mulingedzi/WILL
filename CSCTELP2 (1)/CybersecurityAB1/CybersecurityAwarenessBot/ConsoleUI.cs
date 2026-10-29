using System;
using System.Threading;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Everything related to how the bot LOOKS in the console:
    /// ASCII art, colours, dividers, borders and the "typing" effect.
    /// Keeping this separate from the conversation logic makes both easier to read.
    /// </summary>
    public static class ConsoleUI
    {
        public static void ShowAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
              _____
             /     \
            /  ___  \
           |  /   \  |         CYBERSECURITY
           | |  o  | |         AWARENESS BOT
           |  \___/  |
            \_______/          Stay Alert. Stay Safe.
              |   |
              |   |
              '---'
");
            Console.ResetColor();
            DrawDivider('=', 60, ConsoleColor.DarkCyan);
        }

        public static void ShowWelcomeMessage(string userName)
        {
            DrawDivider('*', 60, ConsoleColor.Yellow);
            TypeText($" Hello, {userName}! Welcome to the Cybersecurity Awareness Bot.", 12, ConsoleColor.Green);
            TypeText(" I'm here to help you stay safe online.", 12, ConsoleColor.Green);
            DrawDivider('*', 60, ConsoleColor.Yellow);
            Console.WriteLine();
        }

        public static void ShowExitMessage(string userName)
        {
            Console.WriteLine();
            DrawDivider('=', 60, ConsoleColor.DarkCyan);
            TypeText($" Stay safe out there, {userName}! Goodbye.", 12, ConsoleColor.Cyan);
            DrawDivider('=', 60, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Prints a horizontal divider line, used to visually separate sections.
        /// </summary>
        public static void DrawDivider(char symbol = '-', int length = 60, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(new string(symbol, length));
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a boxed/bordered message, e.g. for bot replies.
        /// </summary>
        public static void PrintBoxed(string message, ConsoleColor color = ConsoleColor.Green)
        {
            int width = message.Length + 4;
            Console.ForegroundColor = color;
            Console.WriteLine("+" + new string('-', width - 2) + "+");
            Console.WriteLine($"| {message} |");
            Console.WriteLine("+" + new string('-', width - 2) + "+");
            Console.ResetColor();
        }

        /// <summary>
        /// Simulates a conversational typing effect by printing one character at a time.
        /// </summary>
        public static void TypeText(string text, int delayMs = 15, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMs);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
