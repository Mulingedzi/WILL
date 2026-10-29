# Cybersecurity Awareness Bot — Part 1

A console-based chatbot built in C# (.NET 8) for the Department of Cybersecurity's public
awareness campaign. This is the Part 1 foundation: a personalised voice greeting, ASCII
logo, name-based interaction, predefined cybersecurity responses, input validation, and a
coloured console UI with a typing effect.

## Project structure

```
CybersecurityAwarenessBot/
├── CybersecurityAwarenessBot.csproj
├── Program.cs             # Entry point — wires everything together
├── ChatBot.cs              # Conversation loop, asks for the user's name
├── ConsoleUI.cs            # ASCII art, colours, dividers, typing effect
├── VoiceGreeting.cs        # Plays the WAV greeting via System.Media.SoundPlayer
├── ResponseHandler.cs      # Predefined cybersecurity Q&A + exit commands
├── InputValidator.cs       # Shared empty/whitespace input check
├── Assets/
│   └── greeting.wav        # Add your own recorded WAV file here (see Assets/README-audio.txt)
└── .github/workflows/
    └── ci.yml              # GitHub Actions: restore, format check, build
```

## Running it

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet restore
dotnet run
```

The voice greeting only plays on Windows (System.Media.SoundPlayer is Windows-only at
runtime). On other platforms, or if `Assets/greeting.wav` is missing, the bot logs a
notice and continues normally — it never crashes because of the missing audio.

## Adding your voice greeting

See `Assets/README-audio.txt` for step-by-step instructions on recording and placing
`greeting.wav`.

## Setting up GitHub and CI

1. Create a new repository on GitHub and push this project:

   ```bash
   git init
   git add .
   git commit -m "Initial commit: Set up project structure and main files"
   git branch -M main
   git remote add origin <your-repo-url>
   git push -u origin main
   ```

2. The workflow at `.github/workflows/ci.yml` runs automatically on every push/PR to
   `main`. It restores dependencies, checks formatting with `dotnet format`, and builds
   the project. Check the **Actions** tab on GitHub for the green checkmark.

3. Suggested commit sequence (aim for 6+ meaningful commits):
   - `Initial commit: Set up project structure and main files`
   - `Added ASCII logo and console UI styling`
   - `Added voice greeting playback with System.Media.SoundPlayer`
   - `Added greeting and user interaction functionality`
   - `Implemented basic cybersecurity responses and input validation`
   - `Added GitHub Actions CI workflow`

## Notes on design choices

- Logic is split across dedicated classes (`ChatBot`, `ConsoleUI`, `VoiceGreeting`,
  `ResponseHandler`, `InputValidator`) rather than living in `Program.cs`, per the
  code structure requirement.
- `ResponseHandler` uses simple keyword matching so it's easy to extend with more
  topics in later parts of the project.
- All user input is validated before use; empty or unrecognised input gets a graceful
  default reply instead of crashing or hanging.
