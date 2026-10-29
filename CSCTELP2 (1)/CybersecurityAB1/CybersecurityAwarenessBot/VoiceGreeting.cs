using System;
using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Handles playback of the recorded WAV voice greeting when the app launches.
    /// Fails gracefully (never crashes the app) if the file is missing or playback
    /// is unsupported on the current platform.
    /// </summary>
    public static class VoiceGreeting
    {
        public static void Play(string relativePath)
        {
            try
            {
                string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

                if (!File.Exists(fullPath))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"[Voice greeting skipped - '{relativePath}' not found. Add your recorded WAV file to play it.]");
                    Console.ResetColor();
                    return;
                }

                using (SoundPlayer player = new SoundPlayer(fullPath))
                {
                    // PlaySync blocks until the clip finishes, so the greeting
                    // plays fully before the rest of the UI appears.
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Voice greeting could not be played: {ex.Message}]");
                Console.ResetColor();
            }
        }
    }
}
