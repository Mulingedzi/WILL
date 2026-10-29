using System;
using System.Text;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Entry point for the Cybersecurity Awareness Bot.
    /// Wires together the voice greeting, ASCII UI, and conversation loop.
    /// Kept deliberately thin - all real logic lives in dedicated classes.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Ensure box-drawing characters and ASCII art render correctly.
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Cybersecurity Awareness Bot";

            VoiceGreeting.Play("Assets/greeting.wav");

            ConsoleUI.ShowAsciiLogo();

            string userName = ChatBot.AskForName();

            ConsoleUI.ShowWelcomeMessage(userName);

            ChatBot.RunConversationLoop(userName);

            ConsoleUI.ShowExitMessage(userName);
        }
    }
}
