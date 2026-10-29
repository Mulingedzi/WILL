namespace CybersecurityAwarenessBot
{
    /// <summary>
    /// Centralises input validation so every part of the bot handles
    /// empty, null or whitespace-only input the same way.
    /// </summary>
    public static class InputValidator
    {
        public static bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
