using System;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Drives the conversation: greeting the user by name, running the
    /// main input/response loop, and handling invalid input gracefully.
    /// </summary>
    public static class ChatBot
    {
        public static string AskForName()
        {
            string name = string.Empty;

            while (!InputValidator.IsValid(name))
            {
                ConsoleUI.TypeText("Before we begin, what's your name?", 12, ConsoleColor.Yellow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                Console.ResetColor();

                name = Console.ReadLine();

                if (!InputValidator.IsValid(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I didn't catch a name there. Please type your name.");
                    Console.ResetColor();
                }
            }

            return name.Trim();
        }

        public static void RunConversationLoop(string userName)
        {
            ConsoleUI.TypeText("You can ask me about cybersecurity topics, or type 'exit' to quit.", 12, ConsoleColor.Cyan);
            ConsoleUI.DrawDivider('-', 60, ConsoleColor.DarkGray);

            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{userName}> ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (!InputValidator.IsValid(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                if (ResponseHandler.IsExitCommand(input))
                {
                    running = false;
                    continue;
                }

                string response = ResponseHandler.GetResponse(input);
                ConsoleUI.TypeText($"Bot: {response}", 8, ConsoleColor.Green);
                ConsoleUI.DrawDivider('-', 60, ConsoleColor.DarkGray);
            }
        }
    }
}
