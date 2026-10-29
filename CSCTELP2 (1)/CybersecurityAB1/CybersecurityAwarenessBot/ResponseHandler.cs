using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Owns the bot's knowledge: predefined cybersecurity responses and
    /// simple keyword matching against user input.
    /// </summary>
    public static class ResponseHandler
    {
        private static readonly Dictionary<string, string> Responses = new(StringComparer.OrdinalIgnoreCase)
        {
            { "how are you", "I'm running smoothly and ready to help you stay safe online!" },
            { "what's your purpose", "My purpose is to educate you on cybersecurity threats and how to avoid them." },
            { "what is your purpose", "My purpose is to educate you on cybersecurity threats and how to avoid them." },
            { "what can i ask you about", "You can ask me about password safety, phishing scams, and safe browsing habits." },
            { "password", "Use long, unique passwords with a mix of letters, numbers and symbols. Never reuse the same password across accounts, and consider using a password manager." },
            { "phishing", "Phishing emails often create a false sense of urgency, contain suspicious links, or ask for personal details. Always verify the sender before clicking anything or entering information." },
            { "safe browsing", "Stick to HTTPS websites, avoid downloading files from unknown sources, and keep your browser and antivirus software up to date." },
            { "malware", "Malware often arrives through infected downloads or email attachments. Keep your software updated and avoid opening files from unknown senders." },
            { "social engineering", "Social engineering tricks people into giving up confidential information. Be cautious of unexpected requests for personal or financial details, even from people who seem trustworthy." },
        };

        private static readonly HashSet<string> ExitCommands = new(StringComparer.OrdinalIgnoreCase)
        {
            "exit", "quit", "bye", "goodbye"
        };

        public static bool IsExitCommand(string input)
        {
            return ExitCommands.Contains(input.Trim());
        }

        /// <summary>
        /// Finds the first predefined response whose keyword appears in the
        /// user's message. Falls back to a friendly default response.
        /// </summary>
        public static string GetResponse(string input)
        {
            string lowerInput = input.ToLowerInvariant();

            var match = Responses.FirstOrDefault(pair => lowerInput.Contains(pair.Key));

            if (!string.IsNullOrEmpty(match.Key))
            {
                return match.Value;
            }

            return "I didn't quite understand that. Could you rephrase? Try asking about passwords, phishing, or safe browsing.";
        }
    }
}
