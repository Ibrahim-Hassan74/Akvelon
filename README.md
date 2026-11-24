# Akvelon Coding Task — FizzBuzz

A .NET solution implementing the FizzBuzz word replacement algorithm as specified in the Akvelon coding assessment.

---

## Task Description

The algorithm replaces words in an input string according to the following rules:

- Every 3rd word is replaced with `Fizz`.
- Every 5th word is replaced with `Buzz`.
- Every word divisible by both 3 and 5 (every 15th word) is replaced with `FizzBuzz`.

### Rules & Constraints

- Input Length: 7 <= |s| <= 100 characters.
- Null Safety: Input string cannot be null (throws `ArgumentNullException`).
- Alphanumeric Words: Only alphanumeric words are processed and counted (tokens containing at least one alphanumeric character). Pure punctuation/symbol tokens and whitespaces are skipped from counting.
- No Built-in Utilities: No built-in or third-party libraries specifically designed for FizzBuzz detection logic are used.
- Coincidence Calculation: Calculates total occurrences of replacements (`Fizz` = 1, `Buzz` = 1, `FizzBuzz` = 1).

---

## Project Structure

```text
AkvelonSolution/
│
├── .github/workflows/
│   └── ci.yml                     # GitHub Actions CI workflow (Build & Test)
│
├── Akvelon/                       # Main Console Application
│   ├── FizzBuzzDetector.cs        # Core detection and replacement logic
│   ├── FizzBuzzResult.cs          # Result model (OutputString & Count)
│   ├── Program.cs                 # Application entry point with error handling
│   └── Akvelon.csproj
│
├── Akvelon.Tests/                 # Unit Tests (xUnit)
│   ├── FizzBuzzDetectorTests.cs   # Unit tests covering all requirements
│   └── Akvelon.Tests.csproj
│
├── AkvelonSolution.slnx           # Solution file
└── README.md
```

---

## Requirements

- .NET 10.0 SDK (or compatible .NET SDK)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Ibrahim-Hassan74/Akvelon.git
cd Akvelon
```

### 2. Build the Solution

```bash
dotnet build
```

---

## Running the Application

The application reads text from standard input (`stdin`) until End-of-File (EOF).

### Interactive Input

Run the application, enter your text, then press `Ctrl + Z` followed by `Enter` on Windows (or `Ctrl + D` on Linux/macOS) to signal EOF:

```bash
dotnet run --project Akvelon
```

### Piping Input via Terminal

You can pipe text directly into the application:

#### PowerShell:

```powershell
"Mary had a little lamb" | dotnet run --project Akvelon
```

#### Command Prompt (cmd.exe):

```cmd
echo Mary had a little lamb | dotnet run --project Akvelon
```

#### Linux / macOS (Bash / Zsh):

```bash
echo "Mary had a little lamb" | dotnet run --project Akvelon
```

---

## Running Unit Tests

Unit tests are implemented using xUnit and cover all required scenarios and edge cases:

- Full acceptance example from the task specification
- 3rd word replacement (`Fizz`)
- 5th word replacement (`Buzz`)
- 15th word replacement (`FizzBuzz`)
- Punctuation preservation on non-replaced words
- Preservation of multiple spaces and formatting
- Null input validation (`ArgumentNullException`)
- Input containing only non-alphanumeric characters / symbols
- Single word without replacements
- Words containing digits treated as alphanumeric

To run the tests:

```bash
dotnet test
```

For verbose output:

```bash
dotnet test --verbosity normal
```

---

## Continuous Integration (CI)

A GitHub Actions workflow is configured in `.github/workflows/ci.yml` to automatically validate changes on every `push` and `pull_request`:
- Sets up .NET SDK 10.0.x
- Restores dependencies (`dotnet restore`)
- Builds the solution in Release configuration (`dotnet build --configuration Release --no-restore`)
- Executes all unit tests (`dotnet test --configuration Release --no-build --verbosity normal`)

---

## Example

### Input

```text
Mary had a little lamb
Little lamb, little lamb
Mary had a little lamb
It's fleece was white as snow
```

### Result

```text
output string:
Mary had Fizz little Buzz
Fizz lamb, little Fizz
Buzz had Fizz little lamb
FizzBuzz fleece was Fizz as Buzz

count: 9
```
